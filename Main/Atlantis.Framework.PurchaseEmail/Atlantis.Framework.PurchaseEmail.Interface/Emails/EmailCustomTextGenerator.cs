﻿using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.PurchaseEmail.Interface.Providers;
using System.Xml;
using System.Web;
using System.Web.UI.WebControls;
using Atlantis.Framework.Providers.Interface.Currency;
using Atlantis.Framework.Providers.Interface.Links;
using Atlantis.Framework.Providers.Interface.Products;
using Atlantis.Framework.Providers.Currency;

namespace Atlantis.Framework.PurchaseEmail.Interface.Emails
{
  internal class EmailCustomTextGenerator
  {
    OrderData _orderData;
    ICurrencyProvider _currency;
    DepartmentIds _departmentIds;
    ILinkProvider _links;
    IProductProvider _products;

    public EmailCustomTextGenerator(OrderData orderData, ICurrencyProvider currency, DepartmentIds departmentIds, ILinkProvider links, IProductProvider products)
    {
      _orderData = orderData;
      _currency = currency;
      _departmentIds = departmentIds;
      _links = links;
      _products = products;     
    }

    #region ItemText Functions - Blue Razor
    public void BuildItemsText_BR_PlainText(StringBuilder itemsTextBuilder, bool debug)
    {
      BuildItemsText_GD_PlainText(itemsTextBuilder, debug);
    }
    public void BuildItemsText_BR_Html(StringBuilder itemTextBuilder)
    {
      itemTextBuilder.Append("<table cellspacing='2' cellpadding='2' border='0' style='font-family:Arial;font-size:11px'>");
      itemTextBuilder.Append("  <tr>");
      itemTextBuilder.Append("    <td align='right' valign='bottom' class='bodyText'><u>qty</u></td>");
      itemTextBuilder.Append("    <td align='center' valign='bottom' class='bodyText'><u>item</u></td>");
      itemTextBuilder.Append("    <td align='right' valign='bottom' class='bodyText'><u>price</u></td>");
      itemTextBuilder.Append("  </tr>");

      XmlNodeList itemNodes = _orderData.OrderXmlDoc.SelectNodes("/ORDER/ITEMS/ITEM");
      foreach (XmlElement itemElement in itemNodes)
      {
        string isDisplayedInCart = itemElement.GetAttribute("isdisplayedincart");
        bool shouldDisplay = isDisplayedInCart != "0";
        if (shouldDisplay)
        {
          itemTextBuilder.Append("  <tr>");
          itemTextBuilder.Append("    <td align='right' valign='top' class='bodyText'>" +
                                 itemElement.GetAttribute("quantity") + "</td>");
          itemTextBuilder.Append("    <td valign='top' class='bodyText'>" + itemElement.GetAttribute("name"));

          //check for domain nodes in the item's CUSTOMXML 
          XmlNodeList domainNodes = itemElement.SelectNodes("./CUSTOMXML/*/domain");
          foreach (XmlNode domainNode in domainNodes)
          {
            //concatenating to string that holds email text.
            itemTextBuilder.Append("<br />" + domainNode.Attributes["sld"].Value + "." +
                                   domainNode.Attributes["tld"].Value);
            XmlAttribute intlDomainNameAttrib = domainNode.Attributes["intlDomainName"];
            string intlDomainName = null;
            if (intlDomainNameAttrib != null)
            {
              intlDomainName = intlDomainNameAttrib.Value;
            }
            if (!string.IsNullOrEmpty(intlDomainName))
            {
              string intlSld, intlTld;
              BasketHelpers.GetDomainParts(intlDomainName, out intlSld, out intlTld);

              itemTextBuilder.Append("<br />(" + HttpUtility.HtmlEncode(intlSld) + "." +
                                     domainNode.Attributes["tld"].Value + ")");
            }
          }

          //use the domain attribute if the customxml was not used.
          if (domainNodes.Count == 0 && !string.IsNullOrEmpty(itemElement.GetAttribute("domain")))
          {
            itemTextBuilder.Append("<br />" + itemElement.GetAttribute("domain"));
          }

          itemTextBuilder.Append("</td>");

          int itemPrice = 0;
          int.TryParse(itemElement.GetAttribute("_oadjust_adjustedprice"), out itemPrice);

          itemTextBuilder.Append("    <td align='right' valign='top' class='bodyText'>" +
                                 _currency.PriceText(new CurrencyPrice(itemPrice, _currency.SelectedTransactionalCurrencyInfo, CurrencyPriceType.Transactional), false, CurrencyNegativeFormat.Parentheses) + "</td>");
          itemTextBuilder.Append("  </tr>");
        }
      }

      itemTextBuilder.Append("  <tr>");
      itemTextBuilder.Append("    <td colspan='3' align='right' class='bodyText'><hr></td>");
      itemTextBuilder.Append("  </tr>");
      itemTextBuilder.Append("  <tr>");
      itemTextBuilder.Append("    <td colspan='2' align='right' valign='top' class='bodyText'>Subtotal:</td>");
      itemTextBuilder.Append("    <td align='right' valign='top' class='bodyText'>" + _currency.PriceText(_orderData.SubTotal,false, CurrencyNegativeFormat.Parentheses) + "</td>");
      itemTextBuilder.Append("  </tr>");
      itemTextBuilder.Append("  <tr>");
      itemTextBuilder.Append("    <td colspan='2' align='right' valign='top' class='bodyText'>Shipping & Handling:</td>");
      itemTextBuilder.Append("    <td align='right' valign='top' class='bodyText'>" + _currency.PriceText(_orderData.TotalShipping, false) + "</td>");
      itemTextBuilder.Append("  </tr>");
      itemTextBuilder.Append("  <tr>");
      itemTextBuilder.Append("    <td colspan='2' align='right' valign='top' class='bodyText'>Tax:</td>");
      itemTextBuilder.Append("    <td align='right' valign='top' class='bodyText'>" + _currency.PriceText(_orderData.TotalTax, false) + "</td>");
      itemTextBuilder.Append("  </tr>");
      itemTextBuilder.Append("  <tr>");
      itemTextBuilder.Append("    <td colspan='2' align='right' valign='top' class='bodyText'>Total:</td>");
      itemTextBuilder.Append("    <td align='right' valign='top' class='bodyText'>" + _currency.PriceText(_orderData.TotalTotal,false, CurrencyNegativeFormat.Parentheses) + "</td>");
      itemTextBuilder.Append("  </tr>");
      itemTextBuilder.Append("</table>");
    }
    #endregion

