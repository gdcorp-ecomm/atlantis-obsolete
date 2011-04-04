using System.Collections.Generic;
using System.Drawing;


namespace Atlantis.Framework.Graphs
{
  public class GraphData
  {
    List<GraphDataItem> _dataset = new List<GraphDataItem>();
    public List<GraphDataItem> Dataset {
      get { return _dataset ?? (_dataset = new List<GraphDataItem>()); }
      set { _dataset = value; }
    }
    
    /// <summary>
    /// Line, bar, pie section color
    /// </summary>
    public Color PrimaryChartColor { get; set; }

    /// <summary>
    /// Use to include gradients in graph
    /// </summary>
    public Color SecondaryChartColor { get; set; } 
  }
}