using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    public enum OperatorType : byte
    {
        AND = 0, 
        OR = 1, 
        NOT = 2
    }

    public static class OperatorTypeExtensions
    {
        public static byte ValueAsByte(this OperatorType enumValue)
        {
            return (byte)enumValue;
        }

        public static string Name(this OperatorType enumValue)
        {
            return Enum.GetName(typeof(OperatorType), enumValue);
        }
    }
}
