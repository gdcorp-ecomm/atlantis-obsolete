using Atlantis.Framework.Providers.RenderPipeline.Interface;

namespace Atlantis.Framework.Providers.CDS
{
  internal class CDSWidgetRenderContent : IRenderContent
  {
    public string Content { get; private set; }

    internal CDSWidgetRenderContent(string content)
    {
      Content = content;
    }
  }
}
