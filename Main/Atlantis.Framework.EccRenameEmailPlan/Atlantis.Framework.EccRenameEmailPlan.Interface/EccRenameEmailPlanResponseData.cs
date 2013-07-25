using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Atlantis.Framework.Ecc.Interface;
using Atlantis.Framework.Ecc.Interface.jsonHelpers;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.EccRenameEmailPlan.Interface
{
  public class EccRenameEmailPlanResponseData : EccResponseDataBase<object>
  {

    public EccRenameEmailPlanResponseData(string resultJson) : base (resultJson)
    {}

    public EccRenameEmailPlanResponseData(AtlantisException atlantisException) : base (atlantisException)
    {
    }

    public EccRenameEmailPlanResponseData(RequestData requestData, Exception exception) : base(requestData, exception)
    {
    }


  }
  
}
