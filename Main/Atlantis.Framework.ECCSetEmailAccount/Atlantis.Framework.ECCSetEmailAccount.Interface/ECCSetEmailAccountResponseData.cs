using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Atlantis.Framework.Ecc.Interface;
using Atlantis.Framework.Ecc.Interface.jsonHelpers;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.ECCSetEmailAccount.Interface
{
  public class EccSetEmailAccountResponseData : EccResponseDataBase<object>
  {
    public EccSetEmailAccountResponseData(string resultJson) : base(resultJson)
    {
    }

    public EccSetEmailAccountResponseData(AtlantisException atlantisException) : base(atlantisException)
    {
    }

    public EccSetEmailAccountResponseData(RequestData requestData, Exception exception):base(requestData, exception)
    {
    }
  }
}
