using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Atlantis.Framework.Graphs
{
  public class PieGraph : GraphBase
  {
    readonly Color[] _arColors = new[]
                                  {
                                    Color.Red, 
                                    Color.Blue, 
                                    Color.Yellow, 
                                    Color.Purple, 
                                    Color.Orange, 
                                    Color.Green, 
                                    Color.DarkBlue, 
                                    Color.DarkRed, 
                                    Color.Aqua, 
                                    Color.Crimson, 
                                    Color.Cyan, 
                                    Color.Magenta, 
                                    Color.DarkOrchid, 
                                    Color.DarkOrange
                                  };

    private readonly float _topMarginHeight;
    private float _graphCanvasHeight;
    private float _graphCanvasWidth;

    private readonly Font _graphTitleFont = new Font("Tahoma", 10, FontStyle.Bold, GraphicsUnit.Point);
    private readonly Font _graphFont = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);

// ReSharper disable UnusedMember.Local
    private PieGraph()
// ReSharper restore UnusedMember.Local
    {
    }

    public PieGraph(int height, int width)
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

      float totalValue = (base.Data[0] != null ? base.Data[0].AsQueryable().Sum() : 0);
      if (totalValue == 0) return;

      // Calculate the midpoint of the display panel.
      float cx = _graphCanvasWidth / 2;
      float cy = _graphCanvasHeight / 2;

      // Now we need width and height
      //   to be the same so that we'll
      //   draw a circle and not an ellipse.
      if (_graphCanvasWidth > _graphCanvasHeight)
      {
        _graphCanvasWidth = _graphCanvasHeight;
      }
      else
      {
        _graphCanvasHeight = _graphCanvasWidth;
      }

      // Calculate the x and y coordinate of
      //   the upper left corner of the pie (or ellipse)
      //   bounding rectangle.
      float x = cx - (_graphCanvasWidth / 2);
      float y = cy - (_graphCanvasHeight / 2);

      // Get the count into a local variable
      //   so that it's a little easier and the
      //   code is more readable.
      int iCount = base.Data[0].Count;

      // The start angle will be increment through
      //   the draw process so that the next pie
      //   slice (or arc) will continue drawing where
      //   the last one left off.
      float nStartAngle = 0f;

      // We'll cycle through colors, so we need a variable.
      var iColorIndex = 0;

      // Loop through the data.
      for (var i = 0; i < iCount; i++)
      {
        float percentage = (base.Data[0][i] / totalValue) * 360;
        // Draw the slice (or arc).  We draw it 3 times at various intervals to achieve the gradient effect
        Context.FillPie(new SolidBrush((GetColor(iColorIndex, true, .5f))), x + base.Grid.LabelMargin + _topMarginHeight - (_topMarginHeight * .60f), y + _topMarginHeight + (_topMarginHeight * .25f), _graphCanvasWidth, _graphCanvasHeight - (_topMarginHeight * .5f), nStartAngle, percentage);
        Context.FillPie(new SolidBrush(GetColor(iColorIndex, true, .75f)), x + base.Grid.LabelMargin + _topMarginHeight, y + (_topMarginHeight * 1.5f), _graphCanvasWidth - _topMarginHeight, _graphCanvasHeight - _topMarginHeight, nStartAngle, percentage);
        Context.FillPie(new SolidBrush(GetColor(iColorIndex, false, 1f)), x + base.Grid.LabelMargin + (_topMarginHeight * 1.5f), y + (_topMarginHeight * 2), _graphCanvasWidth - (_topMarginHeight * 2), _graphCanvasHeight - (_topMarginHeight * 2), nStartAngle, percentage);
        // Update the start angle.
        nStartAngle += percentage;

        // Cycle to the next color and wrap around
        //   if we've gotten past the end.
        iColorIndex++;

      }
    }

    private Color GetColor(int colorIndex, bool useGradientValue, float adjustmentValue)
    {
      Color myColor;
      if (base.Options.Colors.Count > 0 && base.Options.Colors[0].Count > 0)
      {
        if (colorIndex >= base.Options.Colors[0].Count)
        {
          colorIndex = 0;
        }
        if (useGradientValue)
        {
          Color tweakColor = base.Options.Colors[0][colorIndex];
          float adjustment = (adjustmentValue == 0.0f ? .5f : adjustmentValue);
          myColor = Color.FromArgb(tweakColor.A, (int)(tweakColor.R * adjustment), (int)(tweakColor.G * adjustment), (int)(tweakColor.B * adjustment));
        }
        else
        {
          myColor = base.Options.Colors[0][colorIndex];
        }
      }
      else
      {
        if (colorIndex >= _arColors.Length)
        {
          colorIndex = 0;
        }
        if (useGradientValue)
        {
          Color tweakColor = _arColors[colorIndex];

          float adjustment = (adjustmentValue == 0.0f ? .5f : adjustmentValue);
          myColor = Color.FromArgb(tweakColor.A, (int)(tweakColor.R * adjustment), (int)(tweakColor.G * adjustment), (int)(tweakColor.B * adjustment));
        }
        else
        {
          myColor = _arColors[colorIndex];
        }
      }
      return myColor;
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

      _graphCanvasHeight = Height - base.Grid.LabelMargin - _topMarginHeight;
      _graphCanvasWidth = Width - base.Grid.LabelMargin;

      Context.FillRectangle(new SolidBrush(base.Grid.BackgroundColor), base.Grid.LabelMargin, _topMarginHeight, _graphCanvasWidth, _graphCanvasHeight);

    }

    protected override void Draw()
    {
      SetData();
      SetLegend();
      if (!string.IsNullOrEmpty(base.Title))
      {
        SetupTitle(_graphCanvasWidth / 2, Height - (_topMarginHeight * 2), _graphTitleFont);
      }

      OutputImage(base.OutputStream, base.GraphBitmap);
    }

    #endregion

    private void SetLegend()
    {
      if (base.Options.Legend.DisplayLegend)
      {
        Pen myBorderPen = new Pen(base.Options.Legend.BorderColor, 1);
        SolidBrush myBrush = new SolidBrush(base.Options.Legend.BorderColor);

        switch (base.Options.Legend.Position)
        {
          case LegendPosition.Left:
            using (myBorderPen)
            {
              using (myBrush)
              {
                SizeF textSize = Context.MeasureString(base.Options.Legend.Key[0], _graphFont);
                Context.DrawRectangle(myBorderPen, 1, _topMarginHeight - 1, textSize.Width + 27,
                 (base.Options.Legend.Key.Count * (textSize.Height)) + 2
                 );
                Context.FillRectangle(
                  new SolidBrush(base.Options.Legend.BackgroundColor),
                  2,
                  _topMarginHeight,
                   textSize.Width + 24,
                 (base.Options.Legend.Key.Count * (textSize.Height))
                  );


                int iCount = 1;
                foreach (var item in base.Options.Legend.Key)
                {
                  Context.DrawRectangle(myBorderPen, 4, iCount * 10 + 2, 10, 5);
                  Context.FillRectangle(new SolidBrush(GetColor(iCount, false, 1f)), 4, iCount * 10 + 2, 10, 5);
                  Context.DrawString(item, _graphFont, myBrush, 15, iCount * 10);
                  iCount++;
                }

              }
            }

            break;

          case LegendPosition.Bottom:
          default:
            using (myBorderPen)
            {
              using (myBrush)
              {
                SizeF textSize = Context.MeasureString(base.Options.Legend.Key[0], _graphFont);

                Context.DrawRectangle(myBorderPen, base.Grid.LabelMargin, _topMarginHeight + _graphCanvasHeight + 3, _graphCanvasWidth + 10, (base.Options.Legend.Key.Count % base.Options.Legend.ColumnCount * (textSize.Height)) + 4);
                Context.FillRectangle(new SolidBrush(base.Options.Legend.BackgroundColor), base.Grid.LabelMargin, _topMarginHeight + _graphCanvasHeight + 3, _graphCanvasWidth + 10, (base.Options.Legend.Key.Count % base.Options.Legend.ColumnCount * (textSize.Height)) + 4);

                int iRowCount = 0;
                int iColCount = 1;
                foreach (var item in base.Options.Legend.Key)
                {
                  var modVal = iColCount % base.Options.Legend.ColumnCount;
                  float xPos, yPos;


                  if (modVal > 0)
                  {
                    xPos = (textSize.Width + 25) * (modVal) + 12;
                    yPos = (textSize.Height + 5) * (iRowCount) + _topMarginHeight + _graphCanvasHeight + 4;

                  }
                  else
                  {
                    iRowCount++;
                    xPos = 12;
                    yPos = (textSize.Height + 5) * (iRowCount) + _topMarginHeight + _graphCanvasHeight + 4;

                  }

                  Context.DrawRectangle(myBorderPen, base.Grid.LabelMargin + xPos, yPos, 10, 5);
                  Context.FillRectangle(new SolidBrush(GetColor(iColCount, false, 1f)), base.Grid.LabelMargin + xPos, yPos, 10, 5);
                  Context.DrawString(item, _graphFont, myBrush, base.Grid.LabelMargin + xPos + 10, yPos);
                  iColCount++;
                }

              }
            }
            break;
        }
      }
    }
  }
}