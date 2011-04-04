using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Atlantis.Framework.Graphs
{
  public class Options
  {
    private List<List<Color>> _colors;
    public List<List<Color>> Colors
    {
      get { return _colors ?? (_colors = new List<List<Color>>()); }
      set { _colors = value; }
    }
    public LinearGradientMode GradientMode { get; set; }
    private Legend _legend;
    public Legend Legend
    {
      get { return _legend ?? (_legend = new Legend()); }
      set { _legend = value; }
    }
  }
}