using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Фигура
  /// </summary>
  public class Figure
  {
    /// <summary>
    /// Стандартные размеры фигуры
    /// </summary>
    public static int FIGURE_SIZE
    {
      get;
    } = 3;
    /// <summary>
    /// Клетки фигуры
    /// </summary>
    public Cell[][] FigureShape
    {
      get;
      set;
    }
    /// <summary>
    /// Ширина фигуры
    /// </summary>
    public int WidthFigure
    {
      get;
      set;
    }
    /// <summary>
    /// Очки получаемые за фигуру
    /// </summary>
    public int PointsForFigure
    {
      get;
    }
    /// <summary>
    /// Высота фигуры
    /// </summary>
    public int HeightFigure
    {
      get;
      set;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parFigureCode">Код формы фигуры</param>
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

