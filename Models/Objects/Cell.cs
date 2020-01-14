using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Клетка
  /// </summary>
  public class Cell
  {
    /// <summary>
    /// Заполнена ли клетка
    /// </summary>
    public bool IsFull
    {
      get;
      set;
    }
    /// <summary>
    /// Заполнена ли клетка активной фигурой
    /// </summary>
    public bool IsFilledWithFigures { get; set; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parIsFull">Заполнена ли клетка</param>
    public Cell(bool parIsFull)
    {
      IsFull = parIsFull;
    }
  }
}
