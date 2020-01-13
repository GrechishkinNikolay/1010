using Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Модель игрового окна
  /// </summary>
  public class ModelGamePlay : Model
  {
    /// <summary>
    /// Число строк игрового поля 
    /// </summary>
    public const int COUNT_ROW = 10;
    /// <summary>
    /// Число колонок игрового поля
    /// </summary>
    public const int COUNT_COLUMN = 10;
    /// <summary>
    /// Генератор случайных чисел
    /// </summary>
    private static Random _pseudoRandomNumberGenerator = new Random();
    /// <summary>
    /// Активно ли окно игры
    /// </summary>
    private bool _isGame;
    /// <summary>
    /// Делегат проигрыша
    /// </summary>
    public delegate void _dLoseGame();
    /// <summary>
    /// Событие проигрыша 
    /// </summary>
    public static event _dLoseGame OnLose;
    /// <summary>
    /// Событие проигрыша и перехода в меню
    /// </summary>
    public static event _dLoseGame OnLoseToMenu;
    /// <summary>
    /// Результаты последнего игрока 
    /// </summary>
    private LastGameResults _lastGameResults;
    /// <summary>
    /// Номер активной фигуры
    /// </summary>
    public int ActiveFigureNumber
    {
      get;
      set;
    }
    /// <summary>
    /// Активно ли окно игры
    /// </summary>
    public bool IsGame
    {
      get { return _isGame; }
      set { _isGame = value; }
    }
    /// <summary>
    /// Хранилище фигур
    /// </summary>
    public FiguresShapes FiguresShapes
    {
      get;
      set;
    }
    /// <summary>
    /// Координаты указателя
    /// </summary>
    public Coordinates PointerCoordinates
    {
      get;
      set;
    }
    /// <summary>
    /// Игровое поле
    /// </summary>
    public Field GameField
    {
      get;
      set;
    }
    /// <summary>
    /// Счет
    /// </summary>
    public int Score
    {
      get;
      set;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    public ModelGamePlay()
    {
      GameField = new Field(COUNT_ROW, COUNT_COLUMN);
      FiguresShapes = new FiguresShapes(FigureCodeKeeper.FiguresCodes);
      PointerCoordinates = new Coordinates(3, 3);
      ActiveFigureNumber = _pseudoRandomNumberGenerator.Next(0, FiguresShapes.Figures.Length);
      _lastGameResults = new LastGameResults();
    }
    public void SpawnNewFigure()
    {
      for (int i = 0; i < FiguresShapes.Figures[ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < FiguresShapes.Figures[ActiveFigureNumber].WidthFigure; j++)
        {
          if (FiguresShapes.Figures[ActiveFigureNumber].FigureShape[i][j].IsFull)
          {
            GameField.PlayingField[i + PointerCoordinates.Y][j + PointerCoordinates.X].IsFilledWithFigures = false;
          }
        }
      }
    }
    /// <summary>
    /// Можем ли мы вставить фигуру относительно данных координат
    /// </summary>
    /// <param name="parX">Координата Х</param>
    /// <param name="parY">Координата Y</param>
    public bool CanWePlaceFigure(int parX, int parY)
    {
      for (int i = 0; i < FiguresShapes.Figures[ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < FiguresShapes.Figures[ActiveFigureNumber].WidthFigure; j++)
        {
          if (FiguresShapes.Figures[ActiveFigureNumber].FigureShape[i][j].IsFull &&
            GameField.PlayingField[i + parY][j + parX].IsFull)
          {
            return false;
          }
        }
      }
      return true;
    }
    /// <summary>
    /// Есть ли место для активной фигуры на игровом поле
    /// </summary>
    public bool IsTherePlaceForFigure()
    {
      for (int i = 0; i <= GameField.PlayingField.Length - FiguresShapes.Figures[ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j <= GameField.PlayingField[i].Length - FiguresShapes.Figures[ActiveFigureNumber].WidthFigure; j++)
        {
          if (CanWePlaceFigure(j, i))
          {
            return true;
          }
        }
      }
      return false;
    }
    /// <summary>
    /// Поставить фигуру
    /// </summary>
    /// <returns>Удалось ли поставить фигуру</returns>
    public bool PutTheFigure()
    {
      if (CanWePlaceFigure(PointerCoordinates.X, PointerCoordinates.Y))
      {
        for (int i = 0; i < Figure.FIGURE_SIZE; i++)
        {
          for (int j = 0; j < Figure.FIGURE_SIZE; j++)
          {
            if (FiguresShapes.Figures[ActiveFigureNumber].FigureShape[i][j].IsFull)
            {
              GameField.PlayingField[i + PointerCoordinates.Y][j + PointerCoordinates.X].IsFull = true;
            }
          }
        }
        DeleteFilledRowsAndColumns();
        Score += FiguresShapes.Figures[ActiveFigureNumber].PointsForFigure;
        ActiveFigureNumber = _pseudoRandomNumberGenerator.Next(0, FiguresShapes.Figures.Length);
        PointerCoordinates.X = 3;
        PointerCoordinates.Y = 3;
        SpawnNewFigure();
        if (!IsTherePlaceForFigure())
        {
          Thread.Sleep(2000);
          _lastGameResults.Score = Score;
         if ((SortedScores.Capacity == 0) || (SortedScores.Capacity < 10) || (SortedScores[Math.Min(9, SortedScores.Count - 1)].Value < Score))
          {
            OnLose?.Invoke();
          }
          else
          {
            OnLoseToMenu?.Invoke();
          }
          return true;
        }
      }
      return false;
    }
    /// <summary>
    /// Удалить заполненные горизонтальные и вертикальные линии
    /// </summary>
    public void DeleteFilledRowsAndColumns()
    {
      foreach (Cell[] cells in GameField.PlayingField)
      {
        if (IsFullCellsSet(cells))
        {
          foreach (Cell cell in cells)
          {
            cell.IsFull = false;
          }
          Score += 10;
        }
      }
      Cell[] columnCells = new Cell[COUNT_ROW];
      for (int i = 0; i < COUNT_COLUMN; i++)
      {
        for (int j = 0; j < COUNT_ROW; j++)
        {
          columnCells[j] = GameField.PlayingField[j][i];
        }
        if (IsFullCellsSet(columnCells))
        {
          ClearColumn(i);
          Score += 10;
        }
      }
    }
    /// <summary>
    /// Очистить колонку
    /// </summary>
    /// <param name="parI">Номер удаляемой колонки</param>
    public void ClearColumn(int parI)
    {
      for (int j = 0; j < COUNT_ROW; j++)
      {
        GameField.PlayingField[j][parI].IsFull = false;
      }
    }
    /// <summary>
    /// Полная ли линия
    /// </summary>
    /// <param name="parCellsSet">Линия</param>
    public bool IsFullCellsSet(Cell[] parCellsSet)
    {
      foreach (Cell cell in parCellsSet)
      {
        if (!cell.IsFull)
        {
          return false;
        }
      }
      return true;
    }
    /// <summary>
    /// Передвинуть фигуру вверх
    /// </summary>
    public void MoveFigureUp()
    {
      if (PointerCoordinates.Y > 0)
      {
        PointerCoordinates.Y -= 1;
      }
    }
    /// <summary>
    /// Передвинуть фигуру влево
    /// </summary>
    public void MoveFigureLeft()
    {
      if (PointerCoordinates.X > 0)
      {
        PointerCoordinates.X -= 1;
      }
    }
    /// <summary>
    /// Передвинуть фигуру вниз
    /// </summary>
    public void MoveFigureDown()
    {
      if (PointerCoordinates.Y + FiguresShapes.Figures[ActiveFigureNumber].HeightFigure < COUNT_ROW)
      {
        PointerCoordinates.Y += 1;
      }
    }
    /// <summary>
    /// Передвинуть фигуру вправо
    /// </summary>
    public void MoveFigureRight()
    {
      if (PointerCoordinates.X + FiguresShapes.Figures[ActiveFigureNumber].WidthFigure < COUNT_COLUMN)
      {
        PointerCoordinates.X += 1;
      }
    }
  }
}
