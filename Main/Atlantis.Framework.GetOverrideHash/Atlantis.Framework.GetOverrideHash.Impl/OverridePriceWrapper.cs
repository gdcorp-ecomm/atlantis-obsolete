using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Atlantis.Framework.GetOverrideHash.Impl
{
  class OverridePriceWrapper : IDisposable
  {
    // **************************************************************** //

    private gdOverrideLib.PriceClass m_price;
    private gdOverrideLib.PriceType  m_priceType;

    // **************************************************************** //

    public OverridePriceWrapper()
    {
      m_price = new gdOverrideLib.PriceClass();
    }

    public OverridePriceWrapper(string type)
    {
      m_priceType = new gdOverrideLib.PriceType();
    }

    // **************************************************************** //

    public gdOverrideLib.PriceClass Price
    {
      get { return m_price; }
    }

    public gdOverrideLib.PriceType PriceType
    {
      get { return m_priceType; }
    }

    // **************************************************************** //

    #region IDisposable Members

    // **************************************************************** //

    void IDisposable.Dispose()
    {
      if (m_price != null)
      {
        Marshal.ReleaseComObject(m_price);
        m_price = null;
      }
      if (m_priceType != null)
      {
        Marshal.ReleaseComObject(m_priceType);
        m_priceType = null;
      }
      GC.SuppressFinalize(this);
    }

    // **************************************************************** //

    #endregion

    // **************************************************************** //

    ~OverridePriceWrapper()
    {
      if (m_price != null)
      {
        Marshal.ReleaseComObject(m_price);
        m_price = null;
      }
      if (m_priceType != null)
      {
        Marshal.ReleaseComObject(m_priceType);
        m_priceType = null;
      }
    }

    // **************************************************************** //
  }
}
