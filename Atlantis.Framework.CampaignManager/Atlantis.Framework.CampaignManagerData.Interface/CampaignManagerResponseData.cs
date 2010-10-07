using Atlantis.Framework.Entity.Interface;

namespace Atlantis.Framework.CampaignManagerData.Interface
{
    public class CampaignManagerResponseData<T> : AtlantisEntityResponseData<T>
        where T : class, IAtlantisEntity, new()
    { 
        
    }
}
