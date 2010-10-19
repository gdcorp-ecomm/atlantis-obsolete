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
    [KnownType(typeof(RuleInfo))]
    [KnownType(typeof(RuleSettingsRuleBlockMap))]
    public partial class RuleSettings:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int RuleSettingsID
        {
            get { return _ruleSettingsID; }
            set
            {
                if (_ruleSettingsID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'RuleSettingsID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _ruleSettingsID = value;
                    OnPropertyChanged("RuleSettingsID");
                }
            }
        }
        private int _ruleSettingsID;
    
        [DataMember]
        public int RuleInfoID
        {
            get { return _ruleInfoID; }
            set
            {
                if (_ruleInfoID != value)
                {
                    ChangeTracker.RecordOriginalValue("RuleInfoID", _ruleInfoID);
                    if (!IsDeserializing)
                    {
                        if (RuleInfo != null && RuleInfo.RuleInfoID != value)
                        {
                            RuleInfo = null;
                        }
                    }
                    _ruleInfoID = value;
                    OnPropertyChanged("RuleInfoID");
                }
            }
        }
        private int _ruleInfoID;
    
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
        public string SettingsAsJSON
        {
            get { return _settingsAsJSON; }
            set
            {
                if (_settingsAsJSON != value)
                {
                    _settingsAsJSON = value;
                    OnPropertyChanged("SettingsAsJSON");
                }
            }
        }
        private string _settingsAsJSON;
    
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
        public RuleInfo RuleInfo
        {
            get { return _ruleInfo; }
            set
            {
                if (!ReferenceEquals(_ruleInfo, value))
                {
                    var previousValue = _ruleInfo;
                    _ruleInfo = value;
                    FixupRuleInfo(previousValue);
                    OnNavigationPropertyChanged("RuleInfo");
                }
            }
        }
        private RuleInfo _ruleInfo;
    
        [DataMember]
        public TrackableCollection<RuleSettingsRuleBlockMap> RuleSettingsRuleBlockMaps
        {
            get
            {
                if (_ruleSettingsRuleBlockMaps == null)
                {
                    _ruleSettingsRuleBlockMaps = new TrackableCollection<RuleSettingsRuleBlockMap>();
                    _ruleSettingsRuleBlockMaps.CollectionChanged += FixupRuleSettingsRuleBlockMaps;
                }
                return _ruleSettingsRuleBlockMaps;
            }
            set
            {
                if (!ReferenceEquals(_ruleSettingsRuleBlockMaps, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_ruleSettingsRuleBlockMaps != null)
                    {
                        _ruleSettingsRuleBlockMaps.CollectionChanged -= FixupRuleSettingsRuleBlockMaps;
                    }
                    _ruleSettingsRuleBlockMaps = value;
                    if (_ruleSettingsRuleBlockMaps != null)
                    {
                        _ruleSettingsRuleBlockMaps.CollectionChanged += FixupRuleSettingsRuleBlockMaps;
                    }
                    OnNavigationPropertyChanged("RuleSettingsRuleBlockMaps");
                }
            }
        }
        private TrackableCollection<RuleSettingsRuleBlockMap> _ruleSettingsRuleBlockMaps;

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
            RuleInfo = null;
            RuleSettingsRuleBlockMaps.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupRuleInfo(RuleInfo previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RuleSettings.Contains(this))
            {
                previousValue.RuleSettings.Remove(this);
            }
    
            if (RuleInfo != null)
            {
                if (!RuleInfo.RuleSettings.Contains(this))
                {
                    RuleInfo.RuleSettings.Add(this);
                }
    
                RuleInfoID = RuleInfo.RuleInfoID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("RuleInfo")
                    && (ChangeTracker.OriginalValues["RuleInfo"] == RuleInfo))
                {
                    ChangeTracker.OriginalValues.Remove("RuleInfo");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("RuleInfo", previousValue);
                }
                if (RuleInfo != null && !RuleInfo.ChangeTracker.ChangeTrackingEnabled)
                {
                    RuleInfo.StartTracking();
                }
            }
        }
    
        private void FixupRuleSettingsRuleBlockMaps(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (RuleSettingsRuleBlockMap item in e.NewItems)
                {
                    item.RuleSettings = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("RuleSettingsRuleBlockMaps", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RuleSettingsRuleBlockMap item in e.OldItems)
                {
                    if (ReferenceEquals(item.RuleSettings, this))
                    {
                        item.RuleSettings = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("RuleSettingsRuleBlockMaps", item);
                    }
                }
            }
        }

        #endregion
    }
}