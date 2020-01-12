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
    private static string _name;

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }


    public int Score
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
