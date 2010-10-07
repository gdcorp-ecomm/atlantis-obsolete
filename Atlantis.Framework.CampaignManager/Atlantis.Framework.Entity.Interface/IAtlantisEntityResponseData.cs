using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.Entity.Interface
{
    public interface IAtlantisEntityResponseData<T> : IResponseData
        where T : class, IAtlantisEntity, new()
    {
        AtlantisException Exception { get; }
        ICollection<T> Entities { get; set; }
        int EntityCount { get; }
        bool HasExactlyOneEntity { get; }
    }
}