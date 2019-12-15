using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Cell
  {
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
      get;
      set;
    }

    public Cell(bool parIsFull)
    {
      IsFull = parIsFull;
    }
  }
}
