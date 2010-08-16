using System;
using System.Data;
using System.Threading;
using System.IO;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;

using Atlantis.Framework.DomainCheck.Interface;
using Atlantis.Framework.Backorder.Interface;
using Atlantis.Framework.BuyDomains.Interface;
using Atlantis.Framework.DomainsBot.Interface;
using Atlantis.Framework.FabDomains.Interface;

namespace Atlantis.TestPage.DomainSearch
{
  public partial class _Default : System.Web.UI.Page
  {
    /******************************************************************************/

    const int IBACKORDERASYNC   = 19;
    const int IBUYDOMAINSASYNC  = 20;
    const int IDOMAINCHECKASYNC = 21;
    const int IDOMAINSBOTASYNC  = 22;
    const int IFABDOMAINSASYNC  = 23;

    /******************************************************************************/

    Stopwatch m_swDomainCheck = new Stopwatch();
    Stopwatch m_swBackorder   = new Stopwatch();
    Stopwatch m_swBuyDomains  = new Stopwatch();
    Stopwatch m_swDomainsBot  = new Stopwatch();
    Stopwatch m_swFabDomains  = new Stopwatch();

    /******************************************************************************/

    DomainCheckResponseData m_oDomainCheckResponseData;
    BackorderResponseData m_oBackorderResponseData;

    /******************************************************************************/

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    /******************************************************************************/

    protected void DomainSearchButton_Click(object sender, EventArgs e)
    {
      bool bParallelExecution = true;

      RegisterAsyncTask(new PageAsyncTask(new BeginEventHandler(BeginDomainCheck),
                                          new EndEventHandler(EndDomainCheck),
                                          new EndEventHandler(TimeoutDomainCheck),
                                          null, bParallelExecution));

      RegisterAsyncTask(new PageAsyncTask(new BeginEventHandler(BeginBackorder),
                                          new EndEventHandler(EndBackorder),
                                          new EndEventHandler(TimeoutBackorder),
                                          null, bParallelExecution));

      RegisterAsyncTask(new PageAsyncTask(new BeginEventHandler(BeginBuyDomains),
                                          new EndEventHandler(EndBuyDomains),
                                          new EndEventHandler(TimeoutBuyDomains),
                                          null, bParallelExecution));

      RegisterAsyncTask(new PageAsyncTask(new BeginEventHandler(BeginFabDomains),
                                          new EndEventHandler(EndFabDomains),
                                          new EndEventHandler(TimeoutFabDomains),
                                          null, bParallelExecution));

      RegisterAsyncTask(new PageAsyncTask(new BeginEventHandler(BeginDomainsBot),
                                          new EndEventHandler(EndDomainsBot),
                                          new EndEventHandler(TimeoutDomainsBot),
                                          null, bParallelExecution));

      Stopwatch swActual = new Stopwatch();

      swActual.Start();
      ExecuteRegisteredAsyncTasks();
      swActual.Stop();

      CallTimesLiteral.Text = "Call Times:<br /><br />";

      CallTimesLiteral.Text += String.Format("Domain Check: {0} ms <br />", m_swDomainCheck.ElapsedMilliseconds);
      CallTimesLiteral.Text += String.Format("Backorder: {0} ms <br />", m_swBackorder.ElapsedMilliseconds);
      CallTimesLiteral.Text += String.Format("Buy Domains: {0} ms <br />", m_swBuyDomains.ElapsedMilliseconds);
      CallTimesLiteral.Text += String.Format("Domains Bot: {0} ms <br />", m_swDomainsBot.ElapsedMilliseconds);
      CallTimesLiteral.Text += String.Format("Fabulous Domains: {0} ms <br /><br />", m_swFabDomains.ElapsedMilliseconds);

      long lTotal = m_swDomainCheck.ElapsedMilliseconds +
                    m_swBackorder.ElapsedMilliseconds   +
                    m_swBuyDomains.ElapsedMilliseconds  +
                    m_swDomainsBot.ElapsedMilliseconds  +
                    m_swFabDomains.ElapsedMilliseconds;

      CallTimesLiteral.Text += String.Format("Total: {0} ms Actual: {1} ms -- {2} % faster <br />", 
                                             lTotal, 
                                             swActual.ElapsedMilliseconds,
                                             100.0f *((float)(lTotal - swActual.ElapsedMilliseconds) / (float)lTotal));



      if (m_oBackorderResponseData != null && m_oDomainCheckResponseData != null)
      {
        foreach (KeyValuePair<string, DomainAttributes> oDomain in m_oDomainCheckResponseData.Domains)
        {
          TableRow trDomain = new TableRow();
          TableCell tcName = new TableCell();
          TableCell tcAvailable = new TableCell();
          TableCell tcAvailableCode = new TableCell();
          TableCell tcValidSyntax = new TableCell();
          TableCell tcSyntaxCode = new TableCell();
          TableCell tcSyntaxDescription = new TableCell();
          TableCell tcBackorderable = new TableCell();

          tcName.Text = oDomain.Key;
          tcAvailable.Text = (oDomain.Value.AvailableCode == 1000).ToString();
          tcAvailableCode.Text = oDomain.Value.AvailableCode.ToString();
          tcValidSyntax.Text = (oDomain.Value.SyntaxCode == 1000).ToString();
          tcSyntaxCode.Text = oDomain.Value.SyntaxCode.ToString();
          tcSyntaxDescription.Text = oDomain.Value.SyntaxDescription.ToString();
          tcBackorderable.Text = m_oBackorderResponseData.Domains[oDomain.Key].ToString();

          trDomain.Cells.Add(tcName);
          trDomain.Cells.Add(tcAvailable);
          trDomain.Cells.Add(tcAvailableCode);
          trDomain.Cells.Add(tcValidSyntax);
          trDomain.Cells.Add(tcSyntaxCode);
          trDomain.Cells.Add(tcSyntaxDescription);
          trDomain.Cells.Add(tcBackorderable);

          DomainCheckTable.Rows.Add(trDomain);
        }
      }
    }

