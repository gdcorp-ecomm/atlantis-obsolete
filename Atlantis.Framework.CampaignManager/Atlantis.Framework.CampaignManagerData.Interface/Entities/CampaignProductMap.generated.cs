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
    [KnownType(typeof(Product))]
    public partial class CampaignProductMap:  IAtlantisEntity, IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Primitive Properties
    
        [DataMember]
        public int CampaignProductMapID
        {
            get { return _campaignProductMapID; }
            set
            {
                if (_campaignProductMapID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'CampaignProductMapID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _campaignProductMapID = value;
                    OnPropertyChanged("CampaignProductMapID");
                }
            }
        }
        private int _campaignProductMapID;
    
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
        public int ProductID
        {
            get { return _productID; }
            set
            {
                if (_productID != value)
                {
                    ChangeTracker.RecordOriginalValue("ProductID", _productID);
                    if (!IsDeserializing)
                    {
                        if (Product != null && Product.ProductID != value)
                        {
                            Product = null;
                        }
                    }
                    _productID = value;
                    OnPropertyChanged("ProductID");
                }
            }
        }
        private int _productID;
    
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
        public Product Product
        {
            get { return _product; }
            set
            {
                if (!ReferenceEquals(_product, value))
                {
                    var previousValue = _product;
                    _product = value;
                    FixupProduct(previousValue);
                    OnNavigationPropertyChanged("Product");
                }
            }
        }
        private Product _product;

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
            Product = null;
        }

        #endregion
        #region Association Fixup
    
        private void FixupCampaign(Campaign previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CampaignProductMaps.Contains(this))
            {
                previousValue.CampaignProductMaps.Remove(this);
            }
    
            if (Campaign != null)
            {
                if (!Campaign.CampaignProductMaps.Contains(this))
                {
                    Campaign.CampaignProductMaps.Add(this);
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
    
        private void FixupProduct(Product previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.CampaignProductMaps.Contains(this))
            {
                previousValue.CampaignProductMaps.Remove(this);
            }
    
            if (Product != null)
            {
                if (!Product.CampaignProductMaps.Contains(this))
                {
                    Product.CampaignProductMaps.Add(this);
                }
    
                ProductID = Product.ProductID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Product")
                    && (ChangeTracker.OriginalValues["Product"] == Product))
                {
                    ChangeTracker.OriginalValues.Remove("Product");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Product", previousValue);
                }
                if (Product != null && !Product.ChangeTracker.ChangeTrackingEnabled)
                {
                    Product.StartTracking();
                }
            }
        }

        #endregion
    }
}
