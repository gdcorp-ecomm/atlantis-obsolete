using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization; 

namespace Atlantis.Framework.Entity.Interface.SelfTracking
{
    [CollectionDataContract(
        Name = "ObjectsRemovedFromCollectionProperties",
        ItemName = "DeletedObjectsForProperty", 
        KeyName = "CollectionPropertyName", 
        ValueName = "DeletedObjects")]
    public class ObjectsRemovedFromCollectionProperties : Dictionary<string, ObjectList> { }
}
