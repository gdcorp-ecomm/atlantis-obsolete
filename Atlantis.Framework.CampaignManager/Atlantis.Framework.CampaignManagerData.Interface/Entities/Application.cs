﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(ApplicationMetadata))]
    public partial class Application
    {
        private AppPlacementLocation _location = null;

        [Association("Application_Location", "ApplicationID", "LocationID")]
        public AppPlacementLocation Location
        {
            get { return _location; }
            set { _location = value; }
        }

        private MessageInstance _messageInstance = null;

        [Association("Application_MessageInstance", "ApplicationID", "MessageInstanceID")]
        public MessageInstance MessageInstance      
        {
            get { return _messageInstance; }
            set { _messageInstance = value; }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("Name", "Name")]
        internal class ApplicationMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int ApplicationID;

            [Required]
            [StringLength(50)]
            [DataType(DataType.Text)]
            public string AppKey;

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
