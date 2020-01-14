using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Координаты
  /// </summary>
  public class Coordinates
  {
    /// <summary>
    /// Координата Х
    /// </summary>
    private int _x;
    /// <summary>
    /// Координата Y
    /// </summary>
    private int _y;

    /// <summary>
    /// Свойство координаты Х
    /// </summary>
    public int X
    {
      get
      {
        return _x;
      }
      set
      {
        _x = value;
      }
    }
    /// <summary>
    /// Свойство координаты Y
    /// </summary>
    public int Y
    {
      get
      {
        return _y;
      }
      set
      {
        _y = value;
      }
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">Кордината Х</param>
    /// <param name="parY">Координата Y</param>
    public Coordinates(int parX, int parY)
    {
      _x = parX;
      _y = parY;
    }
  }
}
