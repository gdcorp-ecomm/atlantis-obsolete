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
    [KnownType(typeof(RuleCategory))]
    [KnownType(typeof(RuleSettings))]
    public partial class RuleInfo:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int RuleInfoID
        {
            get { return _ruleInfoID; }
            set
            {
                if (_ruleInfoID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'RuleInfoID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _ruleInfoID = value;
                    OnPropertyChanged("RuleInfoID");
                }
            }
        }
        private int _ruleInfoID;
    
        [DataMember]
        public int RuleCategoryID
        {
            get { return _ruleCategoryID; }
            set
            {
                if (_ruleCategoryID != value)
                {
                    ChangeTracker.RecordOriginalValue("RuleCategoryID", _ruleCategoryID);
                    if (!IsDeserializing)
                    {
                        if (RuleCategory != null && RuleCategory.RuleCategoryID != value)
                        {
                            RuleCategory = null;
                        }
                    }
                    _ruleCategoryID = value;
                    OnPropertyChanged("RuleCategoryID");
                }
            }
        }
        private int _ruleCategoryID;
    
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
        public string ControlID
        {
            get { return _controlID; }
            set
            {
                if (_controlID != value)
                {
                    _controlID = value;
                    OnPropertyChanged("ControlID");
                }
            }
        }
        private string _controlID;
    
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
        public RuleCategory RuleCategory
        {
            get { return _ruleCategory; }
            set
            {
                if (!ReferenceEquals(_ruleCategory, value))
                {
                    var previousValue = _ruleCategory;
                    _ruleCategory = value;
                    FixupRuleCategory(previousValue);
                    OnNavigationPropertyChanged("RuleCategory");
                }
            }
        }
        private RuleCategory _ruleCategory;
    
        [DataMember]
        public TrackableCollection<RuleSettings> RuleSettings
        {
            get
            {
                if (_ruleSettings == null)
                {
                    _ruleSettings = new TrackableCollection<RuleSettings>();
                    _ruleSettings.CollectionChanged += FixupRuleSettings;
                }
                return _ruleSettings;
            }
            set
            {
                if (!ReferenceEquals(_ruleSettings, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_ruleSettings != null)
                    {
                        _ruleSettings.CollectionChanged -= FixupRuleSettings;
                    }
                    _ruleSettings = value;
                    if (_ruleSettings != null)
                    {
                        _ruleSettings.CollectionChanged += FixupRuleSettings;
                    }
                    OnNavigationPropertyChanged("RuleSettings");
                }
            }
        }
        private TrackableCollection<RuleSettings> _ruleSettings;

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
            RuleCategory = null;
            RuleSettings.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupRuleCategory(RuleCategory previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.RuleInfoes.Contains(this))
            {
                previousValue.RuleInfoes.Remove(this);
            }
    
            if (RuleCategory != null)
            {
                if (!RuleCategory.RuleInfoes.Contains(this))
                {
                    RuleCategory.RuleInfoes.Add(this);
                }
    
                RuleCategoryID = RuleCategory.RuleCategoryID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("RuleCategory")
                    && (ChangeTracker.OriginalValues["RuleCategory"] == RuleCategory))
                {
                    ChangeTracker.OriginalValues.Remove("RuleCategory");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("RuleCategory", previousValue);
                }
                if (RuleCategory != null && !RuleCategory.ChangeTracker.ChangeTrackingEnabled)
                {
                    RuleCategory.StartTracking();
                }
            }
        }
    
        private void FixupRuleSettings(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (RuleSettings item in e.NewItems)
                {
                    item.RuleInfo = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("RuleSettings", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (RuleSettings item in e.OldItems)
                {
                    if (ReferenceEquals(item.RuleInfo, this))
                    {
                        item.RuleInfo = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("RuleSettings", item);
                    }
                }
            }
        }

        #endregion
    }
}
