using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.IrisGetIncidentsByShopper.Interface
{
  public class IrisGetIncidentsByShopperResponseData : IResponseData
  {

    public bool IsSuccess { get; private set; }
    private AtlantisException _ex;
    private List<IrisGetIncidentsByShopperResult> _wsGetIrisIncidentsByShopperLinks = new List<IrisGetIncidentsByShopperResult>();


    public int IncidentCount
    {
      get { return _wsGetIrisIncidentsByShopperLinks.Count; }
    }

    public IEnumerable<IrisGetIncidentsByShopperResult> Incidents
    {
      get { return _wsGetIrisIncidentsByShopperLinks; }
    }

    public IrisGetIncidentsByShopperResponseData(IEnumerable<IrisGetIncidentsByShopperResult> wsGetIrisIncidentsByShopperLinks)
    {
      if (wsGetIrisIncidentsByShopperLinks != null)
      {
        _wsGetIrisIncidentsByShopperLinks.AddRange(wsGetIrisIncidentsByShopperLinks);
      }

      IsSuccess = true;
    }

    public IrisGetIncidentsByShopperResponseData(AtlantisException ex)
    {
      _ex = ex;
    }

    public IrisGetIncidentsByShopperResponseData(RequestData oRequestData, Exception ex)
    {
      _ex = new AtlantisException(oRequestData, "IrisGetIncidentsByShopperResponseData", ex.Message, oRequestData.ToXML());
    }

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
