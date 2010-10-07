using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Atlantis.Framework.CampaignManagerData.Interface;
using Atlantis.Framework.CampaignManagerData.Interface.Entities;
using Atlantis.Framework.Entity.Interface.ADO;

namespace Atlantis.Framework.CampaignManagerData.Impl
{
    public class MessageLanguageRequest : BaseRequest<MessageLanguage>
    {
        public override ICollection<MessageLanguage> Query()
        {
            return this.ExecuteProcedure("dbo.MessageLanguageSelect_sp");
        }

        public override MessageLanguage Materialize(DataRow row)
        {
            return new MessageLanguage
            {
                LanguageCode = row.ByteValue("LanguageCode"),
                Name = row.StringValue("LanguageName"),
                LanguageDescription = row.StringValue("LanguageDescription")
            };
        }
    }
}
