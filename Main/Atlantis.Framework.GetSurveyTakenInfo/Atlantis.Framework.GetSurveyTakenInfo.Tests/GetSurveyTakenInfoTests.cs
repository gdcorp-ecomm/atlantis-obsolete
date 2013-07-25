﻿using Atlantis.Framework.GetSurveyTakenInfo.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using Atlantis.Framework.Testing.MockHttpContext;

namespace Atlantis.Framework.GetSurveyTakenInfo.Tests
{
  /// <summary>
  /// Summary description for GetSurveyTakenInfoTests
  /// </summary>
  [TestClass]
  public class GetSurveyTakenInfoTests
  {
    private string _shopperIdSurveyYes = "857527";
    private string _shopperIdSurveyNo = "856045";
    private int _surveyId = 162;

    public GetSurveyTakenInfoTests()
    {
      //
      // TODO: Add constructor logic here
      //
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

    private bool SurveyTaken(string surveyTakenInfo)
    {
      if (string.IsNullOrEmpty(surveyTakenInfo))
      {
        return false;
      }
      else
      {
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(surveyTakenInfo);
        int surveyTakenCount = xml.CreateNavigator().Select("//Survey").Count;
        return (surveyTakenCount > 0);
      }
    }

    #region Additional test attributes

    #endregion

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void CheckSurveyNotTaken()
    {
      MockHttpContext.SetMockHttpContext(string.Empty, "http://localhost", string.Empty);

      GetSurveyTakenInfoRequestData request = new GetSurveyTakenInfoRequestData(_shopperIdSurveyNo
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        ,_surveyId);

      GetSurveyTakenInfoResponseData response = SessionCache.SessionCache.GetProcessRequest<GetSurveyTakenInfoResponseData>(request, 116);
      Assert.IsTrue(response.GetException() == null && SurveyTaken(response.SurveyTakenInfo) == false);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void CheckSurveyTaken()
    {
      GetSurveyTakenInfoRequestData request = new GetSurveyTakenInfoRequestData(_shopperIdSurveyYes
        , string.Empty
        , string.Empty
        , string.Empty
        , 0
        , _surveyId);
      GetSurveyTakenInfoResponseData response = (GetSurveyTakenInfoResponseData)Engine.Engine.ProcessRequest(request, 116);
      Assert.IsTrue(response.GetException() == null && SurveyTaken(response.SurveyTakenInfo) == true);
    }
  }
}
