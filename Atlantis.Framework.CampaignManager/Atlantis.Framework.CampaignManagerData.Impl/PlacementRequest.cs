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
    public class PlacementRequest : BaseRequest<Placement>
    {
        public override ICollection<Placement> Query()
        {
            // TODO: this is a hack, need to pick procs based on predicate expression bodies
            return this.ExecuteProcedure("dbo.PlacementSelectAll_sp");            
        }

        public override ICollection<Placement> Query(Func<Placement, bool> predicate)
        {
            // TODO: use more specific procedures
            // TODO: add way to inspect available procs and compare expression body values
            // with parameters to automatically pick a custom procedure
            return this.ExecuteProcedure("dbo.PlacementSelectAll_sp", predicate);
        }

        public override Placement Single(Func<Placement, bool> predicate)
        {
            // TODO: use more specific procedure
            return this.Query().Single(predicate);
        }

        public override void Update(ICollection<Placement> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var placement in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("PlacementID", placement.PlacementID)                            
                            .Add("Name", placement.Name, String.Empty)
                            .Add("Description", placement.Description, String.Empty)
                            .Add("DateUpdated", placement.DateUpdated);

                        ado.Execute("dbo.PlacementUpdate_sp");
                    }
                }
            }
        }

        public override Placement Materialize(DataRow row)
        {
            return new Placement
            {
                PlacementID = row.IntValue("PlacementID"),                
                Name = row.StringValue("Name"),
                Description = row.StringValue("Description"),                
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated"),
            };
        }
    }
}
