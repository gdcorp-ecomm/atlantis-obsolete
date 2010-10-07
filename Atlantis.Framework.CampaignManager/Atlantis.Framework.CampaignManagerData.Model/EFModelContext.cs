using System;
using System.Data.EntityClient;
using System.Data.Objects;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;

namespace Atlantis.Framework.CampaignManagerData.Model
{
    public partial class EFModelContext 
    {
        public static string Metadata
        {
            get
            {
                return string.Format(
                    "res://{0}/Model.csdl|res://{0}/Model.ssdl|res://{0}/Model.msl",
                    typeof(EFModelContext).Assembly.FullName);
            }
        }
	}
}
