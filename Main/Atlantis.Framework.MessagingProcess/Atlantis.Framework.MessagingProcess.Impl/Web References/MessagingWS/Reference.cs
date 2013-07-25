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

namespace Atlantis.Framework.MessagingProcess.Impl.MessagingWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="WSCgdMessagingSystemServiceSoap", Namespace="urn:WSCgdMessagingSystemService")]
    public partial class WSCgdMessagingSystemService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ProcessXmlOperationCompleted;
        
        private System.Threading.SendOrPostCallback ProcessShopperMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback ProcessGenericMessageOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFailedMessagesByTypeOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetFailedMessagesByNamespaceOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetMessageStatusOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSCgdMessagingSystemService() {
            this.Url = global::Atlantis.Framework.MessagingProcess.Impl.Properties.Settings.Default.Atlantis_Framework_MessagingProcess_Impl_MessagingWS_WSCgdMessagingSystemService;
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
        public event ProcessXmlCompletedEventHandler ProcessXmlCompleted;
        
        /// <remarks/>
        public event ProcessShopperMessageCompletedEventHandler ProcessShopperMessageCompleted;
        
        /// <remarks/>
        public event ProcessGenericMessageCompletedEventHandler ProcessGenericMessageCompleted;
        
        /// <remarks/>
        public event GetFailedMessagesByTypeCompletedEventHandler GetFailedMessagesByTypeCompleted;
        
        /// <remarks/>
        public event GetFailedMessagesByNamespaceCompletedEventHandler GetFailedMessagesByNamespaceCompleted;
        
        /// <remarks/>
        public event GetMessageStatusCompletedEventHandler GetMessageStatusCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#ProcessXml", RequestNamespace="urn:WSCgdMessagingSystemService", ResponseNamespace="urn:WSCgdMessagingSystemService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string ProcessXml(string bstrMessageXml) {
            object[] results = this.Invoke("ProcessXml", new object[] {
                        bstrMessageXml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ProcessXmlAsync(string bstrMessageXml) {
            this.ProcessXmlAsync(bstrMessageXml, null);
        }
        
        /// <remarks/>
        public void ProcessXmlAsync(string bstrMessageXml, object userState) {
            if ((this.ProcessXmlOperationCompleted == null)) {
                this.ProcessXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProcessXmlOperationCompleted);
            }
            this.InvokeAsync("ProcessXml", new object[] {
                        bstrMessageXml}, this.ProcessXmlOperationCompleted, userState);
        }
        
        private void OnProcessXmlOperationCompleted(object arg) {
            if ((this.ProcessXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProcessXmlCompleted(this, new ProcessXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#ProcessShopperMessage", RequestNamespace="urn:WSCgdMessagingSystemService", ResponseNamespace="urn:WSCgdMessagingSystemService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string ProcessShopperMessage(string bstrMessageXml) {
            object[] results = this.Invoke("ProcessShopperMessage", new object[] {
                        bstrMessageXml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ProcessShopperMessageAsync(string bstrMessageXml) {
            this.ProcessShopperMessageAsync(bstrMessageXml, null);
        }
        
        /// <remarks/>
        public void ProcessShopperMessageAsync(string bstrMessageXml, object userState) {
            if ((this.ProcessShopperMessageOperationCompleted == null)) {
                this.ProcessShopperMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProcessShopperMessageOperationCompleted);
            }
            this.InvokeAsync("ProcessShopperMessage", new object[] {
                        bstrMessageXml}, this.ProcessShopperMessageOperationCompleted, userState);
        }
        
        private void OnProcessShopperMessageOperationCompleted(object arg) {
            if ((this.ProcessShopperMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProcessShopperMessageCompleted(this, new ProcessShopperMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#ProcessGenericMessage", RequestNamespace="urn:WSCgdMessagingSystemService", ResponseNamespace="urn:WSCgdMessagingSystemService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string ProcessGenericMessage(string bstrMessageXml) {
            object[] results = this.Invoke("ProcessGenericMessage", new object[] {
                        bstrMessageXml});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ProcessGenericMessageAsync(string bstrMessageXml) {
            this.ProcessGenericMessageAsync(bstrMessageXml, null);
        }
        
        /// <remarks/>
        public void ProcessGenericMessageAsync(string bstrMessageXml, object userState) {
            if ((this.ProcessGenericMessageOperationCompleted == null)) {
                this.ProcessGenericMessageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnProcessGenericMessageOperationCompleted);
            }
            this.InvokeAsync("ProcessGenericMessage", new object[] {
                        bstrMessageXml}, this.ProcessGenericMessageOperationCompleted, userState);
        }
        
        private void OnProcessGenericMessageOperationCompleted(object arg) {
            if ((this.ProcessGenericMessageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ProcessGenericMessageCompleted(this, new ProcessGenericMessageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#GetFailedMessagesByType", RequestNamespace="urn:WSCgdMessagingSystemService", ResponseNamespace="urn:WSCgdMessagingSystemService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetFailedMessagesByType(string bstrNamespace, string bstrType) {
            object[] results = this.Invoke("GetFailedMessagesByType", new object[] {
                        bstrNamespace,
                        bstrType});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetFailedMessagesByTypeAsync(string bstrNamespace, string bstrType) {
            this.GetFailedMessagesByTypeAsync(bstrNamespace, bstrType, null);
        }
        
        /// <remarks/>
        public void GetFailedMessagesByTypeAsync(string bstrNamespace, string bstrType, object userState) {
            if ((this.GetFailedMessagesByTypeOperationCompleted == null)) {
                this.GetFailedMessagesByTypeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFailedMessagesByTypeOperationCompleted);
            }
            this.InvokeAsync("GetFailedMessagesByType", new object[] {
                        bstrNamespace,
                        bstrType}, this.GetFailedMessagesByTypeOperationCompleted, userState);
        }
        
        private void OnGetFailedMessagesByTypeOperationCompleted(object arg) {
            if ((this.GetFailedMessagesByTypeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFailedMessagesByTypeCompleted(this, new GetFailedMessagesByTypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#GetFailedMessagesByNamespace", RequestNamespace="urn:WSCgdMessagingSystemService", ResponseNamespace="urn:WSCgdMessagingSystemService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetFailedMessagesByNamespace(string bstrNamespace) {
            object[] results = this.Invoke("GetFailedMessagesByNamespace", new object[] {
                        bstrNamespace});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetFailedMessagesByNamespaceAsync(string bstrNamespace) {
            this.GetFailedMessagesByNamespaceAsync(bstrNamespace, null);
        }
        
        /// <remarks/>
        public void GetFailedMessagesByNamespaceAsync(string bstrNamespace, object userState) {
            if ((this.GetFailedMessagesByNamespaceOperationCompleted == null)) {
                this.GetFailedMessagesByNamespaceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetFailedMessagesByNamespaceOperationCompleted);
            }
            this.InvokeAsync("GetFailedMessagesByNamespace", new object[] {
                        bstrNamespace}, this.GetFailedMessagesByNamespaceOperationCompleted, userState);
        }
        
        private void OnGetFailedMessagesByNamespaceOperationCompleted(object arg) {
            if ((this.GetFailedMessagesByNamespaceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetFailedMessagesByNamespaceCompleted(this, new GetFailedMessagesByNamespaceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#GetMessageStatus", RequestNamespace="urn:WSCgdMessagingSystemService", ResponseNamespace="urn:WSCgdMessagingSystemService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetMessageStatus(string bstrMessageID) {
            object[] results = this.Invoke("GetMessageStatus", new object[] {
                        bstrMessageID});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetMessageStatusAsync(string bstrMessageID) {
            this.GetMessageStatusAsync(bstrMessageID, null);
        }
        
        /// <remarks/>
        public void GetMessageStatusAsync(string bstrMessageID, object userState) {
            if ((this.GetMessageStatusOperationCompleted == null)) {
                this.GetMessageStatusOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetMessageStatusOperationCompleted);
            }
            this.InvokeAsync("GetMessageStatus", new object[] {
                        bstrMessageID}, this.GetMessageStatusOperationCompleted, userState);
        }
        
        private void OnGetMessageStatusOperationCompleted(object arg) {
            if ((this.GetMessageStatusCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetMessageStatusCompleted(this, new GetMessageStatusCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void ProcessXmlCompletedEventHandler(object sender, ProcessXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProcessXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProcessXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ProcessShopperMessageCompletedEventHandler(object sender, ProcessShopperMessageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProcessShopperMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProcessShopperMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ProcessGenericMessageCompletedEventHandler(object sender, ProcessGenericMessageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProcessGenericMessageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ProcessGenericMessageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetFailedMessagesByTypeCompletedEventHandler(object sender, GetFailedMessagesByTypeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFailedMessagesByTypeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFailedMessagesByTypeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetFailedMessagesByNamespaceCompletedEventHandler(object sender, GetFailedMessagesByNamespaceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetFailedMessagesByNamespaceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetFailedMessagesByNamespaceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetMessageStatusCompletedEventHandler(object sender, GetMessageStatusCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetMessageStatusCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetMessageStatusCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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