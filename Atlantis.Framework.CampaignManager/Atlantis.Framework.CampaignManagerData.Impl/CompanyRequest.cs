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
    public class CompanyRequest : BaseRequest<Company>
    {
        public override ICollection<Company> Query()
        {
            return this.ExecuteProcedure("dbo.CompanySelectAll_sp"); 
        } 

        public override Company Materialize(DataRow row)
        {
            return new Company
            {
                CompanyID = row.ByteValue("CompanyID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
