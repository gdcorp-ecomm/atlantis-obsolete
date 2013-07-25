using System;

using Atlantis.Framework.Interface;

namespace Atlantis.Framework.GetDurationHash.Interface
{
  public class GetDurationHashRequestData : RequestData
  {
    // **************************************************************** //

    private int m_iUnifiedPFID;
    private int m_iPrivateLabelID;
    private double m_dDuration;

    // **************************************************************** //

    public GetDurationHashRequestData(string sShopperID,
                                      string sSourceURL,
                                      string sOrderID,
                                      string sPathway,
                                      int iPageCount)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = 0;
      m_iPrivateLabelID = 0;
      m_dDuration = 0;
    }

    // **************************************************************** //

    public GetDurationHashRequestData(string sShopperID,
                                      string sSourceURL,
                                      string sOrderID,
                                      string sPathway,
                                      int iPageCount,
                                      int iUnifiedPFID,
                                      int iPrivateLabelID,
                                      double dDuration)
      : base(sShopperID, sSourceURL, sOrderID, sPathway, iPageCount)
    {
      m_iUnifiedPFID = iUnifiedPFID;
      m_iPrivateLabelID = iPrivateLabelID;
      m_dDuration = dDuration;
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

    public double Duration
    {
      get { return m_dDuration; }
      set { m_dDuration = value; }
    }

    // **************************************************************** //

    #region RequestData Members

    // **************************************************************** //

    public override string GetCacheMD5()
    {
      throw new Exception("GetDurationHash is not a cacheable request.");
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //
  }
}
