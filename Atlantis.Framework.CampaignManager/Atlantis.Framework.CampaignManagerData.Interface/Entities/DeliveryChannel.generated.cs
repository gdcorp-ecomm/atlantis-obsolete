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
    [KnownType(typeof(Application))]
    [KnownType(typeof(Placement))]
    public partial class DeliveryChannel:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public byte DeliveryChannelCode
        {
            get { return _deliveryChannelCode; }
            set
            {
                if (_deliveryChannelCode != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'DeliveryChannelCode' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
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
        public string ChannelDescription
        {
            get { return _channelDescription; }
            set
            {
                if (_channelDescription != value)
                {
                    _channelDescription = value;
                    OnPropertyChanged("ChannelDescription");
                }
            }
        }
        private string _channelDescription;
    
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

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public TrackableCollection<Application> Applications
        {
            get
            {
                if (_applications == null)
                {
                    _applications = new TrackableCollection<Application>();
                    _applications.CollectionChanged += FixupApplications;
                }
                return _applications;
            }
            set
            {
                if (!ReferenceEquals(_applications, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_applications != null)
                    {
                        _applications.CollectionChanged -= FixupApplications;
                    }
                    _applications = value;
                    if (_applications != null)
                    {
                        _applications.CollectionChanged += FixupApplications;
                    }
                    OnNavigationPropertyChanged("Applications");
                }
            }
        }
        private TrackableCollection<Application> _applications;
    
        [DataMember]
        public TrackableCollection<Placement> Placements
        {
            get
            {
                if (_placements == null)
                {
                    _placements = new TrackableCollection<Placement>();
                    _placements.CollectionChanged += FixupPlacements;
                }
                return _placements;
            }
            set
            {
                if (!ReferenceEquals(_placements, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_placements != null)
                    {
                        _placements.CollectionChanged -= FixupPlacements;
                    }
                    _placements = value;
                    if (_placements != null)
                    {
                        _placements.CollectionChanged += FixupPlacements;
                    }
                    OnNavigationPropertyChanged("Placements");
                }
            }
        }
        private TrackableCollection<Placement> _placements;

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
            Applications.Clear();
            Placements.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupApplications(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Application item in e.NewItems)
                {
                    item.DeliveryChannel = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Applications", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Application item in e.OldItems)
                {
                    if (ReferenceEquals(item.DeliveryChannel, this))
                    {
                        item.DeliveryChannel = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Applications", item);
                    }
                }
            }
        }
    
        private void FixupPlacements(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Placement item in e.NewItems)
                {
                    item.DeliveryChannel = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Placements", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Placement item in e.OldItems)
                {
                    if (ReferenceEquals(item.DeliveryChannel, this))
                    {
                        item.DeliveryChannel = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Placements", item);
                    }
                }
            }
        }

        #endregion
    }
}