using Atlantis.Framework.Interface;
using Atlantis.Framework.Providers.PlaceHolder.Interface;
using Atlantis.Framework.Render.Pipeline.Interface;

namespace Atlantis.Framework.Providers.CDS
{
  internal class CDSWidgetPlaceHolderRenderHandler : IRenderHandler
  {
    public void ProcessContent(IProcessedRenderContent processRenderContent, IProviderContainer providerContainer)
    {
      IPlaceHolderProvider placeHolderProvider = providerContainer.Resolve<IPlaceHolderProvider>();

      IPlaceHolderEncoding placeHolderEncoding = new CDSWidgetPlaceHolderEncoding();

      string modifiedContent = placeHolderProvider.ReplacePlaceHolders(processRenderContent.Content, placeHolderEncoding);

      processRenderContent.OverWriteContent(modifiedContent);
    }
  }
}
