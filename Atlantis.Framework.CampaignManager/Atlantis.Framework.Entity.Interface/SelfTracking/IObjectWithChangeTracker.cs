using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization; 

namespace Atlantis.Framework.Entity.Interface.SelfTracking
{
    /// <summary>
    /// The interface is implemented by the self tracking entities that EF will generate.
    /// We will have an Adapter that converts this interface to the interface that the EF expects.
    /// The Adapter will live on the server side.
    /// </summary>
    public interface IObjectWithChangeTracker : IAtlantisEntity
    {
        /// <summary>
        /// Has all the change tracking information for the subgraph of a given object.
        /// </summary>
        ObjectChangeTracker ChangeTracker { get; }
    }
}
