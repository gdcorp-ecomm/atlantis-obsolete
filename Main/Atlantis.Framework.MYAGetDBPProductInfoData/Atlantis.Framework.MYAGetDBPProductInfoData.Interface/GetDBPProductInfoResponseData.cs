using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Atlantis.Framework.Interface;

namespace Atlantis.Framework.MYAGetDBPProductInfoData.Interface
{
	public class GetDBPProductInfoResponseData : IResponseData
	{
		private AtlantisException _exception = null;
		private bool _success = false;
		private List<DBPProductInfo> _dbpProducts;

		public bool IsSuccess
		{
			get { return _success; }
		}

		public List<DBPProductInfo> dbpProducts
		{
			get { return _dbpProducts; }
		}

		public GetDBPProductInfoResponseData(List<DBPProductInfo> dbpProducts)
		{
			_dbpProducts = dbpProducts;
			_success = true;
		}

		public GetDBPProductInfoResponseData(AtlantisException atlantisException)
		{
			_exception = atlantisException;
		}

		public GetDBPProductInfoResponseData(RequestData requestData, Exception exception)
		{
			_exception = new AtlantisException(requestData,
			                                   "GetDBPProductInfoResponseData",
			                                   exception.Message,
			                                   requestData.ToXML());
		}
		
		#region IResponseData Members

		public string ToXML()
		{
			StringBuilder sb = new StringBuilder();

			try
			{
				using (XmlWriter writer = XmlWriter.Create(sb))
				{
					writer.WriteStartElement("domains");

					foreach (DBPProductInfo p in dbpProducts)
					{
						writer.WriteStartElement("domain");
						writer.WriteAttributeString("domainName", p.CommonName.ToString());
						writer.WriteAttributeString("domainId", p.DomainId.ToString());
						writer.WriteAttributeString("isPrivate", p.IsPrivate.ToString());
						writer.WriteAttributeString("isProtected", p.IsProtected.ToString());
						writer.WriteAttributeString("isBusiness", p.IsBusiness.ToString());
						writer.WriteAttributeString("isSmartDomain", p.IsSmartDomain.ToString());
						writer.WriteAttributeString("resourceId", p.ResourceId.ToString());
						
						writer.WriteEndElement();
					}
					writer.WriteEndElement();
				}
			}
			catch (Exception ex)
			{
				throw new AtlantisException("GetDBPProductInfoResponseData::ToXml", string.Empty, string.Empty, "Error Converting Response Object To XML", ex.Message, string.Empty, string.Empty, string.Empty, string.Empty, 0);
			}

			return sb.ToString();
		}

		public AtlantisException GetException()
		{
			return _exception;
		}

		#endregion
	}
}