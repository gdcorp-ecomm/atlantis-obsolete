using System;
using System.ServiceModel;
using Atlantis.Framework.AuctionRecommendations.Impl.gdAuctionsLeprechaunWS;
using Atlantis.Framework.AuctionRecommendations.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuctionRecommendations.Impl
{
    public class AuctionRecommendationsRequest : IRequest
    {
        public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
        {
            AuctionRecommendationsResponseData oReponseData = null;

            try
            {
                AuctionRecommendationsRequestData request = (AuctionRecommendationsRequestData)oRequestData;
                gdAuctionsLeprechaunWS.gdAuctionsLeprechaunWS service = new gdAuctionsLeprechaunWS.gdAuctionsLeprechaunWS();
                service.Url = ((WsConfigElement)oConfig).WSURL;
                string responseXML = service.AuctionRecommendationsSync(request.RequestXML);
                oReponseData = new AuctionRecommendationsResponseData(responseXML);
                
            }
            catch (Exception ex)
            {
                oReponseData = new AuctionRecommendationsResponseData(oRequestData, ex);
            }

            return oReponseData;
        }
    }
}
