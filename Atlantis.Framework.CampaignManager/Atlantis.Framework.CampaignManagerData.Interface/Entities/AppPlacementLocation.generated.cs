//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using Atlantis.Framework.Entity.Interface;
using Atlantis.Framework.Entity.Interface.SelfTracking;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(LocationRuleBlockMap))]
    [KnownType(typeof(MessageBlock))]
    public partial class AppPlacementLocation:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int LocationID
        {
            get { return _locationID; }
            set
            {
                if (_locationID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'LocationID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _locationID = value;
                    OnPropertyChanged("LocationID");
                }
            }
        }
        private int _locationID;
    
        [DataMember]
        public int ApplicationID
        {
            get { return _applicationID; }
            set
            {
                if (_applicationID != value)
                {
                    _applicationID = value;
                    OnPropertyChanged("ApplicationID");
                }
            }
        }
        private int _applicationID;
    
        [DataMember]
        public int PlacementID
        {
            get { return _placementID; }
            set
            {
                if (_placementID != value)
                {
                    _placementID = value;
                    OnPropertyChanged("PlacementID");
                }
            }
        }
        private int _placementID;
    
        [DataMember]
        public byte DeliveryChannelCode
        {
            get { return _deliveryChannelCode; }
            set
            {
                if (_deliveryChannelCode != value)
                {
                    _deliveryChannelCode = value;
                    OnPropertyChanged("DeliveryChannelCode");
                }
            }
        }
        private byte _deliveryChannelCode;
    
        [DataMember]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }
        private string _name;
    
        [DataMember]
        public string LocationDescription
        {
            get { return _locationDescription; }
            set
            {
                if (_locationDescription != value)
                {
                    _locationDescription = value;
                    OnPropertyChanged("LocationDescription");
                }
            }
        }
        private string _locationDescription;
    
        [DataMember]
        public System.DateTime DateAdded
        {
            get { return _dateAdded; }
            set
            {
                if (_dateAdded != value)
                {
                    _dateAdded = value;
                    OnPropertyChanged("DateAdded");
                }
            }
        }
        private System.DateTime _dateAdded;
    
        [DataMember]
        public System.DateTime DateUpdated
        {
            get { return _dateUpdated; }
            set
            {
                if (_dateUpdated != value)
                {
                    _dateUpdated = value;
                    OnPropertyChanged("DateUpdated");
                }
            }
        }
        private System.DateTime _dateUpdated;
    
        [DataMember]
        public Nullable<int> DefaultMessageBlockID
        {
            get { return _defaultMessageBlockID; }
            set
            {
                if (_defaultMessageBlockID != value)
                {
                    ChangeTracker.RecordOriginalValue("DefaultMessageBlockID", _defaultMessageBlockID);
                    if (!IsDeserializing)
                    {
                        if (MessageBlock != null && MessageBlock.MessageBlockID != value)
                        {
                            MessageBlock = null;
                        }
                    }
                    _defaultMessageBlockID = value;
                    OnPropertyChanged("DefaultMessageBlockID");
                }
            }
        }
        private Nullable<int> _defaultMessageBlockID;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<LocationRuleBlockMap> LocationRuleBlockMaps
        {
            get
            {
                if (_locationRuleBlockMaps == null)
                {
                    _locationRuleBlockMaps = new TrackableCollection<LocationRuleBlockMap>();
                    _locationRuleBlockMaps.CollectionChanged += FixupLocationRuleBlockMaps;
                }
                return _locationRuleBlockMaps;
            }
            set
            {
                if (!ReferenceEquals(_locationRuleBlockMaps, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_locationRuleBlockMaps != null)
                    {
                        _locationRuleBlockMaps.CollectionChanged -= FixupLocationRuleBlockMaps;
                    }
                    _locationRuleBlockMaps = value;
                    if (_locationRuleBlockMaps != null)
                    {
                        _locationRuleBlockMaps.CollectionChanged += FixupLocationRuleBlockMaps;
                    }
                    OnNavigationPropertyChanged("LocationRuleBlockMaps");
                }
            }
        }
        private TrackableCollection<LocationRuleBlockMap> _locationRuleBlockMaps;
    
        [DataMember]
        public MessageBlock MessageBlock
        {
            get { return _messageBlock; }
            set
            {
                if (!ReferenceEquals(_messageBlock, value))
                {
                    var previousValue = _messageBlock;
                    _messageBlock = value;
                    FixupMessageBlock(previousValue);
                    OnNavigationPropertyChanged("MessageBlock");
                }
            }
        }
        private MessageBlock _messageBlock;

        #endregion
        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            LocationRuleBlockMaps.Clear();
            MessageBlock = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupMessageBlock(MessageBlock previousValue, bool skipKeys = false)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.AppPlacementLocations.Contains(this))
            {
                previousValue.AppPlacementLocations.Remove(this);
            }
    
            if (MessageBlock != null)
            {
                if (!MessageBlock.AppPlacementLocations.Contains(this))
                {
                    MessageBlock.AppPlacementLocations.Add(this);
                }
    
                DefaultMessageBlockID = MessageBlock.MessageBlockID;
            }
            else if (!skipKeys)
            {
                DefaultMessageBlockID = null;
            }
    
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MessageBlock")
                    && (ChangeTracker.OriginalValues["MessageBlock"] == MessageBlock))
                {
                    ChangeTracker.OriginalValues.Remove("MessageBlock");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MessageBlock", previousValue);
                }
                if (MessageBlock != null && !MessageBlock.ChangeTracker.ChangeTrackingEnabled)
                {
                    MessageBlock.StartTracking();
                }
            }
        }
    
        private void FixupLocationRuleBlockMaps(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (LocationRuleBlockMap item in e.NewItems)
                {
                    item.AppPlacementLocation = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("LocationRuleBlockMaps", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (LocationRuleBlockMap item in e.OldItems)
                {
                    if (ReferenceEquals(item.AppPlacementLocation, this))
                    {
                        item.AppPlacementLocation = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("LocationRuleBlockMaps", item);
                    }
                }
            }
        }

        #endregion
    }
}
