using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
  public class FiguresShapes
  {
    public Figure[] Figures
    {
      get;
    }

    public FiguresShapes(string[] parFiguresCodes)
    {
      Figures = new Figure[parFiguresCodes.Length];
      for (int i = 0; i < Figures.Length; i++)
      {
        Figures[i] = new Figure(parFiguresCodes[i]);
      }
    }
  }
}
