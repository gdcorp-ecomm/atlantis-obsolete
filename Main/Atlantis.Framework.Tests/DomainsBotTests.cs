using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Atlantis.Framework.DomainsBot.Interface;
using Atlantis.Framework.DomainsBotDatabase.Interface;
using Atlantis.Framework.DomainsBotSemantic.Interface;
using Atlantis.Framework.DomainsBotTypo.Interface;

namespace Atlantis.Framework.Tests
{
	[TestClass]
	public class DomainsBotTests
	{
    public DomainsBotTests() { }

		private TestContext testContextInstance;
		public TestContext TestContext
		{
			get { return testContextInstance; }
			set { testContextInstance = value; }
		}

		[TestMethod]
		public void DomainsBotBasicCall()
		{
			DomainsBotRequestData request = new DomainsBotRequestData(string.Empty, 
                                                                string.Empty, 
                                                                string.Empty, 
                                                                string.Empty, 
                                                                0,
				                                                        "atlantistesty", 
                                                                10, 
                                                                "com");
			request.AddDashes = true;
			request.AddPrefixes = true;
			request.AddRelated = true;
			request.AddSuffixes = true;
			DomainsBotResponseData response = (DomainsBotResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DomainDomainsBot);
			Assert.AreNotEqual<int>(0, response.DomainNames.Count);
		}

    [TestMethod]
    public void DomainsBotSemanticSearch()
    {
      DomainsBotSemanticRequestData request = new DomainsBotSemanticRequestData(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "hello",
                                                                                "com",
                                                                                20);
      request.AddDashes = true;
      request.AddCompound = true;
      request.AddRelated = true;
      request.AddVariations = true;
      request.RemoveKeys = false;
      DomainsBotSemanticResponseData response = (DomainsBotSemanticResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DomainsBotSemantic);
      int count = response.Domains.Count;
      Assert.AreNotEqual<int>(0, count);
    }

    [TestMethod]
    public void DomainsBotDatabaseSearch()
    {
      DomainsBotDatabaseRequestData request = new DomainsBotDatabaseRequestData(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "hello",
                                                                                "com",
                                                                                20);
      request.DatabaseToUse = "godaddypremiumtest";
      request.RemoveKeys = false;
      DomainsBotDatabaseResponseData response = (DomainsBotDatabaseResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DomainsBotDatabase);
      bool noErrors = response.NoErrors;
      int count = response.DomainsWithAttributes.Count;
      Assert.AreNotEqual<int>(0, count);
    }

    [TestMethod]
    public void DomainsBotTypoSearch()
    {
      DomainsBotTypoRequestData request = new DomainsBotTypoRequestData(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                0,
                                                                                "hello",
                                                                                "com",
                                                                                20);
      request.DoCharacterOmission = true;
      request.DoCharacterPermutation = true;
      request.DoCharacterReplacement = true;
      request.ExcludeNumbers = false;
      request.UseDoubledCharacter = true;
      request.UseMissingDot = true;
      DomainsBotTypoResponseData response = (DomainsBotTypoResponseData)Engine.Engine.ProcessRequest(request, EngineRequests.DomainsBotTypo);
      int count = response.Domains.Count;
      Assert.AreNotEqual<int>(0, count);
    }
	}
}
