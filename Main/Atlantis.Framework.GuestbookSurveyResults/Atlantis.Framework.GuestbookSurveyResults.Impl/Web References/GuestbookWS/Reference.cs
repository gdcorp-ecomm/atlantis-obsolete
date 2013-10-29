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

namespace Atlantis.Framework.GuestbookSurveyResults.Impl.GuestbookWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="GuestbookServiceSoap", Namespace="http://www.godaddy.com/fbiGuestbookService")]
    public partial class GuestbookService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetSurveyResultsOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddGuestbookEntryOperationCompleted;
        
        private System.Threading.SendOrPostCallback AddCommercialVoteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GuestbookService() {
            this.Url = global::Atlantis.Framework.GuestbookSurveyResults.Impl.Properties.Settings.Default.Atlantis_Framework_GuestbookSurveyResults_Impl_GuestbookWS_GuestbookService;
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
        public event GetSurveyResultsCompletedEventHandler GetSurveyResultsCompleted;
        
        /// <remarks/>
        public event AddGuestbookEntryCompletedEventHandler AddGuestbookEntryCompleted;
        
        /// <remarks/>
        public event AddCommercialVoteCompletedEventHandler AddCommercialVoteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.godaddy.com/fbiGuestbookService/GetSurveyResults", RequestNamespace="http://www.godaddy.com/fbiGuestbookService", ResponseNamespace="http://www.godaddy.com/fbiGuestbookService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Xml.XmlNode GetSurveyResults(int SurveyID) {
            object[] results = this.Invoke("GetSurveyResults", new object[] {
                        SurveyID});
            return ((System.Xml.XmlNode)(results[0]));
        }
        
        /// <remarks/>
        public void GetSurveyResultsAsync(int SurveyID) {
            this.GetSurveyResultsAsync(SurveyID, null);
        }
        
        /// <remarks/>
        public void GetSurveyResultsAsync(int SurveyID, object userState) {
            if ((this.GetSurveyResultsOperationCompleted == null)) {
                this.GetSurveyResultsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSurveyResultsOperationCompleted);
            }
            this.InvokeAsync("GetSurveyResults", new object[] {
                        SurveyID}, this.GetSurveyResultsOperationCompleted, userState);
        }
        
        private void OnGetSurveyResultsOperationCompleted(object arg) {
            if ((this.GetSurveyResultsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSurveyResultsCompleted(this, new GetSurveyResultsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.godaddy.com/fbiGuestbookService/AddGuestbookEntry", RequestNamespace="http://www.godaddy.com/fbiGuestbookService", ResponseNamespace="http://www.godaddy.com/fbiGuestbookService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public GuestbookResultEnum AddGuestbookEntry(int guestbookId, string domain, WsComment wsComment, int commercialType) {
            object[] results = this.Invoke("AddGuestbookEntry", new object[] {
                        guestbookId,
                        domain,
                        wsComment,
                        commercialType});
            return ((GuestbookResultEnum)(results[0]));
        }
        
        /// <remarks/>
        public void AddGuestbookEntryAsync(int guestbookId, string domain, WsComment wsComment, int commercialType) {
            this.AddGuestbookEntryAsync(guestbookId, domain, wsComment, commercialType, null);
        }
        
        /// <remarks/>
        public void AddGuestbookEntryAsync(int guestbookId, string domain, WsComment wsComment, int commercialType, object userState) {
            if ((this.AddGuestbookEntryOperationCompleted == null)) {
                this.AddGuestbookEntryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddGuestbookEntryOperationCompleted);
            }
            this.InvokeAsync("AddGuestbookEntry", new object[] {
                        guestbookId,
                        domain,
                        wsComment,
                        commercialType}, this.AddGuestbookEntryOperationCompleted, userState);
        }
        
        private void OnAddGuestbookEntryOperationCompleted(object arg) {
            if ((this.AddGuestbookEntryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddGuestbookEntryCompleted(this, new AddGuestbookEntryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.godaddy.com/fbiGuestbookService/AddCommercialVote", RequestNamespace="http://www.godaddy.com/fbiGuestbookService", ResponseNamespace="http://www.godaddy.com/fbiGuestbookService", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int AddCommercialVote(string commercial, string shopperId, string clientIp) {
            object[] results = this.Invoke("AddCommercialVote", new object[] {
                        commercial,
                        shopperId,
                        clientIp});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void AddCommercialVoteAsync(string commercial, string shopperId, string clientIp) {
            this.AddCommercialVoteAsync(commercial, shopperId, clientIp, null);
        }
        
        /// <remarks/>
        public void AddCommercialVoteAsync(string commercial, string shopperId, string clientIp, object userState) {
            if ((this.AddCommercialVoteOperationCompleted == null)) {
                this.AddCommercialVoteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddCommercialVoteOperationCompleted);
            }
            this.InvokeAsync("AddCommercialVote", new object[] {
                        commercial,
                        shopperId,
                        clientIp}, this.AddCommercialVoteOperationCompleted, userState);
        }
        
        private void OnAddCommercialVoteOperationCompleted(object arg) {
            if ((this.AddCommercialVoteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddCommercialVoteCompleted(this, new AddCommercialVoteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.godaddy.com/fbiGuestbookService")]
    public partial class WsComment {
        
        private int commentIdField;
        
        private int guestbookIdField;
        
        private string guestNameField;
        
        private string guestEmailField;
        
        private string guestCommentField;
        
        private System.DateTime createDateField;
        
        private CommentStatusEnum commentStatusIdField;
        
        /// <remarks/>
        public int CommentId {
            get {
                return this.commentIdField;
            }
            set {
                this.commentIdField = value;
            }
        }
        
        /// <remarks/>
        public int GuestbookId {
            get {
                return this.guestbookIdField;
            }
            set {
                this.guestbookIdField = value;
            }
        }
        
        /// <remarks/>
        public string GuestName {
            get {
                return this.guestNameField;
            }
            set {
                this.guestNameField = value;
            }
        }
        
        /// <remarks/>
        public string GuestEmail {
            get {
                return this.guestEmailField;
            }
            set {
                this.guestEmailField = value;
            }
        }
        
        /// <remarks/>
        public string GuestComment {
            get {
                return this.guestCommentField;
            }
            set {
                this.guestCommentField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
        
        /// <remarks/>
        public CommentStatusEnum CommentStatusId {
            get {
                return this.commentStatusIdField;
            }
            set {
                this.commentStatusIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.godaddy.com/fbiGuestbookService")]
    public enum CommentStatusEnum {
        
        /// <remarks/>
        FOS,
        
        /// <remarks/>
        Approved,
        
        /// <remarks/>
        Pending,
        
        /// <remarks/>
        Deleted,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.godaddy.com/fbiGuestbookService")]
    public enum GuestbookResultEnum {
        
        /// <remarks/>
        Success,
        
        /// <remarks/>
        GeneralException,
        
        /// <remarks/>
        CreateWSTGuestbookException,
        
        /// <remarks/>
        UpdateWSTGuestbookException,
        
        /// <remarks/>
        NotNewGuestbookException,
        
        /// <remarks/>
        InvalidGuestbookOrionAccountUidException,
        
        /// <remarks/>
        GuestbookDomainInUseException,
        
        /// <remarks/>
        GuestbookDomainInvalid,
        
        /// <remarks/>
        GuestbookNotFoundException,
        
        /// <remarks/>
        UnableToSetCssResourcesException,
        
        /// <remarks/>
        UnableToSetWSTResourcesException,
        
        /// <remarks/>
        UnableToSetGuestbookStatusException,
        
        /// <remarks/>
        UnableToSetCommentStatusException,
        
        /// <remarks/>
        WSTAuthenticationException,
        
        /// <remarks/>
        UpdateGuestbookContentFilterException,
        
        /// <remarks/>
        NotNewCommentException,
        
        /// <remarks/>
        AddNewCommentException,
        
        /// <remarks/>
        CommentStatusChangeException,
        
        /// <remarks/>
        NotNewUserException,
        
        /// <remarks/>
        NewUserException,
        
        /// <remarks/>
        LoginNameInUseException,
        
        /// <remarks/>
        EmailAddressInUseException,
        
        /// <remarks/>
        LoginNotUpdatedException,
        
        /// <remarks/>
        OldGuestbookActivated,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetSurveyResultsCompletedEventHandler(object sender, GetSurveyResultsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSurveyResultsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSurveyResultsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void AddGuestbookEntryCompletedEventHandler(object sender, AddGuestbookEntryCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddGuestbookEntryCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddGuestbookEntryCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public GuestbookResultEnum Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((GuestbookResultEnum)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void AddCommercialVoteCompletedEventHandler(object sender, AddCommercialVoteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AddCommercialVoteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal AddCommercialVoteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591