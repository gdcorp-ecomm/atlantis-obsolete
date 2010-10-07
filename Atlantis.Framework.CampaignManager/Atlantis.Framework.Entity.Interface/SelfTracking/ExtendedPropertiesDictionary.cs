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
        Name = "ExtendedPropertiesDictionary",
        ItemName = "ExtendedProperties", 
        KeyName = "Name", 
        ValueName = "ExtendedProperty")]
    public class ExtendedPropertiesDictionary : Dictionary<string, Object> { }
}
