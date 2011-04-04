using System.Collections.Generic;
using System.Drawing;

namespace Atlantis.Framework.Graphs
{
  public class Legend
  {
    public bool DisplayLegend { get; set; }
    public int ColumnCount { get; set; }
    public Color BorderColor { get; set; }
    public LegendPosition Position { get; set; }
    public int Margin { get; set; }
    public Color BackgroundColor { get; set; }
    public float BackgroundOpacity { get; set; }
    private List<string> _keys;
    public List<string> Key
    {
      get { return _keys ?? (_keys = new List<string>()); }
      set { _keys = value; }
    }
  }
}