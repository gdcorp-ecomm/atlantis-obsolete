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

namespace Atlantis.Framework.MktgGetShopperPreferences.Impl.PreferencesWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://tempuri.org/")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SubscribeOperationCompleted;
        
        private System.Threading.SendOrPostCallback UnsubscribeOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetShopperCommPreferenceOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetShopperCommDoubleOptInOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetShopperInterestPreferenceOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetShopperOptInsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::Atlantis.Framework.MktgGetShopperPreferences.Impl.Properties.Settings.Default.Atlantis_Framework_MktgGetShopperPreferences_Impl_PreferencesWS_Service;
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
        public event SubscribeCompletedEventHandler SubscribeCompleted;
        
        /// <remarks/>
        public event UnsubscribeCompletedEventHandler UnsubscribeCompleted;
        
        /// <remarks/>
        public event SetShopperCommPreferenceCompletedEventHandler SetShopperCommPreferenceCompleted;
        
        /// <remarks/>
        public event SetShopperCommDoubleOptInCompletedEventHandler SetShopperCommDoubleOptInCompleted;
        
        /// <remarks/>
        public event SetShopperInterestPreferenceCompletedEventHandler SetShopperInterestPreferenceCompleted;
        
        /// <remarks/>
        public event GetShopperOptInsCompletedEventHandler GetShopperOptInsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Subscribe", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Subscribe(string sEmail, int iPublicationId, int iPrivateLabelId, int iEmailType, string sFirstName, string sLastName, string sFromApp, string sFromIPAddr, bool bIsConfirmed) {
            object[] results = this.Invoke("Subscribe", new object[] {
                        sEmail,
                        iPublicationId,
                        iPrivateLabelId,
                        iEmailType,
                        sFirstName,
                        sLastName,
                        sFromApp,
                        sFromIPAddr,
                        bIsConfirmed});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SubscribeAsync(string sEmail, int iPublicationId, int iPrivateLabelId, int iEmailType, string sFirstName, string sLastName, string sFromApp, string sFromIPAddr, bool bIsConfirmed) {
            this.SubscribeAsync(sEmail, iPublicationId, iPrivateLabelId, iEmailType, sFirstName, sLastName, sFromApp, sFromIPAddr, bIsConfirmed, null);
        }
        
        /// <remarks/>
        public void SubscribeAsync(string sEmail, int iPublicationId, int iPrivateLabelId, int iEmailType, string sFirstName, string sLastName, string sFromApp, string sFromIPAddr, bool bIsConfirmed, object userState) {
            if ((this.SubscribeOperationCompleted == null)) {
                this.SubscribeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubscribeOperationCompleted);
            }
            this.InvokeAsync("Subscribe", new object[] {
                        sEmail,
                        iPublicationId,
                        iPrivateLabelId,
                        iEmailType,
                        sFirstName,
                        sLastName,
                        sFromApp,
                        sFromIPAddr,
                        bIsConfirmed}, this.SubscribeOperationCompleted, userState);
        }
        
        private void OnSubscribeOperationCompleted(object arg) {
            if ((this.SubscribeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubscribeCompleted(this, new SubscribeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Unsubscribe", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Unsubscribe(string sEmail, int iPublicationId, int iPrivateLabelId, string sFromApp, string sFromIPAddr) {
            object[] results = this.Invoke("Unsubscribe", new object[] {
                        sEmail,
                        iPublicationId,
                        iPrivateLabelId,
                        sFromApp,
                        sFromIPAddr});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UnsubscribeAsync(string sEmail, int iPublicationId, int iPrivateLabelId, string sFromApp, string sFromIPAddr) {
            this.UnsubscribeAsync(sEmail, iPublicationId, iPrivateLabelId, sFromApp, sFromIPAddr, null);
        }
        
        /// <remarks/>
        public void UnsubscribeAsync(string sEmail, int iPublicationId, int iPrivateLabelId, string sFromApp, string sFromIPAddr, object userState) {
            if ((this.UnsubscribeOperationCompleted == null)) {
                this.UnsubscribeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUnsubscribeOperationCompleted);
            }
            this.InvokeAsync("Unsubscribe", new object[] {
                        sEmail,
                        iPublicationId,
                        iPrivateLabelId,
                        sFromApp,
                        sFromIPAddr}, this.UnsubscribeOperationCompleted, userState);
        }
        
        private void OnUnsubscribeOperationCompleted(object arg) {
            if ((this.UnsubscribeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UnsubscribeCompleted(this, new UnsubscribeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetShopperCommPreference", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SetShopperCommPreference(string sShopperId, int iCommTypeId, bool bOptIn) {
            object[] results = this.Invoke("SetShopperCommPreference", new object[] {
                        sShopperId,
                        iCommTypeId,
                        bOptIn});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetShopperCommPreferenceAsync(string sShopperId, int iCommTypeId, bool bOptIn) {
            this.SetShopperCommPreferenceAsync(sShopperId, iCommTypeId, bOptIn, null);
        }
        
        /// <remarks/>
        public void SetShopperCommPreferenceAsync(string sShopperId, int iCommTypeId, bool bOptIn, object userState) {
            if ((this.SetShopperCommPreferenceOperationCompleted == null)) {
                this.SetShopperCommPreferenceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetShopperCommPreferenceOperationCompleted);
            }
            this.InvokeAsync("SetShopperCommPreference", new object[] {
                        sShopperId,
                        iCommTypeId,
                        bOptIn}, this.SetShopperCommPreferenceOperationCompleted, userState);
        }
        
        private void OnSetShopperCommPreferenceOperationCompleted(object arg) {
            if ((this.SetShopperCommPreferenceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetShopperCommPreferenceCompleted(this, new SetShopperCommPreferenceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetShopperCommDoubleOptIn", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SetShopperCommDoubleOptIn(string sShopperId, int iCommTypeId) {
            object[] results = this.Invoke("SetShopperCommDoubleOptIn", new object[] {
                        sShopperId,
                        iCommTypeId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetShopperCommDoubleOptInAsync(string sShopperId, int iCommTypeId) {
            this.SetShopperCommDoubleOptInAsync(sShopperId, iCommTypeId, null);
        }
        
        /// <remarks/>
        public void SetShopperCommDoubleOptInAsync(string sShopperId, int iCommTypeId, object userState) {
            if ((this.SetShopperCommDoubleOptInOperationCompleted == null)) {
                this.SetShopperCommDoubleOptInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetShopperCommDoubleOptInOperationCompleted);
            }
            this.InvokeAsync("SetShopperCommDoubleOptIn", new object[] {
                        sShopperId,
                        iCommTypeId}, this.SetShopperCommDoubleOptInOperationCompleted, userState);
        }
        
        private void OnSetShopperCommDoubleOptInOperationCompleted(object arg) {
            if ((this.SetShopperCommDoubleOptInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetShopperCommDoubleOptInCompleted(this, new SetShopperCommDoubleOptInCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SetShopperInterestPreference", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SetShopperInterestPreference(string sShopperId, int iCommTypeId, int iInterestTypeId, bool bOptIn) {
            object[] results = this.Invoke("SetShopperInterestPreference", new object[] {
                        sShopperId,
                        iCommTypeId,
                        iInterestTypeId,
                        bOptIn});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetShopperInterestPreferenceAsync(string sShopperId, int iCommTypeId, int iInterestTypeId, bool bOptIn) {
            this.SetShopperInterestPreferenceAsync(sShopperId, iCommTypeId, iInterestTypeId, bOptIn, null);
        }
        
        /// <remarks/>
        public void SetShopperInterestPreferenceAsync(string sShopperId, int iCommTypeId, int iInterestTypeId, bool bOptIn, object userState) {
            if ((this.SetShopperInterestPreferenceOperationCompleted == null)) {
                this.SetShopperInterestPreferenceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetShopperInterestPreferenceOperationCompleted);
            }
            this.InvokeAsync("SetShopperInterestPreference", new object[] {
                        sShopperId,
                        iCommTypeId,
                        iInterestTypeId,
                        bOptIn}, this.SetShopperInterestPreferenceOperationCompleted, userState);
        }
        
        private void OnSetShopperInterestPreferenceOperationCompleted(object arg) {
            if ((this.SetShopperInterestPreferenceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetShopperInterestPreferenceCompleted(this, new SetShopperInterestPreferenceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetShopperOptIns", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetShopperOptIns(string sShopperId) {
            object[] results = this.Invoke("GetShopperOptIns", new object[] {
                        sShopperId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetShopperOptInsAsync(string sShopperId) {
            this.GetShopperOptInsAsync(sShopperId, null);
        }
        
        /// <remarks/>
        public void GetShopperOptInsAsync(string sShopperId, object userState) {
            if ((this.GetShopperOptInsOperationCompleted == null)) {
                this.GetShopperOptInsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetShopperOptInsOperationCompleted);
            }
            this.InvokeAsync("GetShopperOptIns", new object[] {
                        sShopperId}, this.GetShopperOptInsOperationCompleted, userState);
        }
        
        private void OnGetShopperOptInsOperationCompleted(object arg) {
            if ((this.GetShopperOptInsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetShopperOptInsCompleted(this, new GetShopperOptInsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SubscribeCompletedEventHandler(object sender, SubscribeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubscribeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SubscribeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UnsubscribeCompletedEventHandler(object sender, UnsubscribeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UnsubscribeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UnsubscribeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SetShopperCommPreferenceCompletedEventHandler(object sender, SetShopperCommPreferenceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetShopperCommPreferenceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetShopperCommPreferenceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SetShopperCommDoubleOptInCompletedEventHandler(object sender, SetShopperCommDoubleOptInCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetShopperCommDoubleOptInCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetShopperCommDoubleOptInCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SetShopperInterestPreferenceCompletedEventHandler(object sender, SetShopperInterestPreferenceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetShopperInterestPreferenceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetShopperInterestPreferenceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetShopperOptInsCompletedEventHandler(object sender, GetShopperOptInsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetShopperOptInsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetShopperOptInsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591