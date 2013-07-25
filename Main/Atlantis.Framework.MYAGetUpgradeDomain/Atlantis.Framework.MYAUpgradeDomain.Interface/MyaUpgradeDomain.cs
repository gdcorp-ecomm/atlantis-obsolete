using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;

namespace Atlantis.Framework.MYAGetUpgradeDomain.Interface
{
  public class MyaUpgradeDomain : IComparable<MyaUpgradeDomain>
  {
    public string DomainName { get; set; }
    public int ResourceID { get; set; }
    public int DomainID { get; set; }
    public bool IsPrivate { get; set; }
    public bool IsBusiness { get; set; }
    public bool IsProtected { get; set; }
    public bool IsSmartDomain { get; set; }

    public virtual MyaUpgradeDomain PopulateObjectFromDB(IDataReader dr, MYAGetUpgradeDomainRequestData myaGetUpgradeDomainRequestData)
    {
      MyaUpgradeDomain upgradeDomain = new MyaUpgradeDomain();
      upgradeDomain.DomainName = dr["domain"] == DBNull.Value ? string.Empty : Convert.ToString(dr["domain"], CultureInfo.CurrentCulture).Trim();
      upgradeDomain.ResourceID = dr["resource_id"] == DBNull.Value ? -1 : Convert.ToInt32(dr["resource_id"], CultureInfo.CurrentCulture);
      upgradeDomain.DomainID = dr["domainId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["domainId"], CultureInfo.CurrentCulture);
      upgradeDomain.IsPrivate = dr["isPrivate"] == DBNull.Value ? false: Convert.ToBoolean(dr["isPrivate"], CultureInfo.CurrentCulture);
      upgradeDomain.IsBusiness = dr["isBusiness"] == DBNull.Value ? false : Convert.ToBoolean(dr["isBusiness"], CultureInfo.CurrentCulture);
      upgradeDomain.IsProtected = dr["isProtected"] == DBNull.Value ? false : Convert.ToBoolean(dr["isProtected"], CultureInfo.CurrentCulture);
      upgradeDomain.IsSmartDomain = dr["isSmartDomain"] == DBNull.Value ? false : Convert.ToBoolean(dr["isSmartDomain"], CultureInfo.CurrentCulture);
      return upgradeDomain;
    }

    #region IComparable<MyaUpgradeDomain> Members

    public int CompareTo(MyaUpgradeDomain x)
    {
      return string.Compare(DomainName, x.DomainName);
    }

    #endregion
  }
}
