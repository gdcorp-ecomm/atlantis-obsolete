#define ASYNC_IO_GETMINI_CART
#define ASYNC_PAGE_HEADER
#define ASYNC_PAGE_FOOTER

using System;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Atlantis.Framework.Interface;
using Atlantis.Framework.Engine;
using Atlantis.Framework.DataCache;

using Atlantis.Framework.GetShopper.Interface;
using Atlantis.Framework.SearchShoppers.Interface;
using Atlantis.Framework.GetMiniCart.Interface;
using Atlantis.Framework.AddItem.Interface;
using Atlantis.Framework.DeleteItem.Interface;
using Atlantis.Framework.ModifyItem.Interface;
using Atlantis.Framework.GetBasket.Interface;
using Atlantis.Framework.GetPlanFeatures.Interface;
using Atlantis.Framework.LinkInfo.Interface;
using Atlantis.Framework.ProductGroup.Interface;
using Atlantis.Framework.ProductOffer.Interface;
using Atlantis.Framework.ShopperPriceType.Interface;
using Atlantis.Framework.GetOverrideHash.Interface;
using Atlantis.Framework.GetDurationHash.Interface;
using Atlantis.Framework.CreateShopper.Interface;
using Atlantis.Framework.PresentationCentral.Interface;
using Atlantis.Framework.DomainContactCheck.Interface;
using Atlantis.Framework.UpdateItem.Interface;

namespace Atlantis.TestPage
{
  public partial class _Default : System.Web.UI.Page
  {
    /******************************************************************************/

    const int IGETSHOPPERTYPE     = 1;
    const int ISEARCHSHOPPERTYPE  = 2;
    const int IGETMINICARTTYPE    = 3;
    const int IADDITEMTYPE        = 4;
    const int IDELETEITEMTYPE     = 5;
    const int IMODIFYITEMTYPE     = 6;
    const int IGETBASKETTYPE      = 7;
    const int IGETMINICARTTYPEIO  = 8;
    const int ICUSTOMCONTENT      = 9;
    const int IBANNERCONTENT      = 10;
    const int IGETPLANFEATURES    = 11;
    const int ILINKINFO           = 12;
    const int IPRODUCTGROUP       = 13;
    const int IPRODUCTOFFER       = 24;
    const int ISHOPPERPRICETYPE   = 25;
    const int IGETOVERRIDEHASH    = 26;
    const int IGETDURATIONHASH    = 27;
    const int ICREATESHOPPER      = 28;
    const int IHTMLREQUEST        = 29;
    const int IHTMLREQUESTASYNC   = 30;
    /******************************************************************************/

    GetShopperRequestData m_oShopperRequest;
    GetShopperResponseData m_oShopper;

    AsyncResultHandler m_oAsync;
    GetShopperRequestData m_oAsyncShopperRequest;
    GetShopperResponseData m_oAsyncShopper;

    AsyncResultHandler m_oAsyncGetMiniCart;
    GetMiniCartRequestData m_oAsyncGetMiniCartRequestData;

    AsyncResultHandler m_oAsyncGetBasket;
    GetBasketRequestData m_oGetBasketRequestData;

    HtmlRequestData m_oAsyncPageHeaderRequestData;
    HtmlRequestData m_oAsyncPageFooterRequestData;

    delegate IResponseData AsyncResultHandler(RequestData oRequestData, int iType);

    /******************************************************************************/

