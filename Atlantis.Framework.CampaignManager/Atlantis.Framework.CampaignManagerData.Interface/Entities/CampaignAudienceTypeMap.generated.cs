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
    [KnownType(typeof(AudienceType))]
    [KnownType(typeof(Campaign))]
    public partial class CampaignAudienceTypeMap:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int CampaignAudienceTypeMapID
        {
            get { return _campaignAudienceTypeMapID; }
            set
            {
                if (_campaignAudienceTypeMapID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CampaignAudienceTypeMapID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _campaignAudienceTypeMapID = value;
                    OnPropertyChanged("CampaignAudienceTypeMapID");
                }
            }
        }
        private int _campaignAudienceTypeMapID;
    
        [DataMember]
        public int CampaignID
        {
            get { return _campaignID; }
            set
            {
                if (_campaignID != value)
                {
                    ChangeTracker.RecordOriginalValue("CampaignID", _campaignID);
                    if (!IsDeserializing)
                    {
                        if (Campaign != null && Campaign.CampaignID != value)
                        {
                            Campaign = null;
                        }
                    }
                    _campaignID = value;
                    OnPropertyChanged("CampaignID");
                }
            }
        }
        private int _campaignID;
    
        [DataMember]
        public int AudienceTypeID
        {
            get { return _audienceTypeID; }
            set
            {
                if (_audienceTypeID != value)
                {
                    ChangeTracker.RecordOriginalValue("AudienceTypeID", _audienceTypeID);
                    if (!IsDeserializing)
                    {
                        if (AudienceType != null && AudienceType.AudienceTypeID != value)
                        {
                            AudienceType = null;
                        }
                    }
                    _audienceTypeID = value;
                    OnPropertyChanged("AudienceTypeID");
                }
            }
        }
        private int _audienceTypeID;
    
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
        public AudienceType AudienceType
        {
            get { return _audienceType; }
            set
            {
                if (!ReferenceEquals(_audienceType, value))
                {
                    var previousValue = _audienceType;
                    _audienceType = value;
                    FixupAudienceType(previousValue);
                    OnNavigationPropertyChanged("AudienceType");
                }
            }
        }
        private AudienceType _audienceType;
    
        [DataMember]
        public Campaign Campaign
        {
            get { return _campaign; }
            set
            {
                if (!ReferenceEquals(_campaign, value))
                {
                    var previousValue = _campaign;
                    _campaign = value;
                    FixupCampaign(previousValue);
                    OnNavigationPropertyChanged("Campaign");
                }
            }
        }
        private Campaign _campaign;

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
            AudienceType = null;
            Campaign = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupAudienceType(AudienceType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CampaignAudienceTypeMaps.Contains(this))
            {
                previousValue.CampaignAudienceTypeMaps.Remove(this);
            }
    
            if (AudienceType != null)
            {
                if (!AudienceType.CampaignAudienceTypeMaps.Contains(this))
                {
                    AudienceType.CampaignAudienceTypeMaps.Add(this);
                }
    
                AudienceTypeID = AudienceType.AudienceTypeID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("AudienceType")
                    && (ChangeTracker.OriginalValues["AudienceType"] == AudienceType))
                {
                    ChangeTracker.OriginalValues.Remove("AudienceType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("AudienceType", previousValue);
                }
                if (AudienceType != null && !AudienceType.ChangeTracker.ChangeTrackingEnabled)
                {
                    AudienceType.StartTracking();
                }
            }
        }
    
        private void FixupCampaign(Campaign previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CampaignAudienceTypeMaps.Contains(this))
            {
                previousValue.CampaignAudienceTypeMaps.Remove(this);
            }
    
            if (Campaign != null)
            {
                if (!Campaign.CampaignAudienceTypeMaps.Contains(this))
                {
                    Campaign.CampaignAudienceTypeMaps.Add(this);
                }
    
                CampaignID = Campaign.CampaignID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Campaign")
                    && (ChangeTracker.OriginalValues["Campaign"] == Campaign))
                {
                    ChangeTracker.OriginalValues.Remove("Campaign");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Campaign", previousValue);
                }
                if (Campaign != null && !Campaign.ChangeTracker.ChangeTrackingEnabled)
                {
                    Campaign.StartTracking();
                }
            }
        }

        #endregion
    }
}
