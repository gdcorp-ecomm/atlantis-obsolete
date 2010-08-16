using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Configuration.Install;

namespace Atlantis.ConfigBuilder
{
  [RunInstaller(true)]
  public partial class ConfigBuilder : Installer
  {
    const string sConfigFilename = @"atlantis.config";

    public ConfigBuilder()
    {
      InitializeComponent();
    }

    public override void Install(System.Collections.IDictionary stateSaver)
    {
      base.Install(stateSaver);

      if (Context.Parameters.ContainsKey("TargetDir"))
      {
        XmlDocument xdDoc = new XmlDocument();
        string sTargetDir = Context.Parameters["TargetDir"];
        string sPath = Path.Combine(sTargetDir, sConfigFilename);

        xdDoc.Load(sPath);

        XmlNodeList xnlConfigElements = xdDoc.SelectNodes("/ConfigElements/ConfigElement");

        foreach (XmlElement xlConfigElement in xnlConfigElements)
        {
          string sFilename = Path.GetFileName(xlConfigElement.GetAttribute("assembly"));
          xlConfigElement.SetAttribute("assembly", Path.Combine(sTargetDir, sFilename));
        }

        xdDoc.Save(sPath);
      }
    }
  }
}