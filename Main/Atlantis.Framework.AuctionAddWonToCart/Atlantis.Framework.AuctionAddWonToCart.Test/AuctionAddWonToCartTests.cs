using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Atlantis.Framework.AuctionAddWonToCart.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Atlantis.Framework.AuctionAddWonToCart.Test {
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class AuctionAddWonToCartTests
  {
    private int engineRequestId = 391;

    private string _shopperId = "858421";
    private string _itc = "Mobile_Auction_ITC";
    private string _isc = "Mobile_Auction_ISC";


    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void AuctionAddWonToCart() {

      AuctionAddWonToCartResponseData responseData = null;
      var auctions = new List<string>() {"4771730", "123123443"};

      var requestData = new AuctionAddWonToCartRequestData(
                            auctions,
                            _isc,
                            _itc,
                            _shopperId,
                            string.Empty,
                            string.Empty,
                            string.Empty,
                            1
                            ) { RequestTimeout = TimeSpan.FromSeconds(30) };

      responseData = (AuctionAddWonToCartResponseData)Engine.Engine.ProcessRequest(requestData, engineRequestId);

      Assert.IsTrue(responseData.IsSuccess);

    }
  }
}
