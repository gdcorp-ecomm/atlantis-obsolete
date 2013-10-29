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

namespace Atlantis.Framework.AuctionsRetrieveDomains.Impl.TdnamDomainService {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    using System.Data;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="trpLandingDomainsServiceSoap", Namespace="tdnam.com/trpLandingDomains")]
    public partial class trpLandingDomainsService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetCountsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveDomainsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SuperBowlRetrieveDomainsOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveMostActiveByPriceOperationCompleted;
        
        private System.Threading.SendOrPostCallback RetrieveGDListingsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetRecentSalesOperationCompleted;
        
        private System.Threading.SendOrPostCallback GDListingCountOKOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public trpLandingDomainsService() {
            this.Url = global::Atlantis.Framework.AuctionsRetrieveDomains.Impl.Properties.Settings.Default.Atlantis_Framework_AuctionsRetrieveDomains_Impl_g1dwdnaweb01_trpLandingDomainsService;
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
        public event GetCountsCompletedEventHandler GetCountsCompleted;
        
        /// <remarks/>
        public event RetrieveDomainsCompletedEventHandler RetrieveDomainsCompleted;
        
        /// <remarks/>
        public event SuperBowlRetrieveDomainsCompletedEventHandler SuperBowlRetrieveDomainsCompleted;
        
        /// <remarks/>
        public event RetrieveMostActiveByPriceCompletedEventHandler RetrieveMostActiveByPriceCompleted;
        
        /// <remarks/>
        public event RetrieveGDListingsCompletedEventHandler RetrieveGDListingsCompleted;
        
        /// <remarks/>
        public event GetRecentSalesCompletedEventHandler GetRecentSalesCompleted;
        
        /// <remarks/>
        public event GDListingCountOKCompletedEventHandler GDListingCountOKCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/GetCounts", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetCounts() {
            object[] results = this.Invoke("GetCounts", new object[0]);
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetCountsAsync() {
            this.GetCountsAsync(null);
        }
        
        /// <remarks/>
        public void GetCountsAsync(object userState) {
            if ((this.GetCountsOperationCompleted == null)) {
                this.GetCountsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCountsOperationCompleted);
            }
            this.InvokeAsync("GetCounts", new object[0], this.GetCountsOperationCompleted, userState);
        }
        
        private void OnGetCountsOperationCompleted(object arg) {
            if ((this.GetCountsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetCountsCompleted(this, new GetCountsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/RetrieveDomains", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RetrieveDomains(int iRows) {
            object[] results = this.Invoke("RetrieveDomains", new object[] {
                        iRows});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveDomainsAsync(int iRows) {
            this.RetrieveDomainsAsync(iRows, null);
        }
        
        /// <remarks/>
        public void RetrieveDomainsAsync(int iRows, object userState) {
            if ((this.RetrieveDomainsOperationCompleted == null)) {
                this.RetrieveDomainsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveDomainsOperationCompleted);
            }
            this.InvokeAsync("RetrieveDomains", new object[] {
                        iRows}, this.RetrieveDomainsOperationCompleted, userState);
        }
        
        private void OnRetrieveDomainsOperationCompleted(object arg) {
            if ((this.RetrieveDomainsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveDomainsCompleted(this, new RetrieveDomainsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/SuperBowlRetrieveDomains", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string SuperBowlRetrieveDomains(int iRows) {
            object[] results = this.Invoke("SuperBowlRetrieveDomains", new object[] {
                        iRows});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SuperBowlRetrieveDomainsAsync(int iRows) {
            this.SuperBowlRetrieveDomainsAsync(iRows, null);
        }
        
        /// <remarks/>
        public void SuperBowlRetrieveDomainsAsync(int iRows, object userState) {
            if ((this.SuperBowlRetrieveDomainsOperationCompleted == null)) {
                this.SuperBowlRetrieveDomainsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSuperBowlRetrieveDomainsOperationCompleted);
            }
            this.InvokeAsync("SuperBowlRetrieveDomains", new object[] {
                        iRows}, this.SuperBowlRetrieveDomainsOperationCompleted, userState);
        }
        
        private void OnSuperBowlRetrieveDomainsOperationCompleted(object arg) {
            if ((this.SuperBowlRetrieveDomainsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SuperBowlRetrieveDomainsCompleted(this, new SuperBowlRetrieveDomainsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/RetrieveMostActiveByPrice", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string RetrieveMostActiveByPrice(int iRows) {
            object[] results = this.Invoke("RetrieveMostActiveByPrice", new object[] {
                        iRows});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveMostActiveByPriceAsync(int iRows) {
            this.RetrieveMostActiveByPriceAsync(iRows, null);
        }
        
        /// <remarks/>
        public void RetrieveMostActiveByPriceAsync(int iRows, object userState) {
            if ((this.RetrieveMostActiveByPriceOperationCompleted == null)) {
                this.RetrieveMostActiveByPriceOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveMostActiveByPriceOperationCompleted);
            }
            this.InvokeAsync("RetrieveMostActiveByPrice", new object[] {
                        iRows}, this.RetrieveMostActiveByPriceOperationCompleted, userState);
        }
        
        private void OnRetrieveMostActiveByPriceOperationCompleted(object arg) {
            if ((this.RetrieveMostActiveByPriceCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveMostActiveByPriceCompleted(this, new RetrieveMostActiveByPriceCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/RetrieveGDListings", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet RetrieveGDListings(int iRows) {
            object[] results = this.Invoke("RetrieveGDListings", new object[] {
                        iRows});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void RetrieveGDListingsAsync(int iRows) {
            this.RetrieveGDListingsAsync(iRows, null);
        }
        
        /// <remarks/>
        public void RetrieveGDListingsAsync(int iRows, object userState) {
            if ((this.RetrieveGDListingsOperationCompleted == null)) {
                this.RetrieveGDListingsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnRetrieveGDListingsOperationCompleted);
            }
            this.InvokeAsync("RetrieveGDListings", new object[] {
                        iRows}, this.RetrieveGDListingsOperationCompleted, userState);
        }
        
        private void OnRetrieveGDListingsOperationCompleted(object arg) {
            if ((this.RetrieveGDListingsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.RetrieveGDListingsCompleted(this, new RetrieveGDListingsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/GetRecentSales", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public System.Data.DataSet GetRecentSales(int iRows) {
            object[] results = this.Invoke("GetRecentSales", new object[] {
                        iRows});
            return ((System.Data.DataSet)(results[0]));
        }
        
        /// <remarks/>
        public void GetRecentSalesAsync(int iRows) {
            this.GetRecentSalesAsync(iRows, null);
        }
        
        /// <remarks/>
        public void GetRecentSalesAsync(int iRows, object userState) {
            if ((this.GetRecentSalesOperationCompleted == null)) {
                this.GetRecentSalesOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetRecentSalesOperationCompleted);
            }
            this.InvokeAsync("GetRecentSales", new object[] {
                        iRows}, this.GetRecentSalesOperationCompleted, userState);
        }
        
        private void OnGetRecentSalesOperationCompleted(object arg) {
            if ((this.GetRecentSalesCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetRecentSalesCompleted(this, new GetRecentSalesCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("tdnam.com/trpLandingDomains/GDListingCountOK", RequestNamespace="tdnam.com/trpLandingDomains", ResponseNamespace="tdnam.com/trpLandingDomains", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string GDListingCountOK() {
            object[] results = this.Invoke("GDListingCountOK", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GDListingCountOKAsync() {
            this.GDListingCountOKAsync(null);
        }
        
        /// <remarks/>
        public void GDListingCountOKAsync(object userState) {
            if ((this.GDListingCountOKOperationCompleted == null)) {
                this.GDListingCountOKOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGDListingCountOKOperationCompleted);
            }
            this.InvokeAsync("GDListingCountOK", new object[0], this.GDListingCountOKOperationCompleted, userState);
        }
        
        private void OnGDListingCountOKOperationCompleted(object arg) {
            if ((this.GDListingCountOKCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GDListingCountOKCompleted(this, new GDListingCountOKCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetCountsCompletedEventHandler(object sender, GetCountsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetCountsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetCountsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void RetrieveDomainsCompletedEventHandler(object sender, RetrieveDomainsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveDomainsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveDomainsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SuperBowlRetrieveDomainsCompletedEventHandler(object sender, SuperBowlRetrieveDomainsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SuperBowlRetrieveDomainsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SuperBowlRetrieveDomainsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void RetrieveMostActiveByPriceCompletedEventHandler(object sender, RetrieveMostActiveByPriceCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveMostActiveByPriceCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveMostActiveByPriceCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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
    public delegate void RetrieveGDListingsCompletedEventHandler(object sender, RetrieveGDListingsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class RetrieveGDListingsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal RetrieveGDListingsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GetRecentSalesCompletedEventHandler(object sender, GetRecentSalesCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetRecentSalesCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetRecentSalesCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public System.Data.DataSet Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((System.Data.DataSet)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void GDListingCountOKCompletedEventHandler(object sender, GDListingCountOKCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GDListingCountOKCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GDListingCountOKCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
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