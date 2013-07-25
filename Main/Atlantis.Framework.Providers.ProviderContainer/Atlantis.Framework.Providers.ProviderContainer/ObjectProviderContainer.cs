﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web;
using Atlantis.Framework.Providers.Interface.ProviderContainer;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.Providers.ProviderContainer.Impl
{
  public class ObjectProviderContainer: IProviderContainer
  {
    private const string KEY_FORMAT = "Atlantis.Framework.Interface.ObjectProviderContainer.{0}";

    private readonly object _lockSync = new object();
    private readonly IDictionary<Type, Type> _registeredProvidersDictionary = new Dictionary<Type, Type>(64);

    private readonly IDictionary<string, object> _providerInterfaces = new Dictionary<string, object>();

    public ObjectProviderContainer()
    {
    }

    private static string GetObjectKey(Type type)
    {
      return string.Format(KEY_FORMAT, type.FullName);
    }

    private void AddProviderRegistration(Type providerInterface, Type provider)
    {
      if(!_registeredProvidersDictionary.ContainsKey(providerInterface))
      {
        lock(_lockSync)
        {
          if (!_registeredProvidersDictionary.ContainsKey(providerInterface))
          {
            _registeredProvidersDictionary.Add(providerInterface, provider);
          }
        }
      }
    }

    private Type GetProviderFromRegisteredProviders(Type providerInterface)
    {
      if(!_registeredProvidersDictionary.ContainsKey(providerInterface))
      {
        throw new Exception(string.Format("Type {0} is not registered.", providerInterface.Name));
      }

      return _registeredProvidersDictionary[providerInterface];
    }

    public void RegisterProvider<TProviderInterface, TProvider>() where TProviderInterface : class where TProvider : ProviderBase
    {
      Type providerInterfaceType = typeof (TProviderInterface);
      Type providerType = typeof (TProvider);

      if(ProviderContainerHelper.TypeIsAssignable(providerInterfaceType, providerType))
      {
        AddProviderRegistration(providerInterfaceType, providerType);
      }
    }

    public void RegisterProvider<TProviderInterface, TProvider>(TProvider providerInstance)
      where TProviderInterface : class
      where TProvider : ProviderBase
    {
      Type providerInterfaceType = typeof(TProviderInterface);
      Type providerType = typeof(TProvider);

      if (ProviderContainerHelper.TypeIsAssignable(providerInterfaceType, providerType))
      {
        AddProviderRegistration(providerInterfaceType, providerType);
      }
      if (providerInstance != null)
      {
        string key = GetObjectKey(providerInterfaceType);
        _providerInterfaces[key] = providerInstance;
      }
    }

    public TProviderInterface Resolve<TProviderInterface>() where TProviderInterface : class
    {
      TProviderInterface providerInterface = default(TProviderInterface);

      Type providerInterfaceType = typeof (TProviderInterface);
      Type providerType = GetProviderFromRegisteredProviders(providerInterfaceType);

      string key = GetObjectKey(providerInterfaceType);

      if (_providerInterfaces.ContainsKey(key))
      {
        providerInterface = _providerInterfaces[key] as TProviderInterface;
      }

      if (providerInterface == null)
      {
        providerInterface = ProviderContainerHelper.ConstructProvider<TProviderInterface>(providerType, this);
        Debug.WriteLine(string.Format("ObjectProviderContainer: {0}:{1} instantiated | Key: {2} | Url: {3}", providerInterfaceType.Name, providerType.Name, key, string.Empty));
        _providerInterfaces[key] = providerInterface;
      }

      return providerInterface;
    }

    public bool CanResolve<T>()
    {
      Type providerInterfaceType = typeof(T);
      string key = GetObjectKey(providerInterfaceType);
      bool isResolvable = false;
      if (_providerInterfaces.ContainsKey(key))
      {
        isResolvable = true;
      }
      return isResolvable;
    }
  }
}
