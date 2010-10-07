using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atlantis.Framework.CampaignManagerData.Interface.Entities
{
    public enum ApprovalStatusCode : byte
    {
        Unknown = 0, 
        InReview = 1, 
        Approved = 2, 
        Rejected = 3
    }

    public static class ApprovalStatusCodeExtensions
    {
        public static byte ValueAsByte(this ApprovalStatusCode enumValue)
        {
            return (byte)enumValue;
        }

        public static string Name(this ApprovalStatusCode enumValue)
        {
            return Enum.GetName(typeof(ApprovalStatusCode), enumValue);
        }
    }
}
