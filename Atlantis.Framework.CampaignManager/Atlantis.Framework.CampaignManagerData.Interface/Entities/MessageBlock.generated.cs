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
    [KnownType(typeof(MessageLanguage))]
    [KnownType(typeof(MessageBlockCategory))]
    [KnownType(typeof(MessageBlockType))]
    [KnownType(typeof(Placement))]
    [KnownType(typeof(MessageBlockDataItem))]
    [KnownType(typeof(MessageInstance))]
    [KnownType(typeof(AppPlacementLocation))]
    public partial class MessageBlock:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int MessageBlockID
        {
            get { return _messageBlockID; }
            set
            {
                if (_messageBlockID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'MessageBlockID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _messageBlockID = value;
                    OnPropertyChanged("MessageBlockID");
                }
            }
        }
        private int _messageBlockID;
    
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
        public string MessageBlockDescription
        {
            get { return _messageBlockDescription; }
            set
            {
                if (_messageBlockDescription != value)
                {
                    _messageBlockDescription = value;
                    OnPropertyChanged("MessageBlockDescription");
                }
            }
        }
        private string _messageBlockDescription;
    
        [DataMember]
        public short MessageBlockCategoryID
        {
            get { return _messageBlockCategoryID; }
            set
            {
                if (_messageBlockCategoryID != value)
                {
                    ChangeTracker.RecordOriginalValue("MessageBlockCategoryID", _messageBlockCategoryID);
                    if (!IsDeserializing)
                    {
                        if (MessageBlockCategory != null && MessageBlockCategory.MessageBlockCategoryID != value)
                        {
                            MessageBlockCategory = null;
                        }
                    }
                    _messageBlockCategoryID = value;
                    OnPropertyChanged("MessageBlockCategoryID");
                }
            }
        }
        private short _messageBlockCategoryID;
    
        [DataMember]
        public short MessageBlockTypeID
        {
            get { return _messageBlockTypeID; }
            set
            {
                if (_messageBlockTypeID != value)
                {
                    ChangeTracker.RecordOriginalValue("MessageBlockTypeID", _messageBlockTypeID);
                    if (!IsDeserializing)
                    {
                        if (MessageBlockType != null && MessageBlockType.MessageBlockTypeID != value)
                        {
                            MessageBlockType = null;
                        }
                    }
                    _messageBlockTypeID = value;
                    OnPropertyChanged("MessageBlockTypeID");
                }
            }
        }
        private short _messageBlockTypeID;
    
        [DataMember]
        public int PlacementID
        {
            get { return _placementID; }
            set
            {
                if (_placementID != value)
                {
                    ChangeTracker.RecordOriginalValue("PlacementID", _placementID);
                    if (!IsDeserializing)
                    {
                        if (Placement != null && Placement.PlacementID != value)
                        {
                            Placement = null;
                        }
                    }
                    _placementID = value;
                    OnPropertyChanged("PlacementID");
                }
            }
        }
        private int _placementID;
    
        [DataMember]
        public byte LanguageCode
        {
            get { return _languageCode; }
            set
            {
                if (_languageCode != value)
                {
                    ChangeTracker.RecordOriginalValue("LanguageCode", _languageCode);
                    if (!IsDeserializing)
                    {
                        if (MessageLanguage != null && MessageLanguage.LanguageCode != value)
                        {
                            MessageLanguage = null;
                        }
                    }
                    _languageCode = value;
                    OnPropertyChanged("LanguageCode");
                }
            }
        }
        private byte _languageCode;
    
        [DataMember]
        public byte ApprovalStatusCode
        {
            get { return _approvalStatusCode; }
            set
            {
                if (_approvalStatusCode != value)
                {
                    _approvalStatusCode = value;
                    OnPropertyChanged("ApprovalStatusCode");
                }
            }
        }
        private byte _approvalStatusCode;
    
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
        public MessageLanguage MessageLanguage
        {
            get { return _messageLanguage; }
            set
            {
                if (!ReferenceEquals(_messageLanguage, value))
                {
                    var previousValue = _messageLanguage;
                    _messageLanguage = value;
                    FixupMessageLanguage(previousValue);
                    OnNavigationPropertyChanged("MessageLanguage");
                }
            }
        }
        private MessageLanguage _messageLanguage;
    
        [DataMember]
        public MessageBlockCategory MessageBlockCategory
        {
            get { return _messageBlockCategory; }
            set
            {
                if (!ReferenceEquals(_messageBlockCategory, value))
                {
                    var previousValue = _messageBlockCategory;
                    _messageBlockCategory = value;
                    FixupMessageBlockCategory(previousValue);
                    OnNavigationPropertyChanged("MessageBlockCategory");
                }
            }
        }
        private MessageBlockCategory _messageBlockCategory;
    
        [DataMember]
        public MessageBlockType MessageBlockType
        {
            get { return _messageBlockType; }
            set
            {
                if (!ReferenceEquals(_messageBlockType, value))
                {
                    var previousValue = _messageBlockType;
                    _messageBlockType = value;
                    FixupMessageBlockType(previousValue);
                    OnNavigationPropertyChanged("MessageBlockType");
                }
            }
        }
        private MessageBlockType _messageBlockType;
    
        [DataMember]
        public Placement Placement
        {
            get { return _placement; }
            set
            {
                if (!ReferenceEquals(_placement, value))
                {
                    var previousValue = _placement;
                    _placement = value;
                    FixupPlacement(previousValue);
                    OnNavigationPropertyChanged("Placement");
                }
            }
        }
        private Placement _placement;
    
        [DataMember]
        public TrackableCollection<MessageBlockDataItem> MessageBlockDataItems
        {
            get
            {
                if (_messageBlockDataItems == null)
                {
                    _messageBlockDataItems = new TrackableCollection<MessageBlockDataItem>();
                    _messageBlockDataItems.CollectionChanged += FixupMessageBlockDataItems;
                }
                return _messageBlockDataItems;
            }
            set
            {
                if (!ReferenceEquals(_messageBlockDataItems, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_messageBlockDataItems != null)
                    {
                        _messageBlockDataItems.CollectionChanged -= FixupMessageBlockDataItems;
                    }
                    _messageBlockDataItems = value;
                    if (_messageBlockDataItems != null)
                    {
                        _messageBlockDataItems.CollectionChanged += FixupMessageBlockDataItems;
                    }
                    OnNavigationPropertyChanged("MessageBlockDataItems");
                }
            }
        }
        private TrackableCollection<MessageBlockDataItem> _messageBlockDataItems;
    
        [DataMember]
        public TrackableCollection<MessageInstance> MessageInstances
        {
            get
            {
                if (_messageInstances == null)
                {
                    _messageInstances = new TrackableCollection<MessageInstance>();
                    _messageInstances.CollectionChanged += FixupMessageInstances;
                }
                return _messageInstances;
            }
            set
            {
                if (!ReferenceEquals(_messageInstances, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_messageInstances != null)
                    {
                        _messageInstances.CollectionChanged -= FixupMessageInstances;
                    }
                    _messageInstances = value;
                    if (_messageInstances != null)
                    {
                        _messageInstances.CollectionChanged += FixupMessageInstances;
                    }
                    OnNavigationPropertyChanged("MessageInstances");
                }
            }
        }
        private TrackableCollection<MessageInstance> _messageInstances;
    
        [DataMember]
        public TrackableCollection<AppPlacementLocation> AppPlacementLocations
        {
            get
            {
                if (_appPlacementLocations == null)
                {
                    _appPlacementLocations = new TrackableCollection<AppPlacementLocation>();
                    _appPlacementLocations.CollectionChanged += FixupAppPlacementLocations;
                }
                return _appPlacementLocations;
            }
            set
            {
                if (!ReferenceEquals(_appPlacementLocations, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_appPlacementLocations != null)
                    {
                        _appPlacementLocations.CollectionChanged -= FixupAppPlacementLocations;
                    }
                    _appPlacementLocations = value;
                    if (_appPlacementLocations != null)
                    {
                        _appPlacementLocations.CollectionChanged += FixupAppPlacementLocations;
                    }
                    OnNavigationPropertyChanged("AppPlacementLocations");
                }
            }
        }
        private TrackableCollection<AppPlacementLocation> _appPlacementLocations;

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
            MessageLanguage = null;
            MessageBlockCategory = null;
            MessageBlockType = null;
            Placement = null;
            MessageBlockDataItems.Clear();
            MessageInstances.Clear();
            AppPlacementLocations.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupMessageLanguage(MessageLanguage previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MessageBlocks.Contains(this))
            {
                previousValue.MessageBlocks.Remove(this);
            }
    
            if (MessageLanguage != null)
            {
                if (!MessageLanguage.MessageBlocks.Contains(this))
                {
                    MessageLanguage.MessageBlocks.Add(this);
                }
    
                LanguageCode = MessageLanguage.LanguageCode;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MessageLanguage")
                    && (ChangeTracker.OriginalValues["MessageLanguage"] == MessageLanguage))
                {
                    ChangeTracker.OriginalValues.Remove("MessageLanguage");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MessageLanguage", previousValue);
                }
                if (MessageLanguage != null && !MessageLanguage.ChangeTracker.ChangeTrackingEnabled)
                {
                    MessageLanguage.StartTracking();
                }
            }
        }
    
        private void FixupMessageBlockCategory(MessageBlockCategory previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MessageBlocks.Contains(this))
            {
                previousValue.MessageBlocks.Remove(this);
            }
    
            if (MessageBlockCategory != null)
            {
                if (!MessageBlockCategory.MessageBlocks.Contains(this))
                {
                    MessageBlockCategory.MessageBlocks.Add(this);
                }
    
                MessageBlockCategoryID = MessageBlockCategory.MessageBlockCategoryID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MessageBlockCategory")
                    && (ChangeTracker.OriginalValues["MessageBlockCategory"] == MessageBlockCategory))
                {
                    ChangeTracker.OriginalValues.Remove("MessageBlockCategory");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MessageBlockCategory", previousValue);
                }
                if (MessageBlockCategory != null && !MessageBlockCategory.ChangeTracker.ChangeTrackingEnabled)
                {
                    MessageBlockCategory.StartTracking();
                }
            }
        }
    
        private void FixupMessageBlockType(MessageBlockType previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MessageBlocks.Contains(this))
            {
                previousValue.MessageBlocks.Remove(this);
            }
    
            if (MessageBlockType != null)
            {
                if (!MessageBlockType.MessageBlocks.Contains(this))
                {
                    MessageBlockType.MessageBlocks.Add(this);
                }
    
                MessageBlockTypeID = MessageBlockType.MessageBlockTypeID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("MessageBlockType")
                    && (ChangeTracker.OriginalValues["MessageBlockType"] == MessageBlockType))
                {
                    ChangeTracker.OriginalValues.Remove("MessageBlockType");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("MessageBlockType", previousValue);
                }
                if (MessageBlockType != null && !MessageBlockType.ChangeTracker.ChangeTrackingEnabled)
                {
                    MessageBlockType.StartTracking();
                }
            }
        }
    
        private void FixupPlacement(Placement previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MessageBlocks.Contains(this))
            {
                previousValue.MessageBlocks.Remove(this);
            }
    
            if (Placement != null)
            {
                if (!Placement.MessageBlocks.Contains(this))
                {
                    Placement.MessageBlocks.Add(this);
                }
    
                PlacementID = Placement.PlacementID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Placement")
                    && (ChangeTracker.OriginalValues["Placement"] == Placement))
                {
                    ChangeTracker.OriginalValues.Remove("Placement");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Placement", previousValue);
                }
                if (Placement != null && !Placement.ChangeTracker.ChangeTrackingEnabled)
                {
                    Placement.StartTracking();
                }
            }
        }
    
        private void FixupMessageBlockDataItems(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (MessageBlockDataItem item in e.NewItems)
                {
                    item.MessageBlock = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("MessageBlockDataItems", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MessageBlockDataItem item in e.OldItems)
                {
                    if (ReferenceEquals(item.MessageBlock, this))
                    {
                        item.MessageBlock = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("MessageBlockDataItems", item);
                    }
                }
            }
        }
    
        private void FixupMessageInstances(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (MessageInstance item in e.NewItems)
                {
                    item.MessageBlock = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("MessageInstances", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MessageInstance item in e.OldItems)
                {
                    if (ReferenceEquals(item.MessageBlock, this))
                    {
                        item.MessageBlock = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("MessageInstances", item);
                    }
                }
            }
        }
    
        private void FixupAppPlacementLocations(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (AppPlacementLocation item in e.NewItems)
                {
                    item.MessageBlock = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("AppPlacementLocations", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (AppPlacementLocation item in e.OldItems)
                {
                    if (ReferenceEquals(item.MessageBlock, this))
                    {
                        item.MessageBlock = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("AppPlacementLocations", item);
                    }
                }
            }
        }

        #endregion
    }
}