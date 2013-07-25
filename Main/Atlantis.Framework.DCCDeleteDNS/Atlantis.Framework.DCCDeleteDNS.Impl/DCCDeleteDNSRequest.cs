using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCDeleteDNS.Interface;

namespace Atlantis.Framework.DCCDeleteDNS.Impl
{
  public class DCCDeleteDNSRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCDeleteDNSResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        DCCDeleteDNSRequestData oRequest = (DCCDeleteDNSRequestData)oRequestData;

        DnsApi.dnssoapapi oDnsApi = new DnsApi.dnssoapapi();
        oDnsApi.Url = ((WsConfigElement)oConfig).WSURL;
        oDnsApi.Timeout = (int)oRequest.RequestTimeout.TotalMilliseconds;

        DnsApi.authDataType oAuth = new DnsApi.authDataType();
        oAuth.clientid = "gdmobile";
        oDnsApi.clientAuth = oAuth;

        DnsApi.custDataType oCust = new DnsApi.custDataType();
        oCust.shopperid = oRequest.ShopperID;
        oCust.resellerid = oRequest.PrivateLabelID;
        oCust.origin = oRequest.Origin;
        oDnsApi.custInfo = oCust;

        DnsApi.booleanResponseType oResult = oDnsApi.deleteRecords(oRequest.DomainName, getCreateArray(oRequest));

        if (oResult.result)
        {
          responseData = new DCCDeleteDNSResponseData(true);
        }
        else
        {
          List<string> errorList = new List<string>();
          foreach (DnsApi.responseinfoType responseInfo in oResult.responseinfo)
          {
            string sError = "";

            foreach (string error in responseInfo.info)
            {
              sError += error;
            }
            errorList.Add(sError);
          }

          responseData = new DCCDeleteDNSResponseData(errorList);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCDeleteDNSResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCDeleteDNSResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    private DnsApi.rrecordType[] getCreateArray(DCCDeleteDNSRequestData oRequest)
    {
      List<DnsApi.rrecordType> oRecords = new List<DnsApi.rrecordType>();

      foreach (DnsRecordType record in oRequest.Records)
      {
        DnsApi.rrecordType dnsRecord = new DnsApi.rrecordType();
        dnsRecord.attributeUid = record.AttributeUid;
        dnsRecord.data = record.Data;
        dnsRecord.name = record.Name;
        dnsRecord.port = record.Port;
        dnsRecord.priority = record.Priority;
        dnsRecord.protocol = record.Protocol;
        dnsRecord.service = record.Service;
        dnsRecord.status = record.Status;
        dnsRecord.ttl = record.TTL;
        dnsRecord.type = record.Type;
        dnsRecord.weight = record.Weight;
        oRecords.Add(dnsRecord);
      }

      return oRecords.ToArray();
    }

    #endregion
  }
}
