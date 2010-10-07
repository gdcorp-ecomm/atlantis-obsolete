using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;
using System.Runtime.Serialization;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(fbiOfferMetaData))]
    public partial class fbiOffer
    {
        [DataMember]
        [Include]
        [Association("DiscountType_fbiOffer", "discountType", "DiscountTypeName", IsForeignKey = true)]
        public DiscountType DiscountType;
        
        // metadata
        [ScaffoldTable(true)]
        internal class fbiOfferMetaData
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]            
            public int fbiOfferID; 

            [StringLength(16)]
            [DataType(DataType.Text)]            
            public string discountType;

            public int fastballDiscount;

            public int fastballOrderDiscount;

            public int ProductGroupCode;

#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
