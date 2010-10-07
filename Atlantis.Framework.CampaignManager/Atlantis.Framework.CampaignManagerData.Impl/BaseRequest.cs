using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Atlantis.Framework.Entity.Interface;
using Atlantis.Framework.Entity.Interface.ADO;
using Atlantis.Framework.Interface;
using System.Linq.Expressions;

namespace Atlantis.Framework.CampaignManagerData.Impl
{
    public abstract class BaseRequest<T> : ADOEntityRequest<T>
        where T : class, IAtlantisEntity, new()
    {
        public BaseRequest()
        {

        }

        public override IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
        {
            return this.ExecuteRepositoryAction(oRequestData, oConfig);
        }

        public override IResponseData ExecuteRepositoryAction(RequestData oRequestData, ConfigElement oConfig)
        {
            return base.ExecuteRepositoryAction(oRequestData, oConfig);
        }

        public override ICollection<T> Query()
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> Query(params IDataParameter[] parameters)
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> Query(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override ICollection<T> Query(Expression expression)
        {
            throw new NotImplementedException();
        }

        public override T Single(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override void Insert(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public override void Update(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public override void Delete(ICollection<T> entities)
        {
            throw new NotImplementedException();
        }

        public override abstract T Materialize(DataRow row);
    }    

    public enum RequestTypes : int
    {
        AudienceTypeRequest = 5000,
        CampaignRequest = 5001,
        CampaignStatusTypeRequest = 5002,
        CampaignTypeRequest = 5003,
        CompanyRequest = 5004,
        ObjectiveRequest = 5005,
        OfferTypeRequest = 5006,
        ProductRequest = 5007,
        UserResourceRequest = 5008,
    }
}