    #region ItemText Functions - Private Label
    public void BuildItemsText_PL_PlainText(StringBuilder itemsTextBuilder, bool debug)
    {
      itemsTextBuilder.AppendLine(
          PadStringForColumn("QTY", PlainTextPadding.QTY_COL_WIDTH, HorizontalAlign.Center)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn("ITEM", PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Center)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + string.Empty.PadLeft(PlainTextPadding.DOLLAR_COL_WIDTH)
        + PadStringForColumn("PRICE", PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Center)
        );
      if (debug) itemsTextBuilder.Append("<br/>");
      itemsTextBuilder.AppendLine(string.Empty.PadLeft(PlainTextPadding.TOT_COLS_WIDTH, '-') + " ");
      if (debug) itemsTextBuilder.Append("<br/>");


      XmlNodeList itemNodes = _orderData.OrderXmlDoc.SelectNodes("/ORDER/ITEMS/ITEM");
      foreach (XmlElement itemElement in itemNodes)
      {
        int itemPrice = 0;
        int.TryParse(itemElement.GetAttribute("_oadjust_adjustedprice"), out itemPrice);

        itemsTextBuilder.AppendLine(
          PadStringForColumn(itemElement.GetAttribute("quantity"), PlainTextPadding.QTY_COL_WIDTH, HorizontalAlign.Center)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(itemElement.GetAttribute("name"), PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Center)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(new CurrencyPrice(itemPrice, _currency.SelectedTransactionalCurrencyInfo, CurrencyPriceType.Transactional), false, CurrencyNegativeFormat.Parentheses), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Center)
        );

        if (debug) itemsTextBuilder.Append("<br/>");

        //check for domain nodes in the item's CUSTOMXML 
        XmlNodeList domainNodes = itemElement.SelectNodes("./CUSTOMXML/*/domain");
        foreach (XmlNode domainNode in domainNodes)
        {
          //concatenating to string that holds email text.
          itemsTextBuilder.AppendLine(
              string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH)
            + domainNode.Attributes["sld"].Value + "." + domainNode.Attributes["tld"].Value);
          if (debug) itemsTextBuilder.Append("<br/>");
        }

