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
    public class CampaignRequest : BaseRequest<Campaign>
    {
        public override ICollection<Campaign> Query()
        {
            // TODO: this is a hack, need to pick procs based on predicate expression bodies
            var campaigns = this.ExecuteProcedure("dbo.CampaignSelectAll_sp");

            foreach (var campaign in campaigns)
            {
                campaign.CampaignCompanyMaps = GetCompanyMaps(campaign.CampaignID);
                campaign.CampaignObjectiveMaps = GetObjectiveMaps(campaign.CampaignID);
                campaign.CampaignProductMaps = GetProductMaps(campaign.CampaignID);
                campaign.CampaignAudienceTypeMaps = GetAudienceTypeMaps(campaign.CampaignID);
                campaign.CampaignUserResourceMaps = GetUserResourceMaps(campaign.CampaignID);
            }

            return campaigns;
        }

        public override ICollection<Campaign> Query(params IDataParameter[] parameters)
        {            
            var campaigns = this.ExecuteProcedure("dbo.CampaignSelectByCampaignId_sp", parameters);
            foreach (var campaign in campaigns)
            {
                campaign.CampaignCompanyMaps = GetCompanyMaps(campaign.CampaignID);
                campaign.CampaignObjectiveMaps = GetObjectiveMaps(campaign.CampaignID);
                campaign.CampaignProductMaps = GetProductMaps(campaign.CampaignID);
                campaign.CampaignAudienceTypeMaps = GetAudienceTypeMaps(campaign.CampaignID);
                campaign.CampaignUserResourceMaps = GetUserResourceMaps(campaign.CampaignID);
            }

            return campaigns;
        }

        public override ICollection<Campaign> Query(Func<Campaign, bool> predicate)
        {
            // TODO: use more specific procedures
            // TODO: add way to inspect available procs and compare expression body values
            // with parameters to automatically pick a custom procedure
            return this.ExecuteProcedure("dbo.CampaignSelectAll_sp", predicate);
        }

        public override Campaign Single(Func<Campaign, bool> predicate)
        {
            // TODO: use more specific procedure
            return this.Query().Single(predicate);
        }

        public override void Insert(ICollection<Campaign> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var campaign in entities)
                {
                    var procResult = this.ExecuteProcedure("dbo.CampaignGetLastRecord_sp");
                    foreach (var lastCampaign in procResult)
                    {
                        int incrementalNumber = 1;
                        string lastKey = lastCampaign.Key;
                        string currrentYearMonth = DateTime.Now.ToString("yyMM");

                        if (lastKey.StartsWith(currrentYearMonth))
                        {   
                            try
                            {
                                int lastNumber = Int32.Parse(lastKey.Substring(4));
                                incrementalNumber = lastNumber + 1;
                            }
                            catch {}
                        }

                        string newCampaignKey = currrentYearMonth + incrementalNumber; ;

                        using (var ado = new ADOHelper(this.Config))
                        {
                            ado
                                .Add("Key", newCampaignKey)
                                .Add("CampaignTypeID", campaign.CampaignTypeID)
                                .Add("CampaignStatusID", campaign.CampaignStatusTypeID)
                                .Add("OfferTypeID", campaign.OfferTypeID)
                                .Add("OwnerID", campaign.OwnerID)
                                .Add("Priority", campaign.Priority)
                                .Add("PriorityScore", campaign.PriorityScore)
                                .Add("OfferDescription", campaign.OfferDescription, String.Empty)
                                .Add("Name", campaign.Name, String.Empty)
                                .Add("Description", campaign.Description, String.Empty)
                                .Add("Cost", campaign.Cost, 0.00)
                                .Add("TargetDate", campaign.TargetDate)
                                .Add("EndDate", campaign.EndDate)
                                .Add("MercuryIDList", campaign.MercuryIDList ?? String.Empty)
                                .Add("AddToCygnus", campaign.AddToCygnus ?? false)
                                .Add("Disabled", campaign.Disabled)
                                .Add("DateAdded", campaign.DateAdded, DateTime.Now)
                                .Add("DateUpdated", campaign.DateUpdated, DateTime.Now)
                                .Add("ID", -1, ParameterDirection.Output);

                            campaign.CampaignID = (int)ado.ExecuteReturnOutput("dbo.CampaignInsert_sp");


                            if (campaign.AddToCygnus != null && campaign.AddToCygnus == true)
                            {
                                // Get the Inserted Campaign, so that we can insert the same in Cygnus
                                var insertedCampaign = Single(x => x.CampaignID == campaign.CampaignID);

                                StringBuilder sb = new StringBuilder();
                                sb.Append("<Cygnus>");
                                sb.Append("<Parameters>");
                                sb.AppendFormat("<CampaignName>{0}</CampaignName>", insertedCampaign.Key); //16 char max in cygnus
                                sb.AppendFormat("<Offer>{0}</Offer>", insertedCampaign.OfferTypeName); //100 chars max in cygnus
                                sb.AppendFormat("<Product>{0}</Product>", insertedCampaign.Name); //100 chars max in cygnus
                                sb.Append("<ListDedup>1</ListDedup>"); //pass 1 or 3
                                sb.AppendFormat("<ListDueDate>{0}</ListDueDate>", (insertedCampaign.TargetDate == null ? DateTime.Now.ToString("MM/dd/yyyy") : insertedCampaign.TargetDate.ToString()));
                                sb.AppendFormat("<SendDate>{0}</SendDate>", (insertedCampaign.TargetDate == null ? DateTime.Now.ToString("MM/dd/yyyy") : insertedCampaign.TargetDate.ToString()));
                                sb.AppendFormat("<Owner>{0}</Owner>", insertedCampaign.OwnerName);
                                sb.Append("<TestRun>false</TestRun>"); //set to true for a test run
                                sb.Append("<AdministratorOnly>false</AdministratorOnly>");
                                string[] mercuryitems = insertedCampaign.MercuryIDList.Split(','); //since cygnus takes only one QC#, pass the first one from the comma separated list
                                sb.AppendFormat("<MecuryNumber>{0}</MecuryNumber>", (mercuryitems.Count() > 0 ? mercuryitems[0] : string.Empty));
                                sb.AppendFormat("<Alias>{0}</Alias>", insertedCampaign.OwnerName);
                                sb.Append("</Parameters>");
                                sb.Append("</Cygnus>");

                                try
                                {
                                    CMIntegrationService.CampaignManagerIntegrationService cmis = new CMIntegrationService.CampaignManagerIntegrationService();
                                    int response = cmis.InsertCampaignDataIntoCygnus(sb.ToString());
                                }
                                catch (Exception ex)
                                {
                                    throw new Exception(String.Format("Cygnus Insert Error: {0}, {1}", ex.Message, ex.InnerException));
                                }
                            }
                        
                            campaign.CampaignCompanyMaps.ForEach(x =>
                            {
                                x.CampaignID = campaign.CampaignID;
                            });

                            campaign.CampaignAudienceTypeMaps.ForEach(x =>
                            {
                                x.CampaignID = campaign.CampaignID;
                            });

                            campaign.CampaignObjectiveMaps.ForEach(x =>
                            {
                                x.CampaignID = campaign.CampaignID;
                            });

                            campaign.CampaignProductMaps.ForEach(x =>
                            {
                                x.CampaignID = campaign.CampaignID;
                            });

                            campaign.CampaignUserResourceMaps.ForEach(x =>
                            {
                                x.CampaignID = campaign.CampaignID;
                            });
                        }

                        UpdateMappings(campaign);
                    }
                }
            }
        }

        public override void Update(ICollection<Campaign> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var campaign in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado
                            .Add("CampaignID", campaign.CampaignID)
                            .Add("Key", campaign.Key)
                            .Add("CampaignTypeID", campaign.CampaignTypeID)
                            .Add("CampaignStatusTypeID", campaign.CampaignStatusTypeID)
                            .Add("OfferTypeID", campaign.OfferTypeID)
                            .Add("OwnerID", campaign.OwnerID)
                            .Add("Priority", campaign.Priority)
                            .Add("PriorityScore", campaign.PriorityScore)
                            .Add("OfferDescription", campaign.OfferDescription, String.Empty)
                            .Add("Name", campaign.Name, String.Empty)
                            .Add("Description", campaign.Description, String.Empty)
                            .Add("Cost", campaign.Cost, 0.00)
                            .Add("TargetDate", campaign.TargetDate)
                            .Add("EndDate", campaign.EndDate)
                            .Add("MercuryIDList", campaign.MercuryIDList ?? String.Empty)
                            .Add("AddToCygnus", campaign.AddToCygnus ?? false)
                            .Add("Disabled", campaign.Disabled)
                            .Add("DateUpdated", campaign.DateUpdated);

                        ado.Execute("dbo.CampaignUpdate_sp");
                    }

                    UpdateMappings(campaign);
                }
            }
        }

        public override void Delete(ICollection<Campaign> entities)
        {
            if (entities != null && entities.Count > 0)
            {
                foreach (var e in entities)
                {
                    using (var ado = new ADOHelper(this.Config))
                    {
                        ado.Add("CampaignID", e.CampaignID);
                        ado.Execute("dbo.CampaignDelete_sp");
                    }
                }
            }
        }

        public override Campaign Materialize(DataRow row)
        {
            return new Campaign
            {
                CampaignID = row.IntValue("CampaignID"),
                Name = row.StringValue("Name"),
                Key = row.StringValue("Key"),
                CampaignType = new CampaignType
                {
                    CampaignTypeID = row.ByteValue("CampaignTypeID"),
                    Name = row.StringValue("CampaignTypeName")
                },
                CampaignStatusType = new CampaignStatusType
                {
                    CampaignStatusTypeID = row.IntValue("CampaignStatusTypeID"),
                    Name = row.StringValue("CampaignStatusTypeName")
                },
                OfferType = new OfferType
                {
                    OfferTypeID = row.ByteValue("OfferTypeID"),
                    Name = row.StringValue("OfferTypeName")
                },
                Owner = new UserResource
                {
                    UserResourceID = row.IntValue("OwnerID"),
                    Name = row.StringValue("OwnerName")
                },
                Priority = row.StringValue("Priority"),
                PriorityScore = (row.IsNull("PriorityScore") == true ? (byte)0 : row.ByteValue("PriorityScore")),
                OfferDescription = row.StringValue("OfferDescription"),
                Description = row.StringValue("Description"),
                Cost = row.DecimalValue("Cost"),
                TargetDate = row.NullableDateTimeValue("TargetDate"),
                EndDate = row.NullableDateTimeValue("EndDate"),
                MercuryIDList = row.StringValue("MercuryIDList", ""),
                AddToCygnus = (row.IsNull("AddToCygnus") == true ? false : row.BooleanValue("AddToCygnus")),
                Disabled = row.BooleanValue("Disabled"),
                DateAdded = row.DateTimeValue("DateAdded"),
                DateUpdated = row.DateTimeValue("DateUpdated"),
            };
        }

        private void UpdateMappings(Campaign campaign)
        {
            if (campaign.CampaignID > 0)
            {
                Campaign currentCampaign = Single(x => x.CampaignID == campaign.CampaignID);
                UpdateCompanyMaps(campaign, currentCampaign);
                UpdateObjectiveMaps(campaign, currentCampaign);
                UpdateAudienceTypeMaps(campaign, currentCampaign);
                UpdateProductMaps(campaign, currentCampaign);
                UpdateUserResourceMaps(campaign, currentCampaign);
            }
        }

        private void UpdateCompanyMaps(Campaign udpatedCampaign, Campaign currentCampaign)
        {
            UpdateMaps<CampaignCompanyMap>(
                udpatedCampaign.CampaignCompanyMaps,
                currentCampaign.CampaignCompanyMaps,
                (s, c) => { return s.CompanyID == c.CompanyID; },
                (ado, e) =>
                {
                    ado
                        .Add("CampaignID", e.CampaignID)
                        .Add("CompanyID", e.CompanyID)
                        .Add("DateAdded", e.DateAdded, DateTime.Now)
                        .Add("DateUpdated", e.DateUpdated, DateTime.Now)
                        .Add("ID", -1, ParameterDirection.Output);

                    e.CampaignCompanyMapID = (int)ado.Execute("dbo.CampaignCompanyMapInsert_sp");
                },
                (e) =>
                {
                    ExecuteProcedure("dbo.CampaignCompanyMapDelete_sp",
                        new SqlParameter("CampaignID", udpatedCampaign.CampaignID),
                        new SqlParameter("CompanyID", e.CompanyID));
                });
        }

        private void UpdateAudienceTypeMaps(Campaign udpatedCampaign, Campaign currentCampaign)
        {
            UpdateMaps<CampaignAudienceTypeMap>(
                udpatedCampaign.CampaignAudienceTypeMaps,
                currentCampaign.CampaignAudienceTypeMaps,
                (s, c) => { return s.AudienceTypeID == c.AudienceTypeID; },
                (ado, e) =>
                {
                    ado
                        .Add("CampaignID", udpatedCampaign.CampaignID)
                        .Add("AudienceTypeID", e.AudienceTypeID)
                        .Add("DateAdded", e.DateAdded, DateTime.Now)
                        .Add("DateUpdated", e.DateUpdated, DateTime.Now)
                        .Add("ID", -1, ParameterDirection.Output);

                    e.CampaignAudienceTypeMapID = (int)ado.Execute("dbo.CampaignAudienceTypeMapInsert_sp");
                },
                (e) =>
                {
                    ExecuteProcedure("dbo.CampaignAudienceTypeMapDelete_sp",
                        new SqlParameter("CampaignID", udpatedCampaign.CampaignID),
                        new SqlParameter("AudienceTypeID", e.AudienceTypeID));
                });
        }

        private void UpdateObjectiveMaps(Campaign udpatedCampaign, Campaign currentCampaign)
        {
            UpdateMaps<CampaignObjectiveMap>(
                udpatedCampaign.CampaignObjectiveMaps,
                currentCampaign.CampaignObjectiveMaps,
                (s, c) => { return s.ObjectiveID == c.ObjectiveID; },
                (ado, e) =>
                {
                    ado
                        .Add("CampaignID", udpatedCampaign.CampaignID)
                        .Add("ObjectiveID", e.ObjectiveID)
                        .Add("DateAdded", e.DateAdded, DateTime.Now)
                        .Add("DateUpdated", e.DateUpdated, DateTime.Now)
                        .Add("ID", -1, ParameterDirection.Output);

                    e.CampaignObjectiveMapID = (int)ado.Execute("dbo.CampaignObjectiveMapInsert_sp");
                },
                (e) =>
                {
                    ExecuteProcedure("dbo.CampaignObjectiveMapDelete_sp",
                        new SqlParameter("CampaignID", udpatedCampaign.CampaignID),
                        new SqlParameter("ObjectiveID", e.ObjectiveID));
                });
        }

        private void UpdateProductMaps(Campaign udpatedCampaign, Campaign currentCampaign)
        {
            UpdateMaps<CampaignProductMap>(
                udpatedCampaign.CampaignProductMaps,
                currentCampaign.CampaignProductMaps,
                (s, c) => { return s.ProductID == c.ProductID; },
                (ado, e) =>
                {
                    ado
                        .Add("CampaignID", udpatedCampaign.CampaignID)
                        .Add("ProductID", e.ProductID)
                        .Add("DateAdded", e.DateAdded, DateTime.Now)
                        .Add("DateUpdated", e.DateUpdated, DateTime.Now)
                        .Add("ID", -1, ParameterDirection.Output);

                    e.CampaignProductMapID = (int)ado.Execute("dbo.CampaignProductMapInsert_sp");
                },
                (e) =>
                {
                    ExecuteProcedure("dbo.CampaignProductMapDelete_sp",
                        new SqlParameter("CampaignID", udpatedCampaign.CampaignID),
                        new SqlParameter("ProductID", e.ProductID));
                });
        }

        private void UpdateUserResourceMaps(Campaign udpatedCampaign, Campaign currentCampaign)
        {
            UpdateMaps<CampaignUserResourceMap>(
                udpatedCampaign.CampaignUserResourceMaps,
                currentCampaign.CampaignUserResourceMaps,
                (s, c) => { return s.UserResourceID == c.UserResourceID; },
                (ado, e) =>
                {
                    ado
                        .Add("CampaignID", udpatedCampaign.CampaignID)
                        .Add("UserResourceID", e.UserResourceID)
                        .Add("DateAdded", e.DateAdded, DateTime.Now)
                        .Add("DateUpdated", e.DateUpdated, DateTime.Now)
                        .Add("ID", -1, ParameterDirection.Output);

                    e.CampaignUserResourceMapID = (int)ado.Execute("dbo.CampaignUserResourceMapInsert_sp");
                },
                (e) =>
                {
                    ExecuteProcedure("dbo.CampaignUserResourceMapDelete_sp",
                        new SqlParameter("CampaignID", udpatedCampaign.CampaignID),
                        new SqlParameter("UserResourceID", e.UserResourceID));
                });
        }

        private TrackableCollection<CampaignCompanyMap> GetCompanyMaps(int campaignID)
        {
            var maps = new TrackableCollection<CampaignCompanyMap>();

            using (var ado = new ADOHelper(this.Config))
            {
                ado.Add("CampaignID", campaignID);
                var rows = ado.ExecuteReturnRows("dbo.CompanySelectByCampaignId_sp");
                rows.ForEach<CampaignCompanyMap>(
                    (row, entity) =>
                    {
                        entity.Campaign = new Campaign { CampaignID = campaignID };
                        entity.Company = new Company { CompanyID = row.IntValue("CompanyID"), Name = row.StringValue("Name") };
                        maps.Add(entity);
                    });
            }

            return maps;
        }

        private TrackableCollection<CampaignAudienceTypeMap> GetAudienceTypeMaps(int campaignID)
        {
            var maps = new TrackableCollection<CampaignAudienceTypeMap>();

            using (var ado = new ADOHelper(this.Config))
            {
                ado.Add("CampaignID", campaignID);
                var rows = ado.ExecuteReturnRows("dbo.AudienceTypeSelectByCampaignId_sp");
                rows.ForEach<CampaignAudienceTypeMap>(
                    (row, entity) =>
                    {
                        entity.Campaign = new Campaign { CampaignID = campaignID };
                        entity.AudienceType = new AudienceType { AudienceTypeID = row.IntValue("AudienceTypeID"), Name = row.StringValue("Name") };
                        maps.Add(entity);
                    });
            }

            return maps;
        }

        private TrackableCollection<CampaignObjectiveMap> GetObjectiveMaps(int campaignID)
        {
            var maps = new TrackableCollection<CampaignObjectiveMap>();

            using (var ado = new ADOHelper(this.Config))
            {
                ado.Add("CampaignID", campaignID);
                var rows = ado.ExecuteReturnRows("dbo.ObjectiveSelectByCampaignId_sp");
                rows.ForEach<CampaignObjectiveMap>(
                    (row, entity) =>
                    {
                        entity.Campaign = new Campaign { CampaignID = campaignID };
                        entity.Objective = new Objective { ObjectiveID = row.IntValue("ObjectiveID"), Name = row.StringValue("Name") };
                        maps.Add(entity);
                    });
            }

            return maps;
        }

        private TrackableCollection<CampaignProductMap> GetProductMaps(int campaignID)
        {
            var maps = new TrackableCollection<CampaignProductMap>();

            using (var ado = new ADOHelper(this.Config))
            {
                ado.Add("CampaignID", campaignID);
                var rows = ado.ExecuteReturnRows("dbo.ProductSelectByCampaignId_sp");
                rows.ForEach<CampaignProductMap>(
                    (row, entity) =>
                    {
                        entity.Campaign = new Campaign { CampaignID = campaignID };
                        entity.Product = new Product { ProductID = row.IntValue("ProductID"), Name = row.StringValue("Name") };
                        maps.Add(entity);
                    });
            }

            return maps;
        }

        private TrackableCollection<CampaignUserResourceMap> GetUserResourceMaps(int campaignID)
        {
            var maps = new TrackableCollection<CampaignUserResourceMap>();

            using (var ado = new ADOHelper(this.Config))
            {
                ado.Add("CampaignID", campaignID);
                var rows = ado.ExecuteReturnRows("dbo.UserResourceSelectByCampaignId_sp");
                rows.ForEach<CampaignUserResourceMap>(
                    (row, entity) =>
                    {
                        entity.Campaign = new Campaign { CampaignID = campaignID };
                        entity.UserResource = new UserResource { UserResourceID = row.IntValue("UserResourceID"), Name = row.StringValue("Name") };
                        maps.Add(entity);
                    });
            }

            return maps;
        }
    }
}
