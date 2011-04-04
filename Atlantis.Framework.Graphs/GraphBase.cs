using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;

namespace Atlantis.Framework.Graphs
{
  public abstract class GraphBase
  {
// ReSharper disable EmptyConstructor
    protected GraphBase()
// ReSharper restore EmptyConstructor
    {

    }

    public string Title { get; set; }
    public Color TitleColor { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Color BackgroundColor { get; set; }

    private List<List<float>> _data;
    public List<List<float>> Data
    {
      get { return _data ?? (_data = new List<List<float>>()); }
      set { _data = value; }
    }

    private Options _options;
    public Options Options
    {
      get { return _options ?? (_options = new Options()); }
      set { _options = value; }
    }

    private Grid _grid;
    public Grid Grid
    {
      get { return _grid ?? (_grid = new Grid()); }
      set { _grid = value; }
    }

    private Bitmap _graphBitmap;
    public Bitmap GraphBitmap
    {
      get { return _graphBitmap ?? (_graphBitmap = new Bitmap(Width, Height)); }
      set { _graphBitmap = value; }
    }

    private Graphics _context;
    public Graphics Context
    {
      get { return _context ?? (_context = Graphics.FromImage(GraphBitmap)); }
      set { _context = value; }
    }

    protected float Scale { get; set; }

    protected Stream OutputStream { get; set; }


    protected abstract void InitializeCanvas();
    public abstract void Plot(Stream outputStream, List<List<float>> data, Options options);
    protected abstract void SetData();
    protected abstract void SetupGrid();
    protected abstract void Draw();

    protected void SetupTitle(float xPosition, float yPosition, Font font)
    {
      Context.DrawString(Title, font, new SolidBrush(TitleColor), xPosition, yPosition);
    }

    protected void OutputImage(Stream outputStream, Bitmap image)
    {
      Context.PixelOffsetMode = PixelOffsetMode.HighQuality;
      Context.CompositingQuality = CompositingQuality.HighQuality;
      Context.InterpolationMode = InterpolationMode.NearestNeighbor;
      Context.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

      OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);

      using (Bitmap quantized = quantizer.Quantize(image))
      {
        if (HttpContext.Current != null)
        {
          HttpContext.Current.Response.ContentType = "image/gif";
        }

        //spit out an image
        quantized.Save(outputStream, ImageFormat.Gif);
      }
    }
  }
}