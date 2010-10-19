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
    [KnownType(typeof(MessageBlock))]
    [KnownType(typeof(MessageLanguage))]
    [KnownType(typeof(MessageBlockDataItemAttribute))]
    public partial class MessageBlockDataItem:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int MessageBlockDataItemID
        {
            get { return _messageBlockDataItemID; }
            set
            {
                if (_messageBlockDataItemID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'MessageBlockDataItemID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _messageBlockDataItemID = value;
                    OnPropertyChanged("MessageBlockDataItemID");
                }
            }
        }
        private int _messageBlockDataItemID;
    
        [DataMember]
        public int MessageBlockID
        {
            get { return _messageBlockID; }
            set
            {
                if (_messageBlockID != value)
                {
                    ChangeTracker.RecordOriginalValue("MessageBlockID", _messageBlockID);
                    if (!IsDeserializing)
                    {
                        if (MessageBlock != null && MessageBlock.MessageBlockID != value)
                        {
                            MessageBlock = null;
                        }
                    }
                    _messageBlockID = value;
                    OnPropertyChanged("MessageBlockID");
                }
            }
        }
        private int _messageBlockID;
    
        [DataMember]
        public short DataItemSequence
        {
            get { return _dataItemSequence; }
            set
            {
                if (_dataItemSequence != value)
                {
                    _dataItemSequence = value;
                    OnPropertyChanged("DataItemSequence");
                }
            }
        }
        private short _dataItemSequence;
    
        [DataMember]
        public string DataItemKey
        {
            get { return _dataItemKey; }
            set
            {
                if (_dataItemKey != value)
                {
                    _dataItemKey = value;
                    OnPropertyChanged("DataItemKey");
                }
            }
        }
        private string _dataItemKey;
    
        [DataMember]
        public string DataItemType
        {
            get { return _dataItemType; }
            set
            {
                if (_dataItemType != value)
                {
                    _dataItemType = value;
                    OnPropertyChanged("DataItemType");
                }
            }
        }
        private string _dataItemType;
    
        [DataMember]
        public byte BrandCode
        {
            get { return _brandCode; }
            set
            {
                if (_brandCode != value)
                {
                    _brandCode = value;
                    OnPropertyChanged("BrandCode");
                }
            }
        }
        private byte _brandCode;
    
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

        #endregion
        #region Navigation Properties
    
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
        public TrackableCollection<MessageBlockDataItemAttribute> MessageBlockDataItemAttributes
        {
            get
            {
                if (_messageBlockDataItemAttributes == null)
                {
                    _messageBlockDataItemAttributes = new TrackableCollection<MessageBlockDataItemAttribute>();
                    _messageBlockDataItemAttributes.CollectionChanged += FixupMessageBlockDataItemAttributes;
                }
                return _messageBlockDataItemAttributes;
            }
            set
            {
                if (!ReferenceEquals(_messageBlockDataItemAttributes, value))
                {
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        throw new InvalidOperationException("Cannot set the FixupChangeTrackingCollection when ChangeTracking is enabled");
                    }
                    if (_messageBlockDataItemAttributes != null)
                    {
                        _messageBlockDataItemAttributes.CollectionChanged -= FixupMessageBlockDataItemAttributes;
                    }
                    _messageBlockDataItemAttributes = value;
                    if (_messageBlockDataItemAttributes != null)
                    {
                        _messageBlockDataItemAttributes.CollectionChanged += FixupMessageBlockDataItemAttributes;
                    }
                    OnNavigationPropertyChanged("MessageBlockDataItemAttributes");
                }
            }
        }
        private TrackableCollection<MessageBlockDataItemAttribute> _messageBlockDataItemAttributes;

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
            MessageBlock = null;
            MessageLanguage = null;
            MessageBlockDataItemAttributes.Clear();
        }

        #endregion
        #region Association Fixup
    
        private void FixupMessageBlock(MessageBlock previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MessageBlockDataItems.Contains(this))
            {
                previousValue.MessageBlockDataItems.Remove(this);
            }
    
            if (MessageBlock != null)
            {
                if (!MessageBlock.MessageBlockDataItems.Contains(this))
                {
                    MessageBlock.MessageBlockDataItems.Add(this);
                }
    
                MessageBlockID = MessageBlock.MessageBlockID;
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
    
        private void FixupMessageLanguage(MessageLanguage previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.MessageBlockDataItems.Contains(this))
            {
                previousValue.MessageBlockDataItems.Remove(this);
            }
    
            if (MessageLanguage != null)
            {
                if (!MessageLanguage.MessageBlockDataItems.Contains(this))
                {
                    MessageLanguage.MessageBlockDataItems.Add(this);
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
    
        private void FixupMessageBlockDataItemAttributes(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (e.NewItems != null)
            {
                foreach (MessageBlockDataItemAttribute item in e.NewItems)
                {
                    item.MessageBlockDataItem = this;
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        if (!item.ChangeTracker.ChangeTrackingEnabled)
                        {
                            item.StartTracking();
                        }
                        ChangeTracker.RecordAdditionToCollectionProperties("MessageBlockDataItemAttributes", item);
                    }
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (MessageBlockDataItemAttribute item in e.OldItems)
                {
                    if (ReferenceEquals(item.MessageBlockDataItem, this))
                    {
                        item.MessageBlockDataItem = null;
                    }
                    if (ChangeTracker.ChangeTrackingEnabled)
                    {
                        ChangeTracker.RecordRemovalFromCollectionProperties("MessageBlockDataItemAttributes", item);
                    }
                }
            }
        }

        #endregion
    }
}