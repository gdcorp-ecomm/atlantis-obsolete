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
    public class AudienceTypeRequest : BaseRequest<AudienceType>
    {
        public override ICollection<AudienceType> Query()
        {
            return this.ExecuteProcedure("dbo.AudienceTypeSelectAll_sp");
        }

        public override AudienceType Materialize(DataRow row)
        {
            return new AudienceType
            {
                AudienceTypeID = row.ByteValue("AudienceTypeID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
