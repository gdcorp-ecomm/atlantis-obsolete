using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.KiwiLogger.Interface;
using System.Net;
using System.Net.Sockets;
namespace Atlantis.Framework.KiwiLogger.Impl
{
  public class KiwiLoggerRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      KiwiLoggerResponseData oResponseData = null;
      string sResponseXML = "";
      Socket sendSocket=null;
      try
      {
        KiwiLoggerRequestData oKiwiLoggerRequestData = (KiwiLoggerRequestData)oRequestData;
        //Create Connection via UDP to SysLogger
        int ProtocolPort = oKiwiLoggerRequestData.ProtocolPort;
        sendSocket = new Socket(AddressFamily.InterNetwork,
            SocketType.Dgram, oKiwiLoggerRequestData.SocketProtocol);
        IPAddress sendTo = IPAddress.Parse(oKiwiLoggerRequestData.ServerIPAddress);
        EndPoint sendEndPoint = new IPEndPoint(sendTo, ProtocolPort);
        System.Text.StringBuilder newMessage = new StringBuilder();
        newMessage.Append("<");
        newMessage.Append(oKiwiLoggerRequestData.MessagePriority);
        newMessage.Append(">");
        newMessage.Append(oKiwiLoggerRequestData.MessagePrefix);
        newMessage.Append(oKiwiLoggerRequestData.ItemParameters);
        newMessage.Append(oKiwiLoggerRequestData.MessageSuffix);
        //Message is of the format
        //<priority> FieldName=FieldValue FieldName1=FieldValue1 ... etc
        Byte[] messageBuffer = System.Text.Encoding.UTF8.GetBytes(newMessage.ToString());
        sendSocket.SendTo(messageBuffer, messageBuffer.Length, SocketFlags.None,
            sendEndPoint);
        oResponseData = new KiwiLoggerResponseData("<Result>Success</Result>");
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new KiwiLoggerResponseData(sResponseXML, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new KiwiLoggerResponseData(sResponseXML, oRequestData, ex);
      }
      finally
      {
        if (sendSocket != null) 
          sendSocket.Close();
      }
      return oResponseData;


    }

    #endregion
  }
}
