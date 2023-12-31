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
    [KnownType(typeof(DeliveryChannel))]
    public partial class Application:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int ApplicationID
        {
            get { return _applicationID; }
            set
            {
                if (_applicationID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'ApplicationID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _applicationID = value;
                    OnPropertyChanged("ApplicationID");
                }
            }
        }
        private int _applicationID;
    
        [DataMember]
        public string AppKey
        {
            get { return _appKey; }
            set
            {
                if (_appKey != value)
                {
                    _appKey = value;
                    OnPropertyChanged("AppKey");
                }
            }
        }
        private string _appKey;
    
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
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;
    
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
        public byte DeliveryChannelCode
        {
            get { return _deliveryChannelCode; }
            set
            {
                if (_deliveryChannelCode != value)
                {
                    ChangeTracker.RecordOriginalValue("DeliveryChannelCode", _deliveryChannelCode);
                    if (!IsDeserializing)
                    {
                        if (DeliveryChannel != null && DeliveryChannel.DeliveryChannelCode != value)
                        {
                            DeliveryChannel = null;
                        }
                    }
                    _deliveryChannelCode = value;
                    OnPropertyChanged("DeliveryChannelCode");
                }
            }
        }
        private byte _deliveryChannelCode;

        #endregion
        #region Navigation Properties
    
        [DataMember]
        public DeliveryChannel DeliveryChannel
        {
            get { return _deliveryChannel; }
            set
            {
                if (!ReferenceEquals(_deliveryChannel, value))
                {
                    var previousValue = _deliveryChannel;
                    _deliveryChannel = value;
                    FixupDeliveryChannel(previousValue);
                    OnNavigationPropertyChanged("DeliveryChannel");
                }
            }
        }
        private DeliveryChannel _deliveryChannel;

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
            DeliveryChannel = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupDeliveryChannel(DeliveryChannel previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Applications.Contains(this))
            {
                previousValue.Applications.Remove(this);
            }
    
            if (DeliveryChannel != null)
            {
                if (!DeliveryChannel.Applications.Contains(this))
                {
                    DeliveryChannel.Applications.Add(this);
                }
    
                DeliveryChannelCode = DeliveryChannel.DeliveryChannelCode;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("DeliveryChannel")
                    && (ChangeTracker.OriginalValues["DeliveryChannel"] == DeliveryChannel))
                {
                    ChangeTracker.OriginalValues.Remove("DeliveryChannel");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("DeliveryChannel", previousValue);
                }
                if (DeliveryChannel != null && !DeliveryChannel.ChangeTracker.ChangeTrackingEnabled)
                {
                    DeliveryChannel.StartTracking();
                }
            }
        }

        #endregion
    }
}
