using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.IrisGetIncidentsByShopper.Interface
{
  public class IncidentNote
  {
    public int IncidentNoteID { get; set; }
    public int NoteTypeID { get; set; }
    public DateTime CreateDate { get; set; }
    public string CreatedBy { get; set; }
    public string ModifyBy { get; set; }
    public string Description { get; set; }

    public IncidentNote(int incidentNoteID, int noteTypeID, DateTime createDate, string createdBy, string modifyBy, string description)
    {
      IncidentNoteID = incidentNoteID;
      NoteTypeID = noteTypeID;
      CreateDate = createDate;
      ModifyBy = modifyBy;
      Description = description;
    }
  }
}
