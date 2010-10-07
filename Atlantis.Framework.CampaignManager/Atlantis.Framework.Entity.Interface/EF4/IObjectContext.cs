using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;

namespace Atlantis.Framework.Entity.Interface.EF4
{
    public interface IObjectContext : IDisposable
    {
        // so we can infer type
    }
}
