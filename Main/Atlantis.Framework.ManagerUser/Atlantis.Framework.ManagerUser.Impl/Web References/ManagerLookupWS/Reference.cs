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

namespace Atlantis.Framework.ManagerUser.Impl.ManagerLookupWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="LookupServiceSoap", Namespace="http://Company.ManagerUserLookup.WebService")]
    public partial class LookupService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetUserMappingOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetUserMappingXmlOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public LookupService() {
            this.Url = global::Atlantis.Framework.ManagerUser.Impl.Properties.Settings.Default.Atlantis_Framework_ManagerUser_Impl_ManagerLookupWS_LookupService;
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
        public event GetUserMappingCompletedEventHandler GetUserMappingCompleted;
        
        /// <remarks/>
        public event GetUserMappingXmlCompletedEventHandler GetUserMappingXmlCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Company.ManagerUserLookup.WebService/GetUserMapping", RequestNamespace="http://Company.ManagerUserLookup.WebService", ResponseNamespace="http://Company.ManagerUserLookup.WebService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public UserMapping GetUserMapping(string ntDomain, string ntLoginName) {
            object[] results = this.Invoke("GetUserMapping", new object[] {
                        ntDomain,
                        ntLoginName});
            return ((UserMapping)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserMappingAsync(string ntDomain, string ntLoginName) {
            this.GetUserMappingAsync(ntDomain, ntLoginName, null);
        }
        
        /// <remarks/>
        public void GetUserMappingAsync(string ntDomain, string ntLoginName, object userState) {
            if ((this.GetUserMappingOperationCompleted == null)) {
                this.GetUserMappingOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserMappingOperationCompleted);
            }
            this.InvokeAsync("GetUserMapping", new object[] {
                        ntDomain,
                        ntLoginName}, this.GetUserMappingOperationCompleted, userState);
        }
        
        private void OnGetUserMappingOperationCompleted(object arg) {
            if ((this.GetUserMappingCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserMappingCompleted(this, new GetUserMappingCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://Company.ManagerUserLookup.WebService/GetUserMappingXml", RequestNamespace="http://Company.ManagerUserLookup.WebService", ResponseNamespace="http://Company.ManagerUserLookup.WebService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetUserMappingXml(string ntDomain, string ntLoginName) {
            object[] results = this.Invoke("GetUserMappingXml", new object[] {
                        ntDomain,
                        ntLoginName});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetUserMappingXmlAsync(string ntDomain, string ntLoginName) {
            this.GetUserMappingXmlAsync(ntDomain, ntLoginName, null);
        }
        
        /// <remarks/>
        public void GetUserMappingXmlAsync(string ntDomain, string ntLoginName, object userState) {
            if ((this.GetUserMappingXmlOperationCompleted == null)) {
                this.GetUserMappingXmlOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetUserMappingXmlOperationCompleted);
            }
            this.InvokeAsync("GetUserMappingXml", new object[] {
                        ntDomain,
                        ntLoginName}, this.GetUserMappingXmlOperationCompleted, userState);
        }
        
        private void OnGetUserMappingXmlOperationCompleted(object arg) {
            if ((this.GetUserMappingXmlCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetUserMappingXmlCompleted(this, new GetUserMappingXmlCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Company.ManagerUserLookup.WebService")]
    public partial class UserMapping {
        
        private bool successField;
        
        private string statusField;
        
        private string errorField;
        
        private bool forceLoginField;
        
        private bool canImpersonateField;
        
        private int userIdField;
        
        private string fullNameField;
        
        private string loginNameField;
        
        private string mstkTokenField;
        
        private ImpersonationMapping[] impersonationUsersField;
        
        /// <remarks/>
        public bool Success {
            get {
                return this.successField;
            }
            set {
                this.successField = value;
            }
        }
        
        /// <remarks/>
        public string Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
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
        
        /// <remarks/>
        public bool ForceLogin {
            get {
                return this.forceLoginField;
            }
            set {
                this.forceLoginField = value;
            }
        }
        
        /// <remarks/>
        public bool CanImpersonate {
            get {
                return this.canImpersonateField;
            }
            set {
                this.canImpersonateField = value;
            }
        }
        
        /// <remarks/>
        public int UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string FullName {
            get {
                return this.fullNameField;
            }
            set {
                this.fullNameField = value;
            }
        }
        
        /// <remarks/>
        public string LoginName {
            get {
                return this.loginNameField;
            }
            set {
                this.loginNameField = value;
            }
        }
        
        /// <remarks/>
        public string MstkToken {
            get {
                return this.mstkTokenField;
            }
            set {
                this.mstkTokenField = value;
            }
        }
        
        /// <remarks/>
        public ImpersonationMapping[] ImpersonationUsers {
            get {
                return this.impersonationUsersField;
            }
            set {
                this.impersonationUsersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://Company.ManagerUserLookup.WebService")]
    public partial class ImpersonationMapping {
        
        private bool isAuthenticatedUserField;
        
        private int userIdField;
        
        private string loginNameField;
        
        private string fullNameField;
        
        private string mSTKField;
        
        /// <remarks/>
        public bool IsAuthenticatedUser {
            get {
                return this.isAuthenticatedUserField;
            }
            set {
                this.isAuthenticatedUserField = value;
            }
        }
        
        /// <remarks/>
        public int UserId {
            get {
                return this.userIdField;
            }
            set {
                this.userIdField = value;
            }
        }
        
        /// <remarks/>
        public string LoginName {
            get {
                return this.loginNameField;
            }
            set {
                this.loginNameField = value;
            }
        }
        
        /// <remarks/>
        public string FullName {
            get {
                return this.fullNameField;
            }
            set {
                this.fullNameField = value;
            }
        }
        
        /// <remarks/>
        public string MSTK {
            get {
                return this.mSTKField;
            }
            set {
                this.mSTKField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetUserMappingCompletedEventHandler(object sender, GetUserMappingCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserMappingCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserMappingCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public UserMapping Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((UserMapping)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetUserMappingXmlCompletedEventHandler(object sender, GetUserMappingXmlCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetUserMappingXmlCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetUserMappingXmlCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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