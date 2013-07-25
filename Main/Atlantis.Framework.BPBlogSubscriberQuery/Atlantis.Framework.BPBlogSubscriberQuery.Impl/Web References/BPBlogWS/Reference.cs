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

namespace Atlantis.Framework.BPBlogSubscriberQuery.Impl.BPBlogWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="BBSoapBinding", Namespace="BBSoapNS")]
    public partial class BBSoap : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback add_subscriberOperationCompleted;
        
        private System.Threading.SendOrPostCallback add_gdsite_subscriberOperationCompleted;
        
        private System.Threading.SendOrPostCallback query_subscriberOperationCompleted;
        
        private System.Threading.SendOrPostCallback remove_subscriberOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BBSoap() {
            this.Url = global::Atlantis.Framework.BPBlogSubscriberQuery.Impl.Properties.Settings.Default.Atlantis_Framework_BPBlogSubscriberQuery_Impl_BPBlogWS_BBSoap;
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
        public event add_subscriberCompletedEventHandler add_subscriberCompleted;
        
        /// <remarks/>
        public event add_gdsite_subscriberCompletedEventHandler add_gdsite_subscriberCompleted;
        
        /// <remarks/>
        public event query_subscriberCompletedEventHandler query_subscriberCompleted;
        
        /// <remarks/>
        public event remove_subscriberCompletedEventHandler remove_subscriberCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.bobparsons.me-dev.ide/service.php/add_subscriber", RequestNamespace="BBSoapNS", ResponseNamespace="BBSoapNS")]
        [return: System.Xml.Serialization.SoapElementAttribute("response")]
        public string add_subscriber(string email, string firstname, string lastname, int confirmed) {
            object[] results = this.Invoke("add_subscriber", new object[] {
                        email,
                        firstname,
                        lastname,
                        confirmed});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void add_subscriberAsync(string email, string firstname, string lastname, int confirmed) {
            this.add_subscriberAsync(email, firstname, lastname, confirmed, null);
        }
        
        /// <remarks/>
        public void add_subscriberAsync(string email, string firstname, string lastname, int confirmed, object userState) {
            if ((this.add_subscriberOperationCompleted == null)) {
                this.add_subscriberOperationCompleted = new System.Threading.SendOrPostCallback(this.Onadd_subscriberOperationCompleted);
            }
            this.InvokeAsync("add_subscriber", new object[] {
                        email,
                        firstname,
                        lastname,
                        confirmed}, this.add_subscriberOperationCompleted, userState);
        }
        
        private void Onadd_subscriberOperationCompleted(object arg) {
            if ((this.add_subscriberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.add_subscriberCompleted(this, new add_subscriberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.bobparsons.me-dev.ide/service.php/add_gdsite_subscriber", RequestNamespace="BBSoapNS", ResponseNamespace="BBSoapNS")]
        [return: System.Xml.Serialization.SoapElementAttribute("response")]
        public string add_gdsite_subscriber(string email, string firstname, string lastname) {
            object[] results = this.Invoke("add_gdsite_subscriber", new object[] {
                        email,
                        firstname,
                        lastname});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void add_gdsite_subscriberAsync(string email, string firstname, string lastname) {
            this.add_gdsite_subscriberAsync(email, firstname, lastname, null);
        }
        
        /// <remarks/>
        public void add_gdsite_subscriberAsync(string email, string firstname, string lastname, object userState) {
            if ((this.add_gdsite_subscriberOperationCompleted == null)) {
                this.add_gdsite_subscriberOperationCompleted = new System.Threading.SendOrPostCallback(this.Onadd_gdsite_subscriberOperationCompleted);
            }
            this.InvokeAsync("add_gdsite_subscriber", new object[] {
                        email,
                        firstname,
                        lastname}, this.add_gdsite_subscriberOperationCompleted, userState);
        }
        
        private void Onadd_gdsite_subscriberOperationCompleted(object arg) {
            if ((this.add_gdsite_subscriberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.add_gdsite_subscriberCompleted(this, new add_gdsite_subscriberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.bobparsons.me-dev.ide/service.php/query_subscriber", RequestNamespace="BBSoapNS", ResponseNamespace="BBSoapNS")]
        [return: System.Xml.Serialization.SoapElementAttribute("response")]
        public string query_subscriber(string email) {
            object[] results = this.Invoke("query_subscriber", new object[] {
                        email});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void query_subscriberAsync(string email) {
            this.query_subscriberAsync(email, null);
        }
        
        /// <remarks/>
        public void query_subscriberAsync(string email, object userState) {
            if ((this.query_subscriberOperationCompleted == null)) {
                this.query_subscriberOperationCompleted = new System.Threading.SendOrPostCallback(this.Onquery_subscriberOperationCompleted);
            }
            this.InvokeAsync("query_subscriber", new object[] {
                        email}, this.query_subscriberOperationCompleted, userState);
        }
        
        private void Onquery_subscriberOperationCompleted(object arg) {
            if ((this.query_subscriberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.query_subscriberCompleted(this, new query_subscriberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("http://www.bobparsons.me-dev.ide/service.php/remove_subscriber", RequestNamespace="BBSoapNS", ResponseNamespace="BBSoapNS")]
        [return: System.Xml.Serialization.SoapElementAttribute("response")]
        public string remove_subscriber(string email) {
            object[] results = this.Invoke("remove_subscriber", new object[] {
                        email});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void remove_subscriberAsync(string email) {
            this.remove_subscriberAsync(email, null);
        }
        
        /// <remarks/>
        public void remove_subscriberAsync(string email, object userState) {
            if ((this.remove_subscriberOperationCompleted == null)) {
                this.remove_subscriberOperationCompleted = new System.Threading.SendOrPostCallback(this.Onremove_subscriberOperationCompleted);
            }
            this.InvokeAsync("remove_subscriber", new object[] {
                        email}, this.remove_subscriberOperationCompleted, userState);
        }
        
        private void Onremove_subscriberOperationCompleted(object arg) {
            if ((this.remove_subscriberCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.remove_subscriberCompleted(this, new remove_subscriberCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void add_subscriberCompletedEventHandler(object sender, add_subscriberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class add_subscriberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal add_subscriberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void add_gdsite_subscriberCompletedEventHandler(object sender, add_gdsite_subscriberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class add_gdsite_subscriberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal add_gdsite_subscriberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void query_subscriberCompletedEventHandler(object sender, query_subscriberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class query_subscriberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal query_subscriberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void remove_subscriberCompletedEventHandler(object sender, remove_subscriberCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class remove_subscriberCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal remove_subscriberCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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