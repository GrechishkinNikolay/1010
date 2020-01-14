using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
  /// <summary>
  /// Хранилище фигур
  /// </summary>
  public class FiguresShapes
  {
    /// <summary>
    /// Фигуры
    /// </summary>
    public Figure[] Figures
    {
      get;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parFiguresCodes">Коды форм фигур</param>
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
