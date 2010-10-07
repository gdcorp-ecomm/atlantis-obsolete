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
    /// Helper class that captures most of the change tracking work that needs to be done
    /// for self tracking entities.
    /// </summary>
    [DataContract(IsReference = true)]
    public class ObjectChangeTracker
    {
        private bool _isDeserializing;
        private ObjectState _objectState = ObjectState.Added;
        private bool _changeTrackingEnabled;
        private OriginalValuesDictionary _originalValues;
        private ExtendedPropertiesDictionary _extendedProperties;
        private ObjectsAddedToCollectionProperties _objectsAddedToCollections = new ObjectsAddedToCollectionProperties();
        private ObjectsRemovedFromCollectionProperties _objectsRemovedFromCollections = new ObjectsRemovedFromCollectionProperties();
          
        public event EventHandler<ObjectStateChangingEventArgs> ObjectStateChanging;
        
        protected virtual void OnObjectStateChanging(ObjectState newState)
        {
            if (ObjectStateChanging != null)
            {
                ObjectStateChanging(this, new ObjectStateChangingEventArgs() { NewState = newState });
            }
        }

        [DataMember]
        public ObjectState State
        {
            get { return _objectState; }
            set
            {
                if (_isDeserializing || _changeTrackingEnabled)
                {
                    OnObjectStateChanging(value);
                    _objectState = value;
                }
            }
        }

        public bool ChangeTrackingEnabled
        {
            get { return _changeTrackingEnabled; }
            set { _changeTrackingEnabled = value; }
        }

        /// <summary>
        /// Returns the removed objects to collection valued properties that were changed.
        /// </summary>
        [DataMember]
        public ObjectsRemovedFromCollectionProperties ObjectsRemovedFromCollectionProperties
        {
            get
            {
                if (_objectsRemovedFromCollections == null)
                {
                    _objectsRemovedFromCollections = new ObjectsRemovedFromCollectionProperties();
                }
                return _objectsRemovedFromCollections;
            }
        }

        /// <summary>
        /// Returns the original values for properties that were changed.
        /// </summary>
        [DataMember]
        public OriginalValuesDictionary OriginalValues
        {
            get
            {
                if (_originalValues == null)
                {
                    _originalValues = new OriginalValuesDictionary();
                }
                return _originalValues;
            }
        }

        /// <summary>
        /// Returns the extended property values.
        /// This includes key values for independent associations that are needed for the
        /// concurrency model in the Entity Framework
        /// </summary>
        [DataMember]
        public ExtendedPropertiesDictionary ExtendedProperties
        {
            get
            {
                if (_extendedProperties == null)
                {
                    _extendedProperties = new ExtendedPropertiesDictionary();
                }
                return _extendedProperties;
            }
        }

        /// <summary>
        /// Returns the added objects to collection valued properties that were changed.
        /// </summary>
        [DataMember]
        public ObjectsAddedToCollectionProperties ObjectsAddedToCollectionProperties
        {
            get
            {
                if (_objectsAddedToCollections == null)
                {
                    _objectsAddedToCollections = new ObjectsAddedToCollectionProperties();
                }
                return _objectsAddedToCollections;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            _isDeserializing = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            _isDeserializing = false;
        }

        /// <summary>
        /// Resets the ObjectChangeTracker to the Unchanged state and
        /// clears the original values as well as the record of changes
        /// to collection properties
        /// </summary>
        public void AcceptChanges()
        {
            OnObjectStateChanging(ObjectState.Unchanged);
            OriginalValues.Clear();
            ObjectsAddedToCollectionProperties.Clear();
            ObjectsRemovedFromCollectionProperties.Clear();
            ChangeTrackingEnabled = true;
            _objectState = ObjectState.Unchanged;
        }

        /// <summary>
        /// Captures the original value for a property that is changing.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void RecordOriginalValue(string propertyName, object value)
        {
            if (_changeTrackingEnabled && _objectState != ObjectState.Added)
            {
                if (!OriginalValues.ContainsKey(propertyName))
                {
                    OriginalValues[propertyName] = value;
                }
            }
        }

        /// <summary>
        /// Records an addition to collection valued properties on SelfTracking Entities.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void RecordAdditionToCollectionProperties(string propertyName, object value)
        {
            if (_changeTrackingEnabled)
            {
                // Add the entity back after deleting it, we should do nothing here then
                if (ObjectsRemovedFromCollectionProperties.ContainsKey(propertyName)
                    && ObjectsRemovedFromCollectionProperties[propertyName].Contains(value))
                {
                    ObjectsRemovedFromCollectionProperties[propertyName].Remove(value);
                    if (ObjectsRemovedFromCollectionProperties[propertyName].Count == 0)
                    {
                        ObjectsRemovedFromCollectionProperties.Remove(propertyName);
                    }
                    return;
                }

                if (!ObjectsAddedToCollectionProperties.ContainsKey(propertyName))
                {
                    ObjectsAddedToCollectionProperties[propertyName] = new ObjectList();
                    ObjectsAddedToCollectionProperties[propertyName].Add(value);
                }
                else
                {
                    ObjectsAddedToCollectionProperties[propertyName].Add(value);
                }
            }
        }

        /// <summary>
        /// Records a removal to collection valued properties on SelfTracking Entities.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public void RecordRemovalFromCollectionProperties(string propertyName, object value)
        {
            if (_changeTrackingEnabled)
            {
                // Delete the entity back after adding it, we should do nothing here then
                if (ObjectsAddedToCollectionProperties.ContainsKey(propertyName)
                    && ObjectsAddedToCollectionProperties[propertyName].Contains(value))
                {
                    ObjectsAddedToCollectionProperties[propertyName].Remove(value);
                    if (ObjectsAddedToCollectionProperties[propertyName].Count == 0)
                    {
                        ObjectsAddedToCollectionProperties.Remove(propertyName);
                    }
                    return;
                }

                if (!ObjectsRemovedFromCollectionProperties.ContainsKey(propertyName))
                {
                    ObjectsRemovedFromCollectionProperties[propertyName] = new ObjectList();
                    ObjectsRemovedFromCollectionProperties[propertyName].Add(value);
                }
                else
                {
                    if (!ObjectsRemovedFromCollectionProperties[propertyName].Contains(value))
                    {
                        ObjectsRemovedFromCollectionProperties[propertyName].Add(value);
                    }
                }
            }
        }
    }
}
