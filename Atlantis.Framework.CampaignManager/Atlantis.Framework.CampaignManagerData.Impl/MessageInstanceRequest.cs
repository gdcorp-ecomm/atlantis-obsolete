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
    public class MessageInstanceRequest : BaseRequest<MessageInstance>
    {
        public override ICollection<MessageInstance> Query()
        {
            return this.ExecuteProcedure("dbo.MessageInstanceSelect_sp");            
        }

        public override ICollection<MessageInstance> Query(params IDataParameter[] parameters)
        {
            return this.ExecuteProcedure("dbo.MessageInstanceSelect_sp", parameters);
        }

        public override ICollection<MessageInstance> Query(Func<MessageInstance, bool> predicate)
        {
            return this.ExecuteProcedure("dbo.MessageInstanceSelect_sp", predicate);
        }

        public override MessageInstance Single(Func<MessageInstance, bool> predicate)
        {
            return this.Query().Single(predicate);
        }

        public override void Insert(ICollection<MessageInstance> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var messageInstance in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {   
                        ado
                            .Add("discountType", messageInstance.fbiOffer.discountType)
                            .Add("fastballDiscount", (messageInstance.fbiOffer.discountType.ToLower() == "item" ? messageInstance.fbiOffer.fastballDiscount : 0))
                            .Add("fastballOrderDiscount", (messageInstance.fbiOffer.discountType.ToLower() == "order" ? messageInstance.fbiOffer.fastballOrderDiscount : 0))
                            .Add("ProductGroupCode", messageInstance.fbiOffer.ProductGroupCode)
                            .Add("CampaignID", messageInstance.CampaignID)
                            .Add("CampaignMessageID", messageInstance.CampaignMessageID)
                            .Add("ApplicationID", messageInstance.ApplicationID)
                            .Add("PlacementID", messageInstance.PlacementID)
                            .Add("LocationID", messageInstance.LocationID)
                            .Add("DeliveryChannelCode", messageInstance.DeliveryChannelCode)
                            .Add("BrandCode", messageInstance.BrandCode)
                            .Add("LanguageCode", messageInstance.LanguageCode)
                            .Add("RevisionNumber", messageInstance.RevisionNumber)
                            .Add("MessageBlockID", DBNull.Value) //TODO: Pass DBNull when MessageBlockID is null or not set
                            //.Add("MessageBlockID", (messageInstance.MessageBlockID == null ? (object)DBNull.Value : (object)messageInstance.MessageBlockID))
                            .Add("DeploymentStatusCode", messageInstance.DeploymentStatusCode)
                            .Add("StartDate", messageInstance.StartDate)
                            .Add("EndDate", messageInstance.EndDate)
                            .Add("AudienceID", messageInstance.AudienceID)
                            .Add("SegmentID", messageInstance.SegmentID)
                            .Add("SplitID", messageInstance.SplitID)                            
                            .Add("ID", -1, ParameterDirection.Output);

                        messageInstance.MessageInstanceID = (int)ado.ExecuteReturnOutput("dbo.MessageInstanceInsert_sp");
                    }
                }
            }
        }

        public override void Update(ICollection<MessageInstance> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var messageInstance in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("MessageInstanceID", messageInstance.MessageInstanceID)
                            .Add("fbiOfferID", messageInstance.fbiOfferID)
                            .Add("discountType", messageInstance.fbiOffer.discountType)
                            .Add("fastballDiscount", (messageInstance.fbiOffer.discountType.ToLower() == "item" ? messageInstance.fbiOffer.fastballDiscount : 0))
                            .Add("fastballOrderDiscount", (messageInstance.fbiOffer.discountType.ToLower() == "order" ? messageInstance.fbiOffer.fastballOrderDiscount : 0))
                            .Add("ProductGroupCode", messageInstance.fbiOffer.ProductGroupCode)
                            .Add("CampaignID", messageInstance.CampaignID)
                            .Add("CampaignMessageID", messageInstance.CampaignMessageID)
                            .Add("ApplicationID", messageInstance.ApplicationID)
                            .Add("PlacementID", messageInstance.PlacementID)
                            .Add("LocationID", messageInstance.LocationID)
                            .Add("DeliveryChannelCode", messageInstance.DeliveryChannelCode)
                            .Add("BrandCode", messageInstance.BrandCode)
                            .Add("LanguageCode", messageInstance.LanguageCode)
                            .Add("RevisionNumber", messageInstance.RevisionNumber)
                            .Add("MessageBlockID", DBNull.Value) //TODO: Pass DBNull when MessageBlockID is null or not set                            
                            .Add("DeploymentStatusCode", messageInstance.DeploymentStatusCode)
                            .Add("StartDate", messageInstance.StartDate)
                            .Add("EndDate", messageInstance.EndDate)
                            .Add("AudienceID", messageInstance.AudienceID)
                            .Add("SegmentID", messageInstance.SegmentID)
                            .Add("SplitID", messageInstance.SplitID);

                        ado.Execute("dbo.MessageInstanceUpdate_sp");
                    }
                }
            }
        }

        public override void Delete(ICollection<MessageInstance> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado.Add("MessageInstanceID", e.MessageInstanceID);
                        ado.Execute("dbo.MessageInstanceDelete_sp");
                    }
                }
            }
        }

        public override MessageInstance Materialize(DataRow row)
        {
            return new MessageInstance
            {
                MessageInstanceID = row.IntValue("MessageInstanceID"),
                fbiOfferID = row.IntValue("fbiOfferID"),
                fbiOffer = new fbiOffer
                {
                    fbiOfferID = row.IntValue("fbiOfferID"),
                    discountType = row.StringValue("discountType"),
                    fastballDiscount = (row.IsNull("fastballDiscount") == true ? 0 : row.IntValue("fastballDiscount")),
                    fastballOrderDiscount = (row.IsNull("fastballOrderDiscount") == true ? 0 : row.IntValue("fastballOrderDiscount")),
                    ProductGroupCode = row.IntValue("productGroupCode")
                },                
                CampaignID = row.IntValue("CampaignID"),
                CampaignMessage = new CampaignMessage
                {
                    CampaignMessageID = row.IntValue("CampaignMessageID"),
                    Name = row.StringValue("CampaignMessageName")
                },
                ApplicationID = row.IntValue("ApplicationID"),                
                Application = new Application
                {
                    ApplicationID = row.IntValue("ApplicationID"),
                    AppKey = row.StringValue("AppKey"),
                    Name = row.StringValue("ApplicationName")
                },
                PlacementID = row.IntValue("PlacementID"),
                Placement = new Placement
                {
                    PlacementID = row.IntValue("PlacementID"),
                    Name = row.StringValue("PlacementName"),
                    PlacementCode = row.StringValue("PlacementCode")
                },
                LocationID = row.IntValue("LocationID"),
                DeliveryChannelCode = row.ByteValue("DeliveryChannelCode"),
                DeliveryChannel = new DeliveryChannel
                {
                    DeliveryChannelCode = row.ByteValue("DeliveryChannelCode"),
                    Name = row.StringValue("DeliveryChannelName")
                },
                BrandCode = row.ByteValue("BrandCode"),
                LanguageCode = row.ByteValue("LanguageCode"),
                MessageLanguage = new MessageLanguage
                {
                    LanguageCode = row.ByteValue("LanguageCode"),
                    LanguageDescription = "English (United States)"
                },
                RevisionNumber = row.ByteValue("RevisionNumber"),
                MessageBlockID = (row.IsNull("MessageBlockID") == true ? -1 : row.IntValue("MessageBlockID")),
                DeploymentStatusCode = row.ByteValue("DeploymentStatusCode"),
                DeploymentStatus = new DeploymentStatus
                {
                    DeploymentStatusCode = row.ByteValue("DeploymentStatusCode"),
                    DeploymentStatusDescription = "In Development" //TODO: Fix this..this is hard coded for testing
                },
                StartDate = row.DateTimeValue("StartDate"),
                EndDate = row.DateTimeValue("EndDate"),
                AudienceID = row.IntValue("AudienceID"),
                Audience = new Audience                
                {
                    AudienceID = row.IntValue("AudienceID"),
                    Name = row.StringValue("AudienceName")
                },
                SegmentID = row.IntValue("SegmentID"),
                SplitID = row.IntValue("SplitID"),                
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated"),
            };
        }
    }
}
