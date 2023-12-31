﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Data.Objects; 
using Atlantis.Framework.CampaignManagerData.Interface.Entities;

namespace Atlantis.Framework.CampaignManagerData.EF.Impl
{
    public partial class EFModelContext : ObjectContext
    {
        #region ObjectSet Properties
    
        public ObjectSet<AudienceType> AudienceTypes
        {
            get { return _audienceTypes  ?? (_audienceTypes = CreateObjectSet<AudienceType>("AudienceTypes")); }
        }
        private ObjectSet<AudienceType> _audienceTypes;
    
        public ObjectSet<Campaign> Campaigns
        {
            get { return _campaigns  ?? (_campaigns = CreateObjectSet<Campaign>("Campaigns")); }
        }
        private ObjectSet<Campaign> _campaigns;
    
        public ObjectSet<CampaignAudienceTypeMap> CampaignAudienceTypeMaps
        {
            get { return _campaignAudienceTypeMaps  ?? (_campaignAudienceTypeMaps = CreateObjectSet<CampaignAudienceTypeMap>("CampaignAudienceTypeMaps")); }
        }
        private ObjectSet<CampaignAudienceTypeMap> _campaignAudienceTypeMaps;
    
        public ObjectSet<CampaignCompanyMap> CampaignCompanyMaps
        {
            get { return _campaignCompanyMaps  ?? (_campaignCompanyMaps = CreateObjectSet<CampaignCompanyMap>("CampaignCompanyMaps")); }
        }
        private ObjectSet<CampaignCompanyMap> _campaignCompanyMaps;
    
        public ObjectSet<CampaignObjectiveMap> CampaignObjectiveMaps
        {
            get { return _campaignObjectiveMaps  ?? (_campaignObjectiveMaps = CreateObjectSet<CampaignObjectiveMap>("CampaignObjectiveMaps")); }
        }
        private ObjectSet<CampaignObjectiveMap> _campaignObjectiveMaps;
    
        public ObjectSet<CampaignProductMap> CampaignProductMaps
        {
            get { return _campaignProductMaps  ?? (_campaignProductMaps = CreateObjectSet<CampaignProductMap>("CampaignProductMaps")); }
        }
        private ObjectSet<CampaignProductMap> _campaignProductMaps;
    
        public ObjectSet<CampaignStatusType> CampaignStatusTypes
        {
            get { return _campaignStatusTypes  ?? (_campaignStatusTypes = CreateObjectSet<CampaignStatusType>("CampaignStatusTypes")); }
        }
        private ObjectSet<CampaignStatusType> _campaignStatusTypes;
    
        public ObjectSet<CampaignType> CampaignTypes
        {
            get { return _campaignTypes  ?? (_campaignTypes = CreateObjectSet<CampaignType>("CampaignTypes")); }
        }
        private ObjectSet<CampaignType> _campaignTypes;
    
        public ObjectSet<CampaignUserResourceMap> CampaignUserResourceMaps
        {
            get { return _campaignUserResourceMaps  ?? (_campaignUserResourceMaps = CreateObjectSet<CampaignUserResourceMap>("CampaignUserResourceMaps")); }
        }
        private ObjectSet<CampaignUserResourceMap> _campaignUserResourceMaps;
    
        public ObjectSet<Company> Companies
        {
            get { return _companies  ?? (_companies = CreateObjectSet<Company>("Companies")); }
        }
        private ObjectSet<Company> _companies;
    
        public ObjectSet<Objective> Objectives
        {
            get { return _objectives  ?? (_objectives = CreateObjectSet<Objective>("Objectives")); }
        }
        private ObjectSet<Objective> _objectives;
    
        public ObjectSet<OfferType> OfferTypes
        {
            get { return _offerTypes  ?? (_offerTypes = CreateObjectSet<OfferType>("OfferTypes")); }
        }
        private ObjectSet<OfferType> _offerTypes;
    
        public ObjectSet<Product> Products
        {
            get { return _products  ?? (_products = CreateObjectSet<Product>("Products")); }
        }
        private ObjectSet<Product> _products;
    
        public ObjectSet<UserResource> UserResources
        {
            get { return _userResources  ?? (_userResources = CreateObjectSet<UserResource>("UserResources")); }
        }
        private ObjectSet<UserResource> _userResources;
    
        public ObjectSet<Audience> Audiences
        {
            get { return _audiences  ?? (_audiences = CreateObjectSet<Audience>("Audiences")); }
        }
        private ObjectSet<Audience> _audiences;
    
