using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.Entity.Interface
{
    public interface IAtlantisEntityRequest<T> : IRequest, IAtlantisRepository<T>
        where T : class, IAtlantisEntity, new()
    {
        IAtlantisEntityRequestData<T> CurrentRequestData { get; }
        ConfigElement Config { get; }
        IResponseData ExecuteRepositoryAction(RequestData oRequestData, ConfigElement oConfig); 
    }
}