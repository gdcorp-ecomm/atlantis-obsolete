using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Nimitz;

namespace Atlantis.Framework.Entity.Interface.ADO
{
    public class ADOHelper : IDisposable
    {
        private int _timeout = 2;
        private string _connectionString = String.Empty;
        private SqlConnection _connection = null;
        public List<IDataParameter> _parms = new List<IDataParameter>();

        public ADOHelper(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
        }

        public ADOHelper(ConfigElement config)
            : this(ConnectionStringHelper.LookupConnectionString(config))
        {
        }

        #region Fluent Add Parameter Methods
        public ADOHelper Add(IDataParameter parameter)
        {
            _parms.Add(parameter);
            return this;
        }

        public ADOHelper Add(string parameterName, object value)
        {
            return Add(new SqlParameter(parameterName, value));
        }

        public ADOHelper Add(string parameterName, DateTime? value)
        {
            return Add(parameterName, value, DateTime.MinValue);
        }

        public ADOHelper Add(string parameterName, DateTime? value, DateTime defaultValue)
        {
            if (value.HasValue && value != DateTime.MinValue && value >= new DateTime(1753, 1, 1))
            {
                _parms.Add(new SqlParameter(parameterName, value));
            }
            else if (defaultValue > DateTime.MinValue)
            {
                _parms.Add(new SqlParameter(parameterName, defaultValue));
            }
            else
            {
                _parms.Add(new SqlParameter
                {
                    ParameterName = parameterName,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                    IsNullable = true,
                    Direction = ParameterDirection.Input,
                    SqlValue = DBNull.Value
                });
            }
            return this;
        }

        public ADOHelper Add(string parameterName, string value, string defaultValue)
        {
            if (String.IsNullOrEmpty(value))
            {
                value = defaultValue;
            }
            return Add(new SqlParameter(parameterName, value));
        }

        public ADOHelper Add(string parameterName, decimal? value, double defaultValue)
        {
            if (!value.HasValue)
            {
                value = new decimal(defaultValue);
            }
            return Add(new SqlParameter(parameterName, value));
        }

        public ADOHelper Add(string parameterName, string[] values, string joinCharacter)
        {
            if (values != null && values.Length > 0)
            {
                return Add(parameterName, String.Join(",", values));
            }
            return Add(parameterName, DBNull.Value);
        }

        public ADOHelper Add(string parameterName, object value, ParameterDirection parameterDirection)
        {
            _parms.Add(new SqlParameter(parameterName, value)
            {
                Direction = parameterDirection
            });
            return this;
        }
        #endregion

        #region Execute Procedure Methods
        public DataSet ExecuteReturnDataSet(string procName)
        {
            DataSet data = new DataSet();

            try
            {
                using (SqlCommand cmd = new SqlCommand(procName, _connection))
                {
                    cmd.CommandTimeout = _timeout;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameters(cmd);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(data);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return data;
        }

        public DataRowCollection ExecuteReturnRows(string procName)
        {
            DataSet data = ExecuteReturnDataSet(procName);

            if (data != null && data.Tables.Count > 0)
            {
                return data.Tables[0].Rows;
            }

            return null;
        }

        public int Execute(string procName)
        {
            int rowsAffected = 0;

            try
            {
                DataSet data = new DataSet();

                using (SqlCommand cmd = new SqlCommand(procName, _connection))
                {
                    cmd.CommandTimeout = _timeout;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameters(cmd);
                    _connection.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return rowsAffected;
        }

        public object ExecuteReturnOutput(string procName)
        {
            object returnValue = null;

            try
            {
                using (SqlCommand cmd = new SqlCommand(procName, _connection))
                {
                    cmd.CommandTimeout = _timeout;
                    cmd.CommandType = CommandType.StoredProcedure;
                    AddParameters(cmd);
                    _connection.Open();
                    cmd.ExecuteNonQuery();

                    foreach (SqlParameter parm in cmd.Parameters)
                    {
                        if (parm.Direction == ParameterDirection.Output || parm.Direction == ParameterDirection.ReturnValue)
                        {
                            returnValue = parm.Value;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return returnValue;
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            _parms = null;
            CloseConnection();
        }
        #endregion

        private void AddParameters(SqlCommand command)
        {
            if (_parms != null && _parms.Count > 0)
            {
                foreach (SqlParameter parm in _parms)
                {
                    command.Parameters.Add(parm);
                }
            }
        }

        private void CloseConnection()
        {
            try
            {
                if (_connection != null)
                    _connection.Close();
            }
            catch { }
        } 
    }

    public static class ADOHelperExtensions
    {
        public static void ForEach<TEntity>(this ICollection<TEntity> collection, ConfigElement config, Action<ADOHelper, TEntity> action)
            where TEntity : class, IEntity, new()
        {
            if (collection != null && collection.Count > 0)
            {
                foreach (var entity in collection)
                {
                    using (var ado = new ADOHelper(config))
                    {
                        action(ado, entity);
                    }
                }
            }
        }

        public static void ForEach<TEntity>(this DataRowCollection rows, Action<DataRow, TEntity> action)
            where TEntity : class, IEntity, new()
        {
            if (rows != null && rows.Count > 0)
            {
                foreach (DataRow row in rows)
                {
                    var entity = new TEntity();
                    action(row, entity);
                }
            }
        }
    }
}
