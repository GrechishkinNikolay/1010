using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWindowsForms
{
  public class ViewGamePlayWindows : IViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _drawingThread;
    /// <summary>
    /// Прямоугольники 
    /// </summary>
    public RectangleF[][] FieldRectangles
    {
      get;
      set;
    }
    private Font ScoreFont { get; set; }
    public FontFamily ScoreFontFamily { get; set; }
    public ModelGamePlay ModelGamePlay { get; set; }
    public Form Form
    {
      get;
      set;
    }


    public ViewGamePlayWindows(ModelGamePlay parModelGamePlay)
    {
      ModelGamePlay = parModelGamePlay;
      Form = Application.OpenForms[0];
      Form.Height = 430;
      Form.Width = 345;

      Graphics targetgraphics = Form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, Form.Width, Form.Height));
      FieldRectangles = new RectangleF[ModelGamePlay.COUNT_ROW][];
      for (int i = 0; i < ModelGamePlay.COUNT_ROW; i++)
      {
        FieldRectangles[i] = new RectangleF[ModelGamePlay.COUNT_COLUMN];
      }
      for (int i = 0; i < FieldRectangles.Length; i++)
      {
        for (int j = 0; j < FieldRectangles[i].Length; j++)
        {
          FieldRectangles[i][j].Width = 30;
          FieldRectangles[i][j].Height = 30;
          FieldRectangles[i][j].X = 32 * j + 5;
          FieldRectangles[i][j].Y = 32 * i + 60;
        }
      }
      ScoreFontFamily = new FontFamily("Impact");
      ScoreFont = new Font(ScoreFontFamily, 30);
      ModelGamePlay.SpawnNewFigure();
      _drawingThread = new Thread(RedrawCycle);
      _drawingThread.IsBackground = true;
      _drawingThread.Start();
    }

    public void RunForm()
    {
      Application.Run(Form);
    }

    public void DrawField()
    {
      for (int i = 0; i < FieldRectangles.Length; i++)
      {
        for (int j = 0; j < FieldRectangles[i].Length; j++)
        {
          if (ModelGamePlay.GameField.PlayingField[i][j].IsFull)
          {
            _bufferedGraphics.Graphics.FillRectangle(Brushes.Brown, FieldRectangles[i][j]);
          }
          else
          {
            _bufferedGraphics.Graphics.FillRectangle(Brushes.DimGray, FieldRectangles[i][j]);
          }
        }
      }
    }

    public void DrawScore()
    {
      _bufferedGraphics.Graphics.DrawString("Score: " + ModelGamePlay.Score, ScoreFont, Brushes.Chocolate, 10, 10);
    }

    public void DrawActiveFigure()
    {
      for (int i = 0; i < ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].WidthFigure; j++)
        {
          if (ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].FigureShape[i][j].IsFull)
          {
            _bufferedGraphics.Graphics.FillRectangle(Brushes.Chocolate, FieldRectangles[i + ModelGamePlay.PointerCoordinates.Y][j + ModelGamePlay.PointerCoordinates.X]);
          }
        }
      }
    }

    public void RedrawCycle()
    {
      while (ModelGamePlay.IsGame)
      {
        _bufferedGraphics.Graphics.Clear(Color.Black);
        DrawField();
        DrawActiveFigure();
        DrawScore();
        _bufferedGraphics.Render();
      }
    }
  }
}
