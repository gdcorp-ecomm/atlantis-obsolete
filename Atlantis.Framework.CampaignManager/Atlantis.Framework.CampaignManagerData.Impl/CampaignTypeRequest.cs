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
    public class CampaignTypeRequest : BaseRequest<CampaignType>
    {
        public override ICollection<CampaignType> Query()
        {
            return this.ExecuteProcedure("dbo.CampaignTypeSelectAll_sp");
        }

        public override CampaignType Materialize(DataRow row)
        {
            return new CampaignType
            {
                CampaignTypeID = row.ByteValue("CampaignTypeID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
