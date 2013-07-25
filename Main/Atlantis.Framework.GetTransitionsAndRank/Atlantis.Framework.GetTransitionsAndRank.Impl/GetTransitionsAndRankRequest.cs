using System;
using Atlantis.Framework.GetTransitionsAndRank.Impl.BonsaiManager;
using Atlantis.Framework.GetTransitionsAndRank.Interface;
using Atlantis.Framework.Interface;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using System.IO;

namespace Atlantis.Framework.GetTransitionsAndRank.Impl
{
  public class GetTransitionsAndRankRequest : IRequest
  {
    static XmlWriterSettings settings = GetXmlWriterSettings();

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GetTransitionsAndRankResponseData responseData = new GetTransitionsAndRankResponseData();
      GetTransitionsAndRankRequestData requestData = (GetTransitionsAndRankRequestData)oRequestData;
      WsConfigElement configuration = (WsConfigElement)oConfig;

      BonsaiManager.Service manager = new BonsaiManager.Service();
      manager.Url = configuration.WSURL;

      try
      {
        TransitionResponse response = manager.GetTransitionsAndRank(requestData.ResourceID, 
                    requestData.ResourceType, requestData.IDType, requestData.UnifiedProductID);

        if (response.ResultCode < 0)
        {
          string data = string.Format("Result: {0}, Resource ID: {1}, Resource Type: {2}, IDType: {3}, UnifiedProductID: {4}",
            response.ResultCode.ToString(), requestData.ResourceID, requestData.ResourceType, 
            requestData.IDType, requestData.UnifiedProductID.ToString());

          responseData.AtlException = new AtlantisException(oRequestData,
            "GetAccountXMLRequest.RequestHandler", "Could not retrieve account XML", data);
        }
        else
        {
          StringBuilder objectXML = new StringBuilder();
          XmlSerializer serializer = new XmlSerializer(typeof(TransitionResponse));
          serializer.Serialize(XmlWriter.Create(new StringWriter(objectXML), settings), response);
          responseData.XML = objectXML.ToString();
        }
      }
      catch(Exception ex)
      {
        string data = string.Format("Resource ID: {0}, Resource Type: {1}, IDType: {2}, UnifiedProductID: {3}",
            requestData.ResourceID, requestData.ResourceType,
            requestData.IDType, requestData.UnifiedProductID.ToString());

        responseData.AtlException = new AtlantisException(oRequestData,
          "GetAccountXMLRequest.RequestHandler", "Could not retrieve account XML", data, ex);
      }

      return responseData;
    }

    private static XmlWriterSettings GetXmlWriterSettings()
    {
      XmlWriterSettings settings = new XmlWriterSettings();
      settings.OmitXmlDeclaration = true;
      settings.Indent = false;
      return settings;
    }
  }
}
