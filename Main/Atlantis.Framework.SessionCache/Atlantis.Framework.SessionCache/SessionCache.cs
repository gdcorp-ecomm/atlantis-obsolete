﻿using System;
using Atlantis.Framework.Interface;
using System.Web.UI;
using System.Web;

namespace Atlantis.Framework.SessionCache
{
  public static class SessionCache
  {
    #region Properties

    private static bool _minimizeDeserializationsPerRequest = false;
    public static bool MinimizeDeserializationsPerRequest
    {
      get { return _minimizeDeserializationsPerRequest; }
      set { _minimizeDeserializationsPerRequest = value; }
    }

    private const string _CacheKeyPrefix = "SessionCache.";

    #endregion

    #region Methods for Non Framework Responses

    public static void SaveToSession<T>(T sessionItem, string sessionKey)
      where T : class, ISessionSerializableResponse, new()
    {
      string sessionData = string.Empty;
      if (sessionItem != null)
      {
        sessionData = sessionItem.SerializeSessionData();
      }

      Pair itemToSave = SessionCacheItem.NewSessionPair(sessionData);
      HttpContext.Current.Session[sessionKey] = itemToSave;

      if (MinimizeDeserializationsPerRequest)
      {
        string contextKey = _CacheKeyPrefix + sessionKey;
        HttpContext.Current.Items[contextKey] = sessionItem;
      }
    }

    public static void SaveToSession<T>(T sessionItem, string sessionKey, TimeSpan cacheTime)
      where T : class, ISessionSerializableResponse, new()
    {
      string sessionData = string.Empty;
      if (sessionItem != null)
      {
        sessionData = sessionItem.SerializeSessionData();
      }

      Pair itemToSave = SessionCacheItem.NewSessionPair(sessionData, cacheTime);
      HttpContext.Current.Session[sessionKey] = itemToSave;

      if (MinimizeDeserializationsPerRequest)
      {
        string contextKey = _CacheKeyPrefix + sessionKey;
        HttpContext.Current.Items[contextKey] = sessionItem;
      }
    }


    public static T GetFromSession<T>(string sessionKey, out bool isExpired)
      where T : class, ISessionSerializableResponse, new()
    {
      T result = null;
      isExpired = false;

      try
      {
        if (MinimizeDeserializationsPerRequest)
        {
          string contextKey = _CacheKeyPrefix + sessionKey;
          result = HttpContext.Current.Items[contextKey] as T;
        }

        if (result == null)
        {
          Pair sessionPair = HttpContext.Current.Session[sessionKey] as Pair;
          SessionCacheItem cacheItem = new SessionCacheItem(sessionPair);
          if (cacheItem.IsValid)
          {
            result = new T();
            result.DeserializeSessionData(cacheItem.SessionData);
            isExpired = cacheItem.IsExpired;

            if (MinimizeDeserializationsPerRequest)
            {
              string contextKey = _CacheKeyPrefix + sessionKey;
              HttpContext.Current.Items[sessionKey] = result;
            }
          }
        }

      }
      catch (Exception ex)
      {
        string message = "Error deserializing session data: " + ex.Message + " " + ex.StackTrace;
        string data = "Session Key: " + sessionKey;
        AtlantisException aex = new AtlantisException(
          "SessionCache.GetFromSession", string.Empty, "0", message, data,
          string.Empty, string.Empty, string.Empty, string.Empty, 0);
        Engine.Engine.LogAtlantisException(aex);
      }

      return result;
    }

    #endregion

    #region Methods for Framework Responses

    public static T GetProcessRequest<T>(RequestData requestData, int requestType)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      return GetProcessRequest<T>(requestData, requestType, TimeSpan.MaxValue, false);
    }

