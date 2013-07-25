using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.GetTransitionsAndRank.Interface;

namespace Atlantis.Framework.GetTransitionsAndRank.Tests
{
  [TestClass]
  public class GetTransitionsAndRankTests
  {
    [TestMethod]
    public void GetTransitionAndRankBasic()
    {
      GetTransitionsAndRankRequestData requestData = new GetTransitionsAndRankRequestData("847235",
        "http://localhost", "", "", 0, "383392", "hosting", "billing", 42114);
      GetTransitionsAndRankResponseData responseData = (GetTransitionsAndRankResponseData)Engine.Engine.ProcessRequest(requestData, 76);
      Assert.IsTrue(responseData.XML.Contains("<RankTransition NodeName=\"Unlimited Hosting - Linux - Monthly\" NodeRank=\"4\" UnifiedProductID=\"7225\" />"));
    }
  }
}
