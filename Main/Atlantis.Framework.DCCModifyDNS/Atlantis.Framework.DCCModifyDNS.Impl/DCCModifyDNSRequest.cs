﻿using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;
using Atlantis.Framework.DCCModifyDNS.Interface;

namespace Atlantis.Framework.DCCModifyDNS.Impl
{
  public class DCCModifyDNSRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      DCCModifyDNSResponseData responseData = null;
      string responseXml = string.Empty;

      try
      {
        DCCModifyDNSRequestData oRequest = (DCCModifyDNSRequestData)oRequestData;

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

        DnsApi.booleanResponseType oResult = oDnsApi.modifyRecords( oRequest.DomainName, getCreateArray(oRequest));

        if (oResult.errorcode == 0)
        {
          responseData = new DCCModifyDNSResponseData(true);
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

          responseData = new DCCModifyDNSResponseData(errorList);
        }
      }
      catch (AtlantisException exAtlantis)
      {
        responseData = new DCCModifyDNSResponseData(responseXml, exAtlantis);
      }
      catch (Exception ex)
      {
        responseData = new DCCModifyDNSResponseData(responseXml, oRequestData, ex);
      }

      return responseData;
    }

    private DnsApi.rrecordType[] getCreateArray(DCCModifyDNSRequestData oRequest)
    {
      List<DnsApi.rrecordType> oRecords = new List<DnsApi.rrecordType>();

      foreach (DnsRecordType record in oRequest.Records)
      {
        DnsApi.rrecordType dnsRecord = new DnsApi.rrecordType();
        dnsRecord.attributeUid = record.AttributeUid;
        dnsRecord.type = record.Type;
        dnsRecord.data = record.Data;
        dnsRecord.name = record.Name;
        dnsRecord.protocol = record.Protocol;
        dnsRecord.service = record.Service;
        dnsRecord.status = record.Status;

        if (record.Port > 0)
        {
          dnsRecord.port = record.Port;
          dnsRecord.portSpecified = true;
        }

        if(record.Weight > 0)
        {
          dnsRecord.weight = record.Weight;
          dnsRecord.weightSpecified = true;
        }

        if(record.Priority > 0)
        {
          dnsRecord.priority = record.Priority;
          dnsRecord.prioritySpecified = true;
        }

        if (record.TTL > 0)
        {
          dnsRecord.ttl = record.TTL;
          dnsRecord.ttlSpecified = true;
        }
        
        oRecords.Add(dnsRecord);
      }

      return oRecords.ToArray();
    }

    #endregion
  }
}
