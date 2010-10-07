using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface;
using Atlantis.Framework.Entity.Interface.ADO;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.Impl
{
    public class AppPlacementLocationRequest : BaseRequest<AppPlacementLocation>
    {
        public override ICollection<AppPlacementLocation> Query()
        {
            // TODO: this is a hack, need to pick procs based on predicate expression bodies
            return this.ExecuteProcedure("dbo.AppPlacementLocationSelect_sp");
        }

        public override ICollection<AppPlacementLocation> Query(Func<AppPlacementLocation, bool> predicate)
        {
            // TODO: use more specific procedures
            // TODO: add way to inspect available procs and compare expression body values
            // with parameters to automatically pick a custom procedure
            return this.ExecuteProcedure("dbo.AppPlacementLocationSelect_sp", predicate);
        }

        public override AppPlacementLocation Single(Func<AppPlacementLocation, bool> predicate)
        {
            // TODO: use more specific procedure
            return this.Query().Single(predicate);
        }

        public override void Insert(ICollection<AppPlacementLocation> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var appPlacementLocation in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("PlacementID", appPlacementLocation.PlacementID)
                            .Add("ApplicationID", appPlacementLocation.ApplicationID)
                            .Add("Name", appPlacementLocation.Name, String.Empty)
                            .Add("Description", appPlacementLocation.LocationDescription, String.Empty)
                            .Add("DateAdded", appPlacementLocation.DateAdded, DateTime.Now)
                            .Add("DateUpdated", appPlacementLocation.DateUpdated, DateTime.Now)
                            .Add("ID", -1, ParameterDirection.Output);

                        appPlacementLocation.LocationID = (int)ado.ExecuteReturnOutput("dbo.AppPlacementLocationInsert_sp");
                    }
                }
            }
        }

        public override void Update(ICollection<AppPlacementLocation> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var appPlacementLocation in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("LocationID", appPlacementLocation.LocationID)
                            .Add("PlacementID", appPlacementLocation.PlacementID)
                            .Add("ApplicationID", appPlacementLocation.ApplicationID)
                            .Add("Name", appPlacementLocation.Name, String.Empty)
                            .Add("Description", appPlacementLocation.LocationDescription, String.Empty)
                            .Add("DateAdded", appPlacementLocation.DateAdded)
                            .Add("DateUpdated", appPlacementLocation.DateUpdated);

                        ado.Execute("dbo.AppPlacementLocationUpdate_sp");
                    }
                }
            }
        }

        public override void Delete(ICollection<AppPlacementLocation> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado.Add("LocationID", e.LocationID);
                        ado.Execute("dbo.AppPlacementLocationDelete_sp");
                    }
                }
            }
        }

        public override AppPlacementLocation Materialize(DataRow row)
        {
            return new AppPlacementLocation
            {
                LocationID = row.IntValue("LocationID"),
                Name = row.StringValue("LocationName"),
                LocationDescription = row.StringValue("LocationDescription"),
                Application = new Application
                {
                    ApplicationID = row.IntValue("ApplicationID"),
                    Name = row.StringValue("ApplicationName"),
                    AppKey = row.StringValue("AppKey")
                },
                Placement = new Placement
                {
                    PlacementID = row.IntValue("PlacementID"),
                    PlacementCode = row.StringValue("PlacementCode")
                },                
                DeliveryChannelCode = row.ByteValue("DeliveryChannelCode"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
