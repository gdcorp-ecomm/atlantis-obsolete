using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;
using System.Runtime.Serialization;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(AppPlacementLocationMetadata))]
    public partial class AppPlacementLocation
    {
        // custom fields
        public Application Application
        {
            get { return _application; }
            set { _application = value; }
        }

        private Application _application;

        public Placement Placement
        {
            get { return _placement; }
            set { _placement = value; }
        }

        public string PlacementName
        {
            get { return _placement.Name; }
            set { _placement.Name = value; }
        }

        private Placement _placement;

        public DeliveryChannel DeliveryChannel
        {
            get { return _deliveryChannel; }
            set { _deliveryChannel = value; }
        }
        private DeliveryChannel _deliveryChannel;

        public string LocationApplicationPlacementIDs
        {
            get
            {
                return LocationID + ":" + Application.ApplicationID + ":" + Placement.PlacementID;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        internal class AppPlacementLocationMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int ApplicationID;

            [Key]
            [Required]
            [Editable(false)]
            public int PlacementID;

            [Key]
            [Required]
            [Editable(false)]
            public int LocationID;

            [Display]
            [Include]
            [Association("Application_Location", "ApplicationID", "ApplicationID", IsForeignKey = true)]
            public Application Application;

            [Display]
            [Include]
            [Association("Placement_Location", "PlacementID", "PlacementID", IsForeignKey = true)]
            public Placement Placement;

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
