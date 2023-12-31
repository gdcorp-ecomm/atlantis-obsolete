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

namespace Atlantis.Framework.PresentationCentral.Impl.PresentationCentral {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="PresentationCentralSoap", Namespace="http://atlantis.presentationcentral.prod.mesa1.gdg/")]
    public partial class PresentationCentral : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback RequestHTMLOperationCompleted;
        
        private System.Threading.SendOrPostCallback ClearApplicationCacheOperationCompleted;
        
        private System.Threading.SendOrPostCallback ReturnApplicationCacheOperationCompleted;
        
        private System.Threading.SendOrPostCallback getServiceStatusOperationCompleted;
        
        private System.Threading.SendOrPostCallback isMirageDifferentToProdOfferingOperationCompleted;
        
        private System.Threading.SendOrPostCallback CurrentCachedCategoriesOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public PresentationCentral() {
            this.Url = "http://presentationcentral.dev.glbt1.gdg/atlantis/presentationcentral.asmx";
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
        public event RequestHTMLCompletedEventHandler RequestHTMLCompleted;
        
        /// <remarks/>
        public event ClearApplicationCacheCompletedEventHandler ClearApplicationCacheCompleted;
        
        /// <remarks/>
        public event ReturnApplicationCacheCompletedEventHandler ReturnApplicationCacheCompleted;
        
        /// <remarks/>
        public event getServiceStatusCompletedEventHandler getServiceStatusCompleted;
        
        /// <remarks/>
        public event isMirageDifferentToProdOfferingCompletedEventHandler isMirageDifferentToProdOfferingCompleted;
        
        /// <remarks/>
        public event CurrentCachedCategoriesCompletedEventHandler CurrentCachedCategoriesCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://atlantis.presentationcentral.prod.mesa1.gdg/RequestHTML", RequestNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", ResponseNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode RequestHTML(string xmlRequest) {
            object[] results = this.Invoke("RequestHTML", new object[] {
                        xmlRequest});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginRequestHTML(string xmlRequest, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("RequestHTML", new object[] {
                        xmlRequest}, callback, asyncState);
        }
        
        /// <remarks/>
        public System.Xml.XmlNode EndRequestHTML(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void RequestHTMLAsync(string xmlRequest) {
            this.RequestHTMLAsync(xmlRequest, null);
        }
        
        /// <remarks/>
        public void RequestHTMLAsync(string xmlRequest, object userState) {
            if ((this.RequestHTMLOperationCompleted == null)) {
                this.RequestHTMLOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRequestHTMLOperationCompleted);
            }
            this.InvokeAsync("RequestHTML", new object[] {
                        xmlRequest}, this.RequestHTMLOperationCompleted, userState);
        }
        
        private void OnRequestHTMLOperationCompleted(object arg) {
            if ((this.RequestHTMLCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RequestHTMLCompleted(this, new RequestHTMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://atlantis.presentationcentral.prod.mesa1.gdg/ClearApplicationCache", RequestNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", ResponseNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int ClearApplicationCache(string key) {
            object[] results = this.Invoke("ClearApplicationCache", new object[] {
                        key});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginClearApplicationCache(string key, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ClearApplicationCache", new object[] {
                        key}, callback, asyncState);
        }
        
        /// <remarks/>
        public int EndClearApplicationCache(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void ClearApplicationCacheAsync(string key) {
            this.ClearApplicationCacheAsync(key, null);
        }
        
        /// <remarks/>
        public void ClearApplicationCacheAsync(string key, object userState) {
            if ((this.ClearApplicationCacheOperationCompleted == null)) {
                this.ClearApplicationCacheOperationCompleted = new System.Threading.SendOrPostCallback(this.OnClearApplicationCacheOperationCompleted);
            }
            this.InvokeAsync("ClearApplicationCache", new object[] {
                        key}, this.ClearApplicationCacheOperationCompleted, userState);
        }
        
        private void OnClearApplicationCacheOperationCompleted(object arg) {
            if ((this.ClearApplicationCacheCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ClearApplicationCacheCompleted(this, new ClearApplicationCacheCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://atlantis.presentationcentral.prod.mesa1.gdg/ReturnApplicationCache", RequestNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", ResponseNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string ReturnApplicationCache() {
            object[] results = this.Invoke("ReturnApplicationCache", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginReturnApplicationCache(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("ReturnApplicationCache", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndReturnApplicationCache(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void ReturnApplicationCacheAsync() {
            this.ReturnApplicationCacheAsync(null);
        }
        
        /// <remarks/>
        public void ReturnApplicationCacheAsync(object userState) {
            if ((this.ReturnApplicationCacheOperationCompleted == null)) {
                this.ReturnApplicationCacheOperationCompleted = new System.Threading.SendOrPostCallback(this.OnReturnApplicationCacheOperationCompleted);
            }
            this.InvokeAsync("ReturnApplicationCache", new object[0], this.ReturnApplicationCacheOperationCompleted, userState);
        }
        
        private void OnReturnApplicationCacheOperationCompleted(object arg) {
            if ((this.ReturnApplicationCacheCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ReturnApplicationCacheCompleted(this, new ReturnApplicationCacheCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://atlantis.presentationcentral.prod.mesa1.gdg/getServiceStatus", RequestNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", ResponseNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getServiceStatus() {
            object[] results = this.Invoke("getServiceStatus", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BegingetServiceStatus(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("getServiceStatus", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndgetServiceStatus(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
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
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://atlantis.presentationcentral.prod.mesa1.gdg/isMirageDifferentToProdOfferin" +
            "g", RequestNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", ResponseNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool isMirageDifferentToProdOffering(string sShopperID, int privateLabelID) {
            object[] results = this.Invoke("isMirageDifferentToProdOffering", new object[] {
                        sShopperID,
                        privateLabelID});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginisMirageDifferentToProdOffering(string sShopperID, int privateLabelID, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("isMirageDifferentToProdOffering", new object[] {
                        sShopperID,
                        privateLabelID}, callback, asyncState);
        }
        
        /// <remarks/>
        public bool EndisMirageDifferentToProdOffering(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void isMirageDifferentToProdOfferingAsync(string sShopperID, int privateLabelID) {
            this.isMirageDifferentToProdOfferingAsync(sShopperID, privateLabelID, null);
        }
        
        /// <remarks/>
        public void isMirageDifferentToProdOfferingAsync(string sShopperID, int privateLabelID, object userState) {
            if ((this.isMirageDifferentToProdOfferingOperationCompleted == null)) {
                this.isMirageDifferentToProdOfferingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnisMirageDifferentToProdOfferingOperationCompleted);
            }
            this.InvokeAsync("isMirageDifferentToProdOffering", new object[] {
                        sShopperID,
                        privateLabelID}, this.isMirageDifferentToProdOfferingOperationCompleted, userState);
        }
        
        private void OnisMirageDifferentToProdOfferingOperationCompleted(object arg) {
            if ((this.isMirageDifferentToProdOfferingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.isMirageDifferentToProdOfferingCompleted(this, new isMirageDifferentToProdOfferingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://atlantis.presentationcentral.prod.mesa1.gdg/CurrentCachedCategories", RequestNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", ResponseNamespace="http://atlantis.presentationcentral.prod.mesa1.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CurrentCachedCategories() {
            object[] results = this.Invoke("CurrentCachedCategories", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginCurrentCachedCategories(System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("CurrentCachedCategories", new object[0], callback, asyncState);
        }
        
        /// <remarks/>
        public string EndCurrentCachedCategories(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CurrentCachedCategoriesAsync() {
            this.CurrentCachedCategoriesAsync(null);
        }
        
        /// <remarks/>
        public void CurrentCachedCategoriesAsync(object userState) {
            if ((this.CurrentCachedCategoriesOperationCompleted == null)) {
                this.CurrentCachedCategoriesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCurrentCachedCategoriesOperationCompleted);
            }
            this.InvokeAsync("CurrentCachedCategories", new object[0], this.CurrentCachedCategoriesOperationCompleted, userState);
        }
        
        private void OnCurrentCachedCategoriesOperationCompleted(object arg) {
            if ((this.CurrentCachedCategoriesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CurrentCachedCategoriesCompleted(this, new CurrentCachedCategoriesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void RequestHTMLCompletedEventHandler(object sender, RequestHTMLCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RequestHTMLCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RequestHTMLCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Xml.XmlNode Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Xml.XmlNode)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ClearApplicationCacheCompletedEventHandler(object sender, ClearApplicationCacheCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ClearApplicationCacheCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ClearApplicationCacheCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ReturnApplicationCacheCompletedEventHandler(object sender, ReturnApplicationCacheCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ReturnApplicationCacheCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ReturnApplicationCacheCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void isMirageDifferentToProdOfferingCompletedEventHandler(object sender, isMirageDifferentToProdOfferingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class isMirageDifferentToProdOfferingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal isMirageDifferentToProdOfferingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CurrentCachedCategoriesCompletedEventHandler(object sender, CurrentCachedCategoriesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CurrentCachedCategoriesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CurrentCachedCategoriesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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