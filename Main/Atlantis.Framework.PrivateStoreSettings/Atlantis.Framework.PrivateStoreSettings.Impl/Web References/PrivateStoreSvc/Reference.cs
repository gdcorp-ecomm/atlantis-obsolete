﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.1.
// 
#pragma warning disable 1591

namespace Atlantis.Framework.PrivateStoreSettings.Impl.PrivateStoreSvc {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="PrivateStoreSoap", Namespace="http://tempuri.org/")]
    public partial class PrivateStore : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetPrivateStoreSettingsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PrivateStore() {
            this.Url = global::Atlantis.Framework.PrivateStoreSettings.Impl.Properties.Settings.Default.Atlantis_Framework_PrivateStoreSettings_Impl_PrivateStoreSvc_PrivateStore;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event GetPrivateStoreSettingsCompletedEventHandler GetPrivateStoreSettingsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetPrivateStoreSettings", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public PrivateStoreSettings GetPrivateStoreSettings(int marketplaceShopID, bool previewData, bool isSecureConnection) {
            object[] results = this.Invoke("GetPrivateStoreSettings", new object[] {
                        marketplaceShopID,
                        previewData,
                        isSecureConnection});
            return ((PrivateStoreSettings)(results[0]));
        }
        
        /// <remarks/>
        public void GetPrivateStoreSettingsAsync(int marketplaceShopID, bool previewData, bool isSecureConnection) {
            this.GetPrivateStoreSettingsAsync(marketplaceShopID, previewData, isSecureConnection, null);
        }
        
        /// <remarks/>
        public void GetPrivateStoreSettingsAsync(int marketplaceShopID, bool previewData, bool isSecureConnection, object userState) {
            if ((this.GetPrivateStoreSettingsOperationCompleted == null)) {
                this.GetPrivateStoreSettingsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetPrivateStoreSettingsOperationCompleted);
            }
            this.InvokeAsync("GetPrivateStoreSettings", new object[] {
                        marketplaceShopID,
                        previewData,
                        isSecureConnection}, this.GetPrivateStoreSettingsOperationCompleted, userState);
        }
        
        private void OnGetPrivateStoreSettingsOperationCompleted(object arg) {
            if ((this.GetPrivateStoreSettingsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetPrivateStoreSettingsCompleted(this, new GetPrivateStoreSettingsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class PrivateStoreSettings {
        
        private ResponseStatus responseStateField;
        
        private int marketplaceShopIDField;
        
        private string marketplaceShopNameField;
        
        private string marketplaceStoreUrlField;
        
        private bool isStoreHeaderImageOnField;
        
        private string storeHeaderImageUrlField;
        
        private string storeTagLineField;
        
        private string storeHomePageTextField;
        
        private string storeHomePageUrlField;
        
        private bool isPreviewField;
        
        /// <remarks/>
        public ResponseStatus ResponseState {
            get {
                return this.responseStateField;
            }
            set {
                this.responseStateField = value;
            }
        }
        
        /// <remarks/>
        public int MarketplaceShopID {
            get {
                return this.marketplaceShopIDField;
            }
            set {
                this.marketplaceShopIDField = value;
            }
        }
        
        /// <remarks/>
        public string MarketplaceShopName {
            get {
                return this.marketplaceShopNameField;
            }
            set {
                this.marketplaceShopNameField = value;
            }
        }
        
        /// <remarks/>
        public string MarketplaceStoreUrl {
            get {
                return this.marketplaceStoreUrlField;
            }
            set {
                this.marketplaceStoreUrlField = value;
            }
        }
        
        /// <remarks/>
        public bool IsStoreHeaderImageOn {
            get {
                return this.isStoreHeaderImageOnField;
            }
            set {
                this.isStoreHeaderImageOnField = value;
            }
        }
        
        /// <remarks/>
        public string StoreHeaderImageUrl {
            get {
                return this.storeHeaderImageUrlField;
            }
            set {
                this.storeHeaderImageUrlField = value;
            }
        }
        
        /// <remarks/>
        public string StoreTagLine {
            get {
                return this.storeTagLineField;
            }
            set {
                this.storeTagLineField = value;
            }
        }
        
        /// <remarks/>
        public string StoreHomePageText {
            get {
                return this.storeHomePageTextField;
            }
            set {
                this.storeHomePageTextField = value;
            }
        }
        
        /// <remarks/>
        public string StoreHomePageUrl {
            get {
                return this.storeHomePageUrlField;
            }
            set {
                this.storeHomePageUrlField = value;
            }
        }
        
        /// <remarks/>
        public bool IsPreview {
            get {
                return this.isPreviewField;
            }
            set {
                this.isPreviewField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ResponseStatus {
        
        private StatusCode statusField;
        
        private string messageField;
        
        private string stackTraceField;
        
        private string sourceField;
        
        /// <remarks/>
        public StatusCode Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public string StackTrace {
            get {
                return this.stackTraceField;
            }
            set {
                this.stackTraceField = value;
            }
        }
        
        /// <remarks/>
        public string Source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum StatusCode {
        
        /// <remarks/>
        Failure,
        
        /// <remarks/>
        Success,
        
        /// <remarks/>
        Maintenance,
        
        /// <remarks/>
        Timeout,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetPrivateStoreSettingsCompletedEventHandler(object sender, GetPrivateStoreSettingsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetPrivateStoreSettingsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetPrivateStoreSettingsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public PrivateStoreSettings Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((PrivateStoreSettings)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591