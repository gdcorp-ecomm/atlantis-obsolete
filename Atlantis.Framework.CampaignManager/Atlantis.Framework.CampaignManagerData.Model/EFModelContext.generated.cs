﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.EntityClient;
using System.Data.Objects;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;

namespace Atlantis.Framework.CampaignManagerData.Model
{
    public partial class EFModelContext : ObjectContext
    {
    	private const string _notSupportedMessage = "Entity Framework can only be used for model design with this application!";
        public const string ConnectionString = "name=EFModelContext";
        public const string ContainerName = "EFModelContext";
    
        #region Constructors
    
        public EFModelContext()
            : base(ConnectionString, ContainerName)
        {
            throw new NotSupportedException(_notSupportedMessage);
        }
    
        public EFModelContext(string connectionString)
            : base(connectionString, ContainerName)
        {
            throw new NotSupportedException(_notSupportedMessage);
        }
    
        public EFModelContext(EntityConnection connection)
            : base(connection, ContainerName)
        {
            throw new NotSupportedException(_notSupportedMessage);
        } 
    
        #endregion
    
    	#region ObjectSet Properties
    
        public ObjectSet<Application> Applications
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<AppPlacementLocation> AppPlacementLocations
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Audience> Audiences
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<AudienceRuleBlockMap> AudienceRuleBlockMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<AudienceType> AudienceTypes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Campaign> Campaigns
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignAudienceTypeMap> CampaignAudienceTypeMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignCompanyMap> CampaignCompanyMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignMessage> CampaignMessages
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignObjectiveMap> CampaignObjectiveMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignProductMap> CampaignProductMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignStatusType> CampaignStatusTypes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignType> CampaignTypes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<CampaignUserResourceMap> CampaignUserResourceMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Company> Companies
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<DeliveryChannel> DeliveryChannels
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<LocationRuleBlockMap> LocationRuleBlockMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageBlock> MessageBlocks
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageBlockCategory> MessageBlockCategories
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageBlockDataItem> MessageBlockDataItems
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageBlockDataItemAttribute> MessageBlockDataItemAttributes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageBlockDataItemAttributeValue> MessageBlockDataItemAttributeValues
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageBlockType> MessageBlockTypes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageInstance> MessageInstances
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<MessageLanguage> MessageLanguages
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Objective> Objectives
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<OfferType> OfferTypes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Placement> Placements
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Product> Products
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<RuleBlock> RuleBlocks
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<RuleCategory> RuleCategories
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<RuleInfo> RuleInfoes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<RuleSettings> RuleSettings1
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<RuleSettingsRuleBlockMap> RuleSettingsRuleBlockMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Segment> Segments
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<SegmentRuleBlockMap> SegmentRuleBlockMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<Split> Splits
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<SplitRuleBlockMap> SplitRuleBlockMaps
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<UserResource> UserResources
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<fbiOffer> fbiOffers
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<DeploymentStatus> DeploymentStatusList
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<DiscountType> DiscountTypes
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
        public ObjectSet<ProductGroup> ProductGroups
        {
            get { throw new NotSupportedException(_notSupportedMessage); }
        }
    
    	#endregion
    }
}

