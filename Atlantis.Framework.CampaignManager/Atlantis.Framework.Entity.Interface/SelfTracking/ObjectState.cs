using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.Entity.Interface.SelfTracking
{
    [Flags]
    public enum ObjectState
    {
        Unchanged = 0x1,
        Added = 0x2,
        Modified = 0x4,
        Deleted = 0x8
    }
}
