using System;
using System.Collections.Generic;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.Providers.Interface.CDS
{
  public interface ICDSProvider
  {
    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    T GetModel<T>(string query, IProviderContainer providerContainer) where T : new();

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    T GetModel<T>(string query, IProviderContainer providerContainer, Dictionary<string, string> customTokens) where T : new();

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    string GetJson(string query, IProviderContainer providerContainer);

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    string GetJson(string query, IProviderContainer providerContainer, Dictionary<string, string> customTokens);
  }
}
