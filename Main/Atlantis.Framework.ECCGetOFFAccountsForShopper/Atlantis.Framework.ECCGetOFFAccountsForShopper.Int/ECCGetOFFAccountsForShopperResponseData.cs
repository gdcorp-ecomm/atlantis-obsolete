using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Atlantis.Framework.Ecc.Interface;
using Atlantis.Framework.Ecc.Interface.jsonHelpers;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ECCGetOFFAccountsForShopper.Interface
{
  public class ECCGetOFFAccountsForShopperResponseData : EccResponseDataBase<EccOFFAccountDetails>
  {

    public ECCGetOFFAccountsForShopperResponseData(string jsonResponse)
      : base(jsonResponse)
    {
    }

    public ECCGetOFFAccountsForShopperResponseData(RequestData requestData, Exception ex)
      : base(requestData, ex)
    {
    }
  }
}
