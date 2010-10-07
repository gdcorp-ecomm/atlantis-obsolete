using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(SplitRuleBlockMapMetadata))]
    public partial class SplitRuleBlockMap
    {
        // custom fields  

        // metadata
        [ScaffoldTable(true)]
        internal class SplitRuleBlockMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int SplitRuleBlockMapID;

            [Required]
            public int SplitID;

            [Required]
            public int RuleBlockID;

            [Include]
            public Split Split;
             
            [Include]
            public RuleBlock RuleBlock; 

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
