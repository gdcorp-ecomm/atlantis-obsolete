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
        Name = "ObjectsAddedToCollectionProperties",
        ItemName = "AddedObjectsForProperty", 
        KeyName = "CollectionPropertyName", 
        ValueName = "AddedObjects")]
    public class ObjectsAddedToCollectionProperties : Dictionary<string, ObjectList> { }
}
