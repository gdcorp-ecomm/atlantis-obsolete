using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(DeliveryChannelMetadata))]
    public partial class DeliveryChannel
    {
        // custom fields  
        // custom fields  
        private MessageInstance _messageInstance = null;

        [Association("DeliveryChannel_MessageInstance", "DeliveryChannelCode", "MessageInstanceID")]
        public MessageInstance MessageInstance
        {
            get { return _messageInstance; }
            set { _messageInstance = value; }
        }
        
        // metadata
        [ScaffoldTable(true)] 
        internal class DeliveryChannelMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public byte DeliveryChannelCode; 

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
