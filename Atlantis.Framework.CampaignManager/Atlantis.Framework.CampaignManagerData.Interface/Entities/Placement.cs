using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;
using System.ComponentModel;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(PlacementMetadata))]
    public partial class Placement
    {        
        // custom fields  
        private AppPlacementLocation _location = null;

        [Association("Placement_Location", "PlacementID", "LocationID")]
        public AppPlacementLocation Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private MessageInstance _messageInstance = null;

        [Association("Placement_MessageInstance", "PlacementID", "MessageInstanceID")]
        public MessageInstance MessageInstance
        {
            get { return _messageInstance; }
            set { _messageInstance = value; }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("Name", "Name")]
        internal class PlacementMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int PlacementID;

            [Required]
            [StringLength(50)]
            [DataType(DataType.Text)]
            [Display(Name = "Placement")]
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
