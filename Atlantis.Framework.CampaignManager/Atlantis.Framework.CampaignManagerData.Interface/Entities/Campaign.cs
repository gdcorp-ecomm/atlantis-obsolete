using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ServiceModel.DomainServices.Server;
using System.Text;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignMetadata))]
    public partial class Campaign
    {
        // custom fields 
        [Display(Name = "Owner")]
        [ReadOnly(true)]
        [Editable(false)]
        public string OwnerName
        {
            get
            {
                if (_owner != null)
                    return _owner.Name;
                return "";
            }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string OfferTypeName
        {
            get
            {
                if (_offerType != null)
                    return _offerType.Name;
                return string.Empty;
            }
        } 

        [ReadOnly(true)]
        [Editable(false)]
        public string KeyWithParenthesis
        {
            get
            {
                if (Key != null)
                    return string.Format("({0})", Key);
                return string.Empty;
            }
        }

        [Display(Name = "Type")]
        [ReadOnly(true)]
        [Editable(false)]
        public string CampaignTypeName
        {
            get
            {
                if (_campaignType != null)
                    return _campaignType.Name;
                return "";
            }
        }

        [Display(Name = "Status")]
        [ReadOnly(true)]
        [Editable(false)]
        public string CampaignStatusTypeName
        {
            get
            {
                if (_campaignStatusType != null)
                    return _campaignStatusType.Name;
                return "";
            }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string ObjectiveList
        {
            get
            {
                if(CampaignObjectiveMaps.Count > 0)
                    return string.Join(", ", CampaignObjectiveMaps.Select(x => x.Objective.Name.ToString()).ToArray());

                return string.Empty;
            }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string ProductsList
        {
            get
            {
                if (CampaignProductMaps.Count > 0)
                    return string.Join(", ", CampaignProductMaps.Select(x => x.Product.Name.ToString()).ToArray());

                return string.Empty;
            }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string EstimatedRevenue
        {
            get
            {
                return string.Empty;
            }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string DeliveryChannels
        {
            get
            {
                return string.Empty;
            }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string AudienceList
        {
            get
            {
                if (CampaignAudienceTypeMaps.Count > 0)
                    return string.Join(", ", CampaignAudienceTypeMaps.Select(x => x.AudienceType.Name.ToString()).ToArray());

                return string.Empty;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("Key", "Name")]
        internal class CampaignMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            [Display(AutoGenerateField = true, Name = "campaign_guid")]
            public int CampaignID;

            [StringLength(16)] // cygnus takes only upto 16 chars
            [Display(Name = "Campaign #")]
            [DefaultValue("yyyymmxxxx")]
            public string Key;

            [Required]
            [StringLength(150)]
            [DataType(DataType.Text)]
            [Display(Name = "Campaign Name")]
            public string Name;

            [StringLength(1500)]
            [DataType(DataType.MultilineText)]
            public string Description;

            [Required]
            public byte CampaignTypeID;

            [Display(Name = "Campaign Type")]
            [DefaultValue("One-time predefined")]
            [Include]
            public CampaignType CampaignType;

            [Required]
            public int CampaignStatusTypeID;

            [Display(Name = "Offer Type", AutoGenerateFilter=false)]
            [Include]
            public OfferType OfferType;
            
            [Display(Name = "Status")]
            [DefaultValue("Open")]
            [Include]
            public CampaignStatusType CampaignStatusType;

            [StringLength(1500)]
            [DataType(DataType.Text)]
            public string OfferDescription;

            [Required]
            public int OwnerID;

            [StringLength(50)]
            [Display(Name = "Owner")]
            public UserResource Owner;

            [DataType(DataType.Currency)]
            [UIHint("Money")] 
            [Range(0, 999999999999999)]
            [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
            public decimal? Cost;

            [StringLength(2)]            
            [UIHint("ValuesList")]
            [ValuesList("P1,P2")]
            public string Priority;

            [UIHint("ValuesList")]
            [Range (1, 100)]
            public byte PriorityScore;

            [UIHint("Boolean")]
            [ScaffoldColumn(false)]
            public bool AddToCygnus;

            [Required]
            [ScaffoldColumn(false)]
            public bool Disabled;

            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "Target Date")]            
            public DateTime? TargetDate;

            [DataType(DataType.DateTime)]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
            [Display(Name = "End Date")]
            public DateTime? EndDate;

            [StringLength(150)]
            [DataType(DataType.Text)]
            [MercuryItemValidationAttribute(ErrorMessage = "Value entered for Mercury ID(s) field is not valid")]
            public string MercuryIDList;

            [Display(Name = "Target Companies")]
            [Include]
            [ManyToManyRequiredAttribute(ErrorMessage = "Please select one")]
            [UIHint("ManyToMany")]
            public ICollection<CampaignCompanyMap> CampaignCompanyMaps;

            [Display(Name = "Campaign Objectives")]
            [Include]
            [UIHint("ManyToMany")]
            public ICollection<CampaignObjectiveMap> CampaignObjectiveMaps;

            [Display(Name = "Target Products")]
            [Include]
            [UIHint("ManyToMany")]
            public ICollection<CampaignProductMap> CampaignProductMaps;

            [Display(Name = "Target Audience")]
            [Include]
            [UIHint("ManyToMany")]
            public ICollection<CampaignAudienceTypeMap> CampaignAudienceTypeMaps;

            [Display(Name = "Assigned Resources")]
            [Include]
            [UIHint("ManyToMany")]
            public ICollection<CampaignUserResourceMap> CampaignUserResourceMaps; 
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
