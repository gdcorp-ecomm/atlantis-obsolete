using System;
using System.Linq;
using Atlantis.Framework.Interface;
using System.Collections.Generic;

namespace Atlantis.Framework.Entity.Interface
{
    public class AtlantisEntityResponseData<T> : IAtlantisEntityResponseData<T>
        where T : class, IAtlantisEntity, new()
    {
        public AtlantisEntityResponseData()
        {

        }

        public AtlantisEntityResponseData(AtlantisException atlantisException)
        {
            _exception = atlantisException;
        }

        public AtlantisEntityResponseData(IAtlantisEntityRequestData<T> requestData, Exception exception)
        {
            var baseData = requestData as RequestData;

            if (baseData != null)
            {
                _exception = new AtlantisException(
                    baseData,
                    "CampaignManagerResponseData",
                    exception.Message,
                    baseData.ToXML());
            }
        }

        #region IResponseData Members
        public string ToXML()
        {
            return String.Empty;
        }

        public AtlantisException GetException()
        {
            return _exception;
        }
        #endregion

        #region IAtlantisEntityResponseData<T> Members
        public AtlantisException Exception
        {
            get
            {
                return _exception;
            }
        }
        private AtlantisException _exception = null;

        public ICollection<T> Entities
        {
            get
            {
                return _entities;
            }
            set
            {
                _entities = value;
            }
        }
        ICollection<T> _entities = null;

        public int EntityCount
        {
            get
            {
                if (Entities != null && Entities.Count() > 0)
                    return Entities.Count();

                return 0;
            }
        }

        public bool HasExactlyOneEntity
        {
            get
            {
                if (Entities != null && Entities.Count() == 1)
                    return true;

                return false;
            }
        }
        #endregion
    }
}
