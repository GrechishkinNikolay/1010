using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Cell
  {
    public bool IsFull
    {
      get;
      set;
    }
    public bool IsFilledWithFigures { get; set; }

    public Cell(bool parIsFull)
    {
      IsFull = parIsFull;
    }
  }
}
