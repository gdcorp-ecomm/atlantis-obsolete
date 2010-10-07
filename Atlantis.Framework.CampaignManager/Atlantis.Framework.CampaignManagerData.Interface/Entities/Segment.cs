using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(SegmentMetadata))]
    public partial class Segment
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("Name", "Name")]
        internal class SegmentMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            [Display(Name = "Segment #")]
            public int SegmentID; 

            [Required]
            [StringLength(50)]
            [DataType(DataType.Text)]
            public string Name;

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
