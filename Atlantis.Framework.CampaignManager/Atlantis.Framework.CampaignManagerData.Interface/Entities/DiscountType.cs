using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(DiscountTypeMetaData))]
    public partial class DiscountType
    {
        // custom fields  

        //[Include]
        //[Association("DiscountType_MessageInstance", "DiscountTypeName", "MessageInstanceID")]
        //public IList<Campaign> Campaigns { get; set; }

        [Include]
        [Association("DiscountType_fbiOffer", "DiscountTypeName", "fbiOfferID")]
        public fbiOffer fbiOffer
        {
            get { return _fbiOffer; }
            set { _fbiOffer = value; }
        }

        private fbiOffer _fbiOffer = null;


        // metadata
        [ScaffoldTable(true)]
        internal class DiscountTypeMetaData
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int DiscountTypeName;

            [Required]
            [StringLength(256)]
            [DataType(DataType.Text)]
            public string DiscountTypeDescription;
            
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
