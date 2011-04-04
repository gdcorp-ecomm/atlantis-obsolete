using System.Collections.Generic;
using System.Drawing;

namespace Atlantis.Framework.Graphs
{
  public class Grid
  {
    public bool DisplayGrid { get; set; }
    public bool DisplayGridOnTop { get; set; }
    public Color ForegroundColor { get; set; }
    public Color BackgroundColor { get; set; }
    public int TickIncrement { get; set; }
    private List<Tick> _ticks;
    public List<Tick> Ticks
    {
      get { return _ticks ?? (_ticks = new List<Tick>()); }
      set { _ticks = value; }
    }
    public Color TickColor { get; set; }
    public float TicksLineWidth { get; set; }
    public int LabelMargin { get; set; }
    public int BorderWidth { get; set; }
    public Color BorderColor { get; set; }
    public int MarkerIncrement { get; set; }
    private List<Marker> _markings;
    public List<Marker> Markings
    {
      get { return _markings ?? (_markings = new List<Marker>()); }
      set { _markings = value; }
    }
    public Color MarkingsColor { get; set; }
    public int MarkingsLineWidth { get; set; }
  }

}