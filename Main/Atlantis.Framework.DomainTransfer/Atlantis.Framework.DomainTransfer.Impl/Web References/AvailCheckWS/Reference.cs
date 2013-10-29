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

namespace Atlantis.Framework.DomainTransfer.Impl.AvailCheckWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="AvailCheckWebSvcSoap", Namespace="http://tempuri.org/")]
    public partial class AvailCheckWebSvc : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback CheckOperationCompleted;
        
        private System.Threading.SendOrPostCallback DomainSyntaxCheckOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public AvailCheckWebSvc() {
            this.Url = global::Atlantis.Framework.DomainTransfer.Impl.Properties.Settings.Default.Atlantis_Framework_DomainTransfer_Impl_AvailCheckWS_AvailCheckWebSvc;
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
        public event CheckCompletedEventHandler CheckCompleted;
        
        /// <remarks/>
        public event DomainSyntaxCheckCompletedEventHandler DomainSyntaxCheckCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Check", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string Check(string sCheckXML) {
            object[] results = this.Invoke("Check", new object[] {
                        sCheckXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCheck(string sCheckXML, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Check", new object[] {
                        sCheckXML}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCheck(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CheckAsync(string sCheckXML) {
            this.CheckAsync(sCheckXML, null);
        }
        
        /// <remarks/>
        public void CheckAsync(string sCheckXML, object userState) {
            if ((this.CheckOperationCompleted == null)) {
                this.CheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckOperationCompleted);
            }
            this.InvokeAsync("Check", new object[] {
                        sCheckXML}, this.CheckOperationCompleted, userState);
        }
        
        private void OnCheckOperationCompleted(object arg) {
            if ((this.CheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckCompleted(this, new CheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/DomainSyntaxCheck", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string DomainSyntaxCheck(string sCheckXML) {
            object[] results = this.Invoke("DomainSyntaxCheck", new object[] {
                        sCheckXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginDomainSyntaxCheck(string sCheckXML, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("DomainSyntaxCheck", new object[] {
                        sCheckXML}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndDomainSyntaxCheck(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void DomainSyntaxCheckAsync(string sCheckXML) {
            this.DomainSyntaxCheckAsync(sCheckXML, null);
        }
        
        /// <remarks/>
        public void DomainSyntaxCheckAsync(string sCheckXML, object userState) {
            if ((this.DomainSyntaxCheckOperationCompleted == null)) {
                this.DomainSyntaxCheckOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDomainSyntaxCheckOperationCompleted);
            }
            this.InvokeAsync("DomainSyntaxCheck", new object[] {
                        sCheckXML}, this.DomainSyntaxCheckOperationCompleted, userState);
        }
        
        private void OnDomainSyntaxCheckOperationCompleted(object arg) {
            if ((this.DomainSyntaxCheckCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DomainSyntaxCheckCompleted(this, new DomainSyntaxCheckCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void CheckCompletedEventHandler(object sender, CheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void DomainSyntaxCheckCompletedEventHandler(object sender, DomainSyntaxCheckCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DomainSyntaxCheckCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DomainSyntaxCheckCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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