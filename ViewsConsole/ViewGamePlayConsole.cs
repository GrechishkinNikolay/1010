using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViewsConsole
{
  public class ViewGamePlayConsole : ConsoleView
  {
    /// <summary>
    /// Количество символов, печатающихся на каждый блок
    /// </summary>
    public const short WIDTH_BLOCK = 2;
    /// <summary>
    /// Количество символов, печатающихся на каждый блок
    /// </summary>
    public const short HEIGHT_BLOCK = 1;   
    /// <summary>
    /// Смещение по Х
    /// </summary>
    public const short X_OFFSET = 6;  
    /// <summary>
    /// Смещение по Y
    /// </summary>
    public const short Y_OFFSET = 5;
    /// <summary>
    /// Количество строк, выделяемых на блок информации об игре
    /// </summary>
    private const short INFO_BLOCK_ROWS_COUNT = 1;
    public const string CELL_CHAR = "██";
    /// <summary>
    /// Горизонтальный отступ блока информации об игре
    /// </summary>
    private const short INFO_BLOCK_HORIZONAL_PADDING = 4;
    /// <summary>
    /// Ширина экрана в символах
    /// </summary>
    public const short SCREEN_WIDTH_SYMBOLS = 30;
    /// <summary>
    /// Высота экрана в символах
    /// </summary>
    public const short SCREEN_HEIGHT_SYMBOLS = 30;
    /// <summary>
    /// Поток отрисовки
    /// </summary>
    private Thread _RedrawThread;
    /// <summary>
    /// Отрисовщик
    /// </summary>
    private readonly KernelGraphics _graphics;
    private ModelGamePlay _model;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModelGamePlay">модель игры</param>
    public ViewGamePlayConsole(ModelGamePlay parModelGamePlay)
    {
      _graphics = KernelGraphics.Instance;
      _model = parModelGamePlay;

      _RedrawThread = new Thread(new ThreadStart(Redraw));
      _RedrawThread.IsBackground = true;
      _RedrawThread.Start();
    }
    /// <summary>
    /// Перерисовка окна
    /// </summary>
    public override void Redraw()
    {
      while (_model.IsRunning)
      {
        DrawField();
        DrawActiveFigure();
        DrawScore();
        _graphics.Flush();
        Thread.Sleep(1000 / FPS);
      }
    }
    /// <summary>
    /// Отрисовать активную фигуру
    /// </summary>
    private void DrawActiveFigure()
    {
      for (int i = 0; i < _model.FiguresShapes.Figures[_model.ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < _model.FiguresShapes.Figures[_model.ActiveFigureNumber].WidthFigure; j++)
        {
          if (_model.FiguresShapes.Figures[_model.ActiveFigureNumber].FigureShape[i][j].IsFull)
          {
            if (_model.GameField.PlayingField[i + _model.PointerCoordinates.Y][j + _model.PointerCoordinates.X].IsFull)
            {
              _graphics.PrintString((short)((j + _model.PointerCoordinates.X) * WIDTH_BLOCK + X_OFFSET),
                                     (short)((i + _model.PointerCoordinates.Y) * HEIGHT_BLOCK + Y_OFFSET), CELL_CHAR, ConsoleColor.DarkRed);
            }
            else
            {
              _graphics.PrintString((short)((j + _model.PointerCoordinates.X) * WIDTH_BLOCK + X_OFFSET),
                                    (short)((i + _model.PointerCoordinates.Y) * HEIGHT_BLOCK + Y_OFFSET), CELL_CHAR, ConsoleColor.White);
            }
          }
        }
      }
    }

    private void DrawField()
    {
      for (int i = 0; i < _model.GameField.PlayingField.Length; i++)
      {
        for (int j = 0; j < _model.GameField.PlayingField[i].Length; j++)
        {
          if (_model.GameField.PlayingField[i][j].IsFull)
          {
            _graphics.PrintString((short)(j * WIDTH_BLOCK + X_OFFSET), (short)(i * HEIGHT_BLOCK + Y_OFFSET), CELL_CHAR, ConsoleColor.Red);
          }
          else
          {
            _graphics.PrintString((short)(j * WIDTH_BLOCK + X_OFFSET), (short)(i * HEIGHT_BLOCK + Y_OFFSET), CELL_CHAR, ConsoleColor.DarkGray);
          }
        }
      }
    }

    private void DrawScore()
    {
      _graphics.PrintString(2, 1, "Score: " + _model.Score, ConsoleColor.DarkYellow);
    }
  }
}
