using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization; 

namespace Atlantis.Framework.Entity.Interface.SelfTracking
{
    // An interface that provides an event that fires when complex properties change.
    // Changes can be the replacement of a complex property with a new complex type instance or
    // a change to a scalar property within a complex type instance.
    public interface INotifyComplexPropertyChanging
    {
        event EventHandler ComplexPropertyChanging;
    }
}
