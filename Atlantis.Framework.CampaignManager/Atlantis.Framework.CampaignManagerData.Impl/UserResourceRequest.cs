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
    public class UserResourceRequest : BaseRequest<UserResource>
    {
        public override ICollection<UserResource> Query()
        {
            return this.ExecuteProcedure("dbo.UserResourceSelectAll_sp"); 
        }

        public override UserResource Materialize(DataRow row)
        {
            return new UserResource
            {
                UserResourceID = row.ByteValue("UserResourceID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
