using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Atlantis.Framework.DataProvider.Interface;

namespace Atlantis.Framework.DataProvider.Impl
{
  internal sealed class DataProviderFile : DynamicFileBase
  {
    private string m_sAssemblyPath;
    private static DataProviderFile _instance;
    private static object _syncLock = new object();

    private Dictionary<string, ProviderRequestSetting> _requestSettings = new Dictionary<string, ProviderRequestSetting>();

    private DataProviderFile()
    {
    }

    public static DataProviderFile Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (_syncLock)
          {
            if (_instance == null)
              _instance = new DataProviderFile();
          }
        }

        return _instance;
      }
    }

    public override string FilePath
    {
      get
      {
        string sXmlFilename = Path.Combine(AssemblyPath, "DataProvider.xml");
        return sXmlFilename;
      }
    }

    private string AssemblyPath
    {
      get
      {
        if (string.IsNullOrEmpty(m_sAssemblyPath))
        {
          Uri pathUri = new Uri(Path.GetDirectoryName(this.GetType().Assembly.CodeBase));
          m_sAssemblyPath = pathUri.LocalPath;
        }
        return m_sAssemblyPath;
      }
    }

    private void ReadSetttingNode(XmlReader reader, out ProviderRequestSetting rs)
    {
      rs = new ProviderRequestSetting();
      rs.RequestName = reader.GetAttribute("name");
      rs.HostName = reader.GetAttribute("host_name");
      if (string.IsNullOrEmpty(rs.DSN))
      {
        rs.DSN = reader.GetAttribute("dsn");
      }

      if (string.IsNullOrEmpty(rs.AppName))
      {
        rs.AppName = reader.GetAttribute("app_name");
      }

      if (string.IsNullOrEmpty(rs.CertName))
      {
        rs.CertName = reader.GetAttribute("cert_name");
      }

      rs.TargetName = reader.GetAttribute("target_name");
      rs.ParamList = new List<ProviderParameter>();
    }

    private void ReadNodeParams(XmlReader reader, ProviderRequestSetting rs)
    {
      if (reader.ReadToDescendant("param"))
      {
        do
        {
          ProviderParameter param = new ProviderParameter();
          param.Name = reader.GetAttribute("name");
          param.Type = reader.GetAttribute("type");
          param.Size = 0;
          string sz = reader.GetAttribute("size");
          if (!string.IsNullOrEmpty(sz))
          {
            param.Size = Convert.ToInt32(sz);
          }
          string direction = reader.GetAttribute("direction");
          if (!string.IsNullOrEmpty(direction))
          {
            param.Direction = direction;
          }


          rs.ParamList.Add(param);
        }
        while (reader.ReadToNextSibling("param"));
      }
    }

    public override void ProcessFile(System.IO.FileInfo fileInfo)
    {
      Dictionary<string, ProviderRequestSetting> requestSettings = new Dictionary<string, ProviderRequestSetting>();

      using (XmlReader reader = XmlReader.Create(fileInfo.FullName))
      {
        try
        {
          while (reader.Read())
          {
            if (reader.NodeType == XmlNodeType.Element)
            {
              if (reader.Name == "dbsetting")
              {
                ProviderRequestSetting dbs;
                ReadSetttingNode(reader, out dbs);
                ReadNodeParams(reader, dbs);
                dbs.RequestSettingType = ProviderRequestSettingType.StoredProcedure;
                requestSettings.Add(dbs.RequestName, dbs);
              }
              else if (reader.Name == "wssetting")
              {
                ProviderRequestSetting wss;
                ReadSetttingNode(reader, out wss);
                ReadNodeParams(reader, wss);
                wss.RequestSettingType = ProviderRequestSettingType.WebService;
                requestSettings.Add(wss.RequestName, wss);
              }
              else if (reader.Name == "rssetting")
              {
                ProviderRequestSetting rss;
                ReadSetttingNode(reader, out rss);
                ReadNodeParams(reader, rss);
                rss.RequestSettingType = ProviderRequestSettingType.RestService;
                requestSettings.Add(rss.RequestName, rss);
              }
            }
          }
          _requestSettings = requestSettings;
        }
        finally
        {
          reader.Close();
        }
      }
    }

    public ProviderRequestSetting GetRequestSetting(DataProviderRequestData oDataProviderRequestData)
    {
      ProcessFileIfNeeded();
      ProviderRequestSetting result = null;
      _requestSettings.TryGetValue(oDataProviderRequestData.RequestName, out result);
      return result;
    }
  }

}
