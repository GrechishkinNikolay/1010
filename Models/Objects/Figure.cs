using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Figure
  {
    public static int FIGURE_SIZE
    {
      get;
    } = 3;

    public Cell[][] FigureShape
    {
      get;
      set;
    }

    public int WidthFigure
    {
      get;
      set;
    }

    public int PointsForFigure
    {
      get;
    }

    public int HeightFigure
    {
      get;
      set;
    }

    public Figure(string parFigureCode)
    {
      FigureShape = new Cell[FIGURE_SIZE][];
      for (int i = 0; i < FIGURE_SIZE; i++)
      {
        FigureShape[i] = new Cell[FIGURE_SIZE];
        for (int j = 0; j < FIGURE_SIZE; j++)
        {
          FigureShape[i][j] = new Cell(false);
        }
      }
      for (int i = 0; i < parFigureCode.Length; i++)
      {
        FigureShape[i / FIGURE_SIZE][i % FIGURE_SIZE].IsFull = (parFigureCode[i] == '1');
        if (parFigureCode[i] == '1')
        {
          WidthFigure = (i % FIGURE_SIZE + 1) > WidthFigure ? i % FIGURE_SIZE + 1 : WidthFigure;
          HeightFigure = i / FIGURE_SIZE + 1;
          PointsForFigure++;
        }
      }
    }
  }
}

