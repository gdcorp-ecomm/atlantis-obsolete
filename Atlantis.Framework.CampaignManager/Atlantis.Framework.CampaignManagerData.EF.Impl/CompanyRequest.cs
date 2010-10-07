using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface.ADO;

namespace Atlantis.Framework.CampaignManagerData.EF.Impl
{
    public class CompanyRequest : BaseEFRequest<Company>
    {
        public override ICollection<Company> Query()
        {
            using (var ctx = new EFModelContext(this.GetConnectionString()))
            {
                var query = ctx.Companies;
                return query.ToList();
            }
        }   
    }
}
