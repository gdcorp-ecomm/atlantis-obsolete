using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
namespace Atlantis.Framework.KiwiLogger.Interface
{
  public enum KiwiLoggerFacilities
  {
    fac_kernel = 0,
    fac_user_level = 1,
    fac_mail_system = 2,
    fac_system_daemon = 3,
    fac_security_auth = 4,
    fac_internal_syslog = 5,
    fac_printer = 6,
    fac_network_news = 7,
    fac_UUCP = 8,
    fac_clock = 9,
    fac_security_auth_2 = 10,
    fac_ftp = 11,
    fac_NTP = 12,
    fac_logaudit = 13,
    fac_logalert = 14,
    fac_clock_2 = 15,
    fac_user1 = 16,
    fac_user2 = 17,
    fac_user3 = 18,
    fac_user4 = 19,
    fac_user5 = 20,
    fac_user6 = 21,
    fac_user7 = 22
  }
  public enum KiwiLoggerLevels
  {
    emergency=0,
    alert=1,
    critical=2,
    error=3,
    warning=4,
    notice=5,
    information=6,
    debug=7
  }
  public class KiwiLoggerRequestData : RequestData
  {
    private List<KiwiLoggerParameters> _loggingParameters = new List<KiwiLoggerParameters>();
    private int _protocolPort = 514;
    private string _serverIpAddress = "127.0.0.1";
    private System.Net.Sockets.ProtocolType _ProtoColType = System.Net.Sockets.ProtocolType.Udp;


    private KiwiLoggerFacilities _currentFacility = KiwiLoggerFacilities.fac_internal_syslog;
    public KiwiLoggerFacilities MessageFacility
    {
      get
      {
        return _currentFacility;
      }
      set
      {
        _currentFacility = value;
      }
    }
    private KiwiLoggerLevels _currentLevel = KiwiLoggerLevels.notice;
    public KiwiLoggerLevels MessageLevel
    {
      get
      {
        return _currentLevel;
      }
      set
      {
        _currentLevel = value;
      }
    }
    public System.Net.Sockets.ProtocolType SocketProtocol
    {
      get
      {
        return _ProtoColType;
      }
      set
      {
        _ProtoColType = value;
      }
    }
    public int ProtocolPort
    {
      get
      {
        return _protocolPort;
      }
      set
      {
        _protocolPort = value;
      }
    }
    public string ServerIPAddress
    {
      get
      {
        return _serverIpAddress;
      }
      set
      {
        _serverIpAddress = value;
      }
    }
    public int MessagePriority
    {
      get
      {
        int calculatedPriority = (int)_currentFacility * 8 + (int)_currentLevel;
        return calculatedPriority;
      }
      set
      {
        //Determine Facility
        int Facility = value / 8;
        int Level = value - Facility * 8;
        _currentLevel = (KiwiLoggerLevels) Level;
        _currentFacility = (KiwiLoggerFacilities) Facility;
      }
    }
    public KiwiLoggerRequestData(string shopperID,
                                string sourceURL,
                                string orderID,
                                string pathway,
                                int pageCount)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {

    }
    public KiwiLoggerRequestData(string shopperID,
                                string sourceURL,
                                string orderID,
                                string pathway,
                                int pageCount,
                               IEnumerable<KiwiLoggerParameters> itemKeys)
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      _loggingParameters.AddRange(itemKeys);
    }
    public KiwiLoggerRequestData(string shopperID,
                                string sourceURL,
                                string orderID,
                                string pathway,
                                int pageCount,
                                IEnumerable<KiwiLoggerParameters> itemKeys,
                                int port,
                                string ipAddress
                                )
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      _loggingParameters.AddRange(itemKeys);
      _protocolPort = port;
      _serverIpAddress = ipAddress;
    }
    public KiwiLoggerRequestData(string shopperID,
                                string sourceURL,
                                string orderID,
                                string pathway,
                                int pageCount,
                                IEnumerable<KiwiLoggerParameters> itemKeys,
                                int port,
                                string ipAddress,
                                int priority
                                )
      : base(shopperID, sourceURL, orderID, pathway, pageCount)
    {
      _loggingParameters.AddRange(itemKeys);
      _loggingParameters.AddRange(itemKeys);
      _protocolPort = port;
      _serverIpAddress = ipAddress;
      MessagePriority = priority;
    }
    private string _messagePrefix = string.Empty;
    public string MessagePrefix
    {
      get
      {
        return _messagePrefix;
      }
      set
      {
        _messagePrefix=value;
      }
    }
    private string _messageSuffix = string.Empty;
    public string MessageSuffix
    {
      get
      {
        return _messageSuffix;
      }
      set
      {
        _messageSuffix = value;
      }
    }
    public void AddItem(string fieldName, string fieldValue)
    {
      _loggingParameters.Add(new KiwiLoggerParameters(fieldName, fieldValue));
    }

    public void AddItems(IEnumerable<KiwiLoggerParameters> itemKeys)
    {
      _loggingParameters.AddRange(itemKeys);
    }
    public string ItemParameters
    {
      get
      {
        string result = string.Empty;
        List<string> itemParms = _loggingParameters.ConvertAll<string>(
          new Converter<KiwiLoggerParameters, string>(
            delegate(KiwiLoggerParameters item) { return item.ToString(); }
            ));
        result = string.Join(" ", itemParms.ToArray());
        return result;
      }
    }
    public override string GetCacheMD5()
    {
      throw new Exception("KiwiLogger is not a cacheable request.");
    }
  }
}
