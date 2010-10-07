using System;
using System.Data.Objects;
using Atlantis.Framework.Entity.Interface.EF4;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.EF.Impl
{
    public partial class EFModelContext : ObjectContext, IObjectContext
    { 
        public EFModelContext(string connectionString) 
            : base(connectionString) 
        {
            this.DefaultContainerName = "EFModelContext";
            // Creating proxies requires the use of the ProxyDataContractResolver and
            // may allow lazy loading which can expand the loaded graph during serialization.
            ContextOptions.ProxyCreationEnabled = false;
            ContextOptions.LazyLoadingEnabled = false;
            ObjectMaterialized += new ObjectMaterializedEventHandler(HandleObjectMaterialized);
        } 

        private void HandleObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
        {
            var entity = e.Entity as IObjectWithChangeTracker;
            if (entity != null)
            {
                bool changeTrackingEnabled = entity.ChangeTracker.ChangeTrackingEnabled;
                try
                {
                    entity.MarkAsUnchanged();
                }
                finally
                {
                    entity.ChangeTracker.ChangeTrackingEnabled = changeTrackingEnabled;
                }
                this.StoreReferenceKeyValues(entity);
            }
        }
    }
}
