using System;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAResourceStatus.Interface
{
  public class MYAResourceStatusResponseData : IResponseData
  {
    #region Properties
    private AtlantisException _exception = null;
    private bool _success = false;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public ResourceStatusInfo ResourceStatusInfo { get; private set; }
    #endregion

    public MYAResourceStatusResponseData(ResourceStatusInfo resourceStatusInfo)
    {
      ResourceStatusInfo = resourceStatusInfo;
      _success = true;
    }

    public MYAResourceStatusResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public MYAResourceStatusResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "MYAResourceStatusResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      XDocument xDoc = new XDocument();
      XElement root = new XElement("resource",
        new XAttribute("isFree", ResourceStatusInfo.IsFree.ToString()),
        new XAttribute("isPastDue", ResourceStatusInfo.IsPastDue.ToString()),
        new XAttribute("billingStatusId", ResourceStatusInfo.GdShopBillingStatusId.ToString()));

      xDoc.Add(root);

      return xDoc.ToString();

    }

    public AtlantisException GetException()
    {
      return _exception;
    }

    #endregion

  }
}
