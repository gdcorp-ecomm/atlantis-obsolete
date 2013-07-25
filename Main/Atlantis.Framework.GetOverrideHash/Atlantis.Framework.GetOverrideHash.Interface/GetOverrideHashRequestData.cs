using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetOverrideHash.Interface
{
  public class GetOverrideHashRequestData : RequestData
  {
    // **************************************************************** //

    int m_iUnifiedPFID;
    int m_iPrivateLabelID;
    int m_iOverrideListPrice;
    int m_iOverrideCurrentPrice;
    int m_iOverrideCurrentCost;
    int m_iOverridePriceTypeId;
    bool m_bGetCostHash;
    bool m_priceTypeHash = false;

    // **************************************************************** //

    public GetOverrideHashRequestData(string sShopperID,
                                      string sSourceURL,
                                      string sOrderID,
                                      string sPathway,
                                      int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = 0;
      m_iPrivateLabelID = 0;
      m_iOverrideCurrentPrice = 0;
      m_iOverrideCurrentCost = 0;
      m_bGetCostHash = false;
    }

    // **************************************************************** //

    public GetOverrideHashRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  int iUnifiedPFID,
                                  int iPrivateLabelID,
                                  int iOverrideListPrice,
                                  int iOverrideCurrentPrice)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = iUnifiedPFID;
      m_iPrivateLabelID = iPrivateLabelID;
      m_iOverrideListPrice = iOverrideListPrice;
      m_iOverrideCurrentPrice = iOverrideCurrentPrice;
      m_iOverrideCurrentCost = 0;
      m_bGetCostHash = false;
    }

    // **************************************************************** //

    public GetOverrideHashRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  int iUnifiedPFID,
                                  int iPrivateLabelID,
                                  int iOverrideListPrice,
                                  int iOverrideCurrentPrice,
                                  int iOverrideCurrentCost)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = iUnifiedPFID;
      m_iPrivateLabelID = iPrivateLabelID;
      m_iOverrideListPrice = iOverrideListPrice;
      m_iOverrideCurrentPrice = iOverrideCurrentPrice;
      m_iOverrideCurrentCost = iOverrideCurrentCost;
      m_bGetCostHash = true;
    }

    // **************************************************************** //

    public GetOverrideHashRequestData(string sShopperID,
                                  string sSourceURL,
                                  string sOrderID,
                                  string sPathway,
                                  int iPageCount,
                                  int iUnifiedPFID,
                                  int iPrivateLabelID,
                                  int ipriceTypeId)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = iUnifiedPFID;
      m_iPrivateLabelID = iPrivateLabelID;
      m_iOverridePriceTypeId = ipriceTypeId;
      m_bGetCostHash = false;
      m_priceTypeHash = true;
    }

    // **************************************************************** //

    public int UnifiedPFID
    {
      get { return m_iUnifiedPFID; }
      set { m_iUnifiedPFID = value; }
    }

    // **************************************************************** //

    public int PrivateLabelID
    {
      get { return m_iPrivateLabelID; }
      set { m_iPrivateLabelID = value; }
    }

    // **************************************************************** //

    public int OverrideListPrice
    {
      get { return m_iOverrideListPrice; }
      set { m_iOverrideListPrice = value; }
    }

    // **************************************************************** //

    public int OverrideCurrentPrice
    {
      get { return m_iOverrideCurrentPrice; }
      set { m_iOverrideCurrentPrice = value; }
    }

    // **************************************************************** //

    public int OverrideCurrentCost
    {
      get { return m_iOverrideCurrentCost; }
      set { m_iOverrideCurrentCost = value; }
    }

    // **************************************************************** //

    public int OverridePriceTypeId
    {
      get { return m_iOverridePriceTypeId; }
      set { m_iOverridePriceTypeId = value; }
    }

    // **************************************************************** //

    public bool GetCostHash
    {
      get { return m_bGetCostHash; }
    }

    public bool GetPriceTypeHash
    {
      get { return m_priceTypeHash; }
    }

    // **************************************************************** //

    #region RequestData Members

    // **************************************************************** //

    public override string GetCacheMD5()
    {
      throw new Exception("GetOverrideHash is not a cacheable request");
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