        public ObjectSet<Segment> Segments
        {
            get { return _segments  ?? (_segments = CreateObjectSet<Segment>("Segments")); }
        }
        private ObjectSet<Segment> _segments;
    
        public ObjectSet<Split> Splits
        {
            get { return _splits  ?? (_splits = CreateObjectSet<Split>("Splits")); }
        }
        private ObjectSet<Split> _splits;
    
        public ObjectSet<Application> Applications
        {
            get { return _applications  ?? (_applications = CreateObjectSet<Application>("Applications")); }
        }
        private ObjectSet<Application> _applications;
    
        public ObjectSet<Placement> Placements
        {
            get { return _placements  ?? (_placements = CreateObjectSet<Placement>("Placements")); }
        }
        private ObjectSet<Placement> _placements;
    
        public ObjectSet<AudienceRuleBlockMap> AudienceRuleBlockMaps
        {
            get { return _audienceRuleBlockMaps  ?? (_audienceRuleBlockMaps = CreateObjectSet<AudienceRuleBlockMap>("AudienceRuleBlockMaps")); }
        }
        private ObjectSet<AudienceRuleBlockMap> _audienceRuleBlockMaps;
    
        public ObjectSet<PlacementApplicationMap> PlacementApplicationMaps
        {
            get { return _placementApplicationMaps  ?? (_placementApplicationMaps = CreateObjectSet<PlacementApplicationMap>("PlacementApplicationMaps")); }
        }
        private ObjectSet<PlacementApplicationMap> _placementApplicationMaps;
    
        public ObjectSet<PlacementApplicationRuleBlockMap> PlacementApplicationRuleBlockMaps
        {
            get { return _placementApplicationRuleBlockMaps  ?? (_placementApplicationRuleBlockMaps = CreateObjectSet<PlacementApplicationRuleBlockMap>("PlacementApplicationRuleBlockMaps")); }
        }
        private ObjectSet<PlacementApplicationRuleBlockMap> _placementApplicationRuleBlockMaps;
    
        public ObjectSet<RuleBlock> RuleBlocks
        {
            get { return _ruleBlocks  ?? (_ruleBlocks = CreateObjectSet<RuleBlock>("RuleBlocks")); }
        }
        private ObjectSet<RuleBlock> _ruleBlocks;
    
        public ObjectSet<RuleCategory> RuleCategories
        {
            get { return _ruleCategories  ?? (_ruleCategories = CreateObjectSet<RuleCategory>("RuleCategories")); }
        }
        private ObjectSet<RuleCategory> _ruleCategories;
    
        public ObjectSet<RuleInfo> RuleInfoes
        {
            get { return _ruleInfoes  ?? (_ruleInfoes = CreateObjectSet<RuleInfo>("RuleInfoes")); }
        }
        private ObjectSet<RuleInfo> _ruleInfoes;
    
        public ObjectSet<RuleSettings> RuleSettings1
        {
            get { return _ruleSettings1  ?? (_ruleSettings1 = CreateObjectSet<RuleSettings>("RuleSettings1")); }
        }
        private ObjectSet<RuleSettings> _ruleSettings1;
    
        public ObjectSet<RuleSettingsRuleBlockMap> RuleSettingsRuleBlockMaps
        {
            get { return _ruleSettingsRuleBlockMaps  ?? (_ruleSettingsRuleBlockMaps = CreateObjectSet<RuleSettingsRuleBlockMap>("RuleSettingsRuleBlockMaps")); }
        }
        private ObjectSet<RuleSettingsRuleBlockMap> _ruleSettingsRuleBlockMaps;
    
        public ObjectSet<SegmentRuleBlockMap> SegmentRuleBlockMaps
        {
            get { return _segmentRuleBlockMaps  ?? (_segmentRuleBlockMaps = CreateObjectSet<SegmentRuleBlockMap>("SegmentRuleBlockMaps")); }
        }
        private ObjectSet<SegmentRuleBlockMap> _segmentRuleBlockMaps;
    
        public ObjectSet<SplitRuleBlockMap> SplitRuleBlockMaps
        {
            get { return _splitRuleBlockMaps  ?? (_splitRuleBlockMaps = CreateObjectSet<SplitRuleBlockMap>("SplitRuleBlockMaps")); }
        }
        private ObjectSet<SplitRuleBlockMap> _splitRuleBlockMaps;

        #endregion
    }
}
