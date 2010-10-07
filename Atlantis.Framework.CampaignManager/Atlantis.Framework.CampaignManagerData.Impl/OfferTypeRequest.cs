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
    public class OfferTypeRequest : BaseRequest<OfferType>
    {
        public override ICollection<OfferType> Query()
        {
            return this.ExecuteProcedure("dbo.OfferTypeSelectAll_sp"); 
        }

        public override OfferType Materialize(DataRow row)
        {
            return new OfferType
            {
                OfferTypeID = row.ByteValue("OfferTypeID"),
                Name = row.StringValue("Name"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated")
            };
        }
    }
}
