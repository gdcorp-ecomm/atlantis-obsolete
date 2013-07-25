using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAGetHostingCredits.Interface
{
  public class MYAGetHostingCreditsResponseData : IResponseData
  {
    private AtlantisException _exception = null;
    private string _resultXML = string.Empty;
    private List<HostingCredit> _hostingCredits;
    private bool _success = false;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public List<HostingCredit> HostingCredits
    {
      get { return _hostingCredits; }
    }

    public MYAGetHostingCreditsResponseData(string xml)
    {
      _hostingCredits = new List<HostingCredit>();

      if (!string.IsNullOrEmpty(xml))
      {
        XmlDocument xdoc = new XmlDocument();
        xdoc.LoadXml(xml);
        XmlNodeList hostingCreditNodes = xdoc.SelectNodes("credits/credit");

        if (hostingCreditNodes != null)
        {
          foreach (XmlNode node in hostingCreditNodes)
          {
            HostingCredit hc = new HostingCredit();

            hc.Id = Convert.ToInt32(node.Attributes["id"].Value);
            hc.Count = Convert.ToInt32(node.Attributes["count"].Value);

            _hostingCredits.Add(hc);
          }
        }
      }
      _success = true;

    }

    public MYAGetHostingCreditsResponseData(List<HostingCredit> hostingCredits)
    {
      _hostingCredits = hostingCredits;
      _success = true;
    }

     public MYAGetHostingCreditsResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public MYAGetHostingCreditsResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "MYAGetHostingCreditsResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }

    #region IResponseData Members

    public string ToXML()
    {
      XDocument resultDoc = new XDocument();
      XElement resultRoot = new XElement("credits");
      resultDoc.Add(resultRoot);

      foreach (HostingCredit hc in HostingCredits)
      {
        resultRoot.Add(new XElement("credit",
          new XAttribute("id", hc.Id.ToString()),
          new XAttribute("count", hc.Count.ToString())));
      }
      return resultDoc.ToString();
    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
