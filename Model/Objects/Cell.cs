using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Cell
  {
    private bool _isFull;
    //private Сoordinates coordinates;

    //public Сoordinates Сoordinates
    //{
    //  get
    //  {
    //    return coordinates;
    //  }
    //  set
    //  {
    //    coordinates = value;
    //  }
    //}

    public bool IsFull
    {
      get
      {
        return _isFull;
      }
      set
      {
        _isFull = value;
      }
    }

    public Cell(bool isFull)
    {
      _isFull = isFull;
    }
  }
}