    protected void Page_Load(object sender, EventArgs e)
    {
#if ASYNC_PAGE_HEADER
        PageAsyncTask taskPageHeader = new PageAsyncTask
        (
          new BeginEventHandler(BeginPageHeaderAsyncOp),
          new EndEventHandler(EndPageHeaderAsyncOp),
          new EndEventHandler(TimeoutPageHeaderAsyncOp),
          null
        );

        RegisterAsyncTask(taskPageHeader);
#else
     GeneratePageHeader();
#endif

#if ASYNC_PAGE_FOOTER
        PageAsyncTask taskPageFooter = new PageAsyncTask
          (
            new BeginEventHandler(BeginPageFooterAsyncOp),
            new EndEventHandler(EndPageFooterAsyncOp),
            new EndEventHandler(TimeoutPageFooterAsyncOp),
            null
          );

        RegisterAsyncTask(taskPageFooter);
#else
        GeneratePageFooter();
#endif

#if ASYNC_SHOPPER_DATA
      PageAsyncTask task = new PageAsyncTask
         (
           new BeginEventHandler(BeginAsyncOperation),
           new EndEventHandler(EndAsyncOperation),
           new EndEventHandler(TimeoutAsyncOperation),
           null
         );
      
      RegisterAsyncTask(task);
#else
      GenerateShopperData();
#endif

#if ASYNC_GET_MINI_CART
      PageAsyncTask taskGetMini = new PageAsyncTask
        (
          new BeginEventHandler(BeginGetMiniCartAsyncOp),
          new EndEventHandler(EndGetMiniCartAsyncOp),
          new EndEventHandler(TimeoutGetMiniCartAsyncOp),
          null
        );
      RegisterAsyncTask(taskGetMini);
#elif ASYNC_IO_GETMINI_CART
      PageAsyncTask taskGetMiniIO = new PageAsyncTask
        (
          new BeginEventHandler(BeginGetMiniCartAsyncIOOp),
          new EndEventHandler(EndGetMiniCartAsyncIOOp),
          new EndEventHandler(TimeoutGetMiniCartAsyncIOOp),
          null
        );
      RegisterAsyncTask(taskGetMiniIO);
#else
      GenerateMiniCart();
#endif

#if ASYNC_GET_BASKET
      PageAsyncTask taskGetBasket = new PageAsyncTask
        (
          new BeginEventHandler(BeginGetBasketAsyncOp),
          new EndEventHandler(EndGetBasketAsyncOp),
          new EndEventHandler(TimeoutGetBasketAsyncOp),
          null
        );

      RegisterAsyncTask(taskGetBasket);
#else
        GenerateBasket();
#endif



    }

    /******************************************************************************/

