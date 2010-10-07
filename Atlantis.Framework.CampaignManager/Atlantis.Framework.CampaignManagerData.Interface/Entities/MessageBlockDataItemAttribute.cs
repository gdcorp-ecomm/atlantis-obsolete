using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(MessageBlockDataItemAttributeMetadata))]
    public partial class MessageBlockDataItemAttribute
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        internal class MessageBlockDataItemAttributeMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int MessageBlockDataItemAttributeID; 

            [Required]
            [Editable(false)]
            [DataType(DataType.DateTime)]
            public DateTime DateAdded;
            
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
