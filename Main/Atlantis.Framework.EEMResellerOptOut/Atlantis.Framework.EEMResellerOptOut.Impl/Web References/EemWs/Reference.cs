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

namespace Atlantis.Framework.EEMResellerOptOut.Impl.EemWs {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="CampaignBlazerSoap", Namespace="http://ecm.com/webservices/")]
    public partial class CampaignBlazer : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetAuthenticationGuidOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResetOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateNewAccountOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResellerOptInOperationCompleted;
        
        private System.Threading.SendOrPostCallback ResellerOptOutOperationCompleted;
        
        private System.Threading.SendOrPostCallback CreateNewCustomerOperationCompleted;
        
        private System.Threading.SendOrPostCallback RenewAccountOperationCompleted;
        
        private System.Threading.SendOrPostCallback RenewCustomerOperationCompleted;
        
        private System.Threading.SendOrPostCallback UpdateCustomerOperationCompleted;
        
        private System.Threading.SendOrPostCallback RemoveCustomerOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetCustomerSummaryOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public CampaignBlazer() {
            this.Url = global::Atlantis.Framework.EEMResellerOptOut.Impl.Properties.Settings.Default.Atlantis_Framework_EEMResellerOptOut_Impl_EemWs_CampaignBlazer;
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
        public event GetAuthenticationGuidCompletedEventHandler GetAuthenticationGuidCompleted;
        
        /// <remarks/>
        public event ResetCompletedEventHandler ResetCompleted;
        
        /// <remarks/>
        public event CreateNewAccountCompletedEventHandler CreateNewAccountCompleted;
        
        /// <remarks/>
        public event ResellerOptInCompletedEventHandler ResellerOptInCompleted;
        
        /// <remarks/>
        public event ResellerOptOutCompletedEventHandler ResellerOptOutCompleted;
        
        /// <remarks/>
        public event CreateNewCustomerCompletedEventHandler CreateNewCustomerCompleted;
        
        /// <remarks/>
        public event RenewAccountCompletedEventHandler RenewAccountCompleted;
        
        /// <remarks/>
        public event RenewCustomerCompletedEventHandler RenewCustomerCompleted;
        
        /// <remarks/>
        public event UpdateCustomerCompletedEventHandler UpdateCustomerCompleted;
        
        /// <remarks/>
        public event RemoveCustomerCompletedEventHandler RemoveCustomerCompleted;
        
        /// <remarks/>
        public event GetCustomerSummaryCompletedEventHandler GetCustomerSummaryCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/GetAuthenticationGuid", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetAuthenticationGuid(int customerId) {
            object[] results = this.Invoke("GetAuthenticationGuid", new object[] {
                        customerId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetAuthenticationGuidAsync(int customerId) {
            this.GetAuthenticationGuidAsync(customerId, null);
        }
        
        /// <remarks/>
        public void GetAuthenticationGuidAsync(int customerId, object userState) {
            if ((this.GetAuthenticationGuidOperationCompleted == null)) {
                this.GetAuthenticationGuidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetAuthenticationGuidOperationCompleted);
            }
            this.InvokeAsync("GetAuthenticationGuid", new object[] {
                        customerId}, this.GetAuthenticationGuidOperationCompleted, userState);
        }
        
        private void OnGetAuthenticationGuidOperationCompleted(object arg) {
            if ((this.GetAuthenticationGuidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetAuthenticationGuidCompleted(this, new GetAuthenticationGuidCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/Reset", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Reset() {
            this.Invoke("Reset", new object[0]);
        }
        
        /// <remarks/>
        public void ResetAsync() {
            this.ResetAsync(null);
        }
        
        /// <remarks/>
        public void ResetAsync(object userState) {
            if ((this.ResetOperationCompleted == null)) {
                this.ResetOperationCompleted = new System.Threading.SendOrPostCallback(this.OnResetOperationCompleted);
            }
            this.InvokeAsync("Reset", new object[0], this.ResetOperationCompleted, userState);
        }
        
        private void OnResetOperationCompleted(object arg) {
            if ((this.ResetCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ResetCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/CreateNewAccount", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int CreateNewAccount(string newAccountXML) {
            object[] results = this.Invoke("CreateNewAccount", new object[] {
                        newAccountXML});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void CreateNewAccountAsync(string newAccountXML) {
            this.CreateNewAccountAsync(newAccountXML, null);
        }
        
        /// <remarks/>
        public void CreateNewAccountAsync(string newAccountXML, object userState) {
            if ((this.CreateNewAccountOperationCompleted == null)) {
                this.CreateNewAccountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateNewAccountOperationCompleted);
            }
            this.InvokeAsync("CreateNewAccount", new object[] {
                        newAccountXML}, this.CreateNewAccountOperationCompleted, userState);
        }
        
        private void OnCreateNewAccountOperationCompleted(object arg) {
            if ((this.CreateNewAccountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateNewAccountCompleted(this, new CreateNewAccountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/ResellerOptIn", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ResellerOptIn(string ResellerOptInXML) {
            this.Invoke("ResellerOptIn", new object[] {
                        ResellerOptInXML});
        }
        
        /// <remarks/>
        public void ResellerOptInAsync(string ResellerOptInXML) {
            this.ResellerOptInAsync(ResellerOptInXML, null);
        }
        
        /// <remarks/>
        public void ResellerOptInAsync(string ResellerOptInXML, object userState) {
            if ((this.ResellerOptInOperationCompleted == null)) {
                this.ResellerOptInOperationCompleted = new System.Threading.SendOrPostCallback(this.OnResellerOptInOperationCompleted);
            }
            this.InvokeAsync("ResellerOptIn", new object[] {
                        ResellerOptInXML}, this.ResellerOptInOperationCompleted, userState);
        }
        
        private void OnResellerOptInOperationCompleted(object arg) {
            if ((this.ResellerOptInCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ResellerOptInCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/ResellerOptOut", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void ResellerOptOut(string ResellerOptOutXML) {
            this.Invoke("ResellerOptOut", new object[] {
                        ResellerOptOutXML});
        }
        
        /// <remarks/>
        public void ResellerOptOutAsync(string ResellerOptOutXML) {
            this.ResellerOptOutAsync(ResellerOptOutXML, null);
        }
        
        /// <remarks/>
        public void ResellerOptOutAsync(string ResellerOptOutXML, object userState) {
            if ((this.ResellerOptOutOperationCompleted == null)) {
                this.ResellerOptOutOperationCompleted = new System.Threading.SendOrPostCallback(this.OnResellerOptOutOperationCompleted);
            }
            this.InvokeAsync("ResellerOptOut", new object[] {
                        ResellerOptOutXML}, this.ResellerOptOutOperationCompleted, userState);
        }
        
        private void OnResellerOptOutOperationCompleted(object arg) {
            if ((this.ResellerOptOutCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ResellerOptOutCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/CreateNewCustomer", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int CreateNewCustomer(int privateLabelId, System.DateTime billingDate, int customerBillingTypeId, int emailLimit) {
            object[] results = this.Invoke("CreateNewCustomer", new object[] {
                        privateLabelId,
                        billingDate,
                        customerBillingTypeId,
                        emailLimit});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void CreateNewCustomerAsync(int privateLabelId, System.DateTime billingDate, int customerBillingTypeId, int emailLimit) {
            this.CreateNewCustomerAsync(privateLabelId, billingDate, customerBillingTypeId, emailLimit, null);
        }
        
        /// <remarks/>
        public void CreateNewCustomerAsync(int privateLabelId, System.DateTime billingDate, int customerBillingTypeId, int emailLimit, object userState) {
            if ((this.CreateNewCustomerOperationCompleted == null)) {
                this.CreateNewCustomerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCreateNewCustomerOperationCompleted);
            }
            this.InvokeAsync("CreateNewCustomer", new object[] {
                        privateLabelId,
                        billingDate,
                        customerBillingTypeId,
                        emailLimit}, this.CreateNewCustomerOperationCompleted, userState);
        }
        
        private void OnCreateNewCustomerOperationCompleted(object arg) {
            if ((this.CreateNewCustomerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CreateNewCustomerCompleted(this, new CreateNewCustomerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/RenewAccount", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RenewAccount(string accountXML) {
            object[] results = this.Invoke("RenewAccount", new object[] {
                        accountXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RenewAccountAsync(string accountXML) {
            this.RenewAccountAsync(accountXML, null);
        }
        
        /// <remarks/>
        public void RenewAccountAsync(string accountXML, object userState) {
            if ((this.RenewAccountOperationCompleted == null)) {
                this.RenewAccountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRenewAccountOperationCompleted);
            }
            this.InvokeAsync("RenewAccount", new object[] {
                        accountXML}, this.RenewAccountOperationCompleted, userState);
        }
        
        private void OnRenewAccountOperationCompleted(object arg) {
            if ((this.RenewAccountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RenewAccountCompleted(this, new RenewAccountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/RenewCustomer", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int RenewCustomer(int customerId, int baseEmailLimit) {
            object[] results = this.Invoke("RenewCustomer", new object[] {
                        customerId,
                        baseEmailLimit});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void RenewCustomerAsync(int customerId, int baseEmailLimit) {
            this.RenewCustomerAsync(customerId, baseEmailLimit, null);
        }
        
        /// <remarks/>
        public void RenewCustomerAsync(int customerId, int baseEmailLimit, object userState) {
            if ((this.RenewCustomerOperationCompleted == null)) {
                this.RenewCustomerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRenewCustomerOperationCompleted);
            }
            this.InvokeAsync("RenewCustomer", new object[] {
                        customerId,
                        baseEmailLimit}, this.RenewCustomerOperationCompleted, userState);
        }
        
        private void OnRenewCustomerOperationCompleted(object arg) {
            if ((this.RenewCustomerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RenewCustomerCompleted(this, new RenewCustomerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/UpdateCustomer", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void UpdateCustomer(string customerXML) {
            this.Invoke("UpdateCustomer", new object[] {
                        customerXML});
        }
        
        /// <remarks/>
        public void UpdateCustomerAsync(string customerXML) {
            this.UpdateCustomerAsync(customerXML, null);
        }
        
        /// <remarks/>
        public void UpdateCustomerAsync(string customerXML, object userState) {
            if ((this.UpdateCustomerOperationCompleted == null)) {
                this.UpdateCustomerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateCustomerOperationCompleted);
            }
            this.InvokeAsync("UpdateCustomer", new object[] {
                        customerXML}, this.UpdateCustomerOperationCompleted, userState);
        }
        
        private void OnUpdateCustomerOperationCompleted(object arg) {
            if ((this.UpdateCustomerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateCustomerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/RemoveCustomer", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void RemoveCustomer(int customerId) {
            this.Invoke("RemoveCustomer", new object[] {
                        customerId});
        }
        
        /// <remarks/>
        public void RemoveCustomerAsync(int customerId) {
            this.RemoveCustomerAsync(customerId, null);
        }
        
        /// <remarks/>
        public void RemoveCustomerAsync(int customerId, object userState) {
            if ((this.RemoveCustomerOperationCompleted == null)) {
                this.RemoveCustomerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRemoveCustomerOperationCompleted);
            }
            this.InvokeAsync("RemoveCustomer", new object[] {
                        customerId}, this.RemoveCustomerOperationCompleted, userState);
        }
        
        private void OnRemoveCustomerOperationCompleted(object arg) {
            if ((this.RemoveCustomerCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RemoveCustomerCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://ecm.com/webservices/GetCustomerSummary", RequestNamespace="http://ecm.com/webservices/", ResponseNamespace="http://ecm.com/webservices/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetCustomerSummary(string customerXML) {
            object[] results = this.Invoke("GetCustomerSummary", new object[] {
                        customerXML});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetCustomerSummaryAsync(string customerXML) {
            this.GetCustomerSummaryAsync(customerXML, null);
        }
        
        /// <remarks/>
        public void GetCustomerSummaryAsync(string customerXML, object userState) {
            if ((this.GetCustomerSummaryOperationCompleted == null)) {
                this.GetCustomerSummaryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCustomerSummaryOperationCompleted);
            }
            this.InvokeAsync("GetCustomerSummary", new object[] {
                        customerXML}, this.GetCustomerSummaryOperationCompleted, userState);
        }
        
        private void OnGetCustomerSummaryOperationCompleted(object arg) {
            if ((this.GetCustomerSummaryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCustomerSummaryCompleted(this, new GetCustomerSummaryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetAuthenticationGuidCompletedEventHandler(object sender, GetAuthenticationGuidCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetAuthenticationGuidCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetAuthenticationGuidCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ResetCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreateNewAccountCompletedEventHandler(object sender, CreateNewAccountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateNewAccountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateNewAccountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void ResellerOptInCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void ResellerOptOutCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void CreateNewCustomerCompletedEventHandler(object sender, CreateNewCustomerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CreateNewCustomerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal CreateNewCustomerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void RenewAccountCompletedEventHandler(object sender, RenewAccountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RenewAccountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RenewAccountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void RenewCustomerCompletedEventHandler(object sender, RenewCustomerCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RenewCustomerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RenewCustomerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void UpdateCustomerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void RemoveCustomerCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetCustomerSummaryCompletedEventHandler(object sender, GetCustomerSummaryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCustomerSummaryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCustomerSummaryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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