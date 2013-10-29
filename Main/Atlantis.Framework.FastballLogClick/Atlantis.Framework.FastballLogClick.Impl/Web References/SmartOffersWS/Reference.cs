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

namespace Atlantis.Framework.FastballLogClick.Impl.SmartOffersWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="SmartOffersSoap", Namespace="https://fastball.godaddy.com/")]
    public partial class SmartOffers : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetOffersOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOffersWithPlidOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetOffersListWithPlidOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDailyOffersWithPlidOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogOfferImpressionWithRepOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogOfferImpressionOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogOfferClickOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogOfferClickWithRepOperationCompleted;
        
        private System.Threading.SendOrPostCallback LogOfferDeclineWithRepOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSmartOffersHealthOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public SmartOffers() {
            this.Url = global::Atlantis.Framework.FastballLogClick.Impl.Properties.Settings.Default.Atlantis_Framework_FastballLogClick_Impl_SmartOffersWS_SmartOffers;
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
        public event GetOffersCompletedEventHandler GetOffersCompleted;
        
        /// <remarks/>
        public event GetOffersWithPlidCompletedEventHandler GetOffersWithPlidCompleted;
        
        /// <remarks/>
        public event GetOffersListWithPlidCompletedEventHandler GetOffersListWithPlidCompleted;
        
        /// <remarks/>
        public event GetDailyOffersWithPlidCompletedEventHandler GetDailyOffersWithPlidCompleted;
        
        /// <remarks/>
        public event LogOfferImpressionWithRepCompletedEventHandler LogOfferImpressionWithRepCompleted;
        
        /// <remarks/>
        public event LogOfferImpressionCompletedEventHandler LogOfferImpressionCompleted;
        
        /// <remarks/>
        public event LogOfferClickCompletedEventHandler LogOfferClickCompleted;
        
        /// <remarks/>
        public event LogOfferClickWithRepCompletedEventHandler LogOfferClickWithRepCompleted;
        
        /// <remarks/>
        public event LogOfferDeclineWithRepCompletedEventHandler LogOfferDeclineWithRepCompleted;
        
        /// <remarks/>
        public event GetSmartOffersHealthCompletedEventHandler GetSmartOffersHealthCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/GetOffers", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetOffers(string shopper_id, short application_id) {
            object[] results = this.Invoke("GetOffers", new object[] {
                        shopper_id,
                        application_id});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void GetOffersAsync(string shopper_id, short application_id) {
            this.GetOffersAsync(shopper_id, application_id, null);
        }
        
        /// <remarks/>
        public void GetOffersAsync(string shopper_id, short application_id, object userState) {
            if ((this.GetOffersOperationCompleted == null)) {
                this.GetOffersOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOffersOperationCompleted);
            }
            this.InvokeAsync("GetOffers", new object[] {
                        shopper_id,
                        application_id}, this.GetOffersOperationCompleted, userState);
        }
        
        private void OnGetOffersOperationCompleted(object arg) {
            if ((this.GetOffersCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetOffersCompleted(this, new GetOffersCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/GetOffersWithPlid", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetOffersWithPlid(string shopper_id, short application_id, int privateLabelId) {
            object[] results = this.Invoke("GetOffersWithPlid", new object[] {
                        shopper_id,
                        application_id,
                        privateLabelId});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void GetOffersWithPlidAsync(string shopper_id, short application_id, int privateLabelId) {
            this.GetOffersWithPlidAsync(shopper_id, application_id, privateLabelId, null);
        }
        
        /// <remarks/>
        public void GetOffersWithPlidAsync(string shopper_id, short application_id, int privateLabelId, object userState) {
            if ((this.GetOffersWithPlidOperationCompleted == null)) {
                this.GetOffersWithPlidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOffersWithPlidOperationCompleted);
            }
            this.InvokeAsync("GetOffersWithPlid", new object[] {
                        shopper_id,
                        application_id,
                        privateLabelId}, this.GetOffersWithPlidOperationCompleted, userState);
        }
        
        private void OnGetOffersWithPlidOperationCompleted(object arg) {
            if ((this.GetOffersWithPlidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetOffersWithPlidCompleted(this, new GetOffersWithPlidCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/GetOffersListWithPlid", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetOffersListWithPlid(string shopper_id, short application_id, int privateLabelId) {
            object[] results = this.Invoke("GetOffersListWithPlid", new object[] {
                        shopper_id,
                        application_id,
                        privateLabelId});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetOffersListWithPlidAsync(string shopper_id, short application_id, int privateLabelId) {
            this.GetOffersListWithPlidAsync(shopper_id, application_id, privateLabelId, null);
        }
        
        /// <remarks/>
        public void GetOffersListWithPlidAsync(string shopper_id, short application_id, int privateLabelId, object userState) {
            if ((this.GetOffersListWithPlidOperationCompleted == null)) {
                this.GetOffersListWithPlidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetOffersListWithPlidOperationCompleted);
            }
            this.InvokeAsync("GetOffersListWithPlid", new object[] {
                        shopper_id,
                        application_id,
                        privateLabelId}, this.GetOffersListWithPlidOperationCompleted, userState);
        }
        
        private void OnGetOffersListWithPlidOperationCompleted(object arg) {
            if ((this.GetOffersListWithPlidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetOffersListWithPlidCompleted(this, new GetOffersListWithPlidCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/GetDailyOffersWithPlid", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetDailyOffersWithPlid(int privateLabelId) {
            object[] results = this.Invoke("GetDailyOffersWithPlid", new object[] {
                        privateLabelId});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void GetDailyOffersWithPlidAsync(int privateLabelId) {
            this.GetDailyOffersWithPlidAsync(privateLabelId, null);
        }
        
        /// <remarks/>
        public void GetDailyOffersWithPlidAsync(int privateLabelId, object userState) {
            if ((this.GetDailyOffersWithPlidOperationCompleted == null)) {
                this.GetDailyOffersWithPlidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDailyOffersWithPlidOperationCompleted);
            }
            this.InvokeAsync("GetDailyOffersWithPlid", new object[] {
                        privateLabelId}, this.GetDailyOffersWithPlidOperationCompleted, userState);
        }
        
        private void OnGetDailyOffersWithPlidOperationCompleted(object arg) {
            if ((this.GetDailyOffersWithPlidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDailyOffersWithPlidCompleted(this, new GetDailyOffersWithPlidCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/LogOfferImpressionWithRep", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LogOfferImpressionWithRep(string shopper_id, string fbiOfferID_list, short application_id, System.DateTime impressionDate, string visitGuid, int pageCount, short impressionType, int repVersion) {
            this.Invoke("LogOfferImpressionWithRep", new object[] {
                        shopper_id,
                        fbiOfferID_list,
                        application_id,
                        impressionDate,
                        visitGuid,
                        pageCount,
                        impressionType,
                        repVersion});
        }
        
        /// <remarks/>
        public void LogOfferImpressionWithRepAsync(string shopper_id, string fbiOfferID_list, short application_id, System.DateTime impressionDate, string visitGuid, int pageCount, short impressionType, int repVersion) {
            this.LogOfferImpressionWithRepAsync(shopper_id, fbiOfferID_list, application_id, impressionDate, visitGuid, pageCount, impressionType, repVersion, null);
        }
        
        /// <remarks/>
        public void LogOfferImpressionWithRepAsync(string shopper_id, string fbiOfferID_list, short application_id, System.DateTime impressionDate, string visitGuid, int pageCount, short impressionType, int repVersion, object userState) {
            if ((this.LogOfferImpressionWithRepOperationCompleted == null)) {
                this.LogOfferImpressionWithRepOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOfferImpressionWithRepOperationCompleted);
            }
            this.InvokeAsync("LogOfferImpressionWithRep", new object[] {
                        shopper_id,
                        fbiOfferID_list,
                        application_id,
                        impressionDate,
                        visitGuid,
                        pageCount,
                        impressionType,
                        repVersion}, this.LogOfferImpressionWithRepOperationCompleted, userState);
        }
        
        private void OnLogOfferImpressionWithRepOperationCompleted(object arg) {
            if ((this.LogOfferImpressionWithRepCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogOfferImpressionWithRepCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/LogOfferImpression", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LogOfferImpression(string shopper_id, string fbiOfferID_list, short application_id, System.DateTime impressionDate, string visitGuid, int pageCount) {
            this.Invoke("LogOfferImpression", new object[] {
                        shopper_id,
                        fbiOfferID_list,
                        application_id,
                        impressionDate,
                        visitGuid,
                        pageCount});
        }
        
        /// <remarks/>
        public void LogOfferImpressionAsync(string shopper_id, string fbiOfferID_list, short application_id, System.DateTime impressionDate, string visitGuid, int pageCount) {
            this.LogOfferImpressionAsync(shopper_id, fbiOfferID_list, application_id, impressionDate, visitGuid, pageCount, null);
        }
        
        /// <remarks/>
        public void LogOfferImpressionAsync(string shopper_id, string fbiOfferID_list, short application_id, System.DateTime impressionDate, string visitGuid, int pageCount, object userState) {
            if ((this.LogOfferImpressionOperationCompleted == null)) {
                this.LogOfferImpressionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOfferImpressionOperationCompleted);
            }
            this.InvokeAsync("LogOfferImpression", new object[] {
                        shopper_id,
                        fbiOfferID_list,
                        application_id,
                        impressionDate,
                        visitGuid,
                        pageCount}, this.LogOfferImpressionOperationCompleted, userState);
        }
        
        private void OnLogOfferImpressionOperationCompleted(object arg) {
            if ((this.LogOfferImpressionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogOfferImpressionCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/LogOfferClick", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LogOfferClick(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount) {
            this.Invoke("LogOfferClick", new object[] {
                        fbiOfferID,
                        shopper_id,
                        clickDate,
                        application_id,
                        visitGuid,
                        pageCount});
        }
        
        /// <remarks/>
        public void LogOfferClickAsync(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount) {
            this.LogOfferClickAsync(fbiOfferID, shopper_id, clickDate, application_id, visitGuid, pageCount, null);
        }
        
        /// <remarks/>
        public void LogOfferClickAsync(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, object userState) {
            if ((this.LogOfferClickOperationCompleted == null)) {
                this.LogOfferClickOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOfferClickOperationCompleted);
            }
            this.InvokeAsync("LogOfferClick", new object[] {
                        fbiOfferID,
                        shopper_id,
                        clickDate,
                        application_id,
                        visitGuid,
                        pageCount}, this.LogOfferClickOperationCompleted, userState);
        }
        
        private void OnLogOfferClickOperationCompleted(object arg) {
            if ((this.LogOfferClickCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogOfferClickCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/LogOfferClickWithRep", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LogOfferClickWithRep(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, int repVersion, long ucid) {
            this.Invoke("LogOfferClickWithRep", new object[] {
                        fbiOfferID,
                        shopper_id,
                        clickDate,
                        application_id,
                        visitGuid,
                        pageCount,
                        repVersion,
                        ucid});
        }
        
        /// <remarks/>
        public void LogOfferClickWithRepAsync(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, int repVersion, long ucid) {
            this.LogOfferClickWithRepAsync(fbiOfferID, shopper_id, clickDate, application_id, visitGuid, pageCount, repVersion, ucid, null);
        }
        
        /// <remarks/>
        public void LogOfferClickWithRepAsync(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, int repVersion, long ucid, object userState) {
            if ((this.LogOfferClickWithRepOperationCompleted == null)) {
                this.LogOfferClickWithRepOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOfferClickWithRepOperationCompleted);
            }
            this.InvokeAsync("LogOfferClickWithRep", new object[] {
                        fbiOfferID,
                        shopper_id,
                        clickDate,
                        application_id,
                        visitGuid,
                        pageCount,
                        repVersion,
                        ucid}, this.LogOfferClickWithRepOperationCompleted, userState);
        }
        
        private void OnLogOfferClickWithRepOperationCompleted(object arg) {
            if ((this.LogOfferClickWithRepCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogOfferClickWithRepCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/LogOfferDeclineWithRep", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void LogOfferDeclineWithRep(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, int repVersion, long ucid, short disposition) {
            this.Invoke("LogOfferDeclineWithRep", new object[] {
                        fbiOfferID,
                        shopper_id,
                        clickDate,
                        application_id,
                        visitGuid,
                        pageCount,
                        repVersion,
                        ucid,
                        disposition});
        }
        
        /// <remarks/>
        public void LogOfferDeclineWithRepAsync(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, int repVersion, long ucid, short disposition) {
            this.LogOfferDeclineWithRepAsync(fbiOfferID, shopper_id, clickDate, application_id, visitGuid, pageCount, repVersion, ucid, disposition, null);
        }
        
        /// <remarks/>
        public void LogOfferDeclineWithRepAsync(int fbiOfferID, string shopper_id, System.DateTime clickDate, short application_id, string visitGuid, int pageCount, int repVersion, long ucid, short disposition, object userState) {
            if ((this.LogOfferDeclineWithRepOperationCompleted == null)) {
                this.LogOfferDeclineWithRepOperationCompleted = new System.Threading.SendOrPostCallback(this.OnLogOfferDeclineWithRepOperationCompleted);
            }
            this.InvokeAsync("LogOfferDeclineWithRep", new object[] {
                        fbiOfferID,
                        shopper_id,
                        clickDate,
                        application_id,
                        visitGuid,
                        pageCount,
                        repVersion,
                        ucid,
                        disposition}, this.LogOfferDeclineWithRepOperationCompleted, userState);
        }
        
        private void OnLogOfferDeclineWithRepOperationCompleted(object arg) {
            if ((this.LogOfferDeclineWithRepCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.LogOfferDeclineWithRepCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("https://fastball.godaddy.com/GetSmartOffersHealth", RequestNamespace="https://fastball.godaddy.com/", ResponseNamespace="https://fastball.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetSmartOffersHealth() {
            object[] results = this.Invoke("GetSmartOffersHealth", new object[0]);
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void GetSmartOffersHealthAsync() {
            this.GetSmartOffersHealthAsync(null);
        }
        
        /// <remarks/>
        public void GetSmartOffersHealthAsync(object userState) {
            if ((this.GetSmartOffersHealthOperationCompleted == null)) {
                this.GetSmartOffersHealthOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSmartOffersHealthOperationCompleted);
            }
            this.InvokeAsync("GetSmartOffersHealth", new object[0], this.GetSmartOffersHealthOperationCompleted, userState);
        }
        
        private void OnGetSmartOffersHealthOperationCompleted(object arg) {
            if ((this.GetSmartOffersHealthCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSmartOffersHealthCompleted(this, new GetSmartOffersHealthCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetOffersCompletedEventHandler(object sender, GetOffersCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetOffersCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetOffersCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetOffersWithPlidCompletedEventHandler(object sender, GetOffersWithPlidCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetOffersWithPlidCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetOffersWithPlidCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetOffersListWithPlidCompletedEventHandler(object sender, GetOffersListWithPlidCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetOffersListWithPlidCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetOffersListWithPlidCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void GetDailyOffersWithPlidCompletedEventHandler(object sender, GetDailyOffersWithPlidCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDailyOffersWithPlidCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDailyOffersWithPlidCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void LogOfferImpressionWithRepCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void LogOfferImpressionCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void LogOfferClickCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void LogOfferClickWithRepCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void LogOfferDeclineWithRepCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetSmartOffersHealthCompletedEventHandler(object sender, GetSmartOffersHealthCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSmartOffersHealthCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSmartOffersHealthCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591