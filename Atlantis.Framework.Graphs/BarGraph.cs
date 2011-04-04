using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;


namespace Atlantis.Framework.Graphs
{
  public class BarGraph : GraphBase
  {
    public bool DisplayAsHorizontalBars { get; set; }

    private readonly float _topMarginHeight;
    private float _graphCanvasZeroXPosition;
    private float _graphCanvasZeroYPosition;
    private float _graphCanvasHeight;
    private float _graphCanvasWidth;

    private Font _graphTitleFont = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
    private Font _graphFont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

// ReSharper disable UnusedMember.Local
    private BarGraph()
// ReSharper restore UnusedMember.Local
    {
    }

    public BarGraph(int height, int width)
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
      int datasetCounter = 0;
      foreach (var theData in base.Data)
      {
        int iLoopCounter = 0;
        foreach (var item in theData)
        {
          
          RectangleF myRect = GetBarRectangle(DisplayAsHorizontalBars, item, iLoopCounter, theData.Count, datasetCounter);

          Brush myBrush = null;
          using (myBrush)
          {
            myBrush = base.Options.Colors[datasetCounter].Count > 1
                        ? (Brush)
                          new LinearGradientBrush(myRect, base.Options.Colors[datasetCounter][0],
                                                  base.Options.Colors[datasetCounter][1],
                                                  base.Options.GradientMode)
                        : new SolidBrush(base.Options.Colors[iLoopCounter][0]);


            Context.FillRectangle(myBrush, myRect);
          }

          iLoopCounter += 1;
        }
        datasetCounter++;
      }
    }

    private RectangleF GetBarRectangle(bool isHorizontal, float dataItemValue,  int dataItemIndex, int  dataItemTotalCount,int dataSetIndex)
    {
      float xCoord, yCoord, width, height, columnSpacing, colOffset;
     
      float scaleValue = (base.Scale == 0.0f ? _graphCanvasHeight : base.Scale);
      float markingAlignment = (base.Grid.Markings != null ? (base.Grid.Markings.Count == 0 ? 1 : base.Grid.Markings.Count) : 1);

      if (isHorizontal)
      {
        colOffset = CalculateColOffset(_graphCanvasHeight, dataItemTotalCount);
        columnSpacing = CalculateColSpacing(colOffset,dataSetIndex);
        height = (_graphCanvasHeight / dataItemTotalCount) * .975f - colOffset;
        width = dataItemValue - (((_graphCanvasWidth / markingAlignment) - (scaleValue / markingAlignment)) + markingAlignment);
        xCoord = _graphCanvasZeroXPosition;
        yCoord = _topMarginHeight + ((height + colOffset) * dataItemIndex) + colOffset + columnSpacing;
      } else
      {
        colOffset = CalculateColOffset(_graphCanvasWidth, dataItemTotalCount);
        columnSpacing = CalculateColSpacing(colOffset, dataSetIndex);
        width = (_graphCanvasWidth / dataItemTotalCount) * .975f - colOffset;
        height = dataItemValue - (((_graphCanvasHeight / markingAlignment) - (scaleValue / markingAlignment)) + markingAlignment);
        yCoord = _graphCanvasZeroYPosition + (_graphCanvasHeight - height);
        xCoord = base.Grid.LabelMargin + ((width + colOffset)*dataItemIndex) + colOffset + columnSpacing;
      }

     //System.Diagnostics.Debug.WriteLine(string.Format("X:{0}, Y:{1}, H:{2}, W:{3}",xCoord, yCoord, height, width));

      return new RectangleF(xCoord, yCoord, width == 0 ? .0001f : width, height==0 ? .0001f : height);
    }

    private float CalculateColOffset(float bounds, int dataItemTotalCount)
    {
      return (bounds / dataItemTotalCount - ((bounds / dataItemTotalCount) * .975f)) * 2.5f;
    }

    private float  CalculateColSpacing(float offset, int currentColumn)
    {
      return offset * (currentColumn + 1);
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
                        MarkingsLineWidth = 1,
                        TicksLineWidth = 1,
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
          Marker currentMark = base.Grid.Markings[(iMarkerCount * increment) - 1];

          float barWidth;
          float barHeight;
          float nYCoordinate;
          float nXCoordinate;

          if (DisplayAsHorizontalBars)
          {
            barWidth = base.Grid.MarkingsLineWidth;
            barHeight = _graphCanvasWidth - _topMarginHeight;
            nYCoordinate = _graphCanvasZeroYPosition;
            nXCoordinate = ((base.Scale == 0.0f ? _graphCanvasWidth : base.Scale) / iTotalMarks * iMarkerCount) + (_graphCanvasZeroXPosition / 2.5f);

            Context.FillRectangle(new SolidBrush(base.Grid.MarkingsColor), nXCoordinate, nYCoordinate, barWidth, barHeight);
            Context.DrawString(currentMark.Label, _graphFont, new SolidBrush(base.Grid.MarkingsColor), nXCoordinate, nYCoordinate + _graphCanvasHeight);
          }
          else
          {
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
          Tick currentTick = base.Grid.Ticks[(iTickCount * increment) - 1];

          float barWidth;
          float barHeight;
          float nYCoordinate;
          float nXCoordinate;

          if (DisplayAsHorizontalBars)
          {
            barWidth = _graphCanvasWidth;
            barHeight = base.Grid.TicksLineWidth;
            nXCoordinate = _graphCanvasZeroXPosition;
            nYCoordinate = ((base.Scale == 0.0f ? _graphCanvasHeight : base.Scale) / iTotalTicks * iTickCount) + (_graphCanvasZeroYPosition / 2.5f);
            Context.FillRectangle(new SolidBrush(base.Grid.TickColor), nXCoordinate, nYCoordinate, barWidth, barHeight);
            Context.DrawString(currentTick.Label, _graphFont, new SolidBrush(base.Grid.TickColor), nXCoordinate / 2, nYCoordinate - (iTotalTicks * 1.5f));

          }
          else
          {
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