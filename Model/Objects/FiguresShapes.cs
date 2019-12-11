using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
  class FiguresShapes
  {
    private readonly Figure[] _figures;

    public void FiguresShapes(string[] parFiguresCodes)
    {
      _figures = new Figure[parFiguresCodes.Length];
      for (int i = 0; i < _figures.Length; i++)
      {
        for (int j = 0; j < _figures[i].Length; j++)
        {
          for (int k = 0; k < _figures; k++)
          {

          }
          _figures[i].FigureShape[i][j]
        }
      }
    }

  }
}
