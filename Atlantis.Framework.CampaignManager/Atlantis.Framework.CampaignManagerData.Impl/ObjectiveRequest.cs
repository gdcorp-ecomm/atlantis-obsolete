using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface.ADO;

namespace Atlantis.Framework.CampaignManagerData.Impl
{
    public class ObjectiveRequest : BaseRequest<Objective>
    {
        public override ICollection<Objective> Query()
        {
            return this.ExecuteProcedure("dbo.ObjectiveSelectAll_sp");
        }

        public override Objective Materialize(DataRow row)
        {
            return new Objective
            {
                ObjectiveID = row.ByteValue("ObjectiveID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
