using System;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace Atlantis.Framework.SiteAdminRoles.Interface
{
  public class SiteAdminRolesRequestData : RequestData
  {
    public TimeSpan RequestTimeout { get; set; }
    private int _roleId;

    public SiteAdminRolesRequestData(string shopperId, string sourceUrl, string orderId, string pathway, int pageCount, int roleTypeId)
      : base(shopperId, sourceUrl, orderId, pathway, pageCount)
    {
      _roleId = roleTypeId;
      RequestTimeout = TimeSpan.FromSeconds(5);
    }

    public int RoleId
    {
      get { return _roleId; }
    }

    public override string GetCacheMD5()
    {
      MD5CryptoServiceProvider md5Provider = new MD5CryptoServiceProvider();
      md5Provider.Initialize();
      byte[] stringBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(_roleId.ToString());
      byte[] md5Bytes = md5Provider.ComputeHash(stringBytes);
      return BitConverter.ToString(md5Bytes).Replace("-", string.Empty);
    }

    public override string ToXML()
    {
      XElement requestElement = new XElement("SiteAdminRoleRequest", new XAttribute("roleTypeId", _roleId.ToString()));
      return requestElement.ToString();
    }
  }
}
