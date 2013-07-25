using System;
using System.IO;
using System.Xml;
using Atlantis.Framework.Interface;
using Atlantis.Framework.SessionCache;

namespace Atlantis.Framework.CRMLynxPermission.Interface
{
  public class CRMLynxPermissionResponseData : IResponseData, ISessionSerializableResponse
  {
    #region Properties
    private AtlantisException _exAtlantis = null;

    private bool _userHasAccess = false;
    public bool UserHasAccess
    {
      get { return _userHasAccess; }
    }

    private bool _success = false;
    public bool IsSuccess
    {
      get { return _success; }
    }
    #endregion 

    public CRMLynxPermissionResponseData()
    { }

    public CRMLynxPermissionResponseData(bool userHasAccess)
    {
      _success = true;
      _userHasAccess = userHasAccess;
    }

    public CRMLynxPermissionResponseData(AtlantisException atlantisException)
    {
      _exAtlantis = atlantisException;
    }

    public CRMLynxPermissionResponseData(RequestData requestData, Exception exception)
    {
      _exAtlantis = new AtlantisException(requestData
        , "CRMLynxPermissionResponseData"
        , exception.Message
        , requestData.ToXML());
    }


    #region IResponseData Members

    public string ToXML()
    {
      return string.Format("<UserHasAccess>{0}</UserHasAccess>", UserHasAccess.ToString());
    }

    public AtlantisException GetException()
    {
      return _exAtlantis;
    }

    #endregion

    #region ISessionSerializableResponse Members

    public string SerializeSessionData()
    {
      return ToXML();
    }

    public void DeserializeSessionData(string sessionData)
    {
      if (!string.IsNullOrEmpty(sessionData))
      {
        using (XmlReader reader = XmlReader.Create(new StringReader(sessionData)))
        {
          if (reader.Read())
          {
            reader.ReadStartElement("UserHasAccess");
            if (bool.TryParse(reader.Value, out _userHasAccess))
            {
              _success = true;
            }
          }
        }
      }
    }
    #endregion
  }
}
