using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Objects
{
  public class FigureCodeKeeper
  {
    private static readonly string LONG_I_FIGURE_HORIZONTAL = "111000000";
    private static readonly string LONG_I_FIGURE_VERTICAL = "100100100";
    private static readonly string LONG_L_FIGURE_LEFT_B = "100100111";
    private static readonly string LONG_L_FIGURE_LEFT_T = "111100100";
    private static readonly string LONG_L_FIGURE_RIGHT_T = "111001001";
    private static readonly string LONG_L_FIGURE_RIGHT_B = "001001111";
    private static readonly string SHORT_L_FIGURE_LEFT_B = "100110000";
    private static readonly string SHORT_L_FIGURE_LEFT_T = "110100000";
    private static readonly string SHORT_L_FIGURE_RIGHT_T = "110010000";
    private static readonly string SHORT_L_FIGURE_RIGHT_B = "010110000";
    private static readonly string SHORT_I_FIGURE_HORIZONTAL = "110000000";
    private static readonly string SHORT_I_FIGURE_VERTICAL = "100100000";
    private static readonly string SMALL_SQUARE = "110110000";
    private static readonly string BIG_SQUARE = "111111111";
    private static readonly string POINT = "100000000";

    private static readonly string[] _figuresCodes = new String[] { LONG_I_FIGURE_HORIZONTAL, LONG_I_FIGURE_VERTICAL, LONG_L_FIGURE_LEFT_B, LONG_L_FIGURE_LEFT_T, LONG_L_FIGURE_RIGHT_T, LONG_L_FIGURE_RIGHT_B,
      SHORT_L_FIGURE_LEFT_B, SHORT_L_FIGURE_LEFT_T, SHORT_L_FIGURE_RIGHT_T, SHORT_L_FIGURE_RIGHT_B, SHORT_I_FIGURE_HORIZONTAL, SHORT_I_FIGURE_VERTICAL, SMALL_SQUARE, BIG_SQUARE, POINT};

    public static string[] FiguresCodes
    {
      get
      {
        return _figuresCodes;
      }
    }
  }
}