    void GenerateShopperData()
    {
      try
      {
        m_oShopperRequest = new GetShopperRequestData(GetShopperIDTextBox.Text, 
                                                      "SourceURL", 
                                                      "OrderID", 
                                                      "Pathway", 0, 
                                                      "RequestedBy");
        m_oShopperRequest.AddField("first_name");
        m_oShopperRequest.AddField("last_name");
        m_oShopperRequest.AddField("email");
        m_oShopperRequest.AddField("phone1");
        m_oShopperRequest.AddField("city");

        m_oShopper = (GetShopperResponseData)Engine.ProcessRequest(m_oShopperRequest, IGETSHOPPERTYPE);

        GetShopperLiteral.Text = HttpContext.Current.Server.HtmlEncode(m_oShopper.ToXML());
      }
      catch (Exception ex)
      {
        GetShopperLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    void BuildMiniCart(GetMiniCartRequestData oGetMiniCartRequestData, GetMiniCartResponseData oMiniCart)
    {
      string[] sAttributes = new string[] { "pf_id", "quantity" };

      TableRow trHeader = GetMiniCartResultTable.Rows[0];
      GetMiniCartResultTable.Rows.Clear();
      GetMiniCartResultTable.Rows.Add(trHeader);

      for (int i = 0; i < oMiniCart.ItemCount; ++i)
      {
        TableRow trItem = new TableRow();

        foreach (string sAttribute in sAttributes)
        {
          TableCell tcAttribute = new TableCell();
          tcAttribute.Text = oMiniCart.GetItemAttribute(i, sAttribute);
          trItem.Cells.Add(tcAttribute);
        }

        GetMiniCartResultTable.Rows.Add(trItem);
      }
    }

    /******************************************************************************/

    void BuildBasket(GetBasketRequestData oGetBasketRequestData, GetBasketResponseData oBasket)
    {
      string[] sAttributes = new string[] { "pf_id", "quantity" };

      TableRow trHeader = GetBasketResultTable.Rows[0];
      GetBasketResultTable.Rows.Clear();
      GetBasketResultTable.Rows.Add(trHeader);

      for (int i = 0; i < oBasket.ItemCount; ++i)
      {
        TableRow trItem = new TableRow();
        TableCell tcButton = new TableCell();
        LinkButton btnDelete = new LinkButton();

        foreach (string sAttribute in sAttributes)
        {
          TableCell tcAttribute = new TableCell();
          tcAttribute.Text = oBasket.GetItemAttribute(i, sAttribute);
          trItem.Cells.Add(tcAttribute);
        }

        btnDelete.ID = "DeleteLink" + Convert.ToString(i);
        btnDelete.Text = "delete";
        btnDelete.Command += new CommandEventHandler(DeleteItemButton_Click);
        btnDelete.CommandArgument = oGetBasketRequestData.ShopperID + "|" + Convert.ToString(i);
        tcButton.Controls.Add(btnDelete);
        trItem.Cells.Add(tcButton);

        GetBasketResultTable.Rows.Add(trItem);
      }
    }

    /******************************************************************************/

    IAsyncResult BeginGetBasketAsyncOp(object sender, EventArgs e, AsyncCallback cb, object state)
    {
      IAsyncResult result = null;

      try
      {
        m_oGetBasketRequestData = new GetBasketRequestData(GetBasketShopperIDTextBox.Text,
                                                           "SourceURL",
                                                           "OrderID",
                                                           "Pathway", 0);

        m_oAsyncGetBasket = new AsyncResultHandler(Engine.ProcessRequest);
        result = m_oAsyncGetBasket.BeginInvoke(m_oGetBasketRequestData, IGETBASKETTYPE, cb, state);
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }

      return result;
    }

    void EndGetBasketAsyncOp(IAsyncResult ar)
    {
      BuildBasket(m_oGetBasketRequestData, (GetBasketResponseData)m_oAsyncGetBasket.EndInvoke(ar));
    }

    void TimeoutGetBasketAsyncOp(IAsyncResult ar)
    {
      ErrorLiteral.Text = "Data temporarily unavailable";
    }

    /******************************************************************************/

    IAsyncResult BeginGetMiniCartAsyncOp(object sender, EventArgs e, AsyncCallback cb, object state)
    {
      IAsyncResult result = null;

      try
      {
        m_oAsyncGetMiniCartRequestData = new GetMiniCartRequestData(GetMiniCartShopperIDTextBox.Text,
                                                                   "SourceURL",
                                                                   "OrderID",
                                                                   "Pathway", 0);
        m_oAsyncGetMiniCart = new AsyncResultHandler(Engine.ProcessRequest);
        result = m_oAsyncGetMiniCart.BeginInvoke(m_oAsyncGetMiniCartRequestData, IGETMINICARTTYPE, cb, state);
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }

      return result;
    }

    void EndGetMiniCartAsyncOp(IAsyncResult ar)
    {
      GetMiniCartResponseData oMiniCart = (GetMiniCartResponseData)m_oAsyncGetMiniCart.EndInvoke(ar);
      BuildMiniCart(m_oAsyncGetMiniCartRequestData, oMiniCart);
    }

    void TimeoutGetMiniCartAsyncOp(IAsyncResult result)
    {
      ErrorLiteral.Text = "Data temporarily unavailable";
    }

    /******************************************************************************/

    IAsyncResult BeginGetMiniCartAsyncIOOp(object sender, EventArgs e, AsyncCallback cb, object state)
    {
      IAsyncResult result = null;

      try
      {
        m_oAsyncGetMiniCartRequestData = new GetMiniCartRequestData(GetMiniCartShopperIDTextBox.Text,
                                                                   "SourceURL",
                                                                   "OrderID",
                                                                   "Pathway", 0);

        result = Engine.BeginProcessRequest(m_oAsyncGetMiniCartRequestData, IGETMINICARTTYPEIO, cb, state);
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }

      return result;
    }

    void EndGetMiniCartAsyncIOOp(IAsyncResult ar)
    {
      GetMiniCartResponseData oMiniCart = (GetMiniCartResponseData)Engine.EndProcessRequest(ar);
      BuildMiniCart(m_oAsyncGetMiniCartRequestData, oMiniCart);
    }

    void TimeoutGetMiniCartAsyncIOOp(IAsyncResult result)
    {
      ErrorLiteral.Text = "Data temporarily unavailable";
    }

    /******************************************************************************/

    void GenerateMiniCart()
    {
      GetMiniCartRequestData oGetMiniCartRequestData = new GetMiniCartRequestData(GetMiniCartShopperIDTextBox.Text,
                                                                                  "SourceURL",
                                                                                  "OrderID",
                                                                                  "Pathway", 0);

      GetMiniCartResponseData oMiniCart =
        (GetMiniCartResponseData)Engine.ProcessRequest(oGetMiniCartRequestData, IGETMINICARTTYPE);
      BuildMiniCart(oGetMiniCartRequestData, oMiniCart);
    }

    /******************************************************************************/

    void GenerateBasket()
    {
      GetBasketRequestData oGetBasketRequestData = new GetBasketRequestData(GetBasketShopperIDTextBox.Text,
                                                                            "SourceURL",
                                                                            "OrderID",
                                                                            "Pathway", 0);

      GetBasketResponseData oBasket =
        (GetBasketResponseData)Engine.ProcessRequest(oGetBasketRequestData, IGETBASKETTYPE);

      BuildBasket(oGetBasketRequestData, oBasket);
        
    }

    /******************************************************************************/

    void GeneratePageHeader()
    {
        HtmlRequestData oHtmlRequestData = new HtmlRequestData( "header", "sales", 1, false,
                                                                               "",
                                                                              "SourceURL",
                                                                              "OrderID",
                                                                              "Pathway", 0);
        string xml = oHtmlRequestData.ToXML();
        HtmlResponseData oHtmlResponseData =
          (HtmlResponseData)Engine.ProcessRequest(oHtmlRequestData, IHTMLREQUEST);

        string sHtml = oHtmlResponseData.GetHtml("header");
        PageHeaderLiteral.Text = sHtml;
        string sXml = oHtmlResponseData.ToXML();
    }

    /******************************************************************************/

    void GeneratePageFooter()
    {
      HtmlRequestData oHtmlRequestData = new HtmlRequestData("footer", "sales", 1, false, GetBasketShopperIDTextBox.Text,
                                                                              "SourceURL",
                                                                              "OrderID",
                                                                              "Pathway", 0);

        HtmlResponseData oHtmlResponseData =
          (HtmlResponseData)Engine.ProcessRequest(oHtmlRequestData, IHTMLREQUEST);

        string sHtml = oHtmlResponseData.GetHtml("footer");
        PageFooterLiteral.Text = sHtml;
        string sXml = oHtmlResponseData.ToXML();
    }

    /******************************************************************************/
    IAsyncResult BeginPageHeaderAsyncOp(object sender, EventArgs e, AsyncCallback cb, object state)
    {
        IAsyncResult result = null;

        try
        {
          m_oAsyncPageHeaderRequestData = new HtmlRequestData("header", "sales", 1, false, "",
                                                                       "SourceURL",
                                                                       "OrderID",
                                                                       "Pathway", 0);
			m_oAsyncPageHeaderRequestData.ParamsElement.Attributes["bobsblog"] = "Whoa!";

            result = Engine.BeginProcessRequest(m_oAsyncPageHeaderRequestData, IHTMLREQUESTASYNC, cb, state);
        }
        catch (AtlantisException exAtlantis)
        {
            ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = ex.Message;
        }

        return result;
    }

    void EndPageHeaderAsyncOp(IAsyncResult ar)
    {
        HtmlResponseData oPageHeaderResponseData = (HtmlResponseData)Engine.EndProcessRequest(ar); 
        string sHtml = oPageHeaderResponseData.GetHtml("header");
        PageHeaderLiteral.Text = sHtml;
        string sXml = oPageHeaderResponseData.ToXML();
    }

    void TimeoutPageHeaderAsyncOp(IAsyncResult result)
    {
        ErrorLiteral.Text = "Page Header data temporarily unavailable.";
    }

    /******************************************************************************/
    
      IAsyncResult BeginPageFooterAsyncOp(object sender, EventArgs e, AsyncCallback cb, object state)
    {
        IAsyncResult result = null;

        try
        {

            m_oAsyncPageFooterRequestData = new HtmlRequestData( "footer2", "sales", 1, false, "",
                                                                     "SourceURL",
                                                                     "OrderID",
                                                                     "Pathway", 0);

            result = Engine.BeginProcessRequest(m_oAsyncPageFooterRequestData, IHTMLREQUESTASYNC, cb, state);
        }
        catch (AtlantisException exAtlantis)
        {
            ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = ex.Message;
        }

        return result;
    }

    void EndPageFooterAsyncOp(IAsyncResult ar)
    {
        HtmlResponseData oPageFooterResponseData = (HtmlResponseData)Engine.EndProcessRequest(ar); 
        string sHtml = oPageFooterResponseData.GetHtml("footer2");
        PageFooterLiteral.Text = sHtml;
        string sXml = oPageFooterResponseData.ToXML();
    }

    void TimeoutPageFooterAsyncOp(IAsyncResult result)
    {
        ErrorLiteral.Text = "Page Footer data temporarily unavailable.";
    }


    /******************************************************************************/


    /******************************************************************************/

    IAsyncResult BeginAsyncOperation(object sender, EventArgs e, AsyncCallback cb, object state)
    {
      IAsyncResult result = null;
      try
      {
        m_oAsyncShopperRequest = new GetShopperRequestData(GetShopperIDTextBox.Text,
                                                           "SourceURL",
                                                           "OrderID",
                                                           "Pathway", 0,
                                                           "RequestedBy");
        m_oAsyncShopperRequest.AddField("first_name");
        m_oAsyncShopperRequest.AddField("last_name");
        m_oAsyncShopperRequest.AddField("email");
        m_oAsyncShopperRequest.AddField("phone1");
        m_oAsyncShopperRequest.AddField("city");

        m_oAsync = new AsyncResultHandler(Engine.ProcessRequest);
        result = m_oAsync.BeginInvoke((RequestData)m_oAsyncShopperRequest, IGETSHOPPERTYPE, cb, state);
      }
      catch (AtlantisException exAtlantis)
      {
        GetShopperLiteral.Text = exAtlantis.ToXml();
      }
      catch (Exception ex)
      {
        GetShopperLiteral.Text = ex.Message;
      }
      return result;
    }

    void EndAsyncOperation(IAsyncResult ar)
    {
      m_oAsyncShopper = (GetShopperResponseData)m_oAsync.EndInvoke(ar);
      GetShopperLiteral.Text = m_oAsyncShopper.ToXML();
    }

    void TimeoutAsyncOperation(IAsyncResult ar)
    {
      GetShopperLiteral.Text = "Data temporarily unavailable";
    }

    /******************************************************************************/

    protected void SearchShoppersButton_Click(object sender, EventArgs e)
    {
      try
      {
        SearchShoppersRequestData oSearchShoppersRequestData = new SearchShoppersRequestData("SearchingShopper",
                                                                                             "SourceURL",
                                                                                             "OrderID",
                                                                                             "Pathway", 0,
                                                                                             "Atlantis");

        SearchShoppersRequestData.SearchField[] fields = new SearchShoppersRequestData.SearchField[] 
        {
          new SearchShoppersRequestData.SearchField("first_name", SearchShoppersFirstNameTextBox.Text),
          new SearchShoppersRequestData.SearchField("last_name", SearchShoppersLastNameTextBox.Text),
        };

        oSearchShoppersRequestData.AddSearchFields(fields);
        oSearchShoppersRequestData.AddReturnFields(new string[] { "shopper_id", "email" });

        SearchShoppersResponseData oShoppers =
          (SearchShoppersResponseData)Engine.ProcessRequest(oSearchShoppersRequestData, ISEARCHSHOPPERTYPE);

        for (int i = 0; i < oShoppers.ShopperCount; ++i)
        {
          TableRow trShopper = new TableRow();
          TableCell tcEmail = new TableCell();
          TableCell tcShopperID = new TableCell();

          tcEmail.Text = oShoppers.GetShopperAttribute(i, "email");
          tcShopperID.Text = oShoppers.GetShopperAttribute(i, "shopper_id");

          trShopper.Cells.Add(tcEmail);
          trShopper.Cells.Add(tcShopperID);

          SearchShoppersResultTable.Rows.Add(trShopper);
        }

        SearchShoppersResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oShoppers.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void AddItemButton_Click(object sender, EventArgs e)
    {
      try
      {
        if (AddItemProductIDTextBox.Text.Length > 0 && AddItemQuantityTextBox.Text.Length > 0)
        {
          AddItemRequestData oAddItemRequestData = new AddItemRequestData(AddItemShopperIDTextBox.Text,
                                                                          "SourceURL",
                                                                          "OrderID",
                                                                          "Pathway", 0);
          oAddItemRequestData.AddItem(AddItemProductIDTextBox.Text, AddItemQuantityTextBox.Text);

          AddItemResponseData oResponseData =
            (AddItemResponseData)Engine.ProcessRequest(oAddItemRequestData, IADDITEMTYPE);

          AddItemResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());

          GenerateBasket();
        }
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void AddContactInfo_Click(object sender, EventArgs e)
    {
      try
      {
        if (AddItemProductIDTextBox.Text.Length > 0 && AddItemQuantityTextBox.Text.Length > 0)
        {
          AddItemRequestData oAddItemRequestData = new AddItemRequestData(AddItemShopperIDTextBox.Text,
                                                                          "SourceURL",
                                                                          "OrderID",
                                                                          "Pathway", 0);

          List<string> tlds = new List<string>();
          tlds.Add( ".COM" );
          DomainContactGroup contactGroup = new DomainContactGroup(tlds, 1);


          DomainContact registrantContact = new DomainContact(
             "Bill", "Registrant", "bregistrant@bongo.com",
                 "MumboJumbo", true,
                  "101 N Street", "Suite 100", "Littleton", "CO",
                  "80130", "US", "(303)-555-1213", "(303)-555-2213");
          List<DomainContactError> Errors = new List<DomainContactError>();
          contactGroup.SetContact(DomainContact.DomainContactType.Registrant, registrantContact);
         
          oAddItemRequestData.AddContactInfo(contactGroup);

          string sText = oAddItemRequestData.ToXML();
          AddContactXmlTextBox.Text = sText;

          AddItemResponseData oResponseData =
            (AddItemResponseData)Engine.ProcessRequest(oAddItemRequestData, IADDITEMTYPE);

          AddItemResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());

          GenerateBasket();
        }
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void ModfiyItemButton_Click(object sender, EventArgs e)
    {
      try
      {
        ModifyItemRequestData oModifyItemRequestData = new ModifyItemRequestData(ModifyItemShopperIDTextBox.Text,
                                                                                 "SourceURL",
                                                                                 "OrderID",
                                                                                 "Pathway", 3,
                                                                                 ModifyItemIndexTextBox.Text,
                                                                                 ModifyItemQuantityTextBox.Text);

        ModifyItemResponseData oResponseData =
          (ModifyItemResponseData)Engine.ProcessRequest(oModifyItemRequestData, IMODIFYITEMTYPE);

        ModifyItemResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());

        GenerateBasket();
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void DeleteItemButton_Click(object sender, CommandEventArgs e)
    {
      //try
      //{
      //  LinkButton btnDelete = sender as LinkButton;

      //  if (btnDelete != null)
      //  {
      //    string[] args = btnDelete.CommandArgument.Split('|');

      //    DeleteItemRequestData oDeleteItemRequestData = new DeleteItemRequestData(args[0],
      //                                                                             "SourceURL",
      //                                                                             "OrderID",
      //                                                                             "Pathway", 0);

      //    oDeleteItemRequestData.AddItemId(args[1]);

      //    DeleteItemResponseData oResponseData =
      //      (DeleteItemResponseData)Engine.ProcessRequest(oDeleteItemRequestData, IDELETEITEMTYPE);

      //    bool bSuccess = oResponseData.IsSuccess;

      //    DeleteItemResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());

      //    GenerateBasket();
      //  }
      //}
      //catch (AtlantisException exAtlantis)
      //{
      //  ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      //}
      //catch (Exception ex)
      //{
      //  ErrorLiteral.Text = ex.Message;
      //}
    }

    protected void GetPlanFeaturesButton_Click(object sender, EventArgs e)
    {
      try
      {
        int iUnifiedPFID = Convert.ToInt32(GetPlanFeaturesUnifiedPFIDTextBox.Text);
        GetPlanFeaturesRequestData oGetPlanFeaturesRequestData = new GetPlanFeaturesRequestData("ShopperID",
                                                                                                "SourceURL",
                                                                                                "OrderID",
                                                                                                "Pathway", 0,
                                                                                                iUnifiedPFID);
        GetPlanFeaturesResponseData oResponseData =
          (GetPlanFeaturesResponseData)DataCache.GetProcessRequest(oGetPlanFeaturesRequestData, IGETPLANFEATURES);

        GetPlanFeaturesResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void LinkInfoButton_Click(object sender, EventArgs e)
    {
      try
      {
        LinkInfoRequestData oLinkInfoRequestData = new LinkInfoRequestData("ShopperID",
                                                                           "SourceURL",
                                                                           "OrderID",
                                                                           "Pathway", 0);

        oLinkInfoRequestData.ContextID      = Convert.ToInt32(LinkInfoContextIDTextBox.Text);

        LinkInfoResponseData oResponseData = 
          (LinkInfoResponseData)DataCache.GetProcessRequest(oLinkInfoRequestData, ILINKINFO);

        LinkInfoResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void ProductGroupButton_Click(object sender, EventArgs e)
    {
      try
      {
        ProductGroupRequestData oProductGroupRequestData = new ProductGroupRequestData("ShopperID",
                                                                                       "SourceURL",
                                                                                       "OrderID",
                                                                                       "Pathway", 0);

        oProductGroupRequestData.UnifiedProductGroupID = Convert.ToInt32(ProductGroupUnifiedIDTextBox.Text);

        ProductGroupResponseData oResponseData = 
          (ProductGroupResponseData)DataCache.GetProcessRequest(oProductGroupRequestData, IPRODUCTGROUP);

        ProductGroupResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void ProductOfferButton_Click(object sender, EventArgs e)
    {
      try
      {
        ProductOfferRequestData oProductOfferRequestData = new ProductOfferRequestData("ShopperID",
          "SourceURL",
          "OrderID",
          "Pathway", 0,
          Convert.ToInt32(ProductOfferPLIDTextBox.Text));

        ProductOfferResponseData oResponseData =
          (ProductOfferResponseData)DataCache.GetProcessRequest(oProductOfferRequestData, IPRODUCTOFFER);

        ProductOfferResultLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void ShopperPriceTypeButton_Click(object sender, EventArgs e)
    {
      try
      {
        ShopperPriceTypeRequestData oShopperPriceTypeRequestData 
          = new ShopperPriceTypeRequestData(ShopperPriceTypeShopperIDTextBox.Text,
                                            "SourceURL",
                                            "OrderID",
                                            "Pathway",
                                            0, Convert.ToInt32(ShopperPriceTypePLIDTextBox.Text));
                                          

        ShopperPriceTypeResponseData oResponseData =
          (ShopperPriceTypeResponseData)DataCache.GetProcessRequest(oShopperPriceTypeRequestData, ISHOPPERPRICETYPE);

        int iPriceType = oResponseData.PriceType;

        ShopperPriceTypeLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void GetOverrideHashButton_Click(object sender, EventArgs e)
    {
      try
      {
        GetOverrideHashRequestData oGetOverrideHashRequestData 
          = new GetOverrideHashRequestData("ShopperID",
                                           "SourceURL",
                                           "OrderID",
                                           "Pathway",0, 
                                           Convert.ToInt32(GetOverrideHashUnifiedPFIDTextBox.Text),
                                           Convert.ToInt32(GetOverrideHashPLIDTextBox.Text),
                                           Convert.ToInt32(GetOverrideHashOverrideListPriceTextBox.Text),
                                           Convert.ToInt32(GetOverrideHashOverrideCurrentPriceTextBox.Text));

        GetOverrideHashResponseData oResponseData =
          (GetOverrideHashResponseData)Engine.ProcessRequest(oGetOverrideHashRequestData, IGETOVERRIDEHASH);

        string sHash = oResponseData.Hash;

        GetOverrideHashLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    /******************************************************************************/

    protected void GetDurationHashButton_Click(object sender, EventArgs e)
    {
      try
      {
        GetDurationHashRequestData oGetDurationHashRequestData 
          = new GetDurationHashRequestData("ShopperID",
                                           "SourceURL",
                                           "OrderID",
                                           "Pathway", 0,
                                           Convert.ToInt32(GetDurationHashUnifiedPFIDTextBox.Text),
                                           Convert.ToInt32(GetDurationHashPLIDTextBox.Text),
                                           Convert.ToDouble(GetDurationHashDurationTextBox.Text));


        GetDurationHashResponseData oResponseData =
          (GetDurationHashResponseData)Engine.ProcessRequest(oGetDurationHashRequestData, IGETDURATIONHASH);

        string sHash = oResponseData.Hash;

        GetDurationHashLiteral.Text = HttpContext.Current.Server.HtmlEncode(oResponseData.ToXML());
      }
      catch (AtlantisException exAtlantis)
      {
        ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
      }
      catch (Exception ex)
      {
        ErrorLiteral.Text = ex.Message;
      }
    }

    protected void CreateShopper_Click(object sender, EventArgs e)
    {
        try
        {
            CreateShopperRequestData oCreateShopperRequestData
              = new CreateShopperRequestData("SourceUrl", string.Empty, string.Empty, 0, Convert.ToInt32(CreateShopperPLIDTextBox.Text));

            CreateShopperResponseData oResponseData =
              (CreateShopperResponseData)Engine.ProcessRequest(oCreateShopperRequestData, ICREATESHOPPER);

            string sShopperID = oResponseData.GetShopperId();
            CreateShopperLiteral.Text = sShopperID;
          }
        catch (AtlantisException exAtlantis)
        {
            ErrorLiteral.Text = HttpContext.Current.Server.HtmlEncode(exAtlantis.ToXml());
        }
        catch (Exception ex)
        {
            ErrorLiteral.Text = ex.Message;
        }
    }

    protected void GetFooterButton_Click(object sender, EventArgs e)
    {

    }

    protected void cmdUpdateItem_Click(object sender, EventArgs e)
    {
        UpdateItemRequestData oData = new UpdateItemRequestData("853392", "www.yahoo.com", "0", string.Empty, 0, 6503, 1, 0, 50, 1);
        Atlantis.Framework.UpdateItem.Impl.UpdateItemRequest oRequest = new Atlantis.Framework.UpdateItem.Impl.UpdateItemRequest();
        IResponseData oResponse= Atlantis.Framework.Engine.Engine.ProcessRequest(oData, 38);
    }
  }
}
