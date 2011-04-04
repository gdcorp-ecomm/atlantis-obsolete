using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Atlantis.Framework.Graphs
{
  public class LineGraph : GraphBase
  {
    private readonly float _topMarginHeight;
    private float _graphCanvasZeroXPosition;
    private float _graphCanvasZeroYPosition;
    private float _graphCanvasHeight;
    private float _graphCanvasWidth;

    private Font _graphTitleFont = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
    private Font _graphFont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

// ReSharper disable UnusedMember.Local
    private LineGraph()
// ReSharper restore UnusedMember.Local
    {
    }

    public LineGraph(int height, int width)
    {
      Height = height;
      Width = width;
      _topMarginHeight = 10;
    }

    #region Overrides of GraphBase

    protected override void InitializeCanvas()
    {
      /*
                 width
        0----------------------
       0|    0________________|  TopMarginHeight
        |   0|                |
        |    | canvasWidth    |
        |    |                |
height  |    |                |   CanvasHeight
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

      SetupGrid();



    }

    public override void Plot(Stream outputStream, List<List<float>> data, Options options)
    {
      base.Options = options;
      base.Data = data;
      base.OutputStream = outputStream;

      InitializeCanvas();
      Draw();

    }

    protected override void SetData()
    {
      int iDatasetCount = 0;
      foreach (var dataset in Data)
      {
        var linePen = new Pen((base.Options.Colors.Count > 0 && base.Options.Colors[iDatasetCount].Count > 0 ? base.Options.Colors[iDatasetCount][0] : Color.Red), 2);

        var pointSeperation = _graphCanvasWidth / dataset.Count;
        var nXOffset = pointSeperation / 2f;

        for (int iPointCounter = 0; iPointCounter < dataset.Count; iPointCounter++)
        {
          if (iPointCounter < dataset.Count - 1)
          {
            Context.DrawLine(linePen, iPointCounter * pointSeperation + nXOffset + base.Grid.LabelMargin, _graphCanvasHeight - dataset[iPointCounter] + _topMarginHeight, (iPointCounter + 1) * pointSeperation + nXOffset + base.Grid.LabelMargin, _graphCanvasHeight - dataset[iPointCounter + 1] + _topMarginHeight);
          }
        }
        iDatasetCount++;
      }
    }

    protected override void SetupGrid()
    {
      if (base.Grid == null)
      {
        base.Grid = new Grid
                      {
                        BackgroundColor = Color.White,
                        BorderColor = Color.Black,
                        BorderWidth = 1,
                        DisplayGrid = true,
                        DisplayGridOnTop = false,
                        ForegroundColor = Color.White,
                        LabelMargin = 5,
                        MarkingsColor = Color.LightGray,
                        MarkingsLineWidth = 2,
                        TickColor = Color.LightGray
                      };
      }

      Context.Clear(base.BackgroundColor);

      _graphCanvasZeroXPosition = base.Grid.LabelMargin;
      _graphCanvasZeroYPosition = _topMarginHeight;
      _graphCanvasHeight = Height - base.Grid.LabelMargin - _topMarginHeight;
      _graphCanvasWidth = Width - base.Grid.LabelMargin;

      Context.FillRectangle(new SolidBrush(base.Grid.BackgroundColor), base.Grid.LabelMargin, _topMarginHeight, _graphCanvasWidth, _graphCanvasHeight);

    }

    private void SetupMarkers()
    {
      if (base.Grid.Markings != null && base.Grid.Markings.Count > 0)
      {
        var increment = base.Grid.MarkerIncrement == 0 ? 5 : base.Grid.MarkerIncrement;
        //calculate number of ticks to render
        var iTotalMarks = base.Grid.Markings.Count / increment;

        for (int iMarkerCount = 1; iMarkerCount <= iTotalMarks; iMarkerCount++)
        {
          Marker currentMark = base.Grid.Markings[(iMarkerCount*increment) - 1];

          float barWidth;
          float barHeight;
          float nYCoordinate;
          float nXCoordinate;


          barWidth = _graphCanvasWidth;
          barHeight = base.Grid.MarkingsLineWidth;
          nYCoordinate = _graphCanvasHeight - ((base.Scale == 0.0f ? _graphCanvasHeight : base.Scale) / iTotalMarks * iMarkerCount) + _graphCanvasZeroYPosition;
          nXCoordinate = _graphCanvasZeroXPosition;
          Context.FillRectangle(new SolidBrush(base.Grid.MarkingsColor), nXCoordinate, nYCoordinate, barWidth, barHeight);
          Context.DrawString(currentMark.Label, _graphFont,
                             base.Grid.ForegroundColor == Color.White ? Brushes.Black : Brushes.White, 5, (currentMark.YPosition > 0 ? currentMark.YPosition : nYCoordinate - 5));




        }
      }
    }

    private void SetupTicks()
    {
      if (base.Grid.Ticks != null && base.Grid.Ticks.Count > 0)
      {
        var increment = base.Grid.TickIncrement == 0 ? 5 : base.Grid.TickIncrement;
        //calculate number of ticks to render
        var iTotalTicks = base.Grid.Ticks.Count / increment;

        for (int iTickCount = iTotalTicks; iTickCount >= 1; iTickCount--)
        {
          Tick currentTick = base.Grid.Ticks[(iTickCount*increment) - 1];

          float barWidth;
          float barHeight;
          float nYCoordinate;
          float nXCoordinate;


          barWidth = base.Grid.TicksLineWidth;
          barHeight = _graphCanvasWidth;
          nYCoordinate = _graphCanvasZeroYPosition + _graphCanvasHeight;
          nXCoordinate = ((base.Scale == 0.0f ? _graphCanvasWidth : base.Scale) / iTotalTicks * iTickCount) + (_graphCanvasZeroXPosition / 2.5f);
          Context.FillRectangle(new SolidBrush(base.Grid.TickColor), nXCoordinate + (iTotalTicks * 2.5f), nYCoordinate - _graphCanvasHeight, barWidth, barHeight - _graphCanvasZeroYPosition);
          Context.DrawString(currentTick.Label, _graphFont,
                             base.Grid.ForegroundColor == Color.White ? Brushes.Black : Brushes.White, nXCoordinate, nYCoordinate);



        }
      }
    }

    protected override void Draw()
    {
      if (base.Grid.DisplayGrid && !base.Grid.DisplayGridOnTop)
      {
        SetupMarkers();
        SetupTicks();
      }

      SetData();

      if (base.Grid.DisplayGrid && base.Grid.DisplayGridOnTop)
      {
        SetupMarkers();
        SetupTicks();
      }
      if (!string.IsNullOrEmpty(base.Title))
      {
        SetupTitle(_graphCanvasWidth / 2, Height - (_topMarginHeight * 2), _graphTitleFont);
      }

      OutputImage(base.OutputStream, base.GraphBitmap);
    }

    #endregion
  }
}