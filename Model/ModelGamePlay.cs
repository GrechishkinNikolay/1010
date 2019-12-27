using Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class ModelGamePlay
  {
    private const int COUNT_ROW = 10;
    private const int COUNT_COLUMN = 10;
    private static Random _pseudoRandomNumberGenerator = new Random();

    public int ActiveFigureNumber
    {
      get;
      set;
    }

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
    }
  
    public bool CanWePlaceFigure()
    {
      for (int i = 0; i < FiguresShapes.Figures[ActiveFigureNumber].HeightFigure; i++)
      {
        for (int j = 0; j < FiguresShapes.Figures[ActiveFigureNumber].WidthFigure; j++)
        {
          if (!(FiguresShapes.Figures[ActiveFigureNumber].FigureShape[i][j].IsFull &&
            GameField.PlayingField[i + PointerCoordinates.Y][j + PointerCoordinates.X].IsFull))
          {
            return false;
          }
        }
      }
      return true;
    }

    public void PutTheFigure()
    {
      if (CanWePlaceFigure())
      {
        for (int i = 0; i < Figure.FIGURE_SIZE; i++)
        {
          for (int j = 0; j < Figure.FIGURE_SIZE; j++)
          {
            GameField.PlayingField[i + PointerCoordinates.Y][j + PointerCoordinates.X] = FiguresShapes.Figures[ActiveFigureNumber].FigureShape[i][j];
          }
        }
        ActiveFigureNumber = _pseudoRandomNumberGenerator.Next(0, FiguresShapes.Figures.Length);
        DeleteFilledRowsAndColumns();
        Score += FiguresShapes.Figures[ActiveFigureNumber].PointsForFigure;
        PointerCoordinates.X = 4;
        PointerCoordinates.Y = 3;
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
      if (PointerCoordinates.Y + FiguresShapes.Figures[ActiveFigureNumber].WidthFigure < COUNT_COLUMN)
      {
        PointerCoordinates.X += 1;
      }
    }

  }
}
