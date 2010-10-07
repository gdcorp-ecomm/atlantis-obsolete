using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignObjectiveMapMetadata))]
    public partial class CampaignObjectiveMap
    {
        // custom fields 
        public string ObjectiveName
        {
            get
            {
                return Objective.Name;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("ObjectiveName")]
        internal class CampaignObjectiveMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int CampaignObjectiveMapID;

            [Required]
            public int CampaignID;

            [Required]
            public int ObjectiveID;

            [Include]
            public Campaign Campaign;
             
            [Include]
            public Objective Objective; 

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
