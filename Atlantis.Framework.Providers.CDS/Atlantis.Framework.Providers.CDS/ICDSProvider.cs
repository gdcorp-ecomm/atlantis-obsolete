using System;
using System.Collections.Generic;

namespace Atlantis.Framework.Providers.Interface.CDS
{
  public interface ICDSProvider
  {
    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    T GetModel<T>(string query) where T : new();

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    T GetModel<T>(string query, Dictionary<string, string> customTokens) where T : new();

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    string GetJson(string query);

    [Obsolete("Please use the new Atlantis.Framework.Providers.ICDSContent provider")]
    string GetJson(string query, Dictionary<string, string> customTokens);
  }
}
