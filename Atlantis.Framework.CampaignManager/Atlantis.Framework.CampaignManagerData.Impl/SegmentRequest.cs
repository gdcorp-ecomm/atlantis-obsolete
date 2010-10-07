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
    public class SegmentRequest : BaseRequest<Segment>
    {
        public override ICollection<Segment> Query()
        {
            // TODO: this is a hack, need to pick procs based on predicate expression bodies
            return this.ExecuteProcedure("dbo.SegmentSelectAll_sp");            
        }

        public override ICollection<Segment> Query(Func<Segment, bool> predicate)
        {
            // TODO: use more specific procedures
            // TODO: add way to inspect available procs and compare expression body values
            // with parameters to automatically pick a custom procedure
            return this.ExecuteProcedure("dbo.SegmentSelectAll_sp", predicate);
        }

        public override Segment Single(Func<Segment, bool> predicate)
        {
            // TODO: use more specific procedure
            return this.Query().Single(predicate);
        }

        public override void Insert(ICollection<Segment> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var segment in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("AudienceID", segment.AudienceID)
                            .Add("Name", segment.Name, String.Empty)
                            .Add("Description", segment.SegmentDescription, String.Empty)
                            .Add("DateAdded", segment.DateAdded, DateTime.Now)
                            .Add("DateUpdated", segment.DateUpdated, DateTime.Now)
                            .Add("ID", -1, ParameterDirection.Output);

                        segment.SegmentID = (int)ado.ExecuteReturnOutput("dbo.SegmentInsert_sp");
                    }
                }
            }
        }

        public override void Update(ICollection<Segment> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var segment in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("SegmentID", segment.SegmentID)
                            .Add("AudienceID", segment.AudienceID)
                            .Add("Name", segment.Name, String.Empty)
                            .Add("Description", segment.SegmentDescription, String.Empty)
                            .Add("DateUpdated", segment.DateUpdated);

                        ado.Execute("dbo.SegmentUpdate_sp");
                    }
                }
            }
        }

        public override void Delete(ICollection<Segment> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado.Add("SegmentID", e.SegmentID);
                        ado.Execute("dbo.SegmentDelete_sp");
                    }
                }
            }
        }

        public override Segment Materialize(DataRow row)
        {
            return new Segment
            {
                SegmentID = row.IntValue("SegmentID"),
                AudienceID = row.IntValue("AudienceID"),
                Name = row.StringValue("Name"),
                SegmentDescription = row.StringValue("Description"),                
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated"),
            };
        }
    }
}
