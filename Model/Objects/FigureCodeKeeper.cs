using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
  public class FigureCodeKeeper
  {
    private static readonly string LONG_L_FIGURE = "100100111";
    private static readonly string LONG_I_FIGURE = "100100100";
    private static readonly string LONG_T_FIGURE = "111010010";
    private static readonly string SHORT_L_FIGURE = "100100111";
    private static readonly string SHORT_I_FIGURE = "100100000";
    private static readonly string SHORT_T_FIGURE = "111010000";
    private static readonly string SMALL_SQUARE = "110110000";
    private static readonly string BIG_SQUARE = "111111111";
    private static readonly string LEFT_SMALL_DIAGONAL = "100010000";
    private static readonly string RIGHT_SMALL_DIAGONAL = "010100000";
    private static readonly string RIGHT_BIG_DIAGONAL = "001010100";
    private static readonly string LEFT_BIG_DIAGONAL = "100010001";

    private static readonly string[] _figuresCodes = new String[] { LONG_L_FIGURE, LONG_I_FIGURE, LONG_T_FIGURE, SHORT_L_FIGURE, SHORT_I_FIGURE,
      SHORT_T_FIGURE,SMALL_SQUARE, BIG_SQUARE, LEFT_SMALL_DIAGONAL, RIGHT_SMALL_DIAGONAL, RIGHT_BIG_DIAGONAL, LEFT_BIG_DIAGONAL};

    public static string[] FiguresCodes
    {
      get
      {
        return _figuresCodes;
      }
    }
  }
}
