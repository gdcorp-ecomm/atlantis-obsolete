using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAGetDBPProductInfoData.Interface
{
	public class DBPProductInfo : IComparable<DBPProductInfo>
	{
		int _plid;
		private const Int32 NO_PFID_LOCATED = (Int32.MinValue + 1); 
		#region Properties
		private string _commonName;
		public string CommonName
		{
			get { return _commonName; }
			set { _commonName = value; }
		}

		private string _resourceId;
		public string ResourceId
		{
			get { return _resourceId; }
			set { _resourceId = value; }
		}

		private string _domainId;
		public string DomainId
		{
			get { return _domainId; }
			set { _domainId = value; }
		}

		private bool _isPrivate;
		public bool IsPrivate
		{
			get { return _isPrivate; }
			set { _isPrivate = value; }
		}

		private bool _isBusiness;
		public bool IsBusiness
		{
			get { return _isBusiness; }
			set { _isBusiness = value; }
		}

		private bool _isProtected;
		public bool IsProtected
		{
			get { return _isProtected; }
			set { _isProtected = value; }
		}

		private bool _isSmartDomain;
		public bool IsSmartDomain
		{
			get { return _isSmartDomain; }
			set { _isSmartDomain = value; }
		}

		public int ProductId { get; set; }

		#endregion

		public DBPProductInfo()
		{
			_plid = 1;
		}

		public DBPProductInfo(int privateLabelId)
		{
			_plid = privateLabelId;
		}


		public virtual DBPProductInfo PopulateObjectFromDB(IDataReader dr, GetDBPProductInfoRequestData myaProductRequestData, bool hasIsFreeColumn, ConfigElement config)
		{
			DBPProductInfo dbpInfo = new DBPProductInfo(this._plid);
			dbpInfo.CommonName = dr["domain"] == DBNull.Value ? string.Empty : Convert.ToString(dr["domain"], CultureInfo.CurrentCulture).Trim();
			dbpInfo.DomainId = dr["domainId"] == DBNull.Value ? string.Empty : Convert.ToString(dr["domainId"], CultureInfo.CurrentCulture).Trim();
			dbpInfo.ResourceId = dr["resource_id"] == DBNull.Value ? string.Empty : Convert.ToString(dr["resource_id"], CultureInfo.CurrentCulture).Trim();

			bool temp = false;
			bool.TryParse(Convert.ToString(dr["isPrivate"], CultureInfo.CurrentCulture).Trim(), out temp);
			dbpInfo.IsPrivate = temp;

			temp = false;
			bool.TryParse(Convert.ToString(dr["isBusiness"], CultureInfo.CurrentCulture).Trim(), out temp);
			dbpInfo.IsBusiness = temp;

			temp = false;
			bool.TryParse(Convert.ToString(dr["isProtected"], CultureInfo.CurrentCulture).Trim(), out temp);
			dbpInfo.IsProtected = temp;

			temp = false;
			bool.TryParse(Convert.ToString(dr["isSmartDomain"], CultureInfo.CurrentCulture).Trim(), out temp);
			dbpInfo.IsSmartDomain = temp;

			SetCurrentItemProductId(config, dbpInfo);

			return dbpInfo;
		}

		private void SetCurrentItemProductId(ConfigElement config, DBPProductInfo dbp)
		{
			switch (_plid)
			{
				case 1:
					if (dbp.IsProtected)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("GD_Default_Protected_PFID"));
					}
					else if (dbp.IsBusiness && dbp.IsPrivate)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("GD_Default_Deluxe_PFID"));
					}
					else if (dbp.IsBusiness)
					{
						int tempId;
						Int32.TryParse(config.GetConfigValue("GD_Default_Business_PFID"),out tempId);
						dbp.ProductId = tempId;
					}
					else if (dbp.IsPrivate)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("GD_Default_Private_PFID"));
					}
					else
					{
						dbp.ProductId = NO_PFID_LOCATED;
					}
					break;
				case 2:
					if (dbp.IsProtected)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("BR_Default_Protected_PFID"));
					}
					else if (dbp.IsBusiness && dbp.IsPrivate)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("BR_Default_Deluxe_PFID"));
					}
					else if (dbp.IsBusiness)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("BR_Default_Business_PFID"));
					}
					else if (dbp.IsPrivate)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("BR_Default_Private_PFID"));
					}
					else
					{
						dbp.ProductId = NO_PFID_LOCATED;
					}
					
					break;

				default:
					if (dbp.IsProtected)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("PL_Default_Protected_PFID"));
					}
					else if (dbp.IsBusiness && dbp.IsPrivate)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("PL_Default_Deluxe_PFID"));
					}
					else if (dbp.IsBusiness)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("PL_Default_Business_PFID"));
					}
					else if (dbp.IsPrivate)
					{
						dbp.ProductId = Int32.Parse(config.GetConfigValue("PL_Default_Private_PFID"));
					}
					else
					{
						dbp.ProductId = NO_PFID_LOCATED;
					}
					
					break;
			}
		}


		#region IComparable<DBPProductInfo> Members

		public int CompareTo(DBPProductInfo x)
		{
			return string.Compare(_commonName, x.CommonName);
		}

		#endregion
	}
}