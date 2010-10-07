using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;
using System.Runtime.Serialization;
using System.ComponentModel;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(MessageInstanceMetadata))]
    public partial class MessageInstance
    {
        // CampaignMessage
        public CampaignMessage CampaignMessage
        {
            get { return _campaignMessage; }
            set { _campaignMessage = value; }
        }

        public string CampaignMessageName
        {
            get { return _campaignMessage.Name; }
            set { _campaignMessage.Name = value; }
        }

        private CampaignMessage _campaignMessage;

        // Application

        public Application Application
        {
            get { return _application; }
            set { _application = value; }        
        }

        [Display(Name = "Application")]
        [Editable(false)]
        public string ApplicationName
        {
            get
            {
                if (_application != null)
                    return _application.Name;
                return "";
            }
        }

        private Application _application;

        // Placement

        public Placement Placement
        {
            get { return _placement; }
            set { _placement = value; }
        }

        [Display(Name = "Placement")]
        [Editable(false)]
        public string PlacementName
        {
            get
            {
                if (_placement != null)
                    return _placement.Name;
                return "";
            }
        }

        private Placement _placement;

        // DeliveryChannel

        public DeliveryChannel DeliveryChannel
        {
            get { return _deliveryChannel;  }
            set { _deliveryChannel = value; }
        }

        [Display(Name = "Channel")]
        [Editable(false)]
        public string DeliveryChannelName
        {
            get
            {
                if (_deliveryChannel != null)
                    return _deliveryChannel.Name;
                return string.Empty;
            }
        }

        private DeliveryChannel _deliveryChannel;

        // DiscountType

        public string DiscountTypeName
        {
            get 
            {
                if (DiscountType != null)
                    return DiscountType.DiscountTypeName;
                return string.Empty;
            }
            set 
            { 
                this.DiscountType.DiscountTypeName = value; 
            } 
        }

        //[Include]
        //[Association("DiscountType_MessageInstance", "DiscountTypeName", "DiscountTypeName", IsForeignKey = true)]
        public DiscountType DiscountType
        {
            get
            {
                return _fbiOffer.DiscountType;
            }
            set 
            {
                this._fbiOffer.DiscountType = value;
            }
        }

        public string PromoCode
        {
            get
            {
                string promoCode = string.Empty;

                if (_fbiOffer != null && _fbiOffer.fastballDiscount != null)
                    promoCode = _fbiOffer.fastballDiscount.ToString();
                else if (_fbiOffer != null && _fbiOffer.fastballOrderDiscount != null)
                    promoCode = _fbiOffer.fastballOrderDiscount.ToString();

                return promoCode;
            }
        }

        public string FastballDiscount
        {
            get
            {
                if (_fbiOffer != null)
                    return _fbiOffer.fastballDiscount.ToString();
                return string.Empty;
            }
        }

        public string FastballOrderDiscount
        {
            get
            {
                if (_fbiOffer != null)
                    return _fbiOffer.fastballOrderDiscount.ToString();
                return string.Empty;
            }
        }

        public string ProductGroupCode
        {
            get
            {
                if (_fbiOffer != null)
                    return _fbiOffer.ProductGroupCode.ToString();
                return string.Empty;
            }
        }

        // Audience

        public Audience Audience
        {
            get { return _audience;  }
            set { _audience = value; }
        }

        [Display(Name = "Audience")]
        [Editable(false)]
        public string AudienceName
        {
            get
            {
                if (_audience != null)
                    return _audience.Name;
                return "";
            }
        }

        private Audience _audience;


        // DeploymentStatus

        public DeploymentStatus DeploymentStatus
        {
            get { return _deploymentStatus; }
            set { _deploymentStatus = value; }
        }

        [ReadOnly(true)]
        [Editable(false)]
        public string DeploymentStatusName
        {
            get
            {
                if (_deploymentStatus != null)
                    return _deploymentStatus.DeploymentStatusDescription;
                return "";
            }
        }

        private DeploymentStatus _deploymentStatus;

        // MessageLanguage

        [ReadOnly(true)]
        [Editable(false)]
        public string MessageLanguageName
        {
            get
            {
                if (_messageLanguage != null)
                    return _messageLanguage.LanguageDescription;
                return "";
            }
        }
        
        // metadata
        [ScaffoldTable(true)]
        internal class MessageInstanceMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int MessageInstanceID;

            [Required]
            public int CampaignMessageID;

            [Required]
            public int ApplicationID; 

            [Required]
            public int PlacementID;

            [Required]
            public int LocationID;

            [Required]
            public int AudienceID;

            [Required]
            public int SegmentID;

            [Required]
            public int SplitID;

            public Nullable<int> MessageBlockID;

            [Display]
            [Include]
            [Association("MessageInstance_CampaignMessage", "CampaignMessageID", "CampaignMessageID")]
            public CampaignMessage CampaignMessage; 

            [Display]
            [Include]
            public MessageBlock MessageBlock;

            [Display]
            [Include]            
            public fbiOffer fbiOffer;

            [DataMember]
            [Display]
            [Include]
            [Association("Application_MessageInstance", "ApplicationID", "ApplicationID", IsForeignKey = true)]
            public Application Application;

            [DataMember]
            [Display]
            [Include]
            [Association("Placement_MessageInstance", "PlacementID", "PlacementID", IsForeignKey = true)]
            public Placement Placement;

            [DataMember]
            [Display]
            [Include]
            [Association("DeliveryChannel_MessageInstance", "DeliveryChannelCode", "DeliveryChannelCode", IsForeignKey = true)]
            public DeliveryChannel DeliveryChannel;

            [DataMember]
            [Display]
            [Include]
            [Association("DeploymentStatus_MessageInstance", "DeploymentStatusCode", "DeploymentStatusCode", IsForeignKey = true)]
            public DeploymentStatus DeploymentStatus;

            [DataMember]
            [Display]
            [Include]
            [Association("MessageLanguage_MessageInstance", "LanguageCode", "LanguageCode", IsForeignKey = true)]
            public MessageLanguage MessageLanguage;

            [DataMember]
            [Display]
            [Include]
            [Association("Audience_MessageInstance", "AudienceID", "AudienceID", IsForeignKey = true)]
            public Audience Audience;

            [Required]
            [Editable(false)]
            [DataType(DataType.DateTime)]
            public DateTime DateAdded;

            [Required]
            [Editable(false)]
            [DataType(DataType.DateTime)]
            public DateTime DateUpdated;
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}