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
    public Figure(Cell[][] parCells)
    {
      _figureShape = parCells;
    }
  }
}

