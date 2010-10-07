﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(AudienceRuleBlockMapMetadata))]
    public partial class AudienceRuleBlockMap
    {
        // custom fields  
        public string RuleBlockOperatorName {
            get
            {
                return RuleBlock.RuleOperatorLabel;
            }
        }

        // metadata
        [ScaffoldTable(true)]
        internal class AudienceRuleBlockMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int AudienceRuleBlockMapID;

            [Required]
            public int AudienceID;

            [Required]
            public int RuleBlockID;

            [Include]
            public Audience Audience;
             
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
