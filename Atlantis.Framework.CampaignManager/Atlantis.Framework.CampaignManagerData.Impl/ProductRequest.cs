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
    public class ProductRequest : BaseRequest<Product>
    {
        public override ICollection<Product> Query()
        {
            return this.ExecuteProcedure("dbo.ProductSelectAll_sp"); 
        }

        public override Product Materialize(DataRow row)
        {
            return new Product
            {
                ProductID = row.ByteValue("ProductID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
