using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Atlantis.Framework.AuctionsDomainName.Interface
{
    public class AuctionToCheck
    {
        private string domainName = string.Empty;
        public string DomainName
        {
            get { return domainName; }
        }

        public AuctionToCheck(string domain)
        {
            domainName = domain;
        }
    }
}
