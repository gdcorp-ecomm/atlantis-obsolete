using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(MessageBlockDataItemMetadata))]
    public partial class MessageBlockDataItem
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        internal class MessageBlockDataItemMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int MessageBlockDataItemID; 

            [Required]
            [Editable(false)]
            [DataType(DataType.DateTime)]
            public DateTime DateAdded;
            
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