    /******************************************************************************/

    IAsyncResult BeginDomainCheck(object sender, EventArgs e, AsyncCallback oCallback, object oState)
    {
      DomainCheckRequestData oRequestData = new DomainCheckRequestData("", "", "", "", 0);

      oRequestData.WaitTime = 2000;
      oRequestData.PrivateLabelID = 1;

      string[] oDomains = DomainSearchTextBox.Text.Split(',', '\n', '\t', ' ');

      foreach (string sDomain in oDomains)
        oRequestData.AddDomainName(sDomain);

      m_swDomainCheck.Reset();
      m_swDomainCheck.Start();
      IAsyncResult oAsyncResult = Engine.BeginProcessRequest(oRequestData, IDOMAINCHECKASYNC, oCallback, oState);

      return oAsyncResult;
    }

    void EndDomainCheck(IAsyncResult oAsyncResult)
    {
      m_oDomainCheckResponseData = (DomainCheckResponseData)Engine.EndProcessRequest(oAsyncResult);
      m_swDomainCheck.Stop();
      KeyValuePair<string, DomainAttributes> oFirstDomain = m_oDomainCheckResponseData.FirstDomain;
      DomainCheckLiteral.Text = HttpContext.Current.Server.HtmlEncode(m_oDomainCheckResponseData.ToXML());
    }

    void TimeoutDomainCheck(IAsyncResult oAsyncResult)
    {
      DomainCheckLiteral.Text = "DomainCheck asynchronous call timeout.";
    }

    /******************************************************************************/

    IAsyncResult BeginBackorder(object sender, EventArgs e, AsyncCallback oCallback, object oState)
    {
      BackorderRequestData oRequestData = new BackorderRequestData("", "", "", "", 0, 1);

      string[] oDomains = DomainSearchTextBox.Text.Split(',', '\n', '\t', ' ');

      foreach (string sDomain in oDomains)
        oRequestData.AddDomainName(sDomain);

      m_swBackorder.Reset();
      m_swBackorder.Start();
      IAsyncResult oAsyncResult = Engine.BeginProcessRequest(oRequestData, IBACKORDERASYNC, oCallback, oState);

      return oAsyncResult;
    }

    void EndBackorder(IAsyncResult oAsyncResult)
    {
      m_oBackorderResponseData = (BackorderResponseData)Engine.EndProcessRequest(oAsyncResult);
      m_swBackorder.Stop();
      KeyValuePair<string, int> oFirstDomain = m_oBackorderResponseData.FirstDomain;
      BackorderLiteral.Text = HttpContext.Current.Server.HtmlEncode(m_oBackorderResponseData.ToXML());
    }

    void TimeoutBackorder(IAsyncResult oAsyncResult)
    {
      BackorderLiteral.Text = "Backorder asynchronous call timeout.";
    }

    /******************************************************************************/

    IAsyncResult BeginBuyDomains(object sender, EventArgs e, AsyncCallback oCallback, object oState)
    {
      BuyDomainsRequestData oRequestData = new BuyDomainsRequestData("", "", "", "", 0);

      string[] oDomains = DomainSearchTextBox.Text.Split(',', '\n', '\t', ' ');

      if(oDomains.Length > 0 && oDomains[0].Length > 0)
        oRequestData.SLD = oDomains[0].Split('.')[0];

      oRequestData.AddTLDs(new string[] { "net", "com", "org" });
      oRequestData.MaxResults = 10;

      m_swBuyDomains.Reset();
      m_swBuyDomains.Start();
      IAsyncResult oAsyncResult = Engine.BeginProcessRequest(oRequestData, IBUYDOMAINSASYNC, oCallback, oState);

      return oAsyncResult;
    }

