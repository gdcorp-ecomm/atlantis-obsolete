using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignMessageMetadata))]
    public partial class CampaignMessage
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("Name", "Name")]
        internal class CampaignMessageMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int CampaignMessageID;

            [Required] 
            public int CampaignID;

            [Display]
            [Include]
            public Campaign Campaign;

            [Required]
            [StringLength(50)]
            [DataType(DataType.Text)]
            public string Name;

            [DataType(DataType.Text)]
            public string CampaignMessageDescription; 

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
