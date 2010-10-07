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
    public class AudienceRequest : BaseRequest<Audience>
    {
        public override ICollection<Audience> Query()
        {
            // TODO: this is a hack, need to pick procs based on predicate expression bodies
            return this.ExecuteProcedure("dbo.AudienceSelectAll_sp");            
        }

        public override ICollection<Audience> Query(Func<Audience, bool> predicate)
        {
            // TODO: use more specific procedures
            // TODO: add way to inspect available procs and compare expression body values
            // with parameters to automatically pick a custom procedure
            return this.ExecuteProcedure("dbo.AudienceSelectAll_sp", predicate);
        }

        public override Audience Single(Func<Audience, bool> predicate)
        {
            // TODO: use more specific procedure
            return this.Query().Single(predicate);
        }

        public override void Insert(ICollection<Audience> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var audience in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("CampaignID", audience.CampaignID)
                            .Add("Name", audience.Name, String.Empty)
                            .Add("Description", audience.AudienceDescription, String.Empty)
                            .Add("DateAdded", audience.DateAdded, DateTime.Now)
                            .Add("DateUpdated", audience.DateUpdated, DateTime.Now)
                            .Add("ID", -1, ParameterDirection.Output);

                        audience.AudienceID = (int)ado.ExecuteReturnOutput("dbo.AudienceInsert_sp");
                    }
                }
            }
        }

        public override void Update(ICollection<Audience> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var audience in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("AudienceID", audience.AudienceID)
                            .Add("CampaignID", audience.CampaignID)
                            .Add("Name", audience.Name, String.Empty)
                            .Add("Description", audience.AudienceDescription, String.Empty)
                            .Add("DateUpdated", audience.DateUpdated);

                        ado.Execute("dbo.AudienceUpdate_sp");
                    }
                }
            }
        }

        public override void Delete(ICollection<Audience> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado.Add("AudienceID", e.AudienceID);
                        ado.Execute("dbo.AudienceDelete_sp");
                    }
                }
            }
        }

        public override Audience Materialize(DataRow row)
        {
            return new Audience
            {
                AudienceID = row.IntValue("AudienceID"),
                CampaignID = row.IntValue("CampaignID"),
                Name = row.StringValue("Name"),
                AudienceDescription = row.StringValue("Description"),                
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated"),
            };
        }
    }
}
