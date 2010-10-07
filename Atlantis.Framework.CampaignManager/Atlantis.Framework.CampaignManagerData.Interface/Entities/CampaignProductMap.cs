using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignProductMapMetadata))]
    public partial class CampaignProductMap
    {
        // custom fields 
        public string ProductName
        {
            get
            {
                return Product.Name;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("ProductName")]
        internal class CampaignProductMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int CampaignProductMapID;

            [Required]
            public int CampaignID;

            [Required]
            public int ProductID;

            [Include]
            public Campaign Campaign;
             
            [Include]
            public Product Product; 

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
