using System;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Atlantis.Framework.Ecc.Interface;
using Atlantis.Framework.Ecc.Interface.jsonHelpers;
using Atlantis.Framework.Interface;


namespace Atlantis.Framework.ECCGetEmailPlanInfo.Interface
{
  public class EccGetEmailPlanInfoResponseData : EccResponseDataBase<EccEmailPlanDetails>
  {

    public EccEmailPlanDetails EmailPlanDetails
    {
      get
      {
        if (Response != null)
        {
          if (Response.Item != null)
          {
            if (Response.Item.Results != null)
              if (Response.Item.Results.Count > 0) return Response.Item.Results[0];
          }
        }
        return null;
      }
    }

    public EccGetEmailPlanInfoResponseData(string resultJson) : base(resultJson)
    {
    }
    
    public EccGetEmailPlanInfoResponseData(AtlantisException atlantisException) : base(atlantisException)
    {
    }

    public EccGetEmailPlanInfoResponseData(RequestData requestData, Exception exception) : base (requestData, exception)
    {
    }

  }
}
