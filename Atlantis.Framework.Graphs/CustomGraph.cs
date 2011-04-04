using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;


namespace Atlantis.Framework.Graphs
{
  public class CustomGraph
  {
    private Bitmap bitMap;
    private Graphics context;

    private int GraphCanvasZeroXPosition;
    private int GraphCanvasZeroYPosition;
    private int GraphCanvasHeight;
    private int GraphCanvasWidth;

    private int LeftMarginWidth = 55;
    private int BottomMarginHeight = 40;
    private int TopMarginHeight = 10;

    #region Properties

    public float Scale { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public GraphType Type { get; set; }
    public Color BackgroundColor { get; set; }
    public Color ForegroundColor { get; set; }
    public Color MarkerColor { get; set; }
    public Color GraphBackgroundColor { get; set; }
    public string GraphTitle { get; set; }

    private List<GraphData> _datasets = new List<GraphData>();
    public List<GraphData> Datasets
    {
      get { return _datasets ?? (_datasets = new List<GraphData>()); }
      set { _datasets = value; }
    }

    private List<string> _markers = new List<string>();
    public List<string> Markers
    {
      get { return _markers ?? (_markers = new List<string>()); }
      set { _markers = value; }
    }

    private Font _titleFont;
    public Font TitleFont
    {
      get { return _titleFont ?? (_titleFont = new Font("Tahoma", 10, FontStyle.Bold)); }
      set { _titleFont = value; }
    }

    private Font _graphFont;
    public Font GraphFont
    {
      get { return _graphFont ?? (_graphFont = new Font("Tahoma", 8, FontStyle.Regular)); }
      set { _graphFont = value; }
    }

    #endregion //Properties


    public void Draw(Stream outputStream)
    {
      InitializeChartCanvas();
      switch (Type)
      {
        case GraphType.Line:
          GenerateLineGraph(outputStream);
          break;

        case GraphType.Pie:
          GeneratePieGraph(outputStream);
          break;

        case GraphType.Bar:
        default:
          GenerateBarGraph(outputStream);
          break;

      }
    }

    private void InitializeChartCanvas()
    {
      /*
                  width
       0----------------------
      0|    0________________|  TopMarginHeight
       |   0|                |
       |    | canvasWidth    |
       |    |                |
height |    |                |   CanvasHeight
       |    |                |
       |    |                |
       |LMW |                |
       |    |----------------|
       |                     |  BottomMarginHeight
       |---------------------|
        
       Inner set of 0,0 is the GraphCanvasZeroPositions.   
       This is the number we should be using as a starting point for drawing our graphs and markers. 
        
       LMW is the left margin width, this is for our Y axis text aka "Markers"
       
       */

      GraphCanvasZeroXPosition = LeftMarginWidth;
      GraphCanvasZeroYPosition = TopMarginHeight;
      GraphCanvasHeight = Height - BottomMarginHeight - TopMarginHeight;
      GraphCanvasWidth = Width - LeftMarginWidth;




      bitMap = new Bitmap(Width, Height);
      context = Graphics.FromImage(bitMap);
      context.PixelOffsetMode = PixelOffsetMode.HighQuality;
      context.CompositingQuality = CompositingQuality.HighQuality;
      context.InterpolationMode = InterpolationMode.NearestNeighbor;
      //context.SmoothingMode = SmoothingMode.AntiAlias;
      context.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
      context.Clear(BackgroundColor);
      context.FillRectangle(new SolidBrush(GraphBackgroundColor), LeftMarginWidth, TopMarginHeight, GraphCanvasWidth, GraphCanvasHeight);

      if (Markers != null && Markers.Count > 0)
      {

        for (int iMarkerCount = 1; iMarkerCount <= Markers.Count; iMarkerCount++)
        {
          float barWidth = GraphCanvasWidth;
          float barHeight = 2; //(Given amount/ Total amount) x100
          float nYCoordinate = GraphCanvasHeight - (Scale / Markers.Count * iMarkerCount) + GraphCanvasZeroYPosition ;
          float nXCoordinate = GraphCanvasZeroXPosition;

          context.FillRectangle(new SolidBrush(MarkerColor), nXCoordinate, nYCoordinate, barWidth, barHeight);
          context.DrawString(Markers[iMarkerCount-1], _graphFont,
                             ForegroundColor == Color.White ? Brushes.Black : Brushes.White, 5, nYCoordinate - 5);


        }
      }
    }

    private void GenerateLineGraph(Stream outputStream)
    {
      throw new NotImplementedException();
    }

    private void GeneratePieGraph(Stream outputStream)
    {
      throw new NotImplementedException();
    }

    private void GenerateBarGraph(Stream outputStream)
    {
      /*
                  width
       0----------------------
      0|    0________________|  TopMarginHeight
       |   0|                |
       |    | canvasWidth    |
       |    |                |
height |    |                |   CanvasHeight
       |    |                |
       |    |                |
       |LMW |                |
       |    |----------------|
       |                     |  BottomMarginHeight
       |---------------------|
        
       Inner set of 0,0 is the GraphCanvasZeroPositions.   
       This is the number we should be using as a starting point for drawing our graphs and markers. 
        
       LMW is the left margin width, this is for our Y axis text aka "Markers"
       
       */


      int datasetCounter = 0;
      float colOffset = 0.0f;
      foreach (var theData in Datasets)
      {
        int iLoopCounter = 0;
        int dataItemCount = theData.Dataset.Count;
        foreach (var item in theData.Dataset)
        {
          int columnSpace = 7;
          int priorDataset = 0;
          if (datasetCounter > 0)
          {
            if (priorDataset == datasetCounter)
            {
              colOffset += 1.75f;
            }
            columnSpace = 10;
          }
       
          float barWidth = GraphCanvasWidth / dataItemCount;
          float barHeight = item.Value - (((GraphCanvasHeight / Markers.Count) - (Scale / Markers.Count)) + Markers.Count);
          float nYCoordinate = GraphCanvasZeroYPosition + (GraphCanvasHeight - barHeight);
          float nXCoordinate = (iLoopCounter * barWidth) + colOffset + LeftMarginWidth + (datasetCounter > 0 ? columnSpace / 2 : 0);

          Brush myBrush;
          RectangleF myRect = new RectangleF(nXCoordinate, nYCoordinate, barWidth - columnSpace, barHeight);

          if (theData.SecondaryChartColor != Color.Empty)
          {
            myBrush = new LinearGradientBrush(myRect, theData.PrimaryChartColor, theData.SecondaryChartColor,
                                              LinearGradientMode.Vertical);
          } else {
            myBrush = new SolidBrush(theData.PrimaryChartColor);
          }

          context.FillRectangle(myBrush, myRect);
          if (datasetCounter == 0)
          {
            context.DrawString(item.Measurement1Title, _graphFont, ForegroundColor == Color.White ? Brushes.Black : Brushes.White, nXCoordinate, (GraphCanvasHeight - 30) + BottomMarginHeight);
          }
          iLoopCounter += 1;
        }
        datasetCounter += 1;
      }

     OutputImage(outputStream, bitMap);

    }

    private void OutputImage(Stream outputStream, Bitmap image)
    {
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