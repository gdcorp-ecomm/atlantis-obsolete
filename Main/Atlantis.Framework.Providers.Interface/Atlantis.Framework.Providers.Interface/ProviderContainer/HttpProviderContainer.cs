﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Atlantis.Framework.Interface;
using System.Web;

namespace Atlantis.Framework.Providers.Interface.ProviderContainer
{
  public class HttpProviderContainer : IProviderContainer
  {
    private const string KEY_FORMAT = "Atlantis.Framework.Interface.HttpProviderContainer.{0}";

    private static readonly object _lockSync = new object();
    private static readonly IDictionary<Type, Type> _registeredProvidersDictionary = new Dictionary<Type, Type>(64);

    private static readonly IProviderContainer _instance = new HttpProviderContainer();
    public static IProviderContainer Instance
    {
      get { return _instance; }
    }

    private HttpProviderContainer()
    {
    }

    private static string GetHttpContextKey(Type type)
    {
      return string.Format(KEY_FORMAT, type.FullName);
    }

    private static void AddProviderRegistration(Type providerInterface, Type provider)
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

    private static Type GetProviderFromRegisteredProviders(Type providerInterface)
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

    public TProviderInterface Resolve<TProviderInterface>() where TProviderInterface : class
    {
      TProviderInterface providerInterface = default(TProviderInterface);

      Type providerInterfaceType = typeof (TProviderInterface);
      Type providerType = GetProviderFromRegisteredProviders(providerInterfaceType);

      string key = GetHttpContextKey(providerInterfaceType);

      if(HttpContext.Current != null)
      {
        providerInterface = HttpContext.Current.Items[key] as TProviderInterface;
      }

      if (providerInterface == null)
      {
        providerInterface = ProviderContainerHelper.ConstructProvider<TProviderInterface>(providerType, this);
        if (HttpContext.Current != null)
        {
          Debug.WriteLine(string.Format("HttpProviderContainer: {0}:{1} instantiated | Key: {2} | Url: {3}", providerInterfaceType.Name, providerType.Name, key, HttpContext.Current.Request.Url));
          HttpContext.Current.Items[key] = providerInterface;
        }
      }

      return providerInterface;
    }

    public bool CanResolve<T>()
    {
      Type providerInterfaceType = typeof(T);
      return _registeredProvidersDictionary.ContainsKey(providerInterfaceType);
    }
  }
}
