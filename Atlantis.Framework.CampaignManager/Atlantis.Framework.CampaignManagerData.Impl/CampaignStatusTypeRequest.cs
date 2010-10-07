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
    public class CampaignStatusTypeRequest : BaseRequest<CampaignStatusType>
    {
        public override ICollection<CampaignStatusType> Query()
        {
            return this.ExecuteProcedure("dbo.CampaignStatusTypeSelectAll_sp");
        }

        public override CampaignStatusType Materialize(DataRow row)
        {
            return new CampaignStatusType
            {
                CampaignStatusTypeID = row.ByteValue("CampaignStatusTypeID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
