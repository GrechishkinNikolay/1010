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
  /// <summary>
  /// Представление окна геймплея
  /// </summary>
  public class ViewGamePlayWindows : IViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    /// <summary>
    /// Поток перерисовки
    /// </summary>
    private Thread _drawingThread;
    /// <summary>
    /// Прямоугольники игрового поля
    /// </summary>
    public RectangleF[][] FieldRectangles { get; set; }
    /// <summary>
    /// Шрифт счета
    /// </summary>
    private Font ScoreFont { get; set; }
    /// <summary>
    /// Семейство шрифтов
    /// </summary>
    public FontFamily ScoreFontFamily { get; set; }
    /// <summary>
    /// Модель окна геймплея
    /// </summary>
    public ModelGamePlay ModelGamePlay { get; set; }
    /// <summary>
    /// Форма
    /// </summary>
    public Form _form { get; set; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModelGamePlay">Модель окна геймплея</param>
    public ViewGamePlayWindows(ModelGamePlay parModelGamePlay)
    {
      ModelGamePlay = parModelGamePlay;
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
      InitForm();
      _drawingThread = new Thread(RedrawCycle);
      _drawingThread.IsBackground = true;
      _drawingThread.Start();
    }
    /// <summary>
    /// Инициализация формы
    /// </summary>
    public void InitForm()
    {
      _form = Application.OpenForms[0];
      Graphics targetgraphics = _form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, _form.Width, _form.Height));
    }
    /// <summary>
    /// Отрисовать игровое поле
    /// </summary>
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
    /// <summary>
    /// Отрисовать счет игрока
    /// </summary>
    public void DrawScore()
    {
      _bufferedGraphics.Graphics.DrawString("Score: " + ModelGamePlay.Score, ScoreFont, Brushes.Chocolate, 10, 10);
    }
    /// <summary>
    /// Отрисовать активную фигуру
    /// </summary>
    public void DrawActiveFigure()
    {
      for (int i = 0; i < ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].WidthFigure; j++)
        {
          if (ModelGamePlay.FiguresShapes.Figures[ModelGamePlay.ActiveFigureNumber].FigureShape[i][j].IsFull)
          {
            if (ModelGamePlay.GameField.PlayingField[i + ModelGamePlay.PointerCoordinates.Y][j + ModelGamePlay.PointerCoordinates.X].IsFull)
            {
              _bufferedGraphics.Graphics.FillRectangle(Brushes.Red, FieldRectangles[i + ModelGamePlay.PointerCoordinates.Y][j + ModelGamePlay.PointerCoordinates.X]);
            }
            else
            {
              _bufferedGraphics.Graphics.FillRectangle(Brushes.Chocolate, FieldRectangles[i + ModelGamePlay.PointerCoordinates.Y][j + ModelGamePlay.PointerCoordinates.X]);
            }
          }
        }
      }
    }
    /// <summary>
    /// Цикл перерисовки
    /// </summary>
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
