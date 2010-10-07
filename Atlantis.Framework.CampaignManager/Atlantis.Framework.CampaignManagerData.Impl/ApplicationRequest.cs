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
    public class ApplicationRequest : BaseRequest<Application>
    {
        public override ICollection<Application> Query()
        {
            return this.ExecuteProcedure("dbo.ApplicationSelectAll_sp");
        }

        public override Application Materialize(DataRow row)
        {
            return new Application
            {
                AppKey = row.StringValue("AppKey"),
                ApplicationID = row.IntValue("ApplicationID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
