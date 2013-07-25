using System;
using System.Data;
using System.ServiceModel;
using Atlantis.Framework.AuctionsDomainName.Impl.g1dwdnaweb01;
using Atlantis.Framework.AuctionsDomainName.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuctionsDomainName.Impl
{
    public class AuctionsDomainNameRequest : IRequest
    {
        public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
        {
            AuctionsDomainNameResponseData oReponseData = null;

            try
            {
                AuctionsDomainNameRequestData request = (AuctionsDomainNameRequestData)oRequestData;
                trpMemberItemService service = new trpMemberItemService();
                service.Url = ((WsConfigElement)oConfig).WSURL;
                DataSet ds = service.FindItemByDomainName(request.Domain);
                string responseXML = ds.GetXml();
                oReponseData = new AuctionsDomainNameResponseData(responseXML);
            }
            catch (Exception ex)
            {
                oReponseData = new AuctionsDomainNameResponseData(oRequestData, ex);
            }

            return oReponseData;
        }
    }
}
