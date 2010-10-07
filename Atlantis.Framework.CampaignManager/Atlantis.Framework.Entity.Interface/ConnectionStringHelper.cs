using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Atlantis.Framework.Nimitz;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.Entity.Interface
{
    internal static class ConnectionStringHelper
    {
        public static string LookupConnectionString(ConfigElement config)
        {
            string connStr = NetConnect.LookupConnectInfo(config);
            return connStr;
        }
    }
}
