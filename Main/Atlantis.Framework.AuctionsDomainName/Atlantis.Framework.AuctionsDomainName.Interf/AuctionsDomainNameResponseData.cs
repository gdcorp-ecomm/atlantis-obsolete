using System;
using Atlantis.Framework.Interface;
using System.Collections.Generic;
using System.Xml;

namespace Atlantis.Framework.AuctionsDomainName.Interface
{
    public class AuctionsDomainNameResponseData : IResponseData
    {
        private AtlantisException _ex;
        private string _auctionReponseXML = string.Empty;
        AuctionAttributes _attributes = null;
        public bool _isSuccess = false;

        public AuctionsDomainNameResponseData(string auctionsXML)
        {
            if (!string.IsNullOrEmpty(auctionsXML))
                _auctionReponseXML = auctionsXML;
            _isSuccess = true;
            _ex = null;
        }

        public AuctionsDomainNameResponseData(RequestData oRequestData, Exception ex)
        {
            _ex = new AtlantisException(oRequestData,
                                      "AuctionsDomainNameResponseData",
                                      ex.Message.ToString(),
                                      oRequestData.ToXML());
        }

        #region IResponseData Members

        public string ToXML()
        {
            throw new NotImplementedException();
        }

        public AtlantisException GetException()
        {
            return _ex;
        }

        public AuctionAttributes DomainAuctionAttributes
        {
            get
            {
                return PopulateFromXML();
            }
        }
        private AuctionAttributes PopulateFromXML()
        {
            if(_auctionReponseXML != "<MemberItems />")
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(_auctionReponseXML);
                XmlNodeList xnlMemberItems = xDoc.SelectNodes("/MemberItems/MemberItem");
                int auctionType = 0;
                string price = string.Empty;
                bool isExpired = false, isPremium = false;
                DateTime auctionExpiration = DateTime.Now;
                DateTime auctionStart = DateTime.Now;
                int memberItemID = 0;

                foreach (XmlNode xnAuction in xnlMemberItems)
                {
                    foreach (XmlNode xNode in xnAuction)
                    {
                        if (xNode.Name == "AuctionEndTime")
                            DateTime.TryParse(xNode.InnerText, out auctionExpiration);
                        else if (xNode.Name == "AuctionStartTime")
                            DateTime.TryParse(xNode.InnerText, out auctionStart);
                        else if (xNode.Name == "AuctionTypeID")
                        {
                            int.TryParse(xNode.InnerText, out auctionType);
                            if (auctionType == 16)//selling an expired auction through GD
                                isExpired = true;
                            else if (auctionType == 23)//premium sold on auctions
                                isPremium = true;
                            else if (auctionType != 16 && auctionType != 20)//active auction
                                isExpired = false;
                        }
                        else if (xNode.Name == "MemberItemID")
                            int.TryParse(xNode.InnerText, out memberItemID);
                        else if (xNode.Name == "CurrentPrice")
                            price = xNode.InnerText.ToString();
                    }
                }
                _attributes = new AuctionAttributes(price, isExpired, auctionType, auctionExpiration, auctionStart, memberItemID, isPremium);    
            }

            return _attributes;
        }
        #endregion
    }
}
