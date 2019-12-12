using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Objects
{
  class FigureCodeKeeper
  {
    private static readonly string LONG_L_FIGURE = "100100111";
    private static readonly string LONG_I_FIGURE = "100100100";
    private static readonly string LONG_T_FIGURE = "111010010";
    private static readonly string SHORT_L_FIGURE = "100100111";
    private static readonly string SHORT_I_FIGURE = "100100000";
    private static readonly string SHORT_T_FIGURE = "111010000";
    private static readonly string[] _figuresCodes = new String[] { LONG_L_FIGURE, LONG_I_FIGURE, LONG_T_FIGURE, SHORT_L_FIGURE, SHORT_I_FIGURE, SHORT_T_FIGURE };

    public static string[] FiguresCodes
    {
      get
      {
        return _figuresCodes;
      }
    }

  }
}
