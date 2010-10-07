using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignUserResourceMapMetadata))]
    public partial class CampaignUserResourceMap
    {
        // custom fields 
        public string UserName
        {
            get
            {
                return UserResource.Name;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("UserName")]
        internal class CampaignUserResourceMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int CampaignUserResourceMapID;

            [Required]
            public int CampaignID;

            [Required]
            public int UserResourceID;

            [Include]
            public Campaign Campaign;
             
            [Include]
            public UserResource UserResource; 

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
