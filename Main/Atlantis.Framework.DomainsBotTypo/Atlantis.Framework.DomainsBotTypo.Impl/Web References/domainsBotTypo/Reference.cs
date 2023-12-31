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

namespace Atlantis.Framework.DomainsBotTypo.Impl.domainsBotTypo {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="TypoGeneratorSoap", Namespace="DomainsBot.TypoGenerator")]
    public partial class TypoGenerator : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback GetTyposOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TypoGenerator() {
            this.Url = global::Atlantis.Framework.DomainsBotTypo.Impl.Properties.Settings.Default.Atlantis_Framework_DomainsBotTypo_Impl_domainsBotTypo_TypoGenerator;
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
        public event GetTyposCompletedEventHandler GetTyposCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DomainsBot.TypoGenerator/GetTypos", RequestNamespace="DomainsBot.TypoGenerator", ResponseNamespace="DomainsBot.TypoGenerator", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string[] GetTypos(string domain, string tlds, bool characterReplacement, bool characterPermutation, bool characterOmission, bool doubledCharacter, bool missingDot, bool excludeNumbers, int limit) {
            object[] results = this.Invoke("GetTypos", new object[] {
                        domain,
                        tlds,
                        characterReplacement,
                        characterPermutation,
                        characterOmission,
                        doubledCharacter,
                        missingDot,
                        excludeNumbers,
                        limit});
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginGetTypos(string domain, string tlds, bool characterReplacement, bool characterPermutation, bool characterOmission, bool doubledCharacter, bool missingDot, bool excludeNumbers, int limit, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("GetTypos", new object[] {
                        domain,
                        tlds,
                        characterReplacement,
                        characterPermutation,
                        characterOmission,
                        doubledCharacter,
                        missingDot,
                        excludeNumbers,
                        limit}, callback, asyncState);
        }
        
        /// <remarks/>
        public string[] EndGetTypos(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((string[])(results[0]));
        }
        
        /// <remarks/>
        public void GetTyposAsync(string domain, string tlds, bool characterReplacement, bool characterPermutation, bool characterOmission, bool doubledCharacter, bool missingDot, bool excludeNumbers, int limit) {
            this.GetTyposAsync(domain, tlds, characterReplacement, characterPermutation, characterOmission, doubledCharacter, missingDot, excludeNumbers, limit, null);
        }
        
        /// <remarks/>
        public void GetTyposAsync(string domain, string tlds, bool characterReplacement, bool characterPermutation, bool characterOmission, bool doubledCharacter, bool missingDot, bool excludeNumbers, int limit, object userState) {
            if ((this.GetTyposOperationCompleted == null)) {
                this.GetTyposOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetTyposOperationCompleted);
            }
            this.InvokeAsync("GetTypos", new object[] {
                        domain,
                        tlds,
                        characterReplacement,
                        characterPermutation,
                        characterOmission,
                        doubledCharacter,
                        missingDot,
                        excludeNumbers,
                        limit}, this.GetTyposOperationCompleted, userState);
        }
        
        private void OnGetTyposOperationCompleted(object arg) {
            if ((this.GetTyposCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetTyposCompleted(this, new GetTyposCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public delegate void GetTyposCompletedEventHandler(object sender, GetTyposCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetTyposCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetTyposCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591