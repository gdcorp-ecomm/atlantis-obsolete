using System;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MyaShopperDataUpdate.Interface
{
  public class MyaShopperDataUpdateResponseData : IResponseData
  {
    #region Members

    private AtlantisException _ex;

    #endregion

    #region Constructors

    public MyaShopperDataUpdateResponseData(bool successful)
    {
      Successful = successful;
    }

    public MyaShopperDataUpdateResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public MyaShopperDataUpdateResponseData(RequestData requestData, Exception ex)
    {
      _ex = new AtlantisException(requestData, "MyaShopperDataUpdateResponseData", ex.Message, requestData.ToXML());
    }

    #endregion

    #region Properties

    public bool Successful { get; set; }

    #endregion

    #region IResponseData Members

    public string ToXML()
    {
      throw new NotImplementedException();
    }

    public AtlantisException GetException()
    {
      return _ex;
    }

    #endregion
  }
}
