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

namespace Atlantis.Framework.UpdateShopper.Impl.WscgdShopper {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="WSCgdShopperServiceSoap", Namespace="urn:WSCgdShopperService")]
    public partial class WSCgdShopperService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetShopperOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateShopperOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchShoppersOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateShopperOperationCompleted;
        
        private System.Threading.SendOrPostCallback AuditShopperOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsShopperPINSetOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateShopperForIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback CopyShopperWithUpdatesOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdatePaymentTypeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSCgdShopperService() {
            this.Url = global::Atlantis.Framework.UpdateShopper.Impl.Properties.Settings.Default.Atlantis_Framework_UpdateShopper_Impl_WscgdShopper_WSCgdShopperService;
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
        public event GetShopperCompletedEventHandler GetShopperCompleted;
        
        /// <remarks/>
        public event UpdateShopperCompletedEventHandler UpdateShopperCompleted;
        
        /// <remarks/>
        public event SearchShoppersCompletedEventHandler SearchShoppersCompleted;
        
        /// <remarks/>
        public event CreateShopperCompletedEventHandler CreateShopperCompleted;
        
        /// <remarks/>
        public event AuditShopperCompletedEventHandler AuditShopperCompleted;
        
        /// <remarks/>
        public event IsShopperPINSetCompletedEventHandler IsShopperPINSetCompleted;
        
        /// <remarks/>
        public event CreateShopperForIdCompletedEventHandler CreateShopperForIdCompleted;
        
        /// <remarks/>
        public event CopyShopperWithUpdatesCompletedEventHandler CopyShopperWithUpdatesCompleted;
        
        /// <remarks/>
        public event UpdatePaymentTypeCompletedEventHandler UpdatePaymentTypeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#GetShopper", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetShopper(string bstrRequestXML) {
            object[] results = this.Invoke("GetShopper", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetShopperAsync(string bstrRequestXML) {
            this.GetShopperAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void GetShopperAsync(string bstrRequestXML, object userState) {
            if ((this.GetShopperOperationCompleted == null)) {
                this.GetShopperOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetShopperOperationCompleted);
            }
            this.InvokeAsync("GetShopper", new object[] {
                        bstrRequestXML}, this.GetShopperOperationCompleted, userState);
        }
        
        private void OnGetShopperOperationCompleted(object arg) {
            if ((this.GetShopperCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetShopperCompleted(this, new GetShopperCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#UpdateShopper", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string UpdateShopper(string bstrRequestXML) {
            object[] results = this.Invoke("UpdateShopper", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateShopperAsync(string bstrRequestXML) {
            this.UpdateShopperAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void UpdateShopperAsync(string bstrRequestXML, object userState) {
            if ((this.UpdateShopperOperationCompleted == null)) {
                this.UpdateShopperOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateShopperOperationCompleted);
            }
            this.InvokeAsync("UpdateShopper", new object[] {
                        bstrRequestXML}, this.UpdateShopperOperationCompleted, userState);
        }
        
        private void OnUpdateShopperOperationCompleted(object arg) {
            if ((this.UpdateShopperCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateShopperCompleted(this, new UpdateShopperCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#SearchShoppers", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string SearchShoppers(string bstrRequestXML) {
            object[] results = this.Invoke("SearchShoppers", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SearchShoppersAsync(string bstrRequestXML) {
            this.SearchShoppersAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void SearchShoppersAsync(string bstrRequestXML, object userState) {
            if ((this.SearchShoppersOperationCompleted == null)) {
                this.SearchShoppersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchShoppersOperationCompleted);
            }
            this.InvokeAsync("SearchShoppers", new object[] {
                        bstrRequestXML}, this.SearchShoppersOperationCompleted, userState);
        }
        
        private void OnSearchShoppersOperationCompleted(object arg) {
            if ((this.SearchShoppersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchShoppersCompleted(this, new SearchShoppersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#CreateShopper", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string CreateShopper(string bstrRequestXML) {
            object[] results = this.Invoke("CreateShopper", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CreateShopperAsync(string bstrRequestXML) {
            this.CreateShopperAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void CreateShopperAsync(string bstrRequestXML, object userState) {
            if ((this.CreateShopperOperationCompleted == null)) {
                this.CreateShopperOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateShopperOperationCompleted);
            }
            this.InvokeAsync("CreateShopper", new object[] {
                        bstrRequestXML}, this.CreateShopperOperationCompleted, userState);
        }
        
        private void OnCreateShopperOperationCompleted(object arg) {
            if ((this.CreateShopperCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateShopperCompleted(this, new CreateShopperCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#AuditShopper", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string AuditShopper(string bstrRequestXML) {
            object[] results = this.Invoke("AuditShopper", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void AuditShopperAsync(string bstrRequestXML) {
            this.AuditShopperAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void AuditShopperAsync(string bstrRequestXML, object userState) {
            if ((this.AuditShopperOperationCompleted == null)) {
                this.AuditShopperOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAuditShopperOperationCompleted);
            }
            this.InvokeAsync("AuditShopper", new object[] {
                        bstrRequestXML}, this.AuditShopperOperationCompleted, userState);
        }
        
        private void OnAuditShopperOperationCompleted(object arg) {
            if ((this.AuditShopperCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AuditShopperCompleted(this, new AuditShopperCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#IsShopperPINSet", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int IsShopperPINSet(string bstrShopperID) {
            object[] results = this.Invoke("IsShopperPINSet", new object[] {
                        bstrShopperID});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void IsShopperPINSetAsync(string bstrShopperID) {
            this.IsShopperPINSetAsync(bstrShopperID, null);
        }
        
        /// <remarks/>
        public void IsShopperPINSetAsync(string bstrShopperID, object userState) {
            if ((this.IsShopperPINSetOperationCompleted == null)) {
                this.IsShopperPINSetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsShopperPINSetOperationCompleted);
            }
            this.InvokeAsync("IsShopperPINSet", new object[] {
                        bstrShopperID}, this.IsShopperPINSetOperationCompleted, userState);
        }
        
        private void OnIsShopperPINSetOperationCompleted(object arg) {
            if ((this.IsShopperPINSetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsShopperPINSetCompleted(this, new IsShopperPINSetCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#CreateShopperForId", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string CreateShopperForId(string bstrRequestXML) {
            object[] results = this.Invoke("CreateShopperForId", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CreateShopperForIdAsync(string bstrRequestXML) {
            this.CreateShopperForIdAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void CreateShopperForIdAsync(string bstrRequestXML, object userState) {
            if ((this.CreateShopperForIdOperationCompleted == null)) {
                this.CreateShopperForIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateShopperForIdOperationCompleted);
            }
            this.InvokeAsync("CreateShopperForId", new object[] {
                        bstrRequestXML}, this.CreateShopperForIdOperationCompleted, userState);
        }
        
        private void OnCreateShopperForIdOperationCompleted(object arg) {
            if ((this.CreateShopperForIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateShopperForIdCompleted(this, new CreateShopperForIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#CopyShopperWithUpdates", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string CopyShopperWithUpdates(string bstrRequestXML) {
            object[] results = this.Invoke("CopyShopperWithUpdates", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void CopyShopperWithUpdatesAsync(string bstrRequestXML) {
            this.CopyShopperWithUpdatesAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void CopyShopperWithUpdatesAsync(string bstrRequestXML, object userState) {
            if ((this.CopyShopperWithUpdatesOperationCompleted == null)) {
                this.CopyShopperWithUpdatesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCopyShopperWithUpdatesOperationCompleted);
            }
            this.InvokeAsync("CopyShopperWithUpdates", new object[] {
                        bstrRequestXML}, this.CopyShopperWithUpdatesOperationCompleted, userState);
        }
        
        private void OnCopyShopperWithUpdatesOperationCompleted(object arg) {
            if ((this.CopyShopperWithUpdatesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CopyShopperWithUpdatesCompleted(this, new CopyShopperWithUpdatesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#UpdatePaymentType", RequestNamespace="urn:WSCgdShopperService", ResponseNamespace="urn:WSCgdShopperService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string UpdatePaymentType(string bstrRequestXML) {
            object[] results = this.Invoke("UpdatePaymentType", new object[] {
                        bstrRequestXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void UpdatePaymentTypeAsync(string bstrRequestXML) {
            this.UpdatePaymentTypeAsync(bstrRequestXML, null);
        }
        
        /// <remarks/>
        public void UpdatePaymentTypeAsync(string bstrRequestXML, object userState) {
            if ((this.UpdatePaymentTypeOperationCompleted == null)) {
                this.UpdatePaymentTypeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdatePaymentTypeOperationCompleted);
            }
            this.InvokeAsync("UpdatePaymentType", new object[] {
                        bstrRequestXML}, this.UpdatePaymentTypeOperationCompleted, userState);
        }
        
        private void OnUpdatePaymentTypeOperationCompleted(object arg) {
            if ((this.UpdatePaymentTypeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdatePaymentTypeCompleted(this, new UpdatePaymentTypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetShopperCompletedEventHandler(object sender, GetShopperCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetShopperCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetShopperCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void UpdateShopperCompletedEventHandler(object sender, UpdateShopperCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateShopperCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateShopperCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SearchShoppersCompletedEventHandler(object sender, SearchShoppersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchShoppersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchShoppersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void CreateShopperCompletedEventHandler(object sender, CreateShopperCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateShopperCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateShopperCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void AuditShopperCompletedEventHandler(object sender, AuditShopperCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AuditShopperCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AuditShopperCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void IsShopperPINSetCompletedEventHandler(object sender, IsShopperPINSetCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsShopperPINSetCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsShopperPINSetCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void CreateShopperForIdCompletedEventHandler(object sender, CreateShopperForIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateShopperForIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateShopperForIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void CopyShopperWithUpdatesCompletedEventHandler(object sender, CopyShopperWithUpdatesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CopyShopperWithUpdatesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CopyShopperWithUpdatesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void UpdatePaymentTypeCompletedEventHandler(object sender, UpdatePaymentTypeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdatePaymentTypeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdatePaymentTypeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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