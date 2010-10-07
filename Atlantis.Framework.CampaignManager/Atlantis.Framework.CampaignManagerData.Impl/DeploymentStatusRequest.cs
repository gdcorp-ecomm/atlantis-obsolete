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
    public class DeploymentStatusRequest : BaseRequest<DeploymentStatus>
    {
        public override ICollection<DeploymentStatus> Query()
        {
            return this.ExecuteProcedure("dbo.DeploymentStatusSelect_sp");
        }

        public override DeploymentStatus Materialize(DataRow row)
        {
            return new DeploymentStatus
            {
                DeploymentStatusCode = row.ByteValue("DeploymentStatusCode"),
                DeploymentStatusName = row.StringValue("DeploymentStatusName"),
                DeploymentStatusDescription = row.StringValue("DeploymentStatusDescription")
            };
        }
    }
}
