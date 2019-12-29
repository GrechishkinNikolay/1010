using Model;
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
  public class ViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private volatile bool _isGame;
    private Thread _drawingThread;
    /// <summary>
    /// Прямоугольники 
    /// </summary>
    public RectangleF[][] FieldRectangles
    {
      get;
      set;
    }
    public ModelGamePlay ModelGamePlay { get; set; }
    public Form GameForm
    {
      get;
      set;
    }


    public ViewWindows(ModelGamePlay parModelGamePlay)
    {
      ModelGamePlay = parModelGamePlay;
      GameForm = new Form();
      GameForm.Height = 430;
      GameForm.Width = 345;
      GameForm.FormBorderStyle = FormBorderStyle.FixedSingle;

      Graphics targetgraphics = GameForm.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(
        targetgraphics,
        new Rectangle(0, 0, GameForm.Width, GameForm.Height));
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
          FieldRectangles[i][j].Height =  30;
          FieldRectangles[i][j].X = 32 * i + 5;
          FieldRectangles[i][j].Y = 32 * j + 60;
        }
      }
      //ModelGamePlay.IsGame = true;
      ModelGamePlay.SpawnNewFigure();
      _drawingThread = new Thread(RedrawCycle);
      _drawingThread.IsBackground = true;
      _drawingThread.Start();
    }

    public void RunForm()
    {
      Application.Run(GameForm);
    }

    public void ShowField()
    {
      for (int i = 0; i < FieldRectangles.Length; i++)
      {
        for (int j = 0; j < FieldRectangles[i].Length; j++)
        {
          _bufferedGraphics.Graphics.FillRectangle(Brushes.DimGray, FieldRectangles[i][j]);
        }
      }
    }

    public void ShowActiveFigure()
    {
      for (int i = 0; i < ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].WidthFigure; j++)
        {
          if (ModelGamePlay.GameField.PlayingField[i + ModelGamePlay.PointerCoordinates.Y][j + ModelGamePlay.PointerCoordinates.X].IsFilledWithFigures)
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
        ShowField();
        ShowActiveFigure();
        _bufferedGraphics.Render();
      }
    }
  }
}
