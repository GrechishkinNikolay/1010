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

    public FiguresShapes(string[] parFiguresCodes)
    {
      _figures = new Figure[parFiguresCodes.Length];
      for (int i = 0; i < _figures.Length; i++)
      {
        _figures[i] = new Figure(parFiguresCodes[i]);
      }
    }
  }
}
