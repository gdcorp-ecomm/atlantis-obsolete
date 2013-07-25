using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.IrisGetIncidentsByShopper.Interface;
using Atlantis.Framework.IrisGetIncidentsByShopper.Impl.IrisWS;

namespace Atlantis.Framework.IrisGetIncidentsByShopper.Impl
{
  public class IrisGetIncidentsByShopperRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IrisGetIncidentsByShopperResponseData oResponseData = null;

      try
      {
        IrisGetIncidentsByShopperRequestData request = (IrisGetIncidentsByShopperRequestData)oRequestData;
        IrisWS.IrisCommunityService service = new IrisCommunityService();

        service.Url = ((WsConfigElement)oConfig).WSURL;

        XmlNode incidentsNode = service.SearchIncidents(request.ToXML());

        XmlNode successNode = incidentsNode.SelectSingleNode("/Success");
        if (!bool.Parse(successNode.InnerXml))
        {
          AtlantisException ex = new AtlantisException(oRequestData, "IrisGetIncidentsByShopperRequest.RequestHandler", "WebService Error", incidentsNode.SelectSingleNode("/Message").Value);
          oResponseData = new IrisGetIncidentsByShopperResponseData(ex);
        }
        else
        {
          IEnumerable<IrisGetIncidentsByShopperResult> incidents = ParseResponseXML(incidentsNode);

          oResponseData = new IrisGetIncidentsByShopperResponseData(incidents);
        }
      }
      catch (Exception ex)
      {
        oResponseData = new IrisGetIncidentsByShopperResponseData(oRequestData, ex);
      }

      return oResponseData;
    }

    #endregion

    private IEnumerable<IrisGetIncidentsByShopperResult> ParseResponseXML(XmlNode incidentsNode)
    {
      List<IrisGetIncidentsByShopperResult> incidentList = new List<IrisGetIncidentsByShopperResult>();

      int incidentID;
      int statusID;
      string status;
      int currentTier;
      string summary;
      IncidentNote note;

      foreach (XmlNode incident in incidentsNode.SelectNodes("/Incident"))
      {
        int.TryParse(incident.Attributes["Id"].Value, out incidentID);
        int.TryParse(incident.Attributes["statusID"].Value, out statusID);
        status = incident.Attributes["Status"].Value;
        int.TryParse(incident.Attributes["CurrentTier"].Value, out currentTier);
        summary = incident.SelectSingleNode("Summary").InnerXml;
        note = GetNoteFromXML(incident.SelectSingleNode("Note"));

        incidentList.Add(new IrisGetIncidentsByShopperResult(incidentID, statusID, status, currentTier, summary, note));

      }

      return incidentList;
    }

    private IncidentNote GetNoteFromXML(XmlNode node)
    {
      int incidentNoteID;
      int noteTypeID;
      DateTime createDate;
      string createdBy;
      string modifyBy;
      string description;

      int.TryParse(node.Attributes["incidentNoteID"].Value, out incidentNoteID);
      int.TryParse(node.Attributes["noteTypeID"].Value, out noteTypeID);
      DateTime.TryParse(node.Attributes["createDate"].Value, out createDate);
      createdBy = node.Attributes["createdBy"].Value;
      modifyBy = node.Attributes["modifyBy"].Value;
      description = node.InnerXml;

      IncidentNote note = new IncidentNote(incidentNoteID, noteTypeID, createDate, createdBy, modifyBy, description);

      return note;
    }
  }
}
