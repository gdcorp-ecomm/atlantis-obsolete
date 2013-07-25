using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.Interface;
using Atlantis.Framework.GSASearch.Interface;
using Atlantis.Framework.Engine;
using System.Net.Sockets;
using System.Collections.Specialized;

namespace Atlantis.Framework.GSASearch.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class GSASearchTests
  {
    public GSASearchTests()
    {
    }

    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes

    private int _engineRequestIdForDevPartition = 332;
    private int _engineRequestIdForTestPartition = 333;
    private int _engineRequestIdForProdPartition = 334;
    private int _engineRequestIdForErroneousPartition = 335;

    #endregion

    /// <summary>
    /// This is the list of test items, and which functions verify the correct functioning of those items:
    /// 
    /// test search for some results:
    ///   SearchForSSLInDEV
    ///   SearchForSSLInTEST
    ///   SearchForSSLInPROD
    ///   
    /// test search for NO results:
    ///   SearchForNothing
    /// 
    /// test changing the partition for dev: 
    ///   SearchForSSLInDEV
    ///   SearchForNothing
    ///   
    /// test changing the partition for test: 
    ///   SearchForSSLInTEST
    ///   
    /// test changing the partition for prod: 
    ///   SearchForSSLInPROD
    ///   
    /// test changing the partition incorrectly:
    ///   SearchWithInvalidPartition
    ///   
    /// test changing the base search url
    ///   malformed: 
    ///     SearchWithInvalidBaseSearchURL
    ///   
    ///   valid:
    ///     SearchWithValidBaseSearchURL
    ///   
    /// test a single collection: 
    ///   SearchForSSLInTEST
    ///   
    /// test multiple collections: 
    ///   SearchForSSLInDEV
    ///   SearchForSSLInPROD
    ///   
    /// test changing the request start index
    ///   correctly: 
    ///     SearchForSSLInDEV
    ///     SearchForSSLInTEST
    ///     SearchForSSLInPROD
    ///   
    ///   incorrectly:
    ///     SearchWithInvalidStartIndex
    ///   
    /// test setting the request page size
    ///   correctly: 
    ///     SearchForSSLInDEV
    ///     SearchForSSLInTEST
    ///     SearchForSSLInPROD
    ///   
    ///   incorrectly:
    ///     SearchWithInvalidPageSize
    ///   
    /// test setting the proxy style shee
    ///   correctly:
    ///     SearchWithProxyStyleSheet
    ///   
    ///   incorrectly by using an invalid name:
    ///     SearchWithProxyStyleSheet
    ///   
    /// test setting the request proxy
    ///   correctly:
    ///     SearchWithProxyStyleSheet
    ///   
    ///   incorrectly:
    ///     SearchWithProxyStyleSheet
    ///   
    /// </summary>

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [ExpectedException(typeof(AtlantisException))]
    public void SearchWithInvalidPartition()
    {
      string site = "fos";
      int pageSize = 2;
      int startIndex = 2;
      string query = "ssl";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output);

      var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForErroneousPartition);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SearchForSSLInTEST()
    {
      string site = "fos";
      int pageSize = 4;
      int startIndex = 1;
      string query = "ssl";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      string partition = "test";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output);
      var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForTestPartition);
      AssertIsStandardXmlResponse(request, response);
      var queryMap = request.SearchQueryMap;
      AssertClientIsPartitioned(queryMap, partition);
      AssertNSitesArePartitioned(queryMap, 1, partition);
      Assert.IsTrue(request.SearchQueryMap[GSAQueryTerms.ProxyStyleSheet] == null);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SearchForSSLInPROD()
    {
      string site = "fos";
      int pageSize = 2;
      int startIndex = 2;
      string query = "ssl";
      string client = "fos|video";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      string partition = "prod";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output);
      var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForProdPartition);
      AssertIsStandardXmlResponse(request, response);
      var queryMap = request.SearchQueryMap;
      AssertClientIsPartitioned(queryMap, partition);
      AssertNSitesArePartitioned(queryMap, 1, partition);
      Assert.IsTrue(request.SearchQueryMap[GSAQueryTerms.ProxyStyleSheet] == null);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SearchForSSLInDEV()
    {
      string site = "fos|video";
      int pageSize = 3;
      int startIndex = 0;
      string query = "ssl";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      string partition = "dev";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0, 
                                             query, startIndex, pageSize, site, 
                                             client, output);
      var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForDevPartition);
      AssertIsStandardXmlResponse(request, response);

      var queryMap = request.SearchQueryMap;
      AssertClientIsPartitioned(queryMap, partition);
      AssertNSitesArePartitioned(queryMap, 2, partition);
      Assert.IsTrue(request.SearchQueryMap[GSAQueryTerms.ProxyStyleSheet] == null);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [ExpectedException(typeof(AtlantisException))]
    public void SearchForNothing()
    {
      string site = "fos";
      int pageSize = 2;
      int startIndex = 2;
      string query = "";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SearchWithInvalidBaseSearchURL()
    {
      string site = "fos";
      int pageSize = 2;
      int startIndex = 2;
      string query = "ssl";
      string client = "fos";
      string baseSearchURL = "http://127.0.0.1:33333/search";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output);
      request.GSABaseURL = baseSearchURL;
      try
      {
        var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForDevPartition);
      }
      catch (AtlantisException ex)
      {
        // see if exception is the correct cause
        Exception iex = ex.InnerException; // check the next level down... maybe the cause is buried
        while (iex != null)
        {
          string name = iex.GetType().FullName;
          if (name.StartsWith("System.Net"))
          {
            return; // exception is okay, it derives from a network error as expected
          }
          iex = iex.InnerException; // check the next level down... maybe the cause is buried
        }
        Assert.Fail("Exception occured, but it was not a network error as expected.");
      }
      catch (Exception)
      {
        Assert.Fail("The wrong exception was returned. ");
        return;
      }
      Assert.Fail("Exception did not occur when connecting to incorrect GSA URL");
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SearchWithValidBaseSearchURL()
    {
      string site = "fos|video";
      int pageSize = 2;
      int startIndex = 2;
      string query = "ssl";
      string client = "fos";
      string baseSearchURL = "http://10.6.7.103/search";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      string partition = "dev";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output);
      request.GSABaseURL = baseSearchURL;
      var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForDevPartition);
      AssertIsStandardXmlResponse(request, response);
      var queryMap = request.SearchQueryMap;
      AssertClientIsPartitioned(queryMap, partition);
      AssertNSitesArePartitioned(queryMap, 2, partition);
      Assert.IsTrue(request.SearchQueryMap[GSAQueryTerms.ProxyStyleSheet] == null);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [ExpectedException(typeof(AtlantisException))]
    public void SearchWithInvalidStartIndex()
    {
      string site = "fos";
      int pageSize = 2;
      int startIndex = -2;
      string query = "ssl";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                              query, startIndex, pageSize, site,
                                              client, output);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    [ExpectedException(typeof(AtlantisException))]
    public void SearchWithInvalidPageSize()
    {
      string site = "fos";
      int pageSize = -2;
      int startIndex = 2;
      string query = "ssl";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                              query, startIndex, pageSize, site,
                                              client, output);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void SearchWithProxyStyleSheet()
    {
      string site = "fos";
      int pageSize = 2;
      int startIndex = 2;
      string query = "ssl";
      string client = "fos";
      string output = "xml_no_dtd";
      string shopperId = "853516";
      string partition = "dev";
      var request = new GSASearchRequestData(shopperId, string.Empty, string.Empty, string.Empty, 0,
                                             query, startIndex, pageSize, site,
                                             client, output, client);
      var response = (GSASearchResponseData)Engine.Engine.ProcessRequest(request, _engineRequestIdForDevPartition);

      Assert.IsTrue(response.IsSuccess, "Response returned IsSuccess==false.");
      AssertIsNotXml(request, response);
      var queryMap = request.SearchQueryMap;
      AssertClientIsPartitioned(queryMap, partition);
      AssertNSitesArePartitioned(queryMap, 1, partition);
      Assert.IsTrue(queryMap[GSAQueryTerms.Client].Equals(queryMap[GSAQueryTerms.ProxyStyleSheet]));
    }

    private void AssertIsNotXml(GSASearchRequestData request, GSASearchResponseData response)
    {
      var xml = new XmlDocument();
      try
      {
        xml.LoadXml(response.Response);
      }
      catch (Exception ex)
      {
        return;
      }
      Assert.Fail("Response was XML, and it is supposed to be HTML");
    }

    private void AssertIsStandardXmlResponse(GSASearchRequestData request, GSASearchResponseData response)
    {
      Assert.IsTrue(response.IsSuccess, "Response returned IsSuccess==false.");

      var xml = new XmlDocument();
      try
      {
        xml.LoadXml(response.Response);
      }
      catch (Exception ex)
      {
        Assert.Fail("Response was not an XML document", ex);
      }

      Assert.IsNotNull(xml.SelectSingleNode("/GSP"));

      var queryParams = request.SearchQueryMap;

      var qNode = xml.SelectSingleNode("/GSP/Q");
      Assert.IsNotNull(qNode);
      Assert.AreEqual<string>(queryParams[GSAQueryTerms.Query], qNode.InnerText, 
        "Submitted query doesn't match the query element that the GSA returned");

      var resultNode = xml.SelectSingleNode("/GSP/RES");
      Assert.IsNotNull(resultNode);

      string startOneBased = (int.Parse(queryParams[GSAQueryTerms.Start]) + 1).ToString();
      Assert.AreEqual<string>(startOneBased, resultNode.Attributes["SN"].InnerText, 
        "Submitted startIndex doesn't match the SN attribute that the GSA returned");

      var searchListingNodes = xml.SelectNodes("/GSP/RES/R");
      if ( !searchListingNodes.Count.ToString().Equals(queryParams[GSAQueryTerms.ResultsPerPage]) )
      {
        Assert.Inconclusive("The results returned for the first page of this query are less than what was requested");
      }

      var urlNodes = xml.SelectNodes("/GSP/RES/R/U");
      Assert.AreEqual<int>(urlNodes.Count, searchListingNodes.Count, "Some search listings did not return URLs");

      var titleNodes = xml.SelectNodes("/GSP/RES/R/T");
      Assert.AreEqual<int>(titleNodes.Count, searchListingNodes.Count, "Some search listings did not return titles");

      var snippetNodes = xml.SelectNodes("/GSP/RES/R/S");
      Assert.AreEqual<int>(snippetNodes.Count, searchListingNodes.Count, "Some search listings did not return snippets");
    }

    private void AssertClientIsPartitioned(NameValueCollection queryMap, string partition)
    {
      Assert.IsTrue(queryMap[GSAQueryTerms.Client].EndsWith(partition));
    }

    private void AssertNSitesArePartitioned(NameValueCollection queryMap, int n, string partition)
    {
      int index = -1;
      for (int i = 0; i < n; i++)
      {
        index = queryMap[GSAQueryTerms.Site].IndexOf(partition, index + 1);
        Assert.IsTrue(index > 0);
      }
      index = queryMap[GSAQueryTerms.Site].IndexOf(partition, index + 1);
      Assert.IsTrue(index == -1);
    }

  }
}
