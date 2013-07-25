using System;
using System.Xml.Linq;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAResourceParentInfo.Interface
{
  public class MYAResourceParentInfoResponseData : IResponseData
  {
    #region Properties
    private AtlantisException _exception = null;
    private bool _success = false;

    public bool IsSuccess
    {
      get { return _success; }
    }

    public ResourceParentInfo ResourceParentInfo { get; private set; }
    #endregion

    public MYAResourceParentInfoResponseData(ResourceParentInfo resourceParentInfo)
    {
      ResourceParentInfo = resourceParentInfo;
      _success = true;
    }

     public MYAResourceParentInfoResponseData(AtlantisException atlantisException)
    {
      _exception = atlantisException;
    }

    public MYAResourceParentInfoResponseData(RequestData requestData, Exception exception)
    {
      _exception = new AtlantisException(requestData,
                                   "MYAResourceParentInfoResponseData",
                                   exception.Message,
                                   requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      XDocument xDoc = new XDocument();
      XElement root = new XElement("resource",
        new XAttribute("parentResourceId", ResourceParentInfo.ParentBillingResourceId.ToString()),
        new XAttribute("parentProductTypeId", ResourceParentInfo.ParentResourceTypeId.ToString()));

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
