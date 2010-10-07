using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(RuleSettingsRuleBlockMapMetadata))]
    public partial class RuleSettingsRuleBlockMap
    {
        // custom fields  
        public RuleOperatorType RuleOperatorType
        {
            get
            {
                return (RuleOperatorType)_operator;
            }
            set
            {
                _operator = (byte)value;
            }
        }

        public string RuleOperatorLabel
        {
            get
            {
                return Enum.GetName(typeof(RuleOperatorType), this.RuleOperatorType);
            } 
        }

        // metadata
        [ScaffoldTable(true)]
        internal class RuleSettingsRuleBlockMapMetadata
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int RuleSettingsRuleBlockMapID;

            [Required]
            public int RuleSettingsID;

            [Required]
            public int RuleBlockID;

            [Required]
            public byte Operator;

            [Required]
            public short Priority;

            [Include]
            [UIHint("RuleSettingsField")]
            public RuleSettings RuleSettings;

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

    public enum RuleOperatorType : byte
    {
        AND = 0,
        OR = 1,
        NOT = 2
    }
}
