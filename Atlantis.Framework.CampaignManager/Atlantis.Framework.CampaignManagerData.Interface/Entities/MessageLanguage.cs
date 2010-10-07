using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(MessageLanguageMetadata))]
    public partial class MessageLanguage
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        internal class MessageLanguageMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public byte LanguageCode; 

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
