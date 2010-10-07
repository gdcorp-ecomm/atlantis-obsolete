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
    public class ProductGroupRequest : BaseRequest<ProductGroup>
    {
        public override ICollection<ProductGroup> Query()
        {
            return this.ExecuteProcedure("dbo.ProductGroupSelect_sp");
        }

        public override ProductGroup Materialize(DataRow row)
        {
            return new ProductGroup
            {
                ProductGroupCode = row.IntValue("ProductGroupCode"),
                ProductGroupName = row.StringValue("ProductGroupName"),
                ProductGroupDescription = row.StringValue("ProductGroupDescription")
            };
        }
    }
}
