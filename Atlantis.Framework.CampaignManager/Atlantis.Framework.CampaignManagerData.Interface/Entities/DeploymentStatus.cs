using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ServiceModel.DomainServices.Server;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [MetadataType(typeof(DeploymentStatusMetaData))]
    public partial class DeploymentStatus
    {
        // custom fields  
        private MessageInstance _messageInstance = null;

        [Association("DeploymentStatus_MessageInstance", "DeploymentStatusCode", "MessageInstanceID")]
        public MessageInstance MessageInstance
        {
            get { return _messageInstance; }
            set { _messageInstance = value; }
        }

        // metadata
        [ScaffoldTable(true)]
        internal class DeploymentStatusMetaData
        {
#pragma warning disable 649 // temporarily disable compiler warnings about unassigned fields
            [Key]
            [Required]
            [Editable(false)]
            public int DeploymentStatusCode;

            [Required]
            [StringLength(64)]
            [DataType(DataType.Text)]
            public string DeploymentStatusName;

            [Required]
            [StringLength(256)]
            [DataType(DataType.Text)]
            public string DeploymentStatusDescription;

            [Required]            
            public bool UserSelectable;
#pragma warning restore 649 // re-enable compiler warnings about unassigned fields
        }
    }
}
