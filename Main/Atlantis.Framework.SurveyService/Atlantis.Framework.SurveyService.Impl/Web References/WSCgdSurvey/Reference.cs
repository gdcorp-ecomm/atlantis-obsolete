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

namespace Atlantis.Framework.SurveyService.Impl.WSCgdSurvey {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="WSCgdSurveyServiceSoap", Namespace="urn:WSCgdSurveyService")]
    public partial class WSCgdSurveyService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback LogCommercialDataOperationCompleted;
        
        private System.Threading.SendOrPostCallback SaveSBAnswersOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public WSCgdSurveyService() {
            this.Url = global::Atlantis.Framework.SurveyService.Impl.Properties.Settings.Default.Atlantis_Framework_SurveyService_Impl_WSCgdSurvey_WSCgdSurveyService;
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
        public event LogCommercialDataCompletedEventHandler LogCommercialDataCompleted;
        
        /// <remarks/>
        public event SaveSBAnswersCompletedEventHandler SaveSBAnswersCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#LogCommercialData", RequestNamespace="urn:WSCgdSurveyService", ResponseNamespace="urn:WSCgdSurveyService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string LogCommercialData(int lReferralID, int lMediaID, int lConnectionID, int lPLID, string bstrServerName) {
            object[] results = this.Invoke("LogCommercialData", new object[] {
                        lReferralID,
                        lMediaID,
                        lConnectionID,
                        lPLID,
                        bstrServerName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginLogCommercialData(int lReferralID, int lMediaID, int lConnectionID, int lPLID, string bstrServerName, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("LogCommercialData", new object[] {
                        lReferralID,
                        lMediaID,
                        lConnectionID,
                        lPLID,
                        bstrServerName}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndLogCommercialData(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void LogCommercialDataAsync(int lReferralID, int lMediaID, int lConnectionID, int lPLID, string bstrServerName) {
            this.LogCommercialDataAsync(lReferralID, lMediaID, lConnectionID, lPLID, bstrServerName, null);
        }
        
        /// <remarks/>
        public void LogCommercialDataAsync(int lReferralID, int lMediaID, int lConnectionID, int lPLID, string bstrServerName, object userState) {
            if ((this.LogCommercialDataOperationCompleted == null)) {
                this.LogCommercialDataOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogCommercialDataOperationCompleted);
            }
            this.InvokeAsync("LogCommercialData", new object[] {
                        lReferralID,
                        lMediaID,
                        lConnectionID,
                        lPLID,
                        bstrServerName}, this.LogCommercialDataOperationCompleted, userState);
        }
        
        private void OnLogCommercialDataOperationCompleted(object arg) {
            if ((this.LogCommercialDataCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogCommercialDataCompleted(this, new LogCommercialDataCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("#SaveSBAnswers", RequestNamespace="urn:WSCgdSurveyService", ResponseNamespace="urn:WSCgdSurveyService")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public string SaveSBAnswers(string bstrIPAddress, int lAdVersion, int lAgeGroupID, int lPoliticalID, string bstrAnswers) {
            object[] results = this.Invoke("SaveSBAnswers", new object[] {
                        bstrIPAddress,
                        lAdVersion,
                        lAgeGroupID,
                        lPoliticalID,
                        bstrAnswers});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSaveSBAnswers(string bstrIPAddress, int lAdVersion, int lAgeGroupID, int lPoliticalID, string bstrAnswers, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SaveSBAnswers", new object[] {
                        bstrIPAddress,
                        lAdVersion,
                        lAgeGroupID,
                        lPoliticalID,
                        bstrAnswers}, callback, asyncState);
        }
        
        /// <remarks/>
        public string EndSaveSBAnswers(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SaveSBAnswersAsync(string bstrIPAddress, int lAdVersion, int lAgeGroupID, int lPoliticalID, string bstrAnswers) {
            this.SaveSBAnswersAsync(bstrIPAddress, lAdVersion, lAgeGroupID, lPoliticalID, bstrAnswers, null);
        }
        
        /// <remarks/>
        public void SaveSBAnswersAsync(string bstrIPAddress, int lAdVersion, int lAgeGroupID, int lPoliticalID, string bstrAnswers, object userState) {
            if ((this.SaveSBAnswersOperationCompleted == null)) {
                this.SaveSBAnswersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSaveSBAnswersOperationCompleted);
            }
            this.InvokeAsync("SaveSBAnswers", new object[] {
                        bstrIPAddress,
                        lAdVersion,
                        lAgeGroupID,
                        lPoliticalID,
                        bstrAnswers}, this.SaveSBAnswersOperationCompleted, userState);
        }
        
        private void OnSaveSBAnswersOperationCompleted(object arg) {
            if ((this.SaveSBAnswersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SaveSBAnswersCompleted(this, new SaveSBAnswersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void LogCommercialDataCompletedEventHandler(object sender, LogCommercialDataCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class LogCommercialDataCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal LogCommercialDataCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void SaveSBAnswersCompletedEventHandler(object sender, SaveSBAnswersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SaveSBAnswersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SaveSBAnswersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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