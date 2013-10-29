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

namespace Atlantis.Framework.StratosphereGetMapUrl.Impl.StratosphereRequestbroker {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="ServiceSoap", Namespace="Stratosphere")]
    public partial class Service : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetMapUrlOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public Service() {
            this.Url = global::Atlantis.Framework.StratosphereGetMapUrl.Impl.Properties.Settings.Default.Atlantis_Framework_StratosphereGetMapUrl_Impl_StratosphereRequestbroker_Service;
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
        public event GetMapUrlCompletedEventHandler GetMapUrlCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("Stratosphere/GetMapUrl", RequestNamespace="Stratosphere", ResponseNamespace="Stratosphere", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("Result")]
        public WebServiceResponse GetMapUrl(string MapType, string LookupValue, out string Url) {
            object[] results = this.Invoke("GetMapUrl", new object[] {
                        MapType,
                        LookupValue});
            Url = ((string)(results[1]));
            return ((WebServiceResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetMapUrl(string MapType, string LookupValue, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetMapUrl", new object[] {
                        MapType,
                        LookupValue}, callback, asyncState);
        }
        
        /// <remarks/>
        public WebServiceResponse EndGetMapUrl(System.IAsyncResult asyncResult, out string Url) {
            object[] results = this.EndInvoke(asyncResult);
            Url = ((string)(results[1]));
            return ((WebServiceResponse)(results[0]));
        }
        
        /// <remarks/>
        public void GetMapUrlAsync(string MapType, string LookupValue) {
            this.GetMapUrlAsync(MapType, LookupValue, null);
        }
        
        /// <remarks/>
        public void GetMapUrlAsync(string MapType, string LookupValue, object userState) {
            if ((this.GetMapUrlOperationCompleted == null)) {
                this.GetMapUrlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMapUrlOperationCompleted);
            }
            this.InvokeAsync("GetMapUrl", new object[] {
                        MapType,
                        LookupValue}, this.GetMapUrlOperationCompleted, userState);
        }
        
        private void OnGetMapUrlOperationCompleted(object arg) {
            if ((this.GetMapUrlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMapUrlCompleted(this, new GetMapUrlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Stratosphere")]
    public partial class WebServiceResponse {
        
        private int resultCodeField;
        
        private string errorField;
        
        /// <remarks/>
        public int ResultCode {
            get {
                return this.resultCodeField;
            }
            set {
                this.resultCodeField = value;
            }
        }
        
        /// <remarks/>
        public string Error {
            get {
                return this.errorField;
            }
            set {
                this.errorField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetMapUrlCompletedEventHandler(object sender, GetMapUrlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMapUrlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMapUrlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public WebServiceResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WebServiceResponse)(this.results[0]));
            }
        }
        
        /// <remarks/>
        public string Url {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591