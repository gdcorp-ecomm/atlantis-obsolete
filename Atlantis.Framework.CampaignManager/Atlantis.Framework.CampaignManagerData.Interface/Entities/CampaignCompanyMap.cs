using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(CampaignCompanyMapMetadata))]
    public partial class CampaignCompanyMap
    {
        // custom fields 
        public string CompanyName
        {
            get
            {
                return Company.Name;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        [DisplayColumn("CompanyName")]
        internal class CampaignCompanyMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int CampaignCompanyMapID;

            [Required]
            public int CampaignID;

            [Required]
            public int CompanyID;

            [Include]
            public Campaign Campaign;
             
            [Include]
            public Company Company; 

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
