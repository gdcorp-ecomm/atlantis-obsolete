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

namespace Atlantis.Framework.GetGuestbookPage.Impl.GuestBookWebService {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="GuestbookServiceSoap", Namespace="http://guestbook.starfieldtech.com.gdg/")]
    public partial class GuestbookService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback AddGuestbookEntryOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetGuestbookPageOperationCompleted;
        
        private System.Threading.SendOrPostCallback TestServerIPOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public GuestbookService() {
            this.Url = global::Atlantis.Framework.GetGuestbookPage.Impl.Properties.Settings.Default.Atlantis_Framework_Guestbook_Impl_GuestBookWebService_GuestbookService;
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
        public event AddGuestbookEntryCompletedEventHandler AddGuestbookEntryCompleted;
        
        /// <remarks/>
        public event GetGuestbookPageCompletedEventHandler GetGuestbookPageCompleted;
        
        /// <remarks/>
        public event TestServerIPCompletedEventHandler TestServerIPCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://guestbook.starfieldtech.com.gdg/AddGuestbookEntry", RequestNamespace="http://guestbook.starfieldtech.com.gdg/", ResponseNamespace="http://guestbook.starfieldtech.com.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public GuestbookResultEnum AddGuestbookEntry(int guestbookId, string domain, WsComment wsComment) {
            object[] results = this.Invoke("AddGuestbookEntry", new object[] {
                        guestbookId,
                        domain,
                        wsComment});
            return ((GuestbookResultEnum)(results[0]));
        }
        
        /// <remarks/>
        public void AddGuestbookEntryAsync(int guestbookId, string domain, WsComment wsComment) {
            this.AddGuestbookEntryAsync(guestbookId, domain, wsComment, null);
        }
        
        /// <remarks/>
        public void AddGuestbookEntryAsync(int guestbookId, string domain, WsComment wsComment, object userState) {
            if ((this.AddGuestbookEntryOperationCompleted == null)) {
                this.AddGuestbookEntryOperationCompleted = new System.Threading.SendOrPostCallback(this.OnAddGuestbookEntryOperationCompleted);
            }
            this.InvokeAsync("AddGuestbookEntry", new object[] {
                        guestbookId,
                        domain,
                        wsComment}, this.AddGuestbookEntryOperationCompleted, userState);
        }
        
        private void OnAddGuestbookEntryOperationCompleted(object arg) {
            if ((this.AddGuestbookEntryCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.AddGuestbookEntryCompleted(this, new AddGuestbookEntryCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://guestbook.starfieldtech.com.gdg/GetGuestbookPage", RequestNamespace="http://guestbook.starfieldtech.com.gdg/", ResponseNamespace="http://guestbook.starfieldtech.com.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public GuestbookResultEnum GetGuestbookPage(string domain, int guestbookId, int commentStatusId, int startRowIndex, int entriesPerPage, out int totalPages, out int totalEntries, out WsComment[] commentList) {
            object[] results = this.Invoke("GetGuestbookPage", new object[] {
                        domain,
                        guestbookId,
                        commentStatusId,
                        startRowIndex,
                        entriesPerPage});
            totalPages = ((int)(results[1]));
            totalEntries = ((int)(results[2]));
            commentList = ((WsComment[])(results[3]));
            return ((GuestbookResultEnum)(results[0]));
        }
        
        /// <remarks/>
        public void GetGuestbookPageAsync(string domain, int guestbookId, int commentStatusId, int startRowIndex, int entriesPerPage) {
            this.GetGuestbookPageAsync(domain, guestbookId, commentStatusId, startRowIndex, entriesPerPage, null);
        }
        
        /// <remarks/>
        public void GetGuestbookPageAsync(string domain, int guestbookId, int commentStatusId, int startRowIndex, int entriesPerPage, object userState) {
            if ((this.GetGuestbookPageOperationCompleted == null)) {
                this.GetGuestbookPageOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetGuestbookPageOperationCompleted);
            }
            this.InvokeAsync("GetGuestbookPage", new object[] {
                        domain,
                        guestbookId,
                        commentStatusId,
                        startRowIndex,
                        entriesPerPage}, this.GetGuestbookPageOperationCompleted, userState);
        }
        
        private void OnGetGuestbookPageOperationCompleted(object arg) {
            if ((this.GetGuestbookPageCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetGuestbookPageCompleted(this, new GetGuestbookPageCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://guestbook.starfieldtech.com.gdg/TestServerIP", RequestNamespace="http://guestbook.starfieldtech.com.gdg/", ResponseNamespace="http://guestbook.starfieldtech.com.gdg/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TestServerIP() {
            object[] results = this.Invoke("TestServerIP", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void TestServerIPAsync() {
            this.TestServerIPAsync(null);
        }
        
        /// <remarks/>
        public void TestServerIPAsync(object userState) {
            if ((this.TestServerIPOperationCompleted == null)) {
                this.TestServerIPOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTestServerIPOperationCompleted);
            }
            this.InvokeAsync("TestServerIP", new object[0], this.TestServerIPOperationCompleted, userState);
        }
        
        private void OnTestServerIPOperationCompleted(object arg) {
            if ((this.TestServerIPCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TestServerIPCompleted(this, new TestServerIPCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://guestbook.starfieldtech.com.gdg/")]
    public partial class WsComment {
        
        private int commentIdField;
        
        private int guestbookIdField;
        
        private string guestNameField;
        
        private string guestEmailField;
        
        private string guestCommentField;
        
        private System.DateTime createDateField;
        
        private CommentStatusEnum commentStatusIdField;
        
        public WsComment() {
            this.commentIdField = -1;
            this.guestbookIdField = -1;
            this.guestNameField = "user";
            this.guestEmailField = "guestEmail";
            this.guestCommentField = "guestComment";
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int CommentId {
            get {
                return this.commentIdField;
            }
            set {
                this.commentIdField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute(-1)]
        public int GuestbookId {
            get {
                return this.guestbookIdField;
            }
            set {
                this.guestbookIdField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("user")]
        public string GuestName {
            get {
                return this.guestNameField;
            }
            set {
                this.guestNameField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("guestEmail")]
        public string GuestEmail {
            get {
                return this.guestEmailField;
            }
            set {
                this.guestEmailField = value;
            }
        }
        
        /// <remarks/>
        [System.ComponentModel.DefaultValueAttribute("guestComment")]
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://guestbook.starfieldtech.com.gdg/")]
    public enum CommentStatusEnum {
        
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://guestbook.starfieldtech.com.gdg/")]
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
    public delegate void GetGuestbookPageCompletedEventHandler(object sender, GetGuestbookPageCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetGuestbookPageCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetGuestbookPageCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
        
        /// <remarks/>
        public int totalPages {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[1]));
            }
        }
        
        /// <remarks/>
        public int totalEntries {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[2]));
            }
        }
        
        /// <remarks/>
        public WsComment[] commentList {
            get {
                this.RaiseExceptionIfNecessary();
                return ((WsComment[])(this.results[3]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void TestServerIPCompletedEventHandler(object sender, TestServerIPCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TestServerIPCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal TestServerIPCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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