        //use the domain attribute if the customxml was not used.
        if (domainNodes.Count == 0 && !string.IsNullOrEmpty(itemElement.GetAttribute("domain")))
        {
          itemsTextBuilder.AppendLine(
            string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH)
          + itemElement.GetAttribute("domain"));
          if (debug) itemsTextBuilder.Append("<br/>");
        }
      }

      itemsTextBuilder.AppendLine(string.Empty.PadLeft(PlainTextPadding.TOT_COLS_WIDTH, '-') + " ");
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Subtotal:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.SubTotal,false, CurrencyNegativeFormat.Parentheses), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Shipping & Handling:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.TotalShipping, false), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Tax:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.TotalTax, false), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Total:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.TotalTotal,false, CurrencyNegativeFormat.Parentheses), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");
    }

    public void BuildItemsText_PL_Html(StringBuilder itemTextBuilder)
    {
      itemTextBuilder.Append("<table width='270' cellspacing='0' cellpadding='0' border='0'><tr><td align='left' class='bodyText'><u>QTY</u></td>");
      itemTextBuilder.Append("<td align='center' class='bodyText'><u>ITEM</u></td>");
      itemTextBuilder.Append("<td align='right' class='bodyText'><u>PRICE</u></td></tr></table>");

      XmlNodeList itemNodes = _orderData.OrderXmlDoc.SelectNodes("/ORDER/ITEMS/ITEM");
      foreach (XmlElement itemElement in itemNodes)
      {
        string isDisplayedInCart = itemElement.GetAttribute("isdisplayedincart");
        bool shouldDisplay = isDisplayedInCart != "0";
        if (shouldDisplay)
        {
          int itemPrice = 0;
          int.TryParse(itemElement.GetAttribute("_oadjust_adjustedprice"), out itemPrice);

          itemTextBuilder.Append(
            "<table width='270' cellspacing='2' cellpadding='2' border='0'><tr><td align='left' class='bodyText'>" +
            itemElement.GetAttribute("quantity") + "</td>");
          itemTextBuilder.Append("<td align='center' class='bodyText'>" + itemElement.GetAttribute("name") + "</td>");
          itemTextBuilder.Append("<td align='right' class='bodyText'>" +
                                 _currency.PriceText(new CurrencyPrice(itemPrice, _currency.SelectedTransactionalCurrencyInfo, CurrencyPriceType.Transactional), false, CurrencyNegativeFormat.Parentheses) +
                                 "</td></tr></table>");

          //check for domain nodes in the item's CUSTOMXML 
          XmlNodeList domainNodes = itemElement.SelectNodes("./CUSTOMXML/*/domain");
          foreach (XmlNode domainNode in domainNodes)
          {
            //concatenating to string that holds email text.
            itemTextBuilder.Append(
              "<table width='270' cellspacing='0' cellpadding='0' border='0'><tr><td class='bodyText' colspan='3' align='center'>" +
              domainNode.Attributes["sld"].Value + "." + domainNode.Attributes["tld"].Value);
            XmlAttribute intlDomainNameAttrib = domainNode.Attributes["intlDomainName"];
            string intlDomainName = null;
            if (intlDomainNameAttrib != null)
            {
              intlDomainName = intlDomainNameAttrib.Value;
            }
            if (!string.IsNullOrEmpty(intlDomainName))
            {
              string intlSld, intlTld;
              BasketHelpers.GetDomainParts(intlDomainName, out intlSld, out intlTld);

              itemTextBuilder.Append("<br />(" + HttpUtility.HtmlEncode(intlSld) + "." +
                                     domainNode.Attributes["tld"].Value + ")");
            }
            itemTextBuilder.Append("</td></tr></table>");
          }

          //use the domain attribute if the customxml was not used.
          if (domainNodes.Count == 0 && !string.IsNullOrEmpty(itemElement.GetAttribute("domain")))
          {
            itemTextBuilder.Append(
              "<table width='270' cellspacing='0' cellpadding='0' border='0'><tr><td class='bodyText' colspan='3' align='center'>" +
              itemElement.GetAttribute("domain"));
            itemTextBuilder.Append("</td></tr></table>");
          }
        }
      }
      itemTextBuilder.Append("<table width='270' cellspacing='0' cellpadding='0' border='0'><tr><td colspan='3' align='center' class='bodyText'><hr></td></tr>");
      itemTextBuilder.Append("<tr><td colspan='3' align='right' class='bodyText'>Subtotal:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.SubTotal,false, CurrencyNegativeFormat.Parentheses) + "</td></tr>");
      itemTextBuilder.Append("<tr><td colspan='3' align='right' class='bodyText'>Shipping & Handling:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.TotalShipping, false) + "</td></tr>");
      itemTextBuilder.Append("<tr><td colspan='3' align='right' class='bodyText'>Tax:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.TotalTax, false) + "</td></tr>");
      itemTextBuilder.Append("<tr><td colspan='3' align='right' class='bodyText'>Total:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.TotalTotal,false, CurrencyNegativeFormat.Parentheses) + "</td></tr>");
      itemTextBuilder.Append("</table>");
    }
    #endregion

    #region ItemText Functions - Godaddy
    public void BuildItemsText_GD_PlainText(StringBuilder itemsTextBuilder, bool debug)
    {
      itemsTextBuilder.AppendLine(
          PadStringForColumn("QTY", PlainTextPadding.QTY_COL_WIDTH, HorizontalAlign.Center)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn("ITEM", PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Center)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + string.Empty.PadLeft(PlainTextPadding.DOLLAR_COL_WIDTH)
        + PadStringForColumn("PRICE", PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Center)
        );

      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(string.Empty.PadLeft(PlainTextPadding.TOT_COLS_WIDTH, '-'));

      if (debug) itemsTextBuilder.Append("<br/>");

      XmlNodeList itemNodes = _orderData.OrderXmlDoc.SelectNodes("/ORDER/ITEMS/ITEM");
      foreach (XmlElement itemElement in itemNodes)
      {
        string periodDescription = GetItemPeriodDuration(itemElement);
        string itemPrice = GetItemPrice(itemElement);
        string nameWithPeriodDescription = itemElement.GetAttribute("name");

        if (!string.IsNullOrEmpty(periodDescription))
          nameWithPeriodDescription += (", " + periodDescription);

        itemsTextBuilder.AppendLine(
          PadStringForColumn(itemElement.GetAttribute("quantity"), PlainTextPadding.QTY_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(nameWithPeriodDescription, nameWithPeriodDescription.Length, HorizontalAlign.Left)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(itemPrice, PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right)
        );
        if (debug) itemsTextBuilder.Append("<br/>");

        //check for domain nodes in the item's CUSTOMXML 
        XmlNodeList domainNodes = itemElement.SelectNodes("./CUSTOMXML/*/domain");
        foreach (XmlNode domainNode in domainNodes)
        {
          //concatenating to string that holds email text.
          itemsTextBuilder.AppendLine(
              string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH)
            + domainNode.Attributes["sld"].Value + "." + domainNode.Attributes["tld"].Value);
          if (debug) itemsTextBuilder.Append("<br/>");
        }

        if (_orderData.Detail.GetAttribute("basket_type") == "marketplace")
        {
          string merchantShopId = itemElement.GetAttribute("mp_shop_id");
          MerchantInfo merchantInfo = new MerchantInfo(merchantShopId);

          itemsTextBuilder.AppendLine(Environment.NewLine + merchantInfo.MarketPlaceName + Environment.NewLine);
          if (debug) itemsTextBuilder.Append("<br/>");
          itemsTextBuilder.AppendLine("Phone: " + merchantInfo.SupportPhone + Environment.NewLine);
          if (debug) itemsTextBuilder.Append("<br/>");
          itemsTextBuilder.AppendLine(merchantInfo.SupportEmailAddress + Environment.NewLine);
          if (debug) itemsTextBuilder.Append("<br/>");
        }

        //use the domain attribute if the customxml was not used.
        if (domainNodes.Count == 0 && !string.IsNullOrEmpty(itemElement.GetAttribute("domain")))
        {
          itemsTextBuilder.AppendLine(
            string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH)
          + itemElement.GetAttribute("domain"));
          if (debug) itemsTextBuilder.Append("<br/>");
        }
      }

      itemsTextBuilder.AppendLine(string.Empty.PadLeft(PlainTextPadding.TOT_COLS_WIDTH, '-') + " ");
      if (debug) itemsTextBuilder.Append("<br/>");

      if (_orderData.OrderDiscountAmount.Price != 0)
      {
        itemsTextBuilder.AppendLine(PadStringForColumn("Special Savings:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
          + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
          + PadStringForColumn(_currency.PriceText(_orderData.OrderDiscountAmount, false), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
        if (debug) itemsTextBuilder.Append("<br/>");
      }

      itemsTextBuilder.AppendLine(PadStringForColumn("Subtotal:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.SubTotal,false, CurrencyNegativeFormat.Parentheses), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Shipping & Handling:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.TotalShipping, false), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Tax:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.TotalTax, false), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");

      itemsTextBuilder.AppendLine(PadStringForColumn("Total:", PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.QTY_COL_WIDTH + PlainTextPadding.NAME_COL_WIDTH, HorizontalAlign.Right)
        + string.Empty.PadLeft(PlainTextPadding.SPACER_COL_WIDTH)
        + PadStringForColumn(_currency.PriceText(_orderData.TotalTotal,false, CurrencyNegativeFormat.Parentheses), PlainTextPadding.PRICE_COL_WIDTH, HorizontalAlign.Right));
      if (debug) itemsTextBuilder.Append("<br/>");
    }

    public void BuildItemsText_GD_Html(StringBuilder itemsTextBuilder)
    {
      itemsTextBuilder.Append("<table width='300' cellspacing='0' cellpadding='0' border='0'><tr><td align='left' class='bodyText'><u>QTY</u></td>");
      itemsTextBuilder.Append("<td align='center' class='bodyText'><u>ITEM</u></td>");
      itemsTextBuilder.Append("<td align='right' class='bodyText' style='padding-right:4px'><u>PRICE</u></td></tr></table>");

      XmlNodeList itemNodes = _orderData.OrderXmlDoc.SelectNodes("/ORDER/ITEMS/ITEM");
      foreach (XmlElement itemElement in itemNodes)
      {
        string periodDescription = GetItemPeriodDuration(itemElement);
        string itemPrice = GetItemPrice(itemElement);

        //if (periodDescription.Length > 0) itemsTextBuilder.Append("<br/>" + periodDescription);

        itemsTextBuilder.Append("<table width='300' cellspacing='2' cellpadding='2' border='0'><tr><td valign='top' align='left' class='bodyText' width='14px'>" + itemElement.GetAttribute("quantity") + "</td>");
        itemsTextBuilder.Append("<td valign='top' align='left' class='bodyText' style='padding-left:12px'>" + itemElement.GetAttribute("name").HtmlWrapWithOutBreakingAnyWords(30) + "<br/>" + periodDescription + "</td>");
        itemsTextBuilder.Append("<td valign='top' align='right' class='bodyText'>" + itemPrice + "</td></tr></table>");

        //check for domain nodes in the item's CUSTOMXML 
        XmlNodeList domainNodes = itemElement.SelectNodes("./CUSTOMXML/*/domain");
        foreach (XmlNode domainNode in domainNodes)
        {
          itemsTextBuilder.Append("<table width='300' cellspacing='0' cellpadding='0' border='0'><tr><td class='bodyText' colspan='3' align='left' style='padding-left:26px'>" + domainNode.Attributes["sld"].Value + "." + domainNode.Attributes["tld"].Value);
          XmlAttribute intlDomainNameAttrib = domainNode.Attributes["intlDomainName"];
          string intlDomainName = null;
          if (intlDomainNameAttrib != null)
          {
            intlDomainName = intlDomainNameAttrib.Value;
          }
          if (!string.IsNullOrEmpty(intlDomainName))
          {
            string intlSld, intlTld;
            BasketHelpers.GetDomainParts(intlDomainName, out intlSld, out intlTld);
            itemsTextBuilder.Append("<br />(" + HttpUtility.HtmlEncode(intlSld + "." + domainNode.Attributes["tld"].Value + ")"));

          }
          itemsTextBuilder.Append("</td></tr></table>");
        }

        if (_orderData.Detail.GetAttribute("basket_type") == "marketplace")
        {
          string merchantShopId = itemElement.GetAttribute("mp_shop_id");
          MerchantInfo merchantInfo = new MerchantInfo(merchantShopId);

          itemsTextBuilder.AppendLine("<table width='300' cellspacing='0' cellpadding='0' border='0'><tr><td class='bodyText' colspan='3' align='left' style='padding-left:26px'>");
          itemsTextBuilder.AppendLine(merchantInfo.MarketPlaceName);
          itemsTextBuilder.AppendLine("<br />Phone: " + merchantInfo.SupportPhone);
          itemsTextBuilder.AppendLine("<br />" + merchantInfo.SupportEmailAddress);
          itemsTextBuilder.AppendLine("</td></tr></table>");
        }

        itemsTextBuilder.AppendLine("<table cellpadding=0 cellspacing=0 border=0><tr><td style='line-height:4px'>&nbsp;</td></tr></table>");

        //use the domain attribute if the customxml was not used.
        if (domainNodes.Count == 0 && !string.IsNullOrEmpty(itemElement.GetAttribute("domain")))
        {
          itemsTextBuilder.AppendLine("<table width='300' cellspacing='0' cellpadding='0' border='0'><tr><td class='bodyText' colspan='3' align='center'>" + itemElement.GetAttribute("domain") + "</td></tr></table>");
        }
      }

      itemsTextBuilder.AppendLine("<table width='300' cellspacing='0' cellpadding='0' border='0'><tr><td colspan='3' align='center' class='bodyText'><hr></td></tr>");
      if (_orderData.OrderDiscountAmount.Price != 0)
      {
        itemsTextBuilder.AppendLine("<tr><td colspan='3' align='right' class='bodyText'>Special Savings:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.OrderDiscountAmount, false) + "</td></tr>");
      }
      itemsTextBuilder.AppendLine("<tr><td colspan='3' align='right' class='bodyText'>Subtotal:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.SubTotal,false, CurrencyNegativeFormat.Parentheses) + "</td></tr>");
      itemsTextBuilder.AppendLine("<tr><td colspan='3' align='right' class='bodyText'>Shipping & Handling:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.TotalShipping, false) + "</td></tr>");
      itemsTextBuilder.AppendLine("<tr><td colspan='3' align='right' class='bodyText'>Tax:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.TotalTax, false) + "</td></tr>");
      itemsTextBuilder.AppendLine("<tr><td colspan='3' align='right' class='bodyText'>Total:&nbsp;&nbsp;&nbsp;" + _currency.PriceText(_orderData.TotalTotal,false, CurrencyNegativeFormat.Parentheses) + "</td></tr>");
      itemsTextBuilder.AppendLine("</table>");
    }

    public string GetItemPeriodDuration(XmlElement item)
    {
      string returnValue = string.Empty;

      string duration = item.GetAttribute("duration");
      string origDescription = item.GetAttribute("period_description");

      if (!string.IsNullOrEmpty(duration) && string.IsNullOrEmpty(item.GetAttribute("parent_bundle_id")))
      {
        string description = null;
        if (string.IsNullOrEmpty(origDescription))
        {
          if (item.GetAttribute("recurring_payment") == "monthly")
          {
            description = "month(s)";
          }
          else
          {
            if (item.GetAttribute("recurring_payment") == "annual")
            {
              description = "year(s)";
            }
          }
          if (!string.IsNullOrEmpty(description))
          {
            returnValue = string.Format("Length: {0} {1}", duration, description);
          }
        }
        else
        {
          returnValue = string.Format("Length: {0} {1}", duration, origDescription);
        }
      }

      return returnValue;
    }

    public string GetItemPrice(XmlElement item)
    {
      string adjustedOrderPrice = item.GetAttribute("_oadjust_adjustedprice");

      if ((adjustedOrderPrice != null) && string.IsNullOrEmpty(item.GetAttribute("parent_bundle_id")))
      {
        int itemPrice;
        int.TryParse(adjustedOrderPrice, out itemPrice);
        return _currency.PriceText(new CurrencyPrice(itemPrice, _currency.SelectedTransactionalCurrencyInfo, CurrencyPriceType.Transactional), false, CurrencyNegativeFormat.Parentheses);
      }
      else
        return string.Empty;
    }

    #endregion

    #region ItemsText Functions - Plain Text related
    public string PadStringForColumn(string text, int colWidth, HorizontalAlign justification)
    {
      string paddedString;

      if (text.Length > colWidth)
      {
        paddedString = text.Substring(0, colWidth);
      }
      else
      {
        if (text.Length == colWidth)
        {
          paddedString = text;
        }
        else
        {
          int paddingSize = colWidth - text.Length;
          switch (justification)
          {
            case HorizontalAlign.Center:
              int reminder = (paddingSize % 2);
              if (reminder == 0) //even
              {
                paddedString = text.PadLeft(reminder + text.Length);
                paddedString = paddedString.PadRight(reminder + paddedString.Length);
              }
              else //odd
              {
                paddedString = text.PadLeft(reminder + 1 + text.Length);
                paddedString = paddedString.PadRight(reminder + paddedString.Length);
              }
              break;
            case HorizontalAlign.Right:
              paddedString = text.PadRight(paddingSize + text.Length);
              break;
            case HorizontalAlign.Left:
            default:
              paddedString = text.PadLeft(paddingSize + text.Length);
              break;
          }
        }
      }

      return paddedString;
    }
    public static class PlainTextPadding
    {
      public const int SPACER_COL_WIDTH = 2;
      public const int QTY_COL_WIDTH = 4;
      public const int NAME_COL_WIDTH = 42;
      public const int DOLLAR_COL_WIDTH = 1;
      public const int PRICE_COL_WIDTH = 11;
      public const int TOT_COLS_WIDTH = 62;
    }
    #endregion

    #region EULA Text Functions

    public void BuildEULAText(Dictionary<EULARuleType, bool> eulaDictionary, StringBuilder itemsTextBuilder, bool debug, string iscCode)
    {
      if (eulaDictionary.Count > 0)
      {
        itemsTextBuilder.AppendLine(Environment.NewLine + Environment.NewLine + "Important Information concerning your purchase:");
        if (debug) itemsTextBuilder.Append("<br/>");

        EULAData eulaDataProvider = new EULAData(_orderData, _departmentIds, _links);
        if (eulaDictionary.ContainsKey(EULARuleType.GiftCard))
        {
          EULAItem eulaData = eulaDataProvider.GetEULAData(EULARuleType.GiftCard, iscCode);
          if (eulaData != null)
          {
            itemsTextBuilder.Append("Your gift card will be emailed to the address you provided. ");
            itemsTextBuilder.Append("If the recipient has not received their gift card within 24 hours, please call customer service at 480-505-8877.  For more information on GoDaddy&#174; Gift Cards, select the Product Info link, below.");
          }
        }
        foreach (EULARuleType eulaRuleKey in eulaDictionary.Keys)
        {
          EULAItem eulaData = eulaDataProvider.GetEULAData(eulaRuleKey, iscCode);
          if (eulaData != null)
          {
            string productName = eulaData.ProductName;
            string productInfoURL = eulaData.ProductInfoURL;
            string legalInfoURL = eulaData.LegalAgreementURL;

            if (!string.IsNullOrEmpty(productName))
            {
              itemsTextBuilder.AppendLine(Environment.NewLine + productName + " ");
            }
            if (!string.IsNullOrEmpty(productInfoURL))
            {
              itemsTextBuilder.AppendLine("Product Info: " + productInfoURL);
            }
            if (!string.IsNullOrEmpty(legalInfoURL))
            {
              itemsTextBuilder.AppendLine(GetAgreementTypeText(eulaData.AgreementType) + ": " + legalInfoURL);
            }
            if (debug) itemsTextBuilder.Append("<br/><br/>");
          }
        }
      }
    }

    public void BuildEULAHTML(Dictionary<EULARuleType, bool> eulaDictionary, StringBuilder itemsTextBuilder, string hostingConcierge, string iscCode)
    {
      if (eulaDictionary.Count > 0)
      {
        EULAData eulaDataProvider = new EULAData(_orderData, _departmentIds, _links);
        
        itemsTextBuilder.Append("<br /><br /><table width='370' cellspacing='1' cellpadding='0' border='0' class='bodyText' bgcolor='#EEEEEE' ");
        itemsTextBuilder.Append("style=\"font-size: 12px; color: black; font-family: arial,sans serif;\">");
        itemsTextBuilder.Append("<tr><td colspan='3' style='line-height:5px'>&nbsp;</td></tr>");
        itemsTextBuilder.Append("<tr><td colspan='3' class='bodyText'><b>Important Information concerning your purchase:</b></td></tr>");
        if (eulaDictionary.ContainsKey(EULARuleType.GiftCard))
        {
          EULAItem eulaData = eulaDataProvider.GetEULAData(EULARuleType.GiftCard, iscCode);
          if (eulaData != null)
          {
            itemsTextBuilder.Append("<tr><td colspan='3' class='bodyText'>");
            itemsTextBuilder.Append("Your gift card will be emailed to the address you provided. ");
            itemsTextBuilder.Append("If the recipient has not received their gift card within 24 hours, please call customer service at 480-505-8877.  For more information on GoDaddy&#174; Gift Cards, select the Product Info link, below.");
            itemsTextBuilder.Append("</td></tr>");
          }
        }
        itemsTextBuilder.Append("<tr><td style='line-height:5px'>&nbsp;</td></tr>");


        bool hostingConciergeHasShown = false;
        foreach (EULARuleType eulaRuleKey in eulaDictionary.Keys)
        {
          EULAItem eulaData = eulaDataProvider.GetEULAData(eulaRuleKey, iscCode);
          if (eulaData != null)
          {
            string productName = eulaData.ProductName;
            string productInfoURL = eulaData.ProductInfoURL;
            string legalInfoURL = eulaData.LegalAgreementURL;

            itemsTextBuilder.Append("<tr>");
            if (!string.IsNullOrEmpty(productName))
            {
              itemsTextBuilder.AppendFormat("<td width=130px class='bodyText' style='padding-left:3px'>{0} </td>", productName);
            }
            if (!string.IsNullOrEmpty(productInfoURL))
            {
              itemsTextBuilder.AppendFormat("<td width=100px class='bodyText'><a href='{0}'>Product Info</a></td>", productInfoURL);
            }
            if (!string.IsNullOrEmpty(legalInfoURL))
            {
              itemsTextBuilder.AppendFormat("<td class='bodyText'><a href='{0}'>{1}</a></td>", legalInfoURL, GetAgreementTypeText(eulaData.AgreementType));
            }
            itemsTextBuilder.Append("</tr>");

            if (!String.IsNullOrEmpty(hostingConcierge) && !hostingConciergeHasShown)
            {
                switch (eulaRuleKey)
                {
                    case EULARuleType.Hosting:
                    case EULARuleType.DedHosting:
                    case EULARuleType.DedVirtHosting:
                        {
                            hostingConciergeHasShown = true;
                            itemsTextBuilder.Append("<tr><td colspan='3' class='bodyText' style='padding-left:3px'>");
                            itemsTextBuilder.Append(hostingConcierge);
                            itemsTextBuilder.Append("</td></tr>");
                        }
                        break;
                }
            }
            itemsTextBuilder.Append("<tr><td style='line-height:5px'>&nbsp;</td></tr>");

          }
        }

        itemsTextBuilder.Append("</table>");
      }
    }

    private string GetAgreementTypeText(EULAType agreementType)
    {
      string text = string.Empty;
      switch (agreementType)
      {
        case EULAType.Legal:
          text = "Legal Agreement";
          break;
        case EULAType.Service:
          text = "Service Agreement";
          break;
        case EULAType.Membership:
          text = "Membership Agreement";
          break;
      }
      return text;
    }
    #endregion

    #region CrossSell Items Functions
    public void BuildCrossSellText(List<CrossSellConfigProductId> crossSellProductIdList, StringBuilder itemsTextBuilder, int ciCode, bool debug, string iscCode)
    {
      CrossSellData xsellProductProvider = new CrossSellData(_orderData, _links, _currency, _products, ciCode);
      int index = 0;

      foreach (CrossSellConfigProductId productId in crossSellProductIdList)
      {
        CrossSellProduct product = xsellProductProvider.GetCrossSellProduct(productId, iscCode);
        if (product != null)
        {
          if (++index > 1)
          {
            itemsTextBuilder.AppendLine("==============================================================");
          }

          if (!string.IsNullOrEmpty(product.ProductName))
          {
            itemsTextBuilder.AppendLine(product.ProductName.ToUpper());
          }
          if (!string.IsNullOrEmpty(product.PriceText))
          {
            itemsTextBuilder.Append(product.PriceText);
          }
          if (product.Id == CrossSellConfigProductId.TRAFFICB || product.Id == CrossSellConfigProductId.HOSTING || product.Id == CrossSellConfigProductId.CART)
          {
            if (!string.IsNullOrEmpty(product.SavingsText))
            {
              itemsTextBuilder.Append(" " + product.SavingsText);
            }
            if (!string.IsNullOrEmpty(product.ProductDescription))
            {
              itemsTextBuilder.Append(" " + product.ProductDescription);
            }
          }
          else
          {
            if (!string.IsNullOrEmpty(product.ProductDescription))
            {
              itemsTextBuilder.Append(" " + product.ProductDescription);
            }
            if (!string.IsNullOrEmpty(product.SavingsText))
            {
              itemsTextBuilder.Append(" " + product.SavingsText);
            }
          }
          if (!string.IsNullOrEmpty(product.ProductUrl))
          {
            itemsTextBuilder.AppendLine();
            itemsTextBuilder.AppendLine("Go to: " + product.ProductUrl);
          }

          if (debug) itemsTextBuilder.Append("<br/><br/>");
        }
      }
    }
    public void BuildCrossSellHTML(List<CrossSellConfigProductId> crossSellProductIdList, StringBuilder itemsTextBuilder, int ciCode, string iscCode)
    {
      bool tableAdded = false;
      CrossSellData xsellProductProvider = new CrossSellData(_orderData, _links, _currency, _products, ciCode);
      int index = 0;
      foreach (CrossSellConfigProductId productId in crossSellProductIdList)
      {
        CrossSellProduct product = xsellProductProvider.GetCrossSellProduct(productId, iscCode);
        if (product != null && (!string.IsNullOrEmpty(product.ProductName) 
            || !string.IsNullOrEmpty(product.ProductDescription)))
        {
            if (!tableAdded)
            {
                tableAdded = true;
                itemsTextBuilder.Append("<table border=\"0\" cellpadding=\"1\" cellspacing=\"0\" " +
                     "style=\"border: 1px solid #999999\" bgcolor=\"#FDFFDA\" width=\"100%\">");
            }
      
          if (++index > 1)
          {
            itemsTextBuilder.AppendLine("<tr><td style=\"padding:6px\"><hr size=\"1\"></td></tr>");
          }
          itemsTextBuilder.Append("<tr><td style=\"padding:6px;font-size:10px;line-height:14px;font-family:verdana, sans serif\">");
          if (!string.IsNullOrEmpty(product.ProductUrl) && !string.IsNullOrEmpty(product.ProductName))
          {
            itemsTextBuilder.AppendFormat("<a href=\"{0}\">{1}</a>", product.ProductUrl, product.ProductName);
          }
          if (!string.IsNullOrEmpty(product.PriceText))
          {
            itemsTextBuilder.AppendFormat(" - <span style=\"color:#CC0000;\">{0}</span>", product.PriceText);
          }
          if (product.Id == CrossSellConfigProductId.TRAFFICB || product.Id == CrossSellConfigProductId.HOSTING || product.Id == CrossSellConfigProductId.CART)
          {
            if (!string.IsNullOrEmpty(product.SavingsText))
            {
              itemsTextBuilder.AppendFormat(" <span style=\"color:#CC0000;\">{0}</span>", product.SavingsText);
            }
            if (!string.IsNullOrEmpty(product.ProductDescription))
            {
              itemsTextBuilder.Append(" " + product.ProductDescription);
            }
          }
          else
          {
            if (!string.IsNullOrEmpty(product.ProductDescription))
            {
              itemsTextBuilder.Append(" " + product.ProductDescription);
            }
            if (!string.IsNullOrEmpty(product.SavingsText))
            {
              itemsTextBuilder.AppendFormat(" <span style=\"color:#CC0000;\">{0}</span>", product.SavingsText);
            }
          }

          itemsTextBuilder.AppendLine("</td></tr>");
        }
      }

      if (tableAdded)
      {
        itemsTextBuilder.AppendLine("</table>");
      }
    }
    #endregion
  }
}
