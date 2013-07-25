using System;
using System.Net;
using Atlantis.Framework.GSASearch.Interface;
using Atlantis.Framework.Interface;
using System.Text;
using System.IO;

namespace Atlantis.Framework.GSASearch.Impl
{
  class GSASearchRequest : IRequest
  {
    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      GSASearchResponseData responseData;
      GSASearchRequestData requestData = null;
      try
      {
        // get the partition
        requestData = (GSASearchRequestData)oRequestData;
        string partition = (oConfig.GetConfigValue("GSAPartition") ?? String.Empty).Trim().ToLower();

        // prep the request to the GSA web server
        var httpRequest = (HttpWebRequest)WebRequest.Create(requestData.GetSearchUrlForPartition(partition));
        httpRequest.Timeout = Convert.ToInt32(requestData.RequestTimeout.TotalMilliseconds);

        // call the GSA, and process the response
        var streamReader = new StreamReader(httpRequest.GetResponse().GetResponseStream());
        string response = streamReader.ReadToEnd();
        streamReader.Close();

        responseData = new GSASearchResponseData(response);
      }
      catch (Exception ex)
      {
        if (oRequestData is GSASearchRequestData)
        {
          responseData = new GSASearchResponseData(requestData, ex);
        }
        else
        {
          responseData = new GSASearchResponseData(oRequestData, ex);
        }
      }
      return responseData;
    }

  }
}
