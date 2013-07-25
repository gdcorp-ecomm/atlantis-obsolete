﻿using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using System.Security.Cryptography;
using System.Xml;
using System.IO;

namespace Atlantis.Framework.GiftCardBalance.Interface
{
  public class GiftCardBalanceRequestData : RequestData
  {
    private string _acctNumber = string.Empty;


    public GiftCardBalanceRequestData(string sShopperID,
                  string sSourceURL,
                  string sOrderID,
                  string sPathway,
                  int iPageCount,
                  string acctNumber)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      _acctNumber = acctNumber;
    }

    public string AccountNumber
    {
      get { return _acctNumber; }
      set { _acctNumber = value; }
    }

    public override string ToXML()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));

      xtwRequest.WriteStartElement("INFO");
      xtwRequest.WriteAttributeString("ShopperID", ShopperID);
      xtwRequest.WriteAttributeString("SourceURL", SourceURL);
      xtwRequest.WriteAttributeString("OrderID", OrderID);
      xtwRequest.WriteAttributeString("Pathway", Pathway);
      xtwRequest.WriteAttributeString("PageCount", System.Convert.ToString(PageCount));
      xtwRequest.WriteAttributeString("AccountNumber", AccountNumber);
      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

    public override string GetCacheMD5()
    {
      throw new NotImplementedException();
    }
  }
}