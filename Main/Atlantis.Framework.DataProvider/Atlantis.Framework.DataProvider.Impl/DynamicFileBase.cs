using System;
using System.IO;

namespace Atlantis.Framework.DataProvider.Impl
{
  public abstract class DynamicFileBase
  {
    private DateTime _lastFileCheck;
    private DateTime _lastTimeStamp;
    private object _syncLock = new object();

    protected DynamicFileBase()
    {
      _lastFileCheck = DateTime.MinValue;
      _lastTimeStamp = DateTime.MinValue;
    }

    public DateTime LastFileCheck
    {
      get { return _lastFileCheck; }
    }

    public DateTime LastTimeStamp
    {
      get { return _lastTimeStamp; }
    }

    public abstract string FilePath
    {
      get;
    }

    public virtual TimeSpan RecheckTimeSpan
    {
      get
      {
        return TimeSpan.FromMinutes(5);
      }
    }

    public abstract void ProcessFile(FileInfo fileInfo);

    protected void ProcessFileIfNeeded()
    {
      string result = string.Empty;

      if (IsReloadRequired())
      {
        lock (_syncLock)
        {
          if (IsReloadRequired())
          {
            ProcessFile();
          }
        }
      }
    }

    private void ProcessFile()
    {
      _lastFileCheck = DateTime.Now;
      FileInfo fileInfo = new FileInfo(FilePath);

      if (fileInfo.Exists)
      {
        _lastTimeStamp = GetCurrentTimeStamp();
        ProcessFile(fileInfo);
      }
      else
      {
        _lastTimeStamp = DateTime.MinValue;
      }
    }

    public void Reset()
    {
      lock (_syncLock)
      {
        _lastFileCheck = DateTime.MinValue;
        _lastTimeStamp = DateTime.MinValue;
      }
    }

    protected virtual DateTime GetCurrentTimeStamp()
    {
      DateTime currentLastWriteTime = _lastTimeStamp;
      DateTime currentCreationTime = _lastTimeStamp;

      try
      {
        FileInfo fileInfo = new FileInfo(FilePath);
        if (fileInfo.Exists)
        {
          fileInfo.Refresh();
          currentLastWriteTime = fileInfo.LastWriteTime;
          currentCreationTime = fileInfo.CreationTime;
        }
      }
      catch
      {
        // If any error occurs accessing the file, we will eat it and return the last known modified time
        // This will avoid a collision if a file update is occuring and we cannot access the file yet.
      }

      DateTime currentTimeStamp = (currentLastWriteTime > currentCreationTime) ? currentLastWriteTime : currentCreationTime;
      return currentTimeStamp;
    }

    private bool IsReloadRequired()
    {
      bool isReloadRequired = false;

      if (DateTime.MinValue == _lastFileCheck)
        isReloadRequired = true;
      else
      {
        TimeSpan timeSpan = DateTime.Now.Subtract(_lastFileCheck);
        if (timeSpan <= RecheckTimeSpan)
          isReloadRequired = false;
        else
        {
          isReloadRequired = (GetCurrentTimeStamp() > _lastTimeStamp);
          // Ensure we don't check the file again for another timespan,
          // but only on the false case, because the true case double
          // checks inside the lock so we cannot change the lastFileCheck
          // or the inside check will return that reload is not required
          if (!isReloadRequired)
            _lastFileCheck = DateTime.Now;
        }
      }

      return isReloadRequired;
    }

  }
}