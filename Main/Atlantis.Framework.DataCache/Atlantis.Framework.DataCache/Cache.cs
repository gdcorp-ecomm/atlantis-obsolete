using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.DataCache
{
  class Cache
  {
#if DEBUG
    static TimeSpan _DEFAULTITEMCACHETIME = TimeSpan.FromMinutes(5);
#else
    static TimeSpan _DEFAULTITEMCACHETIME = TimeSpan.FromMinutes(10);
#endif

    const int MAX_CLEAN = 100;

    Dictionary<string, CachedValue> _cachedValuesDictionary;
    LinkedList<object> _cachedValuesLinkList;

    SlimLock _cacheLock;
    string _cacheName;
    TimeSpan _itemCacheTime;
    DateTime _cacheCreateTime;
    string _privateLabelIdName;
    bool _isBasedOnPrivateLabelId;

    int _iHit = 0;
    int _iMiss = 0;

    private TimeSpan DefaultItemCacheTime
    {
      get { return _DEFAULTITEMCACHETIME; }
    }

    internal Cache(string cacheName, string privateLabelIdName)
    {
      _cachedValuesDictionary = new Dictionary<string, CachedValue>();
      _cachedValuesLinkList = new LinkedList<object>();

      _cacheName = cacheName;
      _privateLabelIdName = privateLabelIdName;
      _isBasedOnPrivateLabelId = true;
      _cacheLock = new SlimLock();
      _itemCacheTime = DefaultItemCacheTime;
      _cacheCreateTime = DateTime.UtcNow;
    }


    internal Cache(string cacheName, bool isBasedOnPrivateLabelId)
      : this(cacheName, null)
    {
      _isBasedOnPrivateLabelId = isBasedOnPrivateLabelId;

    }

    public string PrivateLabelIdName
    {
      get { return _privateLabelIdName; }
    }

    public bool IsBasedOnPrivateLabelId
    {
      get { return _isBasedOnPrivateLabelId; }
    }

    public string GetStats()
    {
      TimeSpan ts = DateTime.UtcNow - _cacheCreateTime;
      int seconds = (int)ts.TotalSeconds + 1;

      int iHit = Interlocked.CompareExchange(ref _iHit, 0, 0);
      int iMiss = Interlocked.CompareExchange(ref _iMiss, 0, 0);

      StringBuilder sb = new StringBuilder();
      sb.Append("<Stats><CacheName>");
      sb.Append(_cacheName);
      sb.Append("</CacheName><CacheCreate>");
      sb.Append(_cacheCreateTime.ToLongTimeString());
      sb.Append("</CacheCreate><HitCount>");
      sb.Append(iHit.ToString());
      sb.Append("</HitCount><MissCount>");
      sb.Append(iMiss.ToString());
      sb.Append("</MissCount><HitPerSecond>");
      sb.Append(((iHit / seconds)).ToString());
      sb.Append("</HitPerSecond><MissPerSecond>");
      sb.Append(((iMiss / seconds)).ToString());
      sb.Append("</MissPerSecond></Stats>");
      return sb.ToString();
    }

    public bool TryGetValue(string key, out CachedValue cachedValue)
    {
      cachedValue = null;
      bool isFresh = false;
      bool foundValue = false;

      try
      {
        using (SlimRead read = _cacheLock.GetReadLock())
        {
          foundValue = _cachedValuesDictionary.TryGetValue(key, out cachedValue);
        }

        if (foundValue && cachedValue != null)
        {
          isFresh = !cachedValue.IsExpired || cachedValue.RefreshInProgress;
        }

#if DEBUG
        if (isFresh && foundValue)
          Interlocked.Increment(ref _iHit);
        else
          Interlocked.Increment(ref _iMiss);
#endif

      }
      catch (Exception ex)
      {
        LogError(_cacheName, key, ex);
        cachedValue = null;
        isFresh = false;
      }

      return isFresh;
    }

    public void RenewValue(CachedValue cachedValue)
    {
      try
      {
        using (SlimWrite write = _cacheLock.GetWriteLock())
        {
          cachedValue.MarkInactive();

          DateTime finalExpiration = DateTime.UtcNow + _itemCacheTime;
          CachedValue renewedCacheValue = new CachedValue(cachedValue.Key, cachedValue.Value, finalExpiration.Ticks, cachedValue.PrivateLabelId);
          _cachedValuesDictionary[renewedCacheValue.Key] = renewedCacheValue;
          _cachedValuesLinkList.AddLast(new WeakReference(renewedCacheValue));
        }
      }
      catch (Exception ex)
      {
        LogError(_cacheName, cachedValue.Key, ex);
      }
    }

    private void QuickClean(CachedValue oldCachedValue)
    {
      try
      {
        int maxCheck = System.Math.Min(MAX_CLEAN, (int)((_cachedValuesLinkList.Count * .05) + 1));
        long timeKeyFiveHoursAgo = (DateTime.UtcNow.AddHours(-5)).Ticks;

        if (oldCachedValue != null)
        {
          oldCachedValue.MarkInactive();
        }

        LinkedListNode<object> oNode = _cachedValuesLinkList.First;
        int i = 0;
        bool bExit = false;
        while (i < maxCheck && oNode != null && !bExit)
        {
          WeakReference oWeakRef = (WeakReference)oNode.Value;
          LinkedListNode<object> oNextNode = oNode.Next;

          CachedValue targetCachedValue = oWeakRef.Target as CachedValue;
          if ((targetCachedValue == null) || (!targetCachedValue.IsActive))
          {
            _cachedValuesLinkList.Remove(oNode);
          }
          else if (targetCachedValue.FinalTicks < timeKeyFiveHoursAgo)
          {
            _cachedValuesLinkList.Remove(oNode);
            _cachedValuesDictionary.Remove(targetCachedValue.Key);
          }
          else
          {
            bExit = true;
          }

          oNode = oNextNode;
          i++;
        }
      }
      catch (Exception ex)
      {
        LogError(_cacheName, "QuickClean", ex);
      }
    }

    // WeakReference - http://msdn2.microsoft.com/en-us/library/ms404247.aspx
    public void AddValue(string key, object cacheValue, int privateLabelId, CachedValue oldCachedValue)
    {
      DateTime finalExpiration = DateTime.UtcNow + _itemCacheTime;
      CachedValue newCachedValue = new CachedValue(key, cacheValue, finalExpiration.Ticks, privateLabelId);

      using (SlimWrite write = _cacheLock.GetWriteLock())
      {
        QuickClean(oldCachedValue);
        _cachedValuesDictionary[newCachedValue.Key] = newCachedValue;
        _cachedValuesLinkList.AddLast(new WeakReference(newCachedValue));
      }
    }

    public void AddValue(string key, object cacheValue, CachedValue oldCachedValue)
    {
      AddValue(key, cacheValue, 0, oldCachedValue);
    }

    public void ClearByPLID(HashSet<int> privateLabelIds)
    {
      try
      {
        if ((privateLabelIds != null) && (privateLabelIds.Count > 0))
        {
          using (SlimWrite write = _cacheLock.GetWriteLock())
          {
            long timeKeyFiveHoursAgo = (DateTime.UtcNow.AddHours(-5)).Ticks;
            LinkedListNode<object> oNode = _cachedValuesLinkList.First;

            while (oNode != null)
            {
              WeakReference oWeakRef = (WeakReference)oNode.Value;
              LinkedListNode<object> oNextNode = oNode.Next;

              CachedValue cachedValue = oWeakRef.Target as CachedValue;
              if ((cachedValue == null) || (!cachedValue.IsActive))
              {
                _cachedValuesLinkList.Remove(oNode);
              }
              else if (cachedValue.FinalTicks < timeKeyFiveHoursAgo)
              {
                cachedValue.MarkInactive();
                _cachedValuesDictionary.Remove(cachedValue.Key);
                _cachedValuesLinkList.Remove(oNode);
              }
              else if ((cachedValue.PrivateLabelId > 0) && (privateLabelIds.Contains(cachedValue.PrivateLabelId)))
              {
                cachedValue.MarkInactive();
                _cachedValuesDictionary.Remove(cachedValue.Key);
                _cachedValuesLinkList.Remove(oNode);
              }

              oNode = oNextNode;
            }
          }
        }
      }
      catch (Exception ex)
      {
        LogError("Cache.ClearByPLID(): " + _cacheName, "", ex);
      }
    }

    public void Clear()
    {
      using (SlimWrite write = _cacheLock.GetWriteLock())
      {
        _cachedValuesLinkList.Clear();
        _cachedValuesDictionary.Clear();
      }
    }

    virtual public string Display()
    {
      StringBuilder sbRequest = new StringBuilder();
      XmlTextWriter xtwRequest = new XmlTextWriter(new StringWriter(sbRequest));
      xtwRequest.WriteStartElement("Cache");
      xtwRequest.WriteAttributeString("MethodName", _cacheName);

#if DEBUG
      using (SlimRead read = _cacheLock.GetReadLock())
      {
        foreach (KeyValuePair<string, CachedValue> oPair in _cachedValuesDictionary)
        {
          xtwRequest.WriteStartElement("Data");
          xtwRequest.WriteAttributeString("Key", oPair.Key);
          xtwRequest.WriteAttributeString("Value", ((CachedValue)oPair.Value).Value.ToString());
          xtwRequest.WriteEndElement();
        }
      }
#endif

      xtwRequest.WriteEndElement();
      return sbRequest.ToString();
    }

    private void LogError(string cacheName, string key, Exception ex)
    {
      if (typeof(Exception) != typeof(ThreadAbortException))
      {
        string message = ex.Message + Environment.NewLine + ex.StackTrace;
        string source = cacheName + ":" + key;
        AtlantisException aex = new AtlantisException(source, "0", message, string.Empty, null, null);
        Engine.Engine.LogAtlantisException(aex);
      }
    }

  }
}
