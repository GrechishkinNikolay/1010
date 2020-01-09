using Models.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ModelGamePlay : Model
  {
    public const int COUNT_ROW = 10;
    public const int COUNT_COLUMN = 10;
    private static Random _pseudoRandomNumberGenerator = new Random();

    public delegate void _menuItemSelection();
    public static event _menuItemSelection onSelectMenuItem;

    public int ActiveFigureNumber
    {
      get;
      set;
    }
    private bool _isGame;

    public bool IsGame
    {
      get { return _isGame; }
      set { _isGame = value; }
    }
    public bool NoPlaceForFigure { get; set; }
    public FiguresShapes FiguresShapes
    {
      get;
      set;
    }

    public Coordinates PointerCoordinates
    {
      get;
      set;
    }

    public Field GameField
    {
      get;
      set;
    }

    public int Score
    {
      get;
      set;
    }

    public ModelGamePlay()
    {
      GameField = new Field(COUNT_ROW, COUNT_COLUMN);
      FiguresShapes = new FiguresShapes(FigureCodeKeeper.FiguresCodes);
      PointerCoordinates = new Coordinates(3, 3);
      ActiveFigureNumber = _pseudoRandomNumberGenerator.Next(0, FiguresShapes.Figures.Length);
    }
    public void CheckForLoss()
    {
      for (int i = 0; i < GameField.PlayingField.Length; i++)
      {
        for (int j = 0; j < GameField.PlayingField[i].Length; j++)
        {

        }
      }
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

    public void PutTheFigure()
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
      }
    }
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

    public void ClearColumn(int parI)
    {
      for (int j = 0; j < COUNT_ROW; j++)
      {
        GameField.PlayingField[j][parI].IsFull = false;
      }
    }

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

    public void MoveFigureUp()
    {
      if (PointerCoordinates.Y > 0)
      {
        PointerCoordinates.Y -= 1;
      }
    }
    public void MoveFigureLeft()
    {
      if (PointerCoordinates.X > 0)
      {
        PointerCoordinates.X -= 1;
      }
    }
    public void MoveFigureDown()
    {
      if (PointerCoordinates.Y + FiguresShapes.Figures[ActiveFigureNumber].HeightFigure < COUNT_ROW)
      {
        PointerCoordinates.Y += 1;
      }
    }
    public void MoveFigureRight()
    {
      if (PointerCoordinates.X + FiguresShapes.Figures[ActiveFigureNumber].WidthFigure < COUNT_COLUMN)
      {
        PointerCoordinates.X += 1;
      }
    }

  }
}
