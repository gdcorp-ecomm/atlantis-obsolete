﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.239.
// 
#pragma warning disable 1591

namespace Atlantis.Framework.DCCForwardingDelete.Impl.RegDCCRequestService {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="RegDCCRequestWSSoap", Namespace="http://tempuri.org/")]
    public partial class RegDCCRequestWS : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SubmitRequestStandardOperationCompleted;
        
        private System.Threading.SendOrPostCallback SubmitRequestAPIOperationCompleted;
        
        private System.Threading.SendOrPostCallback getServiceStatusOperationCompleted;
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public RegDCCRequestWS() {
            this.Url = global::Atlantis.Framework.DCCForwardingDelete.Impl.Properties.Settings.Default.Atlantis_Framework_DCCForwardingDelete_Impl_RegDCCRequestService_RegDCCRequestWS;
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
        public event SubmitRequestStandardCompletedEventHandler SubmitRequestStandardCompleted;
        
        /// <remarks/>
        public event SubmitRequestAPICompletedEventHandler SubmitRequestAPICompleted;
        
        /// <remarks/>
        public event getServiceStatusCompletedEventHandler getServiceStatusCompleted;
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SubmitRequestStandard", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SubmitRequestStandard(string sRequestXML) {
            object[] results = this.Invoke("SubmitRequestStandard", new object[] {
                        sRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SubmitRequestStandardAsync(string sRequestXML) {
            this.SubmitRequestStandardAsync(sRequestXML, null);
        }
        
        /// <remarks/>
        public void SubmitRequestStandardAsync(string sRequestXML, object userState) {
            if ((this.SubmitRequestStandardOperationCompleted == null)) {
                this.SubmitRequestStandardOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubmitRequestStandardOperationCompleted);
            }
            this.InvokeAsync("SubmitRequestStandard", new object[] {
                        sRequestXML}, this.SubmitRequestStandardOperationCompleted, userState);
        }
        
        private void OnSubmitRequestStandardOperationCompleted(object arg) {
            if ((this.SubmitRequestStandardCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubmitRequestStandardCompleted(this, new SubmitRequestStandardCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SubmitRequestAPI", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SubmitRequestAPI(string sRequestXML) {
            object[] results = this.Invoke("SubmitRequestAPI", new object[] {
                        sRequestXML});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void SubmitRequestAPIAsync(string sRequestXML) {
            this.SubmitRequestAPIAsync(sRequestXML, null);
        }
        
        /// <remarks/>
        public void SubmitRequestAPIAsync(string sRequestXML, object userState) {
            if ((this.SubmitRequestAPIOperationCompleted == null)) {
                this.SubmitRequestAPIOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSubmitRequestAPIOperationCompleted);
            }
            this.InvokeAsync("SubmitRequestAPI", new object[] {
                        sRequestXML}, this.SubmitRequestAPIOperationCompleted, userState);
        }
        
        private void OnSubmitRequestAPIOperationCompleted(object arg) {
            if ((this.SubmitRequestAPICompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SubmitRequestAPICompleted(this, new SubmitRequestAPICompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/getServiceStatus", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getServiceStatus() {
            object[] results = this.Invoke("getServiceStatus", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void getServiceStatusAsync() {
            this.getServiceStatusAsync(null);
        }
        
        /// <remarks/>
        public void getServiceStatusAsync(object userState) {
            if ((this.getServiceStatusOperationCompleted == null)) {
                this.getServiceStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OngetServiceStatusOperationCompleted);
            }
            this.InvokeAsync("getServiceStatus", new object[0], this.getServiceStatusOperationCompleted, userState);
        }
        
        private void OngetServiceStatusOperationCompleted(object arg) {
            if ((this.getServiceStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.getServiceStatusCompleted(this, new getServiceStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld(string sRequestXML) {
            object[] results = this.Invoke("HelloWorld", new object[] {
                        sRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync(string sRequestXML) {
            this.HelloWorldAsync(sRequestXML, null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(string sRequestXML, object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[] {
                        sRequestXML}, this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void SubmitRequestStandardCompletedEventHandler(object sender, SubmitRequestStandardCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubmitRequestStandardCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SubmitRequestStandardCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SubmitRequestAPICompletedEventHandler(object sender, SubmitRequestAPICompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubmitRequestAPICompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SubmitRequestAPICompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void getServiceStatusCompletedEventHandler(object sender, getServiceStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class getServiceStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal getServiceStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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