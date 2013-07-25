using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EcommPaymentProfile.Interface
{
  public class EcommPaymentProfileRequestData : RequestData
  {
    private int _profileID = 0;
    public int ProfileID
    {
      get { return _profileID; }
      set { _profileID = value; }
    }

    public EcommPaymentProfileRequestData(string shopperID,
                            string sourceURL,
                            string orderID,
                            string pathway,
                            int pageCount, int profileID)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      this._profileID = profileID;
    }

    public override string GetCacheMD5()
    {
      throw new Exception("EcommPaymentProfile is not a cacheable request.");
    }
  }
}
