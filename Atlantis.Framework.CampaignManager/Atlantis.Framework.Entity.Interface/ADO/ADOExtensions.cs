using System;
using System.Data;
using System.Collections.Generic;

namespace Atlantis.Framework.Entity.Interface.ADO
{
    public static class ADOExtensions
    {
        public static string StringValue(this DataRow row, string columnName, string defaultValue)
        {
            try
            {
                string returnValue = row.StringValue(columnName);
                
                if (String.IsNullOrEmpty(returnValue))
                    return defaultValue;

                return returnValue;
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static string StringValue(this DataRow row, string columnName)
        {
            try
            {
                return row[columnName] as string;
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static int IntValue(this DataRow row, string columnName)
        {
            try
            {
                return Convert.ToInt32(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static double DoubleValue(this DataRow row, string columnName)
        {
            try
            {
                return Convert.ToDouble(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static decimal DecimalValue(this DataRow row, string columnName)
        {
            try
            {
                return Convert.ToDecimal(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static short ShortValue(this DataRow row, string columnName)
        {
            try
            {
                return Convert.ToInt16(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static byte ByteValue(this DataRow row, string columnName)
        {
            try
            {
                return Convert.ToByte(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static bool BooleanValue(this DataRow row, string columnName)
        {
            try
            {
                return Convert.ToBoolean(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static DateTime DateTimeValue(this DataRow row, string columnName)
        {
            try
            {
                if (row[columnName] == DBNull.Value)
                    return DateTime.MinValue;

                return Convert.ToDateTime(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static Nullable<DateTime> NullableDateTimeValue(this DataRow row, string columnName)
        {
            try
            {
                if (row[columnName] == DBNull.Value)
                    return null;

                return Convert.ToDateTime(row[columnName]);
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }

        public static Guid GuidValue(this DataRow row, string columnName)
        {
            try
            {
                object sqlGuid = row[columnName];

                if (sqlGuid != null)
                    return new Guid(sqlGuid.ToString());

                return new Guid();
            }
            catch (Exception ex)
            {
                throw new ColumnConversionException(row, columnName, ex);
            }
        }
    }

    public class ColumnConversionException : Exception
    {
        private DataRow _row = null;
        private string _column = "";
        private string _conversionType = null;
        private Exception _ex = null;
        
        public override string Message
        {
            get
            {
                return String.Format(
                    "Column '{0}' could not be converted to a type of '{1}'! Error: {2}", 
                    _column, 
                    _conversionType ?? "Unknown", 
                    _ex.Message);
            }
        }

        public ColumnConversionException(DataRow row, string column, Exception ex)
            : base("", ex)
        { 
            _row = row;
            _column = column;
            _ex = ex;
            try
            {
                if (row.Table.Columns.Contains(_column))
                {
                    _conversionType = row.Table.Columns[column].DataType.Name;
                }
            }
            catch (Exception tryEx)
            {
                _ex = tryEx;
            }
        }
    }
}
