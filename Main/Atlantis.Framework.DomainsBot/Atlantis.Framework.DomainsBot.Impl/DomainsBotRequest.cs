using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;

using Atlantis.Framework.Interface;
using Atlantis.Framework.DomainsBot.Impl.domainsBot;
using Atlantis.Framework.DomainsBot.Interface;

namespace Atlantis.Framework.DomainsBot.Impl
{
	public class DomainsBotRequest : DomainsBotRequestBase, IRequest
	{
		/******************************************************************************/

		#region IRequest Members

		/******************************************************************************/

		public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
		{
			IResponseData oResponseData = null;

			try
			{
				DomainsBotRequestData oDomainsBotRequestData = (DomainsBotRequestData)oRequestData;

				List<Tld> oTldList = GetTldList(oDomainsBotRequestData.TLDs);
				domainsBot.SearchResult oResponse;

				using (FirstImpact oRequest = new FirstImpact())
				{
					oRequest.Url = ((WsConfigElement)oConfig).WSURL;
          oRequest.Timeout = (int)oDomainsBotRequestData.RequestTimeout.TotalMilliseconds;

					oResponse = oRequest.GetDomainsEx(oDomainsBotRequestData.SearchKey,
																			  oDomainsBotRequestData.MaxResults,
																			  oDomainsBotRequestData.ExcludeTaken,
																			  oTldList.ToArray(),
																			  oDomainsBotRequestData.AddPrefixes,
																			  oDomainsBotRequestData.AddSuffixes,
																			  oDomainsBotRequestData.AddDashes,
																			  oDomainsBotRequestData.AddRelated,
																			  oDomainsBotRequestData.AdvancedSplit,
																			  oDomainsBotRequestData.BaseOnTop,
																			  oDomainsBotRequestData.SessionId);
				}

				oResponseData = new DomainsBotResponseData(oResponse.AvailableResults);
				foreach (Domain DomainSuggestion in oResponse.Domains)
				{
					((DomainsBotResponseData)oResponseData).AddDomain(DomainSuggestion.Name);
				}

			}
			catch (AtlantisException exAtlantis)
			{
				oResponseData = new DomainsBotResponseData(exAtlantis);
			}
			catch (Exception ex)
			{
				oResponseData = new DomainsBotResponseData(oRequestData, ex);
			}

			return oResponseData;
		}

		/******************************************************************************/

		#endregion

		/******************************************************************************/
	}
}