using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(AudienceMetadata))]
    public partial class Audience
    {
        // custom fields  
        private MessageInstance _messageInstance = null;

        [Association("Audience_MessageInstance", "AudienceID", "MessageInstanceID")]
        public MessageInstance MessageInstance
        {
            get { return _messageInstance; }
            set { _messageInstance = value; }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("Name", "Name")]
        internal class AudienceMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            [Display(Name = "Audience #")]
            public int AudienceID; 

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
