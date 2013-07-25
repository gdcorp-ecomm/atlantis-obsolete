using System.Diagnostics;
using Atlantis.Framework.AuthRetrieve.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.AuthRetrieve.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void AuthRetrieveTest()
    {
      string shopperid = "871984";
      int _requestType = 533;

      AuthRetrieveRequestData request = new AuthRetrieveRequestData(shopperid
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , "GDCARTNET-G1DWCARTWEB001"
        , "WRSzDbPuVNmvDhadLPojnSPTJMFNSfXH");
      AuthRetrieveResponseData response = (AuthRetrieveResponseData)Engine.Engine.ProcessRequest(request, _requestType);
      /* Sample artifact call
    https://cart.test.godaddy-com.ide/sso/redirectlogin.aspx?artifact=wbcaaNQKYaJCcdVzwNxCoLnZnNAeBTnj&transferCart=true&shopper_id_old=75866&page=Basket
       * */
      // Cache call
      //AuthRetrieveResponseData response = (AuthRetrieveResponseData)DataCache.DataCache.GetProcessRequest(request, _requestType);

      //https://cart.dev.godaddy-com.ide/Basket.aspx
      //https://cart.dev.godaddy-com.ide/sso/redirectlogin.aspx?artifact=WRSzDbPuVNmvDhadLPojnSPTJMFNSfXH&transferCart=true&shopper_id_old=871984&page=Basket
      //
      // TODO: Add test logic here
      //

      Debug.WriteLine(response.ToXML());
      Assert.IsTrue(response.IsSuccess);
    }

  }
}