    void EndBuyDomains(IAsyncResult oAsyncResult)
    {
      BuyDomainsResponseData oResponseData = (BuyDomainsResponseData)Engine.EndProcessRequest(oAsyncResult);
      m_swBuyDomains.Stop();

      foreach (KeyValuePair<string, BuyDomainAttributes> oDomain in oResponseData.Domains)
      {
        TableRow trDomain = new TableRow();
        TableCell tcName = new TableCell();
        TableCell tcPrice = new TableCell();
        TableCell tcIsFastTransfer = new TableCell();

        tcName.Text = oDomain.Value.DomainName;
        tcPrice.Text = oDomain.Value.Price.ToString();
        tcIsFastTransfer.Text = oDomain.Value.IsFastTransfer.ToString();

        trDomain.Cells.Add(tcName);
        trDomain.Cells.Add(tcPrice);
        trDomain.Cells.Add(tcIsFastTransfer);

        BuyDomainsTable.Rows.Add(trDomain);
      }
      
      BuyDomainsLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
    }

    void TimeoutBuyDomains(IAsyncResult oAsyncResult)
    {
      BuyDomainsLiteral.Text = "BuyDomains asynchronous call timeout.";
    }

    /******************************************************************************/

    IAsyncResult BeginDomainsBot(object sender, EventArgs e, AsyncCallback oCallback, object oState)
    {
      DomainsBotRequestData oRequestData = new DomainsBotRequestData("", "", "", "", 0);

      string[] oDomains = DomainSearchTextBox.Text.Split(',', '\n', '\t', ' ');

      if (oDomains.Length > 0 && oDomains[0].Length > 0)
        oRequestData.SearchKey = oDomains[0].Split('.')[0];

      oRequestData.AddTLDs(new string[] { "net", "com", "org" });

      oRequestData.AddDashes = true;
      oRequestData.AddRelated = true;
      oRequestData.AddPrefixes = true;
      oRequestData.AddSuffixes = true;
      oRequestData.MaxResults = 10;

      m_swDomainsBot.Reset();
      m_swDomainsBot.Start();
      IAsyncResult oAsyncResult = Engine.BeginProcessRequest(oRequestData, IDOMAINSBOTASYNC, oCallback, oState);

      return oAsyncResult;
    }

    void EndDomainsBot(IAsyncResult oAsyncResult)
    {
      DomainsBotResponseData oResponseData = (DomainsBotResponseData)Engine.EndProcessRequest(oAsyncResult);
      m_swDomainsBot.Stop();

      lbDomainBotTotal.Text = oResponseData.AvailableResults.ToString();

      foreach (string sDomainName in oResponseData.DomainNames)
      {
        TableRow trDomain = new TableRow();
        TableCell tcName = new TableCell();

        tcName.Text = sDomainName;
        trDomain.Cells.Add(tcName);

        DomainsBotTable.Rows.Add(trDomain);
      }
      
      //DomainsBotLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
    }

    void TimeoutDomainsBot(IAsyncResult oAsyncResult)
    {
      DomainsBotLiteral.Text = "DomainsBot asynchronous call timeout.";
    }

    /******************************************************************************/

    IAsyncResult BeginFabDomains(object sender, EventArgs e, AsyncCallback oCallback, object oState)
    {
      FabDomainsRequestData oRequestData = new FabDomainsRequestData("", "", "", "", 0);

      string[] oDomains = DomainSearchTextBox.Text.Split(',', '\n', '\t', ' ');

      if (oDomains.Length > 0 && oDomains[0].Length > 0)
        oRequestData.SLD = oDomains[0].Split('.')[0];

      oRequestData.AddTLDs(new string[] { "net", "com", "org" });

      oRequestData.ReturnCount = 10;

      m_swFabDomains.Reset();
      m_swFabDomains.Start();
      IAsyncResult oAsyncResult = Engine.BeginProcessRequest(oRequestData, IFABDOMAINSASYNC, oCallback, oState);

      return oAsyncResult;
    }

    void EndFabDomains(IAsyncResult oAsyncResult)
    {
      FabDomainsResponseData oResponseData = (FabDomainsResponseData)Engine.EndProcessRequest(oAsyncResult);
      m_swFabDomains.Stop();

      foreach (KeyValuePair<string, FabDomainAttributes> oDomain in oResponseData.Domains)
      {
        TableRow trDomain = new TableRow();
        TableCell tcName = new TableCell();
        TableCell tcOwnerType = new TableCell();
        TableCell tcPrice = new TableCell();
        TableCell tcWaterlinePrice = new TableCell();
        TableCell tcCommission = new TableCell();

        tcName.Text = oDomain.Value.DomainName;
        tcOwnerType.Text = oDomain.Value.OwnerType;
        tcPrice.Text = oDomain.Value.Price.ToString();
        tcWaterlinePrice.Text = oDomain.Value.WaterlinePrice.ToString();
        tcCommission.Text = oDomain.Value.CommissionPct.ToString();

        trDomain.Cells.Add(tcName);
        trDomain.Cells.Add(tcOwnerType);
        trDomain.Cells.Add(tcPrice);
        trDomain.Cells.Add(tcWaterlinePrice);
        trDomain.Cells.Add(tcCommission);

        FabDomainsTable.Rows.Add(trDomain);
      }

      FabDomainsLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
    }

    void TimeoutFabDomains(IAsyncResult oAsyncResult)
    {
      FabDomainsLiteral.Text = "FabDomains asynchronous call timeout.";
    }

    /******************************************************************************/
  }
}
