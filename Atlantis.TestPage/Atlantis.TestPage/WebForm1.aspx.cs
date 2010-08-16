using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Atlantis.Framework.KiwiLogger.Interface;
using Atlantis.Framework.Engine;
using Atlantis.Framework.BasePages;
namespace Atlantis.TestPage
{
  public partial class WebForm1 : PrivateLabelAwareBasePage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      
      KiwiLoggerRequestData oKiwiLog = new KiwiLoggerRequestData(ShopperContext.ShopperId, Request.Url.ToString(),
string.Empty, SiteContext.Pathway, SiteContext.PageCount);
      oKiwiLog.MessagePrefix = "UPDATE success ";
      oKiwiLog.AddItem("profile", "332");
      oKiwiLog.AddItem("user", "'854804'");
      oKiwiLog.AddItem("origin", "'Theron/mypage.aspx'");
      oKiwiLog.ServerIPAddress = "172.19.72.106";
      KiwiLoggerResponseData response = (KiwiLoggerResponseData)Engine.ProcessRequest(oKiwiLog, 39);

    }
  }
}
