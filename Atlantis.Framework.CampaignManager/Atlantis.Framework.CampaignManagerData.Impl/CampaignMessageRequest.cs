using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface;
using Atlantis.Framework.Entity.Interface.ADO;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.Impl
{
    public class CampaignMessageRequest : BaseRequest<CampaignMessage>
    {
        public override ICollection<CampaignMessage> Query()
        {
            return this.ExecuteProcedure("dbo.CampaignMessageSelect_sp");            
        }

        public override ICollection<CampaignMessage> Query(Func<CampaignMessage, bool> predicate)
        {
            return this.ExecuteProcedure("dbo.CampaignMessageSelect_sp", predicate);
        }

        public override CampaignMessage Single(Func<CampaignMessage, bool> predicate)
        {
            // TODO: use more specific procedure
            return this.Query().Single(predicate);
        }

        public override ICollection<CampaignMessage> Query(params IDataParameter[] parameters)
        {
            return this.ExecuteProcedure("dbo.CampaignMessageSelect_sp", parameters);
        }

        public override void Insert(ICollection<CampaignMessage> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var campaignMessage in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("CampaignID", campaignMessage.CampaignID)
                            .Add("Name", campaignMessage.Name, String.Empty)
                            .Add("CampaignMessageDescription", campaignMessage.CampaignMessageDescription, String.Empty)                            
                            .Add("ID", -1, ParameterDirection.Output);

                        campaignMessage.CampaignMessageID = (int)ado.ExecuteReturnOutput("dbo.CampaignMessageInsert_sp");
                    }
                }
            }
        }

        public override void Update(ICollection<CampaignMessage> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var campaignMessage in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("CampaignMessageID", campaignMessage.CampaignMessageID)
                            .Add("CampaignID", campaignMessage.CampaignID)
                            .Add("Name", campaignMessage.Name, String.Empty)
                            .Add("CampaignMessageDescription", campaignMessage.CampaignMessageDescription, String.Empty);                     

                        ado.Execute("dbo.CampaignMessageUpdate_sp");
                    }
                }
            }
        }

        public override void Delete(ICollection<CampaignMessage> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado.Add("CampaignMessageID", e.CampaignMessageID);
                        ado.Execute("dbo.CampaignMessageDelete_sp");
                    }
                }
            }
        }

        public override CampaignMessage Materialize(DataRow row)
        {
            return new CampaignMessage
            {
                CampaignMessageID = row.IntValue("CampaignMessageID"),
                CampaignID = row.IntValue("CampaignID"),
                Name = row.StringValue("Name"),
                CampaignMessageDescription = row.StringValue("CampaignMessageDescription"),                
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated"),
            };
        }
    }
}
