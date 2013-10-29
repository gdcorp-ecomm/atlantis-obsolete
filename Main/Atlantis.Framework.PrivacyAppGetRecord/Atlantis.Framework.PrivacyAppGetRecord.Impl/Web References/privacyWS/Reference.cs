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

namespace Atlantis.Framework.PrivacyAppGetRecord.Impl.privacyWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="wscgdPrivacyAppServiceSoap", Namespace="urn:wscgdPrivacyAppService")]
    public partial class wscgdPrivacyAppService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback InsertRecordOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateRecordOperationCompleted;
        
        private System.Threading.SendOrPostCallback DeleteRecordOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertUpdateOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateDeleteOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecordOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertEmailAddressOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetEmailAddressByHashOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public wscgdPrivacyAppService() {
            this.Url = global::Atlantis.Framework.PrivacyAppGetRecord.Impl.Properties.Settings.Default.Atlantis_Framework_PrivacyAppGetRecord_Impl_privacyWS_wscgdPrivacyAppService;
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
        public event InsertRecordCompletedEventHandler InsertRecordCompleted;
        
        /// <remarks/>
        public event UpdateRecordCompletedEventHandler UpdateRecordCompleted;
        
        /// <remarks/>
        public event DeleteRecordCompletedEventHandler DeleteRecordCompleted;
        
        /// <remarks/>
        public event InsertUpdateCompletedEventHandler InsertUpdateCompleted;
        
        /// <remarks/>
        public event UpdateDeleteCompletedEventHandler UpdateDeleteCompleted;
        
        /// <remarks/>
        public event GetRecordCompletedEventHandler GetRecordCompleted;
        
        /// <remarks/>
        public event InsertEmailAddressCompletedEventHandler InsertEmailAddressCompleted;
        
        /// <remarks/>
        public event GetEmailAddressByHashCompletedEventHandler GetEmailAddressByHashCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#InsertRecord", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int InsertRecord(string bstrXML, out string pbstrOutput) {
            object[] results = this.Invoke("InsertRecord", new object[] {
                        bstrXML});
            pbstrOutput = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void InsertRecordAsync(string bstrXML) {
            this.InsertRecordAsync(bstrXML, null);
        }
        
        /// <remarks/>
        public void InsertRecordAsync(string bstrXML, object userState) {
            if ((this.InsertRecordOperationCompleted == null)) {
                this.InsertRecordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertRecordOperationCompleted);
            }
            this.InvokeAsync("InsertRecord", new object[] {
                        bstrXML}, this.InsertRecordOperationCompleted, userState);
        }
        
        private void OnInsertRecordOperationCompleted(object arg) {
            if ((this.InsertRecordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertRecordCompleted(this, new InsertRecordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#UpdateRecord", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int UpdateRecord(string bstrXML, out string pbstrOutput) {
            object[] results = this.Invoke("UpdateRecord", new object[] {
                        bstrXML});
            pbstrOutput = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateRecordAsync(string bstrXML) {
            this.UpdateRecordAsync(bstrXML, null);
        }
        
        /// <remarks/>
        public void UpdateRecordAsync(string bstrXML, object userState) {
            if ((this.UpdateRecordOperationCompleted == null)) {
                this.UpdateRecordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateRecordOperationCompleted);
            }
            this.InvokeAsync("UpdateRecord", new object[] {
                        bstrXML}, this.UpdateRecordOperationCompleted, userState);
        }
        
        private void OnUpdateRecordOperationCompleted(object arg) {
            if ((this.UpdateRecordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateRecordCompleted(this, new UpdateRecordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#DeleteRecord", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int DeleteRecord(string bstrHash, int lAppID, out string pbstrOutput) {
            object[] results = this.Invoke("DeleteRecord", new object[] {
                        bstrHash,
                        lAppID});
            pbstrOutput = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void DeleteRecordAsync(string bstrHash, int lAppID) {
            this.DeleteRecordAsync(bstrHash, lAppID, null);
        }
        
        /// <remarks/>
        public void DeleteRecordAsync(string bstrHash, int lAppID, object userState) {
            if ((this.DeleteRecordOperationCompleted == null)) {
                this.DeleteRecordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnDeleteRecordOperationCompleted);
            }
            this.InvokeAsync("DeleteRecord", new object[] {
                        bstrHash,
                        lAppID}, this.DeleteRecordOperationCompleted, userState);
        }
        
        private void OnDeleteRecordOperationCompleted(object arg) {
            if ((this.DeleteRecordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.DeleteRecordCompleted(this, new DeleteRecordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#InsertUpdate", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int InsertUpdate(string bstrXML, out string pbstrOutput) {
            object[] results = this.Invoke("InsertUpdate", new object[] {
                        bstrXML});
            pbstrOutput = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void InsertUpdateAsync(string bstrXML) {
            this.InsertUpdateAsync(bstrXML, null);
        }
        
        /// <remarks/>
        public void InsertUpdateAsync(string bstrXML, object userState) {
            if ((this.InsertUpdateOperationCompleted == null)) {
                this.InsertUpdateOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertUpdateOperationCompleted);
            }
            this.InvokeAsync("InsertUpdate", new object[] {
                        bstrXML}, this.InsertUpdateOperationCompleted, userState);
        }
        
        private void OnInsertUpdateOperationCompleted(object arg) {
            if ((this.InsertUpdateCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertUpdateCompleted(this, new InsertUpdateCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#UpdateDelete", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int UpdateDelete(string bstrXML, out string pbstrOutput) {
            object[] results = this.Invoke("UpdateDelete", new object[] {
                        bstrXML});
            pbstrOutput = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void UpdateDeleteAsync(string bstrXML) {
            this.UpdateDeleteAsync(bstrXML, null);
        }
        
        /// <remarks/>
        public void UpdateDeleteAsync(string bstrXML, object userState) {
            if ((this.UpdateDeleteOperationCompleted == null)) {
                this.UpdateDeleteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateDeleteOperationCompleted);
            }
            this.InvokeAsync("UpdateDelete", new object[] {
                        bstrXML}, this.UpdateDeleteOperationCompleted, userState);
        }
        
        private void OnUpdateDeleteOperationCompleted(object arg) {
            if ((this.UpdateDeleteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateDeleteCompleted(this, new UpdateDeleteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#GetRecord", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public int GetRecord(string bstrHash, int lAppID, out string pbstrOutput) {
            object[] results = this.Invoke("GetRecord", new object[] {
                        bstrHash,
                        lAppID});
            pbstrOutput = ((string)(results[1]));
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecordAsync(string bstrHash, int lAppID) {
            this.GetRecordAsync(bstrHash, lAppID, null);
        }
        
        /// <remarks/>
        public void GetRecordAsync(string bstrHash, int lAppID, object userState) {
            if ((this.GetRecordOperationCompleted == null)) {
                this.GetRecordOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecordOperationCompleted);
            }
            this.InvokeAsync("GetRecord", new object[] {
                        bstrHash,
                        lAppID}, this.GetRecordOperationCompleted, userState);
        }
        
        private void OnGetRecordOperationCompleted(object arg) {
            if ((this.GetRecordCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecordCompleted(this, new GetRecordCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#InsertEmailAddress", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string InsertEmailAddress(string bstrEmailAddress, out string pbstrError) {
            object[] results = this.Invoke("InsertEmailAddress", new object[] {
                        bstrEmailAddress});
            pbstrError = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void InsertEmailAddressAsync(string bstrEmailAddress) {
            this.InsertEmailAddressAsync(bstrEmailAddress, null);
        }
        
        /// <remarks/>
        public void InsertEmailAddressAsync(string bstrEmailAddress, object userState) {
            if ((this.InsertEmailAddressOperationCompleted == null)) {
                this.InsertEmailAddressOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertEmailAddressOperationCompleted);
            }
            this.InvokeAsync("InsertEmailAddress", new object[] {
                        bstrEmailAddress}, this.InsertEmailAddressOperationCompleted, userState);
        }
        
        private void OnInsertEmailAddressOperationCompleted(object arg) {
            if ((this.InsertEmailAddressCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertEmailAddressCompleted(this, new InsertEmailAddressCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#GetEmailAddressByHash", RequestNamespace="urn:wscgdPrivacyAppService", ResponseNamespace="urn:wscgdPrivacyAppService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string GetEmailAddressByHash(string bstrEmailHash, out string pbstrError) {
            object[] results = this.Invoke("GetEmailAddressByHash", new object[] {
                        bstrEmailHash});
            pbstrError = ((string)(results[1]));
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetEmailAddressByHashAsync(string bstrEmailHash) {
            this.GetEmailAddressByHashAsync(bstrEmailHash, null);
        }
        
        /// <remarks/>
        public void GetEmailAddressByHashAsync(string bstrEmailHash, object userState) {
            if ((this.GetEmailAddressByHashOperationCompleted == null)) {
                this.GetEmailAddressByHashOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetEmailAddressByHashOperationCompleted);
            }
            this.InvokeAsync("GetEmailAddressByHash", new object[] {
                        bstrEmailHash}, this.GetEmailAddressByHashOperationCompleted, userState);
        }
        
        private void OnGetEmailAddressByHashOperationCompleted(object arg) {
            if ((this.GetEmailAddressByHashCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetEmailAddressByHashCompleted(this, new GetEmailAddressByHashCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void InsertRecordCompletedEventHandler(object sender, InsertRecordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertRecordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertRecordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrOutput {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateRecordCompletedEventHandler(object sender, UpdateRecordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateRecordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateRecordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrOutput {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void DeleteRecordCompletedEventHandler(object sender, DeleteRecordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class DeleteRecordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal DeleteRecordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrOutput {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertUpdateCompletedEventHandler(object sender, InsertUpdateCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertUpdateCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertUpdateCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrOutput {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void UpdateDeleteCompletedEventHandler(object sender, UpdateDeleteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateDeleteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal UpdateDeleteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrOutput {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetRecordCompletedEventHandler(object sender, GetRecordCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecordCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecordCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrOutput {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void InsertEmailAddressCompletedEventHandler(object sender, InsertEmailAddressCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class InsertEmailAddressCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal InsertEmailAddressCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrError {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetEmailAddressByHashCompletedEventHandler(object sender, GetEmailAddressByHashCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetEmailAddressByHashCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetEmailAddressByHashCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public string pbstrError {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[1]));
            }
        }
    }
}

#pragma warning restore 1591