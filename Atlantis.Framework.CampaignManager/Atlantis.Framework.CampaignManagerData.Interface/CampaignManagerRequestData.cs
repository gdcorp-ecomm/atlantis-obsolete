using System;
using System.Collections.Generic;
using System.Data;
using Atlantis.Framework.Entity.Interface;

namespace Atlantis.Framework.CampaignManagerData.Interface
{
    public class CampaignManagerRequestData<T> : AtlantisEntityRequestData<T>
        where T : class, IAtlantisEntity, new()
    {
        public CampaignManagerRequestData()
            : base()
        {
        }

        public CampaignManagerRequestData(RepositoryAction repositoryAction, IList<T> entities, params IDataParameter[] parameters)
            : base(repositoryAction, entities, parameters)
        {
        }

        public CampaignManagerRequestData(RepositoryAction repositoryAction, IList<T> entities, Func<T, bool> whereClause)
            : base(repositoryAction, entities, whereClause)
        {
        }
    }
}
