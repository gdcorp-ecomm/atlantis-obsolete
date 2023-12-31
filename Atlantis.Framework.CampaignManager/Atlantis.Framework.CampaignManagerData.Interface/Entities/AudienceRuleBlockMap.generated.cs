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
    [KnownType(typeof(Audience))]
    [KnownType(typeof(RuleBlock))]
    public partial class AudienceRuleBlockMap:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int AudienceRuleBlockMapID
        {
            get { return _audienceRuleBlockMapID; }
            set
            {
                if (_audienceRuleBlockMapID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'AudienceRuleBlockMapID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _audienceRuleBlockMapID = value;
                    OnPropertyChanged("AudienceRuleBlockMapID");
                }
            }
        }
        private int _audienceRuleBlockMapID;
    
        [DataMember]
        public int AudienceID
        {
            get { return _audienceID; }
            set
            {
                if (_audienceID != value)
                {
                    ChangeTracker.RecordOriginalValue("AudienceID", _audienceID);
                    if (!IsDeserializing)
                    {
                        if (Audience != null && Audience.AudienceID != value)
                        {
                            Audience = null;
                        }
                    }
                    _audienceID = value;
                    OnPropertyChanged("AudienceID");
                }
            }
        }
        private int _audienceID;
    
        [DataMember]
        public int RuleBlockID
        {
            get { return _ruleBlockID; }
            set
            {
                if (_ruleBlockID != value)
                {
                    ChangeTracker.RecordOriginalValue("RuleBlockID", _ruleBlockID);
                    if (!IsDeserializing)
                    {
                        if (RuleBlock != null && RuleBlock.RuleBlockID != value)
                        {
                            RuleBlock = null;
                        }
                    }
                    _ruleBlockID = value;
                    OnPropertyChanged("RuleBlockID");
                }
            }
        }
        private int _ruleBlockID;
    
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
        public Audience Audience
        {
            get { return _audience; }
            set
            {
                if (!ReferenceEquals(_audience, value))
                {
                    var previousValue = _audience;
                    _audience = value;
                    FixupAudience(previousValue);
                    OnNavigationPropertyChanged("Audience");
                }
            }
        }
        private Audience _audience;
    
        [DataMember]
        public RuleBlock RuleBlock
        {
            get { return _ruleBlock; }
            set
            {
                if (!ReferenceEquals(_ruleBlock, value))
                {
                    var previousValue = _ruleBlock;
                    _ruleBlock = value;
                    FixupRuleBlock(previousValue);
                    OnNavigationPropertyChanged("RuleBlock");
                }
            }
        }
        private RuleBlock _ruleBlock;

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
            Audience = null;
            RuleBlock = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupAudience(Audience previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.AudienceRuleBlockMaps.Contains(this))
            {
                previousValue.AudienceRuleBlockMaps.Remove(this);
            }
    
            if (Audience != null)
            {
                if (!Audience.AudienceRuleBlockMaps.Contains(this))
                {
                    Audience.AudienceRuleBlockMaps.Add(this);
                }
    
                AudienceID = Audience.AudienceID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Audience")
                    && (ChangeTracker.OriginalValues["Audience"] == Audience))
                {
                    ChangeTracker.OriginalValues.Remove("Audience");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Audience", previousValue);
                }
                if (Audience != null && !Audience.ChangeTracker.ChangeTrackingEnabled)
                {
                    Audience.StartTracking();
                }
            }
        }
    
        private void FixupRuleBlock(RuleBlock previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.AudienceRuleBlockMaps.Contains(this))
            {
                previousValue.AudienceRuleBlockMaps.Remove(this);
            }
    
            if (RuleBlock != null)
            {
                if (!RuleBlock.AudienceRuleBlockMaps.Contains(this))
                {
                    RuleBlock.AudienceRuleBlockMaps.Add(this);
                }
    
                RuleBlockID = RuleBlock.RuleBlockID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("RuleBlock")
                    && (ChangeTracker.OriginalValues["RuleBlock"] == RuleBlock))
                {
                    ChangeTracker.OriginalValues.Remove("RuleBlock");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("RuleBlock", previousValue);
                }
                if (RuleBlock != null && !RuleBlock.ChangeTracker.ChangeTrackingEnabled)
                {
                    RuleBlock.StartTracking();
                }
            }
        }

        #endregion
    }
}
