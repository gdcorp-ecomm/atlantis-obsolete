using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Atlantis.Framework.Entity.Interface;
using System.Data.Objects;
using Atlantis.Framework.Nimitz;
using System.Configuration;
using Atlantis.Framework.Interface;
using System.Data.EntityClient;

namespace Atlantis.Framework.Entity.Interface.EF4
{
    public abstract class EF4EntityRequest<T> : AtlantisEntityRequest<T>
        where T : class, IAtlantisEntity, new()
    {
        protected string GetConnectionString()
        {
            string modelAssembly = this.Config.GetConfigValue("ModelAssembly");
            string modelName = this.Config.GetConfigValue("ModelName");

            if (String.IsNullOrWhiteSpace(modelAssembly))
                throw new ConfigurationErrorsException(String.Format("ModelAssembly was not specified in the atlantis.config for the '{0}' request.", this.Config.ProgID));

            if (String.IsNullOrWhiteSpace(modelName))
                throw new ConfigurationErrorsException(String.Format("ModelName was not specified in the atlantis.config for the '{0}' request.", this.Config.ProgID));

            return GetConnectionString(modelAssembly, modelName, MetadataLocationType.AssemblyResource);
        }    

        protected string GetConnectionString(string modelAssembly, string modelName, MetadataLocationType metadataLocationType)
        {
            string nimitz = ConnectionStringHelper.LookupConnectionString(this.Config);
                         
            EntityConnectionStringBuilder ecs = new EntityConnectionStringBuilder();
            ecs.Provider = "System.Data.SqlClient";
            ecs.ProviderConnectionString = nimitz;
            
            switch (metadataLocationType)
            {
                case MetadataLocationType.AssemblyResource:
                    ecs.Metadata = String.Format(
                        @"res://{0}/{1}.csdl|res://{0}/{1}.ssdl|res://{0}/{1}.msl", 
                        modelAssembly, 
                        modelName);
                    break;
                default:
                    throw new MetadataLocationTypeNotSupported(metadataLocationType);
            }

            string efConnString = ecs.ToString();

            return efConnString;
        }

        public override void Dispose()
        {
            // do nothing
        }
    }

    public enum MetadataLocationType 
    {
        AssemblyResource = 1, 
        AppData = 2, 
        Database = 3 
    }

    public class MetadataLocationTypeNotSupported : Exception
    {
        public override string Message
        {
            get
            {
                return _errorMessage;
            }
        }
        public string _errorMessage = String.Empty;

        public MetadataLocationTypeNotSupported(MetadataLocationType type)
        {
            _errorMessage = String.Format("MetadataLocationType '{0}' is not currently supported!", Enum.GetName(typeof(MetadataLocationType), type));
        }
    }
}
