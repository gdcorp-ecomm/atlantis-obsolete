using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(ProductGroupMetaData))]
    public partial class ProductGroup
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        internal class ProductGroupMetaData
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int ProductGroupCode;

            [Required]
            [StringLength(64)]
            [DataType(DataType.Text)]
            public string ProductGroupName;

            [Required]
            [StringLength(256)]
            [DataType(DataType.Text)]
            public string ProductGroupDescription;
            
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
