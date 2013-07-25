using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.AuctionsDomainName.Interface
{
    public class AuctionsDomainNameRequestData : RequestData
    {
        private string _domain;
        private string _userID;
        private string _userPwd;
        private string _app;
        private int _timeout;

        public AuctionsDomainNameRequestData(string shopperId, string sourceUrl, string orderId, string pathway, int pageCount,
        AuctionToCheck domain, string userID, string userPwd, string app, int timeout)
            : base(shopperId, sourceUrl, orderId, pathway, pageCount)
        {
            _domain = domain.DomainName;
            _userID = userID;
            _userPwd = userPwd;
            _app = app;
            _timeout = timeout;
        }

        public string Domain
        {
            get { return _domain; }
            set { _domain = value; }
        }
        public string UserID
        {
            get { return _userID; }
        }
        public string UserPwd
        {
            get { return _userPwd; }
        }
        public string App
        {
            get { return _app; }
        }
        public int Timeout
        {
            get { return _timeout; }
        }


        public override string GetCacheMD5()
        {
            throw new Exception("AuctionsDomainName is not a cacheable request.");
        }
    }
}
