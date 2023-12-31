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

namespace Atlantis.Framework.DomainsBotDatabase.Impl.domainsBotDatabase {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="FirstImpact3Soap", Namespace="DomainsBot.FirstImpact")]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Name))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(TaggedKey))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(AdvancedSearch[]))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Field[]))]
    public partial class FirstImpact3 : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SearchDomainsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchAvailableDomainsOperationCompleted;
        
        private System.Threading.SendOrPostCallback SearchDatabaseDomainsOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public FirstImpact3() {
            this.Url = global::Atlantis.Framework.DomainsBotDatabase.Impl.Properties.Settings.Default.Atlantis_Framework_DomainsBotDatabase_Impl_domainsBotDatabase_FirstImpact3;
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
        public event SearchDomainsCompletedEventHandler SearchDomainsCompleted;
        
        /// <remarks/>
        public event SearchAvailableDomainsCompletedEventHandler SearchAvailableDomainsCompleted;
        
        /// <remarks/>
        public event SearchDatabaseDomainsCompletedEventHandler SearchDatabaseDomainsCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DomainsBot.FirstImpact/SearchDomains", RequestNamespace="DomainsBot.FirstImpact", ResponseNamespace="DomainsBot.FirstImpact", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public AdvancedResponse SearchDomains(AdvancedSearch[] searches, string[] orderBy, int pageSize, int pageIndex) {
            object[] results = this.Invoke("SearchDomains", new object[] {
                        searches,
                        orderBy,
                        pageSize,
                        pageIndex});
            return ((AdvancedResponse)(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSearchDomains(AdvancedSearch[] searches, string[] orderBy, int pageSize, int pageIndex, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SearchDomains", new object[] {
                        searches,
                        orderBy,
                        pageSize,
                        pageIndex}, callback, asyncState);
        }
        
        /// <remarks/>
        public AdvancedResponse EndSearchDomains(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((AdvancedResponse)(results[0]));
        }
        
        /// <remarks/>
        public void SearchDomainsAsync(AdvancedSearch[] searches, string[] orderBy, int pageSize, int pageIndex) {
            this.SearchDomainsAsync(searches, orderBy, pageSize, pageIndex, null);
        }
        
        /// <remarks/>
        public void SearchDomainsAsync(AdvancedSearch[] searches, string[] orderBy, int pageSize, int pageIndex, object userState) {
            if ((this.SearchDomainsOperationCompleted == null)) {
                this.SearchDomainsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchDomainsOperationCompleted);
            }
            this.InvokeAsync("SearchDomains", new object[] {
                        searches,
                        orderBy,
                        pageSize,
                        pageIndex}, this.SearchDomainsOperationCompleted, userState);
        }
        
        private void OnSearchDomainsOperationCompleted(object arg) {
            if ((this.SearchDomainsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchDomainsCompleted(this, new SearchDomainsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DomainsBot.FirstImpact/SearchAvailableDomains", RequestNamespace="DomainsBot.FirstImpact", ResponseNamespace="DomainsBot.FirstImpact", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Domain[] SearchAvailableDomains(string key, string tlds, int limit, bool addDashes, bool addRelated, bool addCompound, bool addVariations, bool removeKeys, string filters, string supportedLanguages) {
            object[] results = this.Invoke("SearchAvailableDomains", new object[] {
                        key,
                        tlds,
                        limit,
                        addDashes,
                        addRelated,
                        addCompound,
                        addVariations,
                        removeKeys,
                        filters,
                        supportedLanguages});
            return ((Domain[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSearchAvailableDomains(string key, string tlds, int limit, bool addDashes, bool addRelated, bool addCompound, bool addVariations, bool removeKeys, string filters, string supportedLanguages, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SearchAvailableDomains", new object[] {
                        key,
                        tlds,
                        limit,
                        addDashes,
                        addRelated,
                        addCompound,
                        addVariations,
                        removeKeys,
                        filters,
                        supportedLanguages}, callback, asyncState);
        }
        
        /// <remarks/>
        public Domain[] EndSearchAvailableDomains(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Domain[])(results[0]));
        }
        
        /// <remarks/>
        public void SearchAvailableDomainsAsync(string key, string tlds, int limit, bool addDashes, bool addRelated, bool addCompound, bool addVariations, bool removeKeys, string filters, string supportedLanguages) {
            this.SearchAvailableDomainsAsync(key, tlds, limit, addDashes, addRelated, addCompound, addVariations, removeKeys, filters, supportedLanguages, null);
        }
        
        /// <remarks/>
        public void SearchAvailableDomainsAsync(string key, string tlds, int limit, bool addDashes, bool addRelated, bool addCompound, bool addVariations, bool removeKeys, string filters, string supportedLanguages, object userState) {
            if ((this.SearchAvailableDomainsOperationCompleted == null)) {
                this.SearchAvailableDomainsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchAvailableDomainsOperationCompleted);
            }
            this.InvokeAsync("SearchAvailableDomains", new object[] {
                        key,
                        tlds,
                        limit,
                        addDashes,
                        addRelated,
                        addCompound,
                        addVariations,
                        removeKeys,
                        filters,
                        supportedLanguages}, this.SearchAvailableDomainsOperationCompleted, userState);
        }
        
        private void OnSearchAvailableDomainsOperationCompleted(object arg) {
            if ((this.SearchAvailableDomainsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchAvailableDomainsCompleted(this, new SearchAvailableDomainsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("DomainsBot.FirstImpact/SearchDatabaseDomains", RequestNamespace="DomainsBot.FirstImpact", ResponseNamespace="DomainsBot.FirstImpact", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Domain[] SearchDatabaseDomains(string database, string key, string tlds, int limit, bool removeKeys, string filters, string orderBy, string supportedLanguages) {
            object[] results = this.Invoke("SearchDatabaseDomains", new object[] {
                        database,
                        key,
                        tlds,
                        limit,
                        removeKeys,
                        filters,
                        orderBy,
                        supportedLanguages});
            return ((Domain[])(results[0]));
        }
        
        /// <remarks/>
        public System.IAsyncResult BeginSearchDatabaseDomains(string database, string key, string tlds, int limit, bool removeKeys, string filters, string orderBy, string supportedLanguages, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("SearchDatabaseDomains", new object[] {
                        database,
                        key,
                        tlds,
                        limit,
                        removeKeys,
                        filters,
                        orderBy,
                        supportedLanguages}, callback, asyncState);
        }
        
        /// <remarks/>
        public Domain[] EndSearchDatabaseDomains(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((Domain[])(results[0]));
        }
        
        /// <remarks/>
        public void SearchDatabaseDomainsAsync(string database, string key, string tlds, int limit, bool removeKeys, string filters, string orderBy, string supportedLanguages) {
            this.SearchDatabaseDomainsAsync(database, key, tlds, limit, removeKeys, filters, orderBy, supportedLanguages, null);
        }
        
        /// <remarks/>
        public void SearchDatabaseDomainsAsync(string database, string key, string tlds, int limit, bool removeKeys, string filters, string orderBy, string supportedLanguages, object userState) {
            if ((this.SearchDatabaseDomainsOperationCompleted == null)) {
                this.SearchDatabaseDomainsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSearchDatabaseDomainsOperationCompleted);
            }
            this.InvokeAsync("SearchDatabaseDomains", new object[] {
                        database,
                        key,
                        tlds,
                        limit,
                        removeKeys,
                        filters,
                        orderBy,
                        supportedLanguages}, this.SearchDatabaseDomainsOperationCompleted, userState);
        }
        
        private void OnSearchDatabaseDomainsOperationCompleted(object arg) {
            if ((this.SearchDatabaseDomainsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SearchDatabaseDomainsCompleted(this, new SearchDatabaseDomainsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class AdvancedSearch {
        
        private Field[] fieldsField;
        
        private Rule[] rulesField;
        
        private string[] tldsField;
        
        private string[] databasesField;
        
        private string[][] filtersField;
        
        private string[] supportedLanguagesField;
        
        private int limitField;
        
        private bool allowIDNField;
        
        /// <remarks/>
        public Field[] Fields {
            get {
                return this.fieldsField;
            }
            set {
                this.fieldsField = value;
            }
        }
        
        /// <remarks/>
        public Rule[] Rules {
            get {
                return this.rulesField;
            }
            set {
                this.rulesField = value;
            }
        }
        
        /// <remarks/>
        public string[] Tlds {
            get {
                return this.tldsField;
            }
            set {
                this.tldsField = value;
            }
        }
        
        /// <remarks/>
        public string[] Databases {
            get {
                return this.databasesField;
            }
            set {
                this.databasesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] Filters {
            get {
                return this.filtersField;
            }
            set {
                this.filtersField = value;
            }
        }
        
        /// <remarks/>
        public string[] SupportedLanguages {
            get {
                return this.supportedLanguagesField;
            }
            set {
                this.supportedLanguagesField = value;
            }
        }
        
        /// <remarks/>
        public int Limit {
            get {
                return this.limitField;
            }
            set {
                this.limitField = value;
            }
        }
        
        /// <remarks/>
        public bool AllowIDN {
            get {
                return this.allowIDNField;
            }
            set {
                this.allowIDNField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class Field {
        
        private bool addCompoundField;
        
        private bool addDashesField;
        
        private bool addRelatedField;
        
        private bool addVariationsField;
        
        private bool isSplittableField;
        
        private string keyField;
        
        private RatedKey[] prefixesField;
        
        private bool removeKeysField;
        
        private bool spinSynonymsField;
        
        private RatedKey[] suffixesField;
        
        private RatedKey[][] userSynonymsField;
        
        private object valueField;
        
        private string[] supportedLanguagesField;
        
        private RatedKey[][] keysField;
        
        /// <remarks/>
        public bool AddCompound {
            get {
                return this.addCompoundField;
            }
            set {
                this.addCompoundField = value;
            }
        }
        
        /// <remarks/>
        public bool AddDashes {
            get {
                return this.addDashesField;
            }
            set {
                this.addDashesField = value;
            }
        }
        
        /// <remarks/>
        public bool AddRelated {
            get {
                return this.addRelatedField;
            }
            set {
                this.addRelatedField = value;
            }
        }
        
        /// <remarks/>
        public bool AddVariations {
            get {
                return this.addVariationsField;
            }
            set {
                this.addVariationsField = value;
            }
        }
        
        /// <remarks/>
        public bool IsSplittable {
            get {
                return this.isSplittableField;
            }
            set {
                this.isSplittableField = value;
            }
        }
        
        /// <remarks/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        public RatedKey[] Prefixes {
            get {
                return this.prefixesField;
            }
            set {
                this.prefixesField = value;
            }
        }
        
        /// <remarks/>
        public bool RemoveKeys {
            get {
                return this.removeKeysField;
            }
            set {
                this.removeKeysField = value;
            }
        }
        
        /// <remarks/>
        public bool SpinSynonyms {
            get {
                return this.spinSynonymsField;
            }
            set {
                this.spinSynonymsField = value;
            }
        }
        
        /// <remarks/>
        public RatedKey[] Suffixes {
            get {
                return this.suffixesField;
            }
            set {
                this.suffixesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfRatedKey")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public RatedKey[][] UserSynonyms {
            get {
                return this.userSynonymsField;
            }
            set {
                this.userSynonymsField = value;
            }
        }
        
        /// <remarks/>
        public object Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        public string[] SupportedLanguages {
            get {
                return this.supportedLanguagesField;
            }
            set {
                this.supportedLanguagesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfRatedKey")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public RatedKey[][] Keys {
            get {
                return this.keysField;
            }
            set {
                this.keysField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class RatedKey : TaggedKey {
        
        private double rateField;
        
        /// <remarks/>
        public double Rate {
            get {
                return this.rateField;
            }
            set {
                this.rateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(RatedKey))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class TaggedKey {
        
        private string keyField;
        
        /// <remarks/>
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class AdvancedResponse {
        
        private AdvancedSearch[] searchesField;
        
        private Domain[] domainsField;
        
        private int totalResultsField;
        
        private int pageSizeField;
        
        private int pageIndexField;
        
        /// <remarks/>
        public AdvancedSearch[] Searches {
            get {
                return this.searchesField;
            }
            set {
                this.searchesField = value;
            }
        }
        
        /// <remarks/>
        public Domain[] Domains {
            get {
                return this.domainsField;
            }
            set {
                this.domainsField = value;
            }
        }
        
        /// <remarks/>
        public int TotalResults {
            get {
                return this.totalResultsField;
            }
            set {
                this.totalResultsField = value;
            }
        }
        
        /// <remarks/>
        public int PageSize {
            get {
                return this.pageSizeField;
            }
            set {
                this.pageSizeField = value;
            }
        }
        
        /// <remarks/>
        public int PageIndex {
            get {
                return this.pageIndexField;
            }
            set {
                this.pageIndexField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class Domain : Name {
        
        private string extensionField;
        
        private string domainNameField;
        
        /// <remarks/>
        public string Extension {
            get {
                return this.extensionField;
            }
            set {
                this.extensionField = value;
            }
        }
        
        /// <remarks/>
        public string DomainName {
            get {
                return this.domainNameField;
            }
            set {
                this.domainNameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(Domain))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class Name {
        
        private string nameWithoutExtensionField;
        
        private string[] keysField;
        
        private DomainData[][] dataField;
        
        /// <remarks/>
        public string NameWithoutExtension {
            get {
                return this.nameWithoutExtensionField;
            }
            set {
                this.nameWithoutExtensionField = value;
            }
        }
        
        /// <remarks/>
        public string[] Keys {
            get {
                return this.keysField;
            }
            set {
                this.keysField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfDomainData")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public DomainData[][] Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class DomainData {
        
        private string nameField;
        
        private object dataField;
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public object Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="Domainsbot.FirstImpact")]
    public partial class Rule {
        
        private string[] fieldKeysField;
        
        private double rateField;
        
        private bool addDashesField;
        
        private bool addRelatedField;
        
        private bool addVariationsField;
        
        /// <remarks/>
        public string[] FieldKeys {
            get {
                return this.fieldKeysField;
            }
            set {
                this.fieldKeysField = value;
            }
        }
        
        /// <remarks/>
        public double Rate {
            get {
                return this.rateField;
            }
            set {
                this.rateField = value;
            }
        }
        
        /// <remarks/>
        public bool AddDashes {
            get {
                return this.addDashesField;
            }
            set {
                this.addDashesField = value;
            }
        }
        
        /// <remarks/>
        public bool AddRelated {
            get {
                return this.addRelatedField;
            }
            set {
                this.addRelatedField = value;
            }
        }
        
        /// <remarks/>
        public bool AddVariations {
            get {
                return this.addVariationsField;
            }
            set {
                this.addVariationsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SearchDomainsCompletedEventHandler(object sender, SearchDomainsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchDomainsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchDomainsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public AdvancedResponse Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((AdvancedResponse)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SearchAvailableDomainsCompletedEventHandler(object sender, SearchAvailableDomainsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchAvailableDomainsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchAvailableDomainsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Domain[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Domain[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void SearchDatabaseDomainsCompletedEventHandler(object sender, SearchDatabaseDomainsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SearchDatabaseDomainsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SearchDatabaseDomainsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Domain[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Domain[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591