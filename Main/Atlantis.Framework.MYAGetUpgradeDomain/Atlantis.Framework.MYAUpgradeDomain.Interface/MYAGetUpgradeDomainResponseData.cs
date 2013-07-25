using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAGetUpgradeDomain.Interface
{
  public class MYAGetUpgradeDomainResponseData: IResponseData
  {
    private AtlantisException _exception = null;
    private bool _success = false;
    private List<MyaUpgradeDomain> _myaUpgradeDomains;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public List<MyaUpgradeDomain> MyaUpgradeDomains
    {
      get { return _myaUpgradeDomains; }
    }

    public MYAGetUpgradeDomainResponseData(List<MyaUpgradeDomain> myaUpgradeDomains)
    {
      _myaUpgradeDomains = myaUpgradeDomains;
      _success = true;
    }

    public MYAGetUpgradeDomainResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public MYAGetUpgradeDomainResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "MYAGetUpgradeDomainResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      StringBuilder sb = new StringBuilder();

      try
      {
        using (XmlWriter writer = XmlWriter.Create(sb))
        {
          writer.WriteStartElement("domains");

          foreach (MyaUpgradeDomain d in MyaUpgradeDomains)
          {
            writer.WriteStartElement("domain");           

            writer.WriteEndElement();
          }
          writer.WriteEndElement();
        }
      }
      catch (Exception ex)
      {
        throw new AtlantisException("MYAGetUpgradeDomainResponseData::ToXml", string.Empty, string.Empty, "Error Converting Response Object To XML", ex.Message, string.Empty, string.Empty, string.Empty, string.Empty, 0);
      }

      return sb.ToString();
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
