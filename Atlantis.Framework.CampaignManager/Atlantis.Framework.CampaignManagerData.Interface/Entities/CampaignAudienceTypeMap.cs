using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignAudienceTypeMapMetadata))]
    public partial class CampaignAudienceTypeMap
    {
        // custom fields 
        public string AudienceTypeName
        {
            get
            {
                return AudienceType.Name;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("AudienceTypeName")]
        internal class CampaignAudienceTypeMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int CampaignAudienceTypeMapID;

            [Required]
            public int CampaignID;

            [Required]
            public int AudienceTypeID;

            [Include]
            public Campaign Campaign;
             
            [Include]
            public AudienceType AudienceType; 

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
