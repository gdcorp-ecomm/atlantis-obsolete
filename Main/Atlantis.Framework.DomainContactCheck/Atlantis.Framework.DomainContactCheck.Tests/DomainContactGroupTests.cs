using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Atlantis.Framework.DomainContactCheck.Interface;
using System.Xml;

namespace Atlantis.Framework.DomainContactCheck.Tests
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class DomainContactGroupTests
  {
    public DomainContactGroupTests()
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

    #region Additional test attributes
    //
    // You can use the following additional attributes as you write your tests:
    //
    // Use ClassInitialize to run code before running the first test in the class
    // [ClassInitialize()]
    // public static void MyClassInitialize(TestContext testContext) { }
    //
    // Use ClassCleanup to run code after all tests in a class have run
    // [ClassCleanup()]
    // public static void MyClassCleanup() { }
    //
    // Use TestInitialize to run code before running each test 
    // [TestInitialize()]
    // public void MyTestInitialize() { }
    //
    // Use TestCleanup to run code after each test has run
    // [TestCleanup()]
    // public void MyTestCleanup() { }
    //
    #endregion

    [TestMethod]
    public void TestDotCOMContact()
    {
      List<string> tlds = new List<string>();
      tlds.Add(".COM");
      DomainContactGroup contactGroup = new DomainContactGroup(tlds, 1);


      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           "MumboJumbo", true,
          "101 N Street", "Suite 100", "Littleton", "CO",
          "80130", "US", "(303)-555-1213", "(303)-555-2213");
      contactGroup.SetContact(DomainContact.DomainContactType.Registrant, registrantContact);
      Assert.AreEqual(0, registrantContact.Errors.Count);
    }

    [TestMethod]
    public void TestDotJPContact()
    {
      List<string> tlds = new List<string>();
      tlds.Add(".JP");
      DomainContactGroup contactGroup = new DomainContactGroup(tlds, 1);


      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           "MumboJumbo", true,
          "101 N Street", "Suite 100", "Littleton", "CO",
          "80130", "US", "(303)-555-1213", "(303)-555-2213");
      List<DomainContactError> Errors = new List<DomainContactError>();
      contactGroup.SetContact(DomainContact.DomainContactType.Registrant, registrantContact);
      Assert.AreNotEqual(0, registrantContact.Errors.Count);
    }

    [TestMethod]
    public void DomainContactClone()
    {
      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           "MumboJumbo", true,
          "101 N Street", "Suite 100", "Littleton", "CO",
          "80130", "US", "(303)-555-1213", "(303)-555-2213");
      DomainContact clonedContact = registrantContact.Clone() as DomainContact;

      Assert.AreEqual(registrantContact.GetContactXml(DomainContact.DomainContactType.Registrant),
        clonedContact.GetContactXml(DomainContact.DomainContactType.Registrant));
    }

    [TestMethod]
    public void DomainContactXmlConstructor()
    {
      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           "MumboJumbo", true,
          "101 N Street", "Suite 100", "Littleton", "CO",
          "80130", "US", "(303)-555-1213", "(303)-555-2213");
      string xml = registrantContact.GetContactXml(DomainContact.DomainContactType.Registrant);
      XmlDocument contactDoc = new XmlDocument();
      contactDoc.LoadXml(xml);
      DomainContact newContact = new DomainContact(contactDoc);

      Assert.AreEqual(registrantContact.GetContactXml(DomainContact.DomainContactType.Registrant),
        newContact.GetContactXml(DomainContact.DomainContactType.Registrant));
    }

    [TestMethod]
    public void DomainContactXmlConstructorWithErrors()
    {
      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           "MumboJumbo", true,
          "101 N Street", "Suite 100", "Littleton", "CO",
          "80130", "US", "(303)-555-1213", "(303)-555-2213");
      registrantContact.Errors.Add(new DomainContactError("blue", 1, "blue error", (int)DomainContact.DomainContactType.Registrant));
      string xml = registrantContact.GetContactXml(DomainContact.DomainContactType.Registrant);
      Console.WriteLine(xml);
      XmlDocument contactDoc = new XmlDocument();
      contactDoc.LoadXml(xml);
      DomainContact newContact = new DomainContact(contactDoc);

      Assert.AreEqual(registrantContact.GetContactXml(DomainContact.DomainContactType.Registrant),
        newContact.GetContactXml(DomainContact.DomainContactType.Registrant));

      Assert.IsFalse(newContact.IsValid);
    }

    [TestMethod]
    public void DomainContactGroupErrors()
    {
      List<string> tlds = new List<string>();
      tlds.Add("COM");
      tlds.Add("JP");
      DomainContactGroup group = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
       "Bill", "Registrant", "bregistrant@bongo.com",
         "MumboJumbo", true,
        "101 N Street", "Suite 100", "Littleton", "CO",
        "80130", "US", "(303)-555-1213", "(303)-555-2213");
      bool valid = group.SetContact(registrantContact);

      Assert.IsFalse(valid);

      Console.WriteLine(group.ToString());
      Console.WriteLine(group.GetContactXml());
    }

    [TestMethod]
    public void DomainContactGroupErrorsSerialization()
    {
      List<string> tlds = new List<string>();
      tlds.Add("COM");
      tlds.Add("JP");
      DomainContactGroup group = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
       "Bill", "Registrant", "bregistrant@bongo.com",
         "MumboJumbo", true,
        "101 N Street", "Suite 100", "Littleton", "CO",
        "80130", "US", "(303)-555-1213", "(303)-555-2213");
      bool valid = group.SetContact(registrantContact);

      Assert.IsFalse(valid);

      string groupString = group.ToString();
      DomainContactGroup newGroup = new DomainContactGroup(groupString);

      Assert.IsFalse(newGroup.IsValid);

      Assert.AreEqual(newGroup.ToString(), groupString);
    }

    [TestMethod]
    public void DomainContactGroupNewTlds()
    {
      List<string> tlds = new List<string>();
      tlds.Add("COM");
      tlds.Add("NET");
      DomainContactGroup group = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
       "Bill", "Registrant", "bregistrant@bongo.com",
         "MumboJumbo", true,
        "101 N Street", "Suite 100", "Littleton", "CO",
        "80130", "US", "(303)-555-1213", "(303)-555-2213");
      bool valid = group.SetContact(registrantContact);

      Assert.IsTrue(valid);

      tlds.Remove("NET");
      group.SetTlds(tlds);

      Assert.IsTrue(group.IsValid);

      tlds.Add("JP");
      group.SetTlds(tlds);

      Assert.IsFalse(group.IsValid);
      List<DomainContactError> errors = group.GetAllErrors();

      tlds.Remove("JP");
      group.SetTlds(tlds);

      Assert.IsTrue(group.IsValid);
      errors = group.GetAllErrors();

    }

    [TestMethod]
    public void DomainContactGroupTrySetContact()
    {
      List<string> tlds = new List<string>();
      tlds.Add("COM");
      tlds.Add("JP");
      DomainContactGroup group = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
       "Bill", "Registrant", "bregistrant@bongo.com",
         "MumboJumbo", true,
        "101 N Street", "Suite 100", "Littleton", "CO",
        "80130", "US", "(303)-555-1213", "(303)-555-2213");
      bool valid = group.TrySetContact(DomainContact.DomainContactType.Registrant, registrantContact);

      Assert.IsFalse(valid);
      Assert.IsTrue(registrantContact.Errors.Count > 0);

      DomainContact getContact = group.GetContact(DomainContact.DomainContactType.Registrant);
      Assert.IsNull(getContact);

    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void TestDotITContact()
    {
      List<string> tlds = new List<string>();
      tlds.Add(".IT");
      DomainContactGroup contactGroup = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           "MumboJumbo", true,
          "101 N Street", "Suite 100", "Littleton", "Geneva",
          "80130", "CH", "(303)-555-1213", "(303)-555-2213");
      contactGroup.SetContact(DomainContact.DomainContactType.Registrant, registrantContact);
      Assert.AreEqual(0, registrantContact.Errors.Count);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void TestTrusteeVendorIds()
    {
      List<string> tlds = new List<string>();
      tlds.Add(".IT");
      tlds.Add(".FR");
      DomainContactGroup contactGroup = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           string.Empty, false,
          "101 N Street", "Suite 100", "Littleton", "Colorado",
          "80130", "US", "(303)-555-1213", "(303)-555-2213");
      contactGroup.SetContact(DomainContact.DomainContactType.Registrant, registrantContact);
      int trusteesCount = registrantContact.TrusteeVendorIds.Count;
      DomainContact reg = contactGroup.GetContact(DomainContact.DomainContactType.Registrant);
      int regTrusteesCount = reg.TrusteeVendorIds.Count;
      Assert.AreEqual(0, trusteesCount == regTrusteesCount);
    }

    [TestMethod]
    [DeploymentItem("atlantis.config")]
    public void TestDotCaContact()
    {
      List<string> tlds = new List<string>();
      tlds.Add(".CA");
      DomainContactGroup contactGroup = new DomainContactGroup(tlds, 1);

      DomainContact registrantContact = new DomainContact(
         "Bill", "Registrant", "bregistrant@bongo.com",
           string.Empty, false,
          "101 N Street", "Suite 100", "Littleton", "Geneva",
          "80130", "CH", "(303)-555-1213", "(303)-555-2213", "LGR", "ENG");
      contactGroup.SetContact(DomainContact.DomainContactType.Registrant, registrantContact);
      string groupSessionString = contactGroup.ToString();
      string xml = registrantContact.GetContactXml(DomainContact.DomainContactType.Registrant);
      string contactSessionString = registrantContact.GetContactXmlForSession(DomainContact.DomainContactType.Registrant);
      Assert.IsFalse(string.IsNullOrEmpty(groupSessionString) && string.IsNullOrEmpty(xml) && string.IsNullOrEmpty(contactSessionString));
      /*
          <?xml version="1.0" encoding="utf-16" standalone="no"?>
          <contact type="blank or xfer"
          contactType="blank or registrant or administrative"
          tlds="INFO"
          fname="fname"
          lname="lname"
          org="org"
          sa1="some address 1"
          sa2="some address 2"
          city="some city"
          sp="TX"
          pc="76310"
          cc="United States"
          phone="(940) 123-4567"
          fax="(940) 123-4567"
          email=”test@test.com”
          privateLabelId="1334556"
          cacpr = “CCT”/>
          
          cacpr possible values right now are:

          CCO, CCT, RES, GOV, EDU, ASS, HOP, PRT, TDM, TRD, PLT, LAM, TRS, ABO, INB, LGR, OMK, MAJ 
          <error attribute="lname" code="3001" desc="CA Contact must contain at least one word from the valid non-individual CIRA word list" />

       * */
    }
  }
}
