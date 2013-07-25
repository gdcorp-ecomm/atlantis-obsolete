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

namespace Atlantis.Framework.BazaarLinks.Impl.BazaarWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="Bazaar Web ServiceSoap", Namespace="http://bazaar.godaddy.com/")]
    public partial class BazaarWebService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetBazaarLinksOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBazaarAccountOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetBazaarRssFeedsOperationCompleted;
        
        private System.Threading.SendOrPostCallback getServiceStatusOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public BazaarWebService() {
            this.Url = global::Atlantis.Framework.BazaarLinks.Impl.Properties.Settings.Default.Atlantis_Framework_BazaarLinks_Impl_BazaarWS_Bazaar_x0020_Web_x0020_Service;
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
        public event GetBazaarLinksCompletedEventHandler GetBazaarLinksCompleted;
        
        /// <remarks/>
        public event GetBazaarAccountCompletedEventHandler GetBazaarAccountCompleted;
        
        /// <remarks/>
        public event GetBazaarRssFeedsCompletedEventHandler GetBazaarRssFeedsCompleted;
        
        /// <remarks/>
        public event getServiceStatusCompletedEventHandler getServiceStatusCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bazaar.godaddy.com/GetBazaarLinks", RequestNamespace="http://bazaar.godaddy.com/", ResponseNamespace="http://bazaar.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public BazaarLinks GetBazaarLinks(int resourceCount, int discussionCount) {
            object[] results = this.Invoke("GetBazaarLinks", new object[] {
                        resourceCount,
                        discussionCount});
            return ((BazaarLinks)(results[0]));
        }
        
        /// <remarks/>
        public void GetBazaarLinksAsync(int resourceCount, int discussionCount) {
            this.GetBazaarLinksAsync(resourceCount, discussionCount, null);
        }
        
        /// <remarks/>
        public void GetBazaarLinksAsync(int resourceCount, int discussionCount, object userState) {
            if ((this.GetBazaarLinksOperationCompleted == null)) {
                this.GetBazaarLinksOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBazaarLinksOperationCompleted);
            }
            this.InvokeAsync("GetBazaarLinks", new object[] {
                        resourceCount,
                        discussionCount}, this.GetBazaarLinksOperationCompleted, userState);
        }
        
        private void OnGetBazaarLinksOperationCompleted(object arg) {
            if ((this.GetBazaarLinksCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBazaarLinksCompleted(this, new GetBazaarLinksCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bazaar.godaddy.com/GetBazaarAccount", RequestNamespace="http://bazaar.godaddy.com/", ResponseNamespace="http://bazaar.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public BazaarAccount GetBazaarAccount(string gdShopperID) {
            object[] results = this.Invoke("GetBazaarAccount", new object[] {
                        gdShopperID});
            return ((BazaarAccount)(results[0]));
        }
        
        /// <remarks/>
        public void GetBazaarAccountAsync(string gdShopperID) {
            this.GetBazaarAccountAsync(gdShopperID, null);
        }
        
        /// <remarks/>
        public void GetBazaarAccountAsync(string gdShopperID, object userState) {
            if ((this.GetBazaarAccountOperationCompleted == null)) {
                this.GetBazaarAccountOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBazaarAccountOperationCompleted);
            }
            this.InvokeAsync("GetBazaarAccount", new object[] {
                        gdShopperID}, this.GetBazaarAccountOperationCompleted, userState);
        }
        
        private void OnGetBazaarAccountOperationCompleted(object arg) {
            if ((this.GetBazaarAccountCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBazaarAccountCompleted(this, new GetBazaarAccountCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bazaar.godaddy.com/GetBazaarRssFeeds", RequestNamespace="http://bazaar.godaddy.com/", ResponseNamespace="http://bazaar.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GetBazaarRssFeeds(BazaarRssFeedType feedType) {
            object[] results = this.Invoke("GetBazaarRssFeeds", new object[] {
                        feedType});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetBazaarRssFeedsAsync(BazaarRssFeedType feedType) {
            this.GetBazaarRssFeedsAsync(feedType, null);
        }
        
        /// <remarks/>
        public void GetBazaarRssFeedsAsync(BazaarRssFeedType feedType, object userState) {
            if ((this.GetBazaarRssFeedsOperationCompleted == null)) {
                this.GetBazaarRssFeedsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetBazaarRssFeedsOperationCompleted);
            }
            this.InvokeAsync("GetBazaarRssFeeds", new object[] {
                        feedType}, this.GetBazaarRssFeedsOperationCompleted, userState);
        }
        
        private void OnGetBazaarRssFeedsOperationCompleted(object arg) {
            if ((this.GetBazaarRssFeedsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetBazaarRssFeedsCompleted(this, new GetBazaarRssFeedsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://bazaar.godaddy.com/getServiceStatus", RequestNamespace="http://bazaar.godaddy.com/", ResponseNamespace="http://bazaar.godaddy.com/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string getServiceStatus() {
            object[] results = this.Invoke("getServiceStatus", new object[0]);
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bazaar.godaddy.com/")]
    public partial class BazaarLinks {
        
        private BazaarLink[] resourceLinksField;
        
        private BazaarLink[] discussionLinksField;
        
        private BazaarStatus bazaarStateField;
        
        /// <remarks/>
        public BazaarLink[] ResourceLinks {
            get {
                return this.resourceLinksField;
            }
            set {
                this.resourceLinksField = value;
            }
        }
        
        /// <remarks/>
        public BazaarLink[] DiscussionLinks {
            get {
                return this.discussionLinksField;
            }
            set {
                this.discussionLinksField = value;
            }
        }
        
        /// <remarks/>
        public BazaarStatus BazaarState {
            get {
                return this.bazaarStateField;
            }
            set {
                this.bazaarStateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bazaar.godaddy.com/")]
    public partial class BazaarLink {
        
        private string titleTextField;
        
        private string titleUrlField;
        
        /// <remarks/>
        public string TitleText {
            get {
                return this.titleTextField;
            }
            set {
                this.titleTextField = value;
            }
        }
        
        /// <remarks/>
        public string TitleUrl {
            get {
                return this.titleUrlField;
            }
            set {
                this.titleUrlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bazaar.godaddy.com/")]
    public partial class BazaarAccount {
        
        private bool isBazaarMemberField;
        
        private string manageProfileUrlField;
        
        private string inviteUrlField;
        
        private string contributeUrlField;
        
        private string discussionsUrlField;
        
        private string joinNowUrlField;
        
        private int resourcesCountField;
        
        private int discussionsCountField;
        
        private BazaarStatus bazaarStateField;
        
        /// <remarks/>
        public bool IsBazaarMember {
            get {
                return this.isBazaarMemberField;
            }
            set {
                this.isBazaarMemberField = value;
            }
        }
        
        /// <remarks/>
        public string ManageProfileUrl {
            get {
                return this.manageProfileUrlField;
            }
            set {
                this.manageProfileUrlField = value;
            }
        }
        
        /// <remarks/>
        public string InviteUrl {
            get {
                return this.inviteUrlField;
            }
            set {
                this.inviteUrlField = value;
            }
        }
        
        /// <remarks/>
        public string ContributeUrl {
            get {
                return this.contributeUrlField;
            }
            set {
                this.contributeUrlField = value;
            }
        }
        
        /// <remarks/>
        public string DiscussionsUrl {
            get {
                return this.discussionsUrlField;
            }
            set {
                this.discussionsUrlField = value;
            }
        }
        
        /// <remarks/>
        public string JoinNowUrl {
            get {
                return this.joinNowUrlField;
            }
            set {
                this.joinNowUrlField = value;
            }
        }
        
        /// <remarks/>
        public int ResourcesCount {
            get {
                return this.resourcesCountField;
            }
            set {
                this.resourcesCountField = value;
            }
        }
        
        /// <remarks/>
        public int DiscussionsCount {
            get {
                return this.discussionsCountField;
            }
            set {
                this.discussionsCountField = value;
            }
        }
        
        /// <remarks/>
        public BazaarStatus BazaarState {
            get {
                return this.bazaarStateField;
            }
            set {
                this.bazaarStateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bazaar.godaddy.com/")]
    public partial class BazaarStatus {
        
        private StatusCode statusField;
        
        private string messageField;
        
        private string stackTraceField;
        
        /// <remarks/>
        public StatusCode Status {
            get {
                return this.statusField;
            }
            set {
                this.statusField = value;
            }
        }
        
        /// <remarks/>
        public string Message {
            get {
                return this.messageField;
            }
            set {
                this.messageField = value;
            }
        }
        
        /// <remarks/>
        public string StackTrace {
            get {
                return this.stackTraceField;
            }
            set {
                this.stackTraceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bazaar.godaddy.com/")]
    public enum StatusCode {
        
        /// <remarks/>
        Failure,
        
        /// <remarks/>
        Success,
        
        /// <remarks/>
        Maintenance,
        
        /// <remarks/>
        Timeout,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://bazaar.godaddy.com/")]
    public enum BazaarRssFeedType {
        
        /// <remarks/>
        Business,
        
        /// <remarks/>
        Sports,
        
        /// <remarks/>
        Technology,
        
        /// <remarks/>
        Politics,
        
        /// <remarks/>
        World,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetBazaarLinksCompletedEventHandler(object sender, GetBazaarLinksCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBazaarLinksCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBazaarLinksCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public BazaarLinks Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((BazaarLinks)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetBazaarAccountCompletedEventHandler(object sender, GetBazaarAccountCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBazaarAccountCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBazaarAccountCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public BazaarAccount Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((BazaarAccount)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetBazaarRssFeedsCompletedEventHandler(object sender, GetBazaarRssFeedsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetBazaarRssFeedsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetBazaarRssFeedsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
}

#pragma warning restore 1591