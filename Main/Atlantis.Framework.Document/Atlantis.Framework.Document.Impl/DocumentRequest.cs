using System;
using System.Collections.Generic;
using System.Text;
using Atlantis.Framework.Interface;
using Atlantis.Framework.Document.Interface;
using Atlantis.Framework.Document.Impl.DocumentWS;

namespace Atlantis.Framework.Document.Impl
{
  public class DocumentRequest : IRequest
  {
    #region IRequest Members

    public IResponseData RequestHandler(RequestData oRequestData, ConfigElement oConfig)
    {
      IResponseData oResponseData = null;
      string html = null;

      try
      {
        DocumentRequestData request = (DocumentRequestData)oRequestData;
        using (DocumentService documentService = new DocumentService())
        {
          documentService.Url = ((WsConfigElement)oConfig).WSURL;
          html = documentService.document(request.ToXML());
        }

        oResponseData = new DocumentResponseData(html);
      }
      catch (AtlantisException exAtlantis)
      {
        oResponseData = new DocumentResponseData(html, exAtlantis);
      }
      catch (Exception ex)
      {
        oResponseData = new DocumentResponseData(html, oRequestData, ex);
      }

      return oResponseData;

    }

    #endregion

  }
}
