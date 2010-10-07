using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface.EF4;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.EF.Impl
{
    public class CampaignRequest : BaseEFRequest<Campaign>
    {
        public override ICollection<Campaign> Query()
        {
            using (var ctx = new EFModelContext(this.GetConnectionString()))
            {
                var query = ctx.Campaigns
                    .Include("CampaignStatusType")
                    .Include("CampaignType")
                    .Include("OfferType")
                    .Include("Owner")
                    .Include("CampaignCompanyMaps.Company")
                    .Include("CampaignObjectiveMaps.Objective")
                    .Include("CampaignProductMaps.Product")
                    .Include("CampaignAudienceTypeMaps.AudienceType")
                    .Include("CampaignUserResourceMaps");

                return query.ToList();
            }
        }

        public override void Insert(ICollection<Campaign> entities)
        {
            foreach (var entity in entities)
            {
                using (var ctx = new EFModelContext(this.GetConnectionString()))
                {
                    entity.DateAdded = DateTime.Now;
                    entity.DateUpdated = DateTime.Now;
                    ctx.Campaigns.AddObject(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public override void Update(ICollection<Campaign> entities)
        {
            foreach (var entity in entities)
            {
                using (var ctx = new EFModelContext(this.GetConnectionString()))
                {
                    entity.MarkAsModified();
                    entity.DateUpdated = DateTime.Now;
                    ctx.Campaigns.ApplyChanges(entity);
                    ctx.SaveChanges();
                }
            }
        }

        public override void Delete(ICollection<Campaign> entities)
        {
            foreach (var entity in entities)
            {
                using (var ctx = new EFModelContext(this.GetConnectionString()))
                {
                    entity.DateUpdated = DateTime.Now;
                    entity.Disabled = true;
                    ctx.Campaigns.Attach(entity);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
