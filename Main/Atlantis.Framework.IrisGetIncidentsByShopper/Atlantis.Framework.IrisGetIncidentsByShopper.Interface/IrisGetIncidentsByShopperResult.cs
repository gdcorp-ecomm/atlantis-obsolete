using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.IrisGetIncidentsByShopper.Interface
{
  public class IrisGetIncidentsByShopperResult
  {
    public int IncidentID { get; private set; }
    public int StatusID { get; private set; }
    public string Status { get; private set; }
    public int CurrentTier { get; private set; }
    public string Summary { get; private set; }
    public IncidentNote Note { get; private set; }

    public IrisGetIncidentsByShopperResult(int incidentID, int statusID, string status, int currentTier, string summary, IncidentNote note)
    {
      IncidentID = incidentID;
      StatusID = statusID;
      Status = status;
      CurrentTier = currentTier;
      Summary = summary;
      Note = note;
    }
  }
}
