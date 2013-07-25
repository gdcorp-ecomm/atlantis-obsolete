using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Atlantis.Framework.DataProvider.Interface;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.TestLogging
{
  public partial class TestLogForm : Form
  {
    public TestLogForm()
    {
      InitializeComponent();
    }

    private void TestLogForm_Load(object sender, EventArgs e)
    {
      CenterToScreen();
    }

    private void LogException_Click(object sender, EventArgs e)
    {
      try
      {
        Dictionary<string, object> parms = new Dictionary<string, object>();
        parms.Add("shopper_id", ShopperId.Text);
        parms.Add("profile_id", "150256");
        DataProviderRequestData request = new DataProviderRequestData(ShopperId.Text,
          SourceURL.Text, OrderId.Text, Pathway.Text, 7, "somewrongrequest", parms);
        DataProviderResponseData response = (DataProviderResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DataProviderRequest);
      }
      catch (Exception ex)
      {
        string msg = "This error message should be logged in 'gdshop_errorlog' table.\n\n";
        MessageBox.Show(this, msg + ex.Message);
      }
    }

    private void cmdLogDirect_Click(object sender, EventArgs e)
    {
      AtlantisException ex = new AtlantisException(
        "TestLogForm.DirectLog", SourceURL.Text, "0", "Direct error logged using exception", string.Empty,
        ShopperId.Text, OrderId.Text, "127.0.0.1", Pathway.Text, 7);
      Atlantis.Framework.Engine.Engine.LogAtlantisException(ex);
    }


  }

  public static class EngineRequests
  {
    public const int ShopperGet = 1;
    public const int ShopperSearch = 2;
    public const int MiniCartGet = 3;
    public const int CartItemAdd = 4;
    public const int CartItemDelete = 5;
    public const int CartItemModify = 6;
    public const int BasketGet = 7;
    public const int MiniCartIOGet = 8;
    public const int CustomContent = 9;
    public const int BannerContent = 10;
    public const int PlanFeatures = 11;
    public const int LinkInfo = 12;
    public const int ProductGroup = 13;
    public const int DomainBackorder = 14;
    public const int BuyDomains = 15;
    public const int DomainCheck = 16;
    public const int DomainDomainsBot = 17;
    public const int DomainBackorderAsync = 19;
    public const int DomainBuyDomainsAsync = 20;
    public const int DomainCheckAsync = 21;
    public const int DomainDomainsBotAsync = 22;
    public const int DomainABDomainsAsync = 23;
    public const int ProductOffer = 24;
    public const int ShopperPriceType = 25;
    public const int PriceOverrideHash = 26;
    public const int DurationHash = 27;
    public const int CreateShopper = 28;
    public const int PresentationCentralHtmlAsync = 30;
    public const int DomainContactCheck = 31;
    public const int DomainTransfer = 32;
    public const int DomainTransferAsync = 33;
    public const int BasketPriceGet = 34;
    public const int DataProviderRequest = 35;
  }
}
