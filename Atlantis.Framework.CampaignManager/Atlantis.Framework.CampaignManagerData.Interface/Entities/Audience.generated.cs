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
    [KnownType(typeof(Campaign))]
    [KnownType(typeof(AudienceRuleBlockMap))]
    [KnownType(typeof(Segment))]
    public partial class Audience:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int AudienceID
        {
            get { return _audienceID; }
            set
            {
                if (_audienceID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'AudienceID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _audienceID = value;
                    OnPropertyChanged("AudienceID");
                }
            }
        }
        private int _audienceID;
    
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
        public string AudienceDescription
        {
            get { return _audienceDescription; }
            set
            {
                if (_audienceDescription != value)
                {
                    _audienceDescription = value;
                    OnPropertyChanged("AudienceDescription");
                }
            }
        }
        private string _audienceDescription;
    
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
    
        [DataMember]
        public TrackableCollection<AudienceRuleBlockMap> AudienceRuleBlockMaps
        {
            get
            {
                if (_audienceRuleBlockMaps == null)
                {
                    _audienceRuleBlockMaps = new TrackableCollection<AudienceRuleBlockMap>();
                    _audienceRuleBlockMaps.CollectionChanged += FixupAudienceRuleBlockMaps;
                }
                return _audienceRuleBlockMaps;
            }
            set
            {
                if (!ReferenceEquals(_audienceRuleBlockMaps, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_audienceRuleBlockMaps != null)
                    {
                        _audienceRuleBlockMaps.CollectionChanged -= FixupAudienceRuleBlockMaps;
                    }
                    _audienceRuleBlockMaps = value;
                    if (_audienceRuleBlockMaps != null)
                    {
                        _audienceRuleBlockMaps.CollectionChanged += FixupAudienceRuleBlockMaps;
                    }
                    OnNavigationPropertyChanged("AudienceRuleBlockMaps");
                }
            }
        }
        private TrackableCollection<AudienceRuleBlockMap> _audienceRuleBlockMaps;
    
        [DataMember]
        public TrackableCollection<Segment> Segments
        {
            get
            {
                if (_segments == null)
                {
                    _segments = new TrackableCollection<Segment>();
                    _segments.CollectionChanged += FixupSegments;
                }
                return _segments;
            }
            set
            {
                if (!ReferenceEquals(_segments, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_segments != null)
                    {
                        _segments.CollectionChanged -= FixupSegments;
                    }
                    _segments = value;
                    if (_segments != null)
                    {
                        _segments.CollectionChanged += FixupSegments;
                    }
                    OnNavigationPropertyChanged("Segments");
                }
            }
        }
        private TrackableCollection<Segment> _segments;

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
            Campaign = null;
            AudienceRuleBlockMaps.Clear();
            Segments.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupCampaign(Campaign previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Audiences.Contains(this))
            {
                previousValue.Audiences.Remove(this);
            }
    
            if (Campaign != null)
            {
                if (!Campaign.Audiences.Contains(this))
                {
                    Campaign.Audiences.Add(this);
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
    
        private void FixupAudienceRuleBlockMaps(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (AudienceRuleBlockMap item in e.NewItems)
                {
                    item.Audience = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("AudienceRuleBlockMaps", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (AudienceRuleBlockMap item in e.OldItems)
                {
                    if (ReferenceEquals(item.Audience, this))
                    {
                        item.Audience = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("AudienceRuleBlockMaps", item);
                    }
                }
            }
        }
    
        private void FixupSegments(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (Segment item in e.NewItems)
                {
                    item.Audience = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("Segments", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Segment item in e.OldItems)
                {
                    if (ReferenceEquals(item.Audience, this))
                    {
                        item.Audience = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("Segments", item);
                    }
                }
            }
        }

        #endregion
    }
}
