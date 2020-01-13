using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
  /// <summary>
  /// Хранилище кодированных форм фигур
  /// </summary>
  public class FigureCodeKeeper
  {
    /// <summary>
    /// Фигура длинная "I" горизонтальная
    /// </summary>
    private static readonly string LONG_I_FIGURE_HORIZONTAL = "111000000";
    /// <summary>
    /// Фигура длинная "I" вертикальная 
    /// </summary>
    private static readonly string LONG_I_FIGURE_VERTICAL = "100100100";
    /// <summary>
    /// Фигура длинная "L" левая нижняя
    /// </summary>
    private static readonly string LONG_L_FIGURE_LEFT_B = "100100111";
    /// <summary>
    /// Фигура длинная "L" левая верхняя
    /// </summary>
    private static readonly string LONG_L_FIGURE_LEFT_T = "111100100";
    /// <summary>
    /// Фигура длинная "L" правая верхняя
    /// </summary>
    private static readonly string LONG_L_FIGURE_RIGHT_T = "111001001";
    /// <summary>
    /// Фигура длинная "L" правая нижняя
    /// </summary>
    private static readonly string LONG_L_FIGURE_RIGHT_B = "001001111";
    /// <summary>
    /// Фигура длинная "L" левая нижняя
    /// </summary>
    private static readonly string SHORT_L_FIGURE_LEFT_B = "100110000";
    /// <summary>
    /// Фигура короткая "L" левая верзняя
    /// </summary>
    private static readonly string SHORT_L_FIGURE_LEFT_T = "110100000";
    /// <summary>
    /// Фигура короткая "L" правая верхняя
    /// </summary>
    private static readonly string SHORT_L_FIGURE_RIGHT_T = "110010000";
    /// <summary>
    /// Фигура короткая "L" правая нижняя
    /// </summary>
    private static readonly string SHORT_L_FIGURE_RIGHT_B = "010110000";
    /// <summary>
    /// Фигура короткая "I" горизонтальная
    /// </summary>
    private static readonly string SHORT_I_FIGURE_HORIZONTAL = "110000000";
    /// <summary>
    /// Фигура короткая "I" вертикальная 
    /// </summary>
    private static readonly string SHORT_I_FIGURE_VERTICAL = "100100000";
    /// <summary>
    /// Фигура маленький куб
    /// </summary>
    private static readonly string SMALL_SQUARE = "110110000";
    /// <summary>
    /// Фигура короткая большой куб
    /// </summary>
    private static readonly string BIG_SQUARE = "111111111";
    /// <summary>
    /// Фигура точка 
    /// </summary>
    private static readonly string POINT = "100000000";
    /// <summary>
    /// Коды форм фигур
    /// </summary>
    private static readonly string[] _figuresCodes = new String[] { LONG_I_FIGURE_HORIZONTAL, LONG_I_FIGURE_VERTICAL, LONG_L_FIGURE_LEFT_B, LONG_L_FIGURE_LEFT_T, LONG_L_FIGURE_RIGHT_T, LONG_L_FIGURE_RIGHT_B,
      SHORT_L_FIGURE_LEFT_B, SHORT_L_FIGURE_LEFT_T, SHORT_L_FIGURE_RIGHT_T, SHORT_L_FIGURE_RIGHT_B, SHORT_I_FIGURE_HORIZONTAL, SHORT_I_FIGURE_VERTICAL, SMALL_SQUARE, BIG_SQUARE, POINT};
    /// <summary>
    /// Свойство получения кодов форм фигур
    /// </summary>
    public static string[] FiguresCodes
    {
      get
      {
        return _figuresCodes;
      }
    }
  }
}
