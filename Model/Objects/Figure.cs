using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
      for (int i = 0; i < FIGURE_SIZE; i++)
      {
        FigureShape[i] = new Cell[FIGURE_SIZE];
        for (int i = 0; i < length; i++)
        {

        }
      }
      for (int i = 0; i < parFigureCode.Length; i++)
      {
        for (int j = 0; j < FIGURE_SIZE - 1; j++)
        {
          FigureShape[i % FIGURE_SIZE][j].IsFull = (parFigureCode[FIGURE_SIZE * i + j] == '1');
          if (parFigureCode[FIGURE_SIZE * i + j] == '1')
          {
            WidthFigure = j + 1;
            HeightFigure = i + 1;
            PointsForFigure++;
          }
        }
      }
    }
  }
}

