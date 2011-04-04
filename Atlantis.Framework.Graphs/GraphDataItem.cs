
namespace Atlantis.Framework.Graphs
{
  public class GraphDataItem
  {
    /// <summary>
    /// For line or bar graphs, this value is the X-Axis
    /// </summary>
    public string Measurement1Title { get; set; }

    /// <summary>
    /// For line or bar graphs, this value is the Y-Axis
    /// </summary>
    public string Measurement2Title { get; set; }

    public float Value { get; set; }
  }
}