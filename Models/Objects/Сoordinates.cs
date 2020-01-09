using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class Coordinates
  {
    private int _x;
    private int _y;


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

    public Coordinates(int x, int y)
    {
      _x = x;
      _y = y;
    }
  }
}
