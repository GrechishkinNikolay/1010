using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class LastGameResults
  {
    private static int _score;

    public static int Score
    {
      get { return _score; }
      set
      {
        if (value >= 0)
        {
          _score = value;
        }
      }
    }

  }
}