    public static T GetProcessRequest<T>(RequestData requestData, int requestType, TimeSpan cacheTime)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      return GetProcessRequest<T>(requestData, requestType, cacheTime, false);
    }

    public static T GetProcessRequest<T>(RequestData requestData, int requestType, bool forceRequest)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      return GetProcessRequest<T>(requestData, requestType, TimeSpan.MaxValue, forceRequest);
    }

    public static T GetProcessRequest<T>(RequestData requestData, int requestType, TimeSpan cacheTime, bool forceRequest)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      if (cacheTime < TimeSpan.FromSeconds(30))
      {
        cacheTime = TimeSpan.FromSeconds(30);
      }

      T result = null;
      string sessionKey = GetSessionKey(requestData, requestType);
      SessionCacheItem cacheItem = null;

      if (!forceRequest)
      {
        try
        {
          if (!IsResponseInSession<T>(requestData, requestType, true, out result, out cacheItem))
          {
            result = null;
          }
        }
        catch (Exception ex)
        {
          string message = "Error deserializing session data: " + ex.Message + " " + ex.StackTrace;
          string data = "Session Key: " + sessionKey;
          AtlantisException aex = new AtlantisException(requestData, "SessionCache.GetProcessRequest", message, data, ex);
          Engine.Engine.LogAtlantisException(aex);
        }
      }

      if (result == null)
      {
        try
        {

          result = Engine.Engine.ProcessRequest(requestData, requestType) as T;
          if (result == null)
          {
            throw new Exception("Engine request did not result in object of type: " + typeof(T).Name);
          }

          string newSessionData = result.SerializeSessionData();
          Pair newSessionPair;
          if (cacheTime == TimeSpan.MaxValue)
          {
            newSessionPair = SessionCacheItem.NewSessionPair(newSessionData);
          }
          else
          {
            newSessionPair = SessionCacheItem.NewSessionPair(newSessionData, cacheTime);
          }

          HttpContext.Current.Session[sessionKey] = newSessionPair;
          if (MinimizeDeserializationsPerRequest)
          {
            HttpContext.Current.Items[sessionKey] = result;
          }

        }
        catch (Exception ex)
        {

          if ((cacheItem != null) && (cacheItem.IsValid))
          {

            result = new T();
            result.DeserializeSessionData(cacheItem.SessionData);

            // recache with a new timeout
            Pair updatedSessionPair = cacheItem.RefreshedSessionPair(cacheTime);
            HttpContext.Current.Session[sessionKey] = updatedSessionPair;

            if (MinimizeDeserializationsPerRequest)
            {
              HttpContext.Current.Items[sessionKey] = result;
            }

          }
          else
          {
            string message = "Error requesting session data: " + ex.Message + " " + ex.StackTrace;
            string data = "Session Key: " + sessionKey;
            AtlantisException aex = new AtlantisException(requestData, "SessionCache.GetProcessRequest", message, data, ex);
            Engine.Engine.LogAtlantisException(aex);
            throw ex;
          }
        }
      }

      return result;
    }

    #endregion

    #region Methods for Checking if item is in cache

    public static bool IsCachedRequest<T>(RequestData requestData, int requestType)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      SessionCacheItem cacheItem = null;

      T data = default(T);
      return IsResponseInSession(requestData, requestType, false, out data, out cacheItem);
    }

    public static bool IsCachedRequest<T>(RequestData requestData, int requestType, out T data)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      SessionCacheItem cacheItem = null;
      return IsResponseInSession(requestData, requestType, true, out data, out cacheItem);

    }

    private static bool IsResponseInSession<T>(RequestData requestData, int requestType, bool shouldDeserializeData, out T data, out SessionCacheItem cacheItem)
      where T : class, IResponseData, ISessionSerializableResponse, new()
    {
      bool isCachedRequest = false;
      data = null;

      string sessionKey = GetSessionKey(requestData, requestType);
      cacheItem = null;

      if (MinimizeDeserializationsPerRequest)
      {
        data = HttpContext.Current.Items[sessionKey] as T;
      }

      if (data == null)
      {
        Pair sessionPair = HttpContext.Current.Session[sessionKey] as Pair;
        cacheItem = new SessionCacheItem(sessionPair);
        if ((cacheItem.IsValid) && (!cacheItem.IsExpired))
        {
          isCachedRequest = true;
          if (shouldDeserializeData)
          {
            data = new T();
            data.DeserializeSessionData(cacheItem.SessionData);

            if (MinimizeDeserializationsPerRequest)
            {
              HttpContext.Current.Items[sessionKey] = data;
            }
          }
        }
      }
      else
      {
        isCachedRequest = true;
      }

      return isCachedRequest;
    }

    #endregion


    #region Helper Methods
    private static string GetSessionKey(RequestData requestData, int requestType)
    {
      return String.Format("{0}{1}.{2}", _CacheKeyPrefix, requestType.ToString(), requestData.GetCacheMD5());
    }

    #endregion
  }
}
