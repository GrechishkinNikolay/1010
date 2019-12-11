using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Figure
  {
    private Cell[][] _figureShape;

    public int FigureShape
    {
      get
      {
        return FigureShape;
      }
      set
      {
        FigureShape = value;
      }
    }
    public Figure(string parfigureCode)
    {
      for (int i = 0; i < parfigureCode.Length; i++)
      {
        for (int j = 0; j < 3; j++)
        {
          _figureShape[i][j] = parfigureCode[3*i + j]
        }
      }
      _figureShape = parCells;
    }

    public Figure FillFigure(string parfigureCode)
    {
      for (int i = 0; i < str; i++)
      {

      }
    }
  }
}

