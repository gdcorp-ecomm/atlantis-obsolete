using System;
using System.Collections.Generic;
using System.Text;

namespace Atlantis.Framework.AuctionsDomainName.Interface
{
    public class AuctionAttributes
    {
        string priceValue;
        bool isExpiredValue;
        int auctionTypeValue;
        DateTime auctionEndDateValue;
        DateTime auctionStartDateValue;
        int memberItemIdValue;
        bool isPremiumValue;

        public AuctionAttributes(string price, bool isExpired, int auctionType, DateTime auctionEndDate, DateTime auctionStartDate, int memberItemID, bool isPremium)
        {
            priceValue = price;
            isExpiredValue = isExpired;
            auctionTypeValue = auctionType;
            auctionEndDateValue = auctionEndDate;
            auctionStartDateValue = auctionStartDate;
            memberItemIdValue = memberItemID;
            isPremiumValue = isPremium;
        }

        public string Price
        {
            get { return priceValue; }
        }

        public bool IsExpired
        {
            get { return isExpiredValue; }
        }

        public int AuctionType
        {
            get { return auctionTypeValue; }
        }

        public DateTime AuctionEndDate
        {
            get { return auctionEndDateValue; }
        }

        public DateTime AuctionStartDate
        {
            get { return auctionStartDateValue; }
        }

        public int MemberItemID
        {
            get { return memberItemIdValue; }
        }

        public bool IsPremium
        {
            get { return isPremiumValue; }
        }
    }
}
