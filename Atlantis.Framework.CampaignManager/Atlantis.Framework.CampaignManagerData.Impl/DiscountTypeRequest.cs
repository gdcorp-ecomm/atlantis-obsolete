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
    public class DiscountTypeRequest : BaseRequest<DiscountType>
    {
        public override ICollection<DiscountType> Query()
        {
            return this.ExecuteProcedure("dbo.DiscountTypeSelect_sp");
        }

        public override DiscountType Materialize(DataRow row)
        {
            return new DiscountType
            {
                DiscountTypeName = row.StringValue("DiscountType"),
                DiscountTypeDescription = row.StringValue("DiscountTypeDescription"),                
            };
        }
    }
}
