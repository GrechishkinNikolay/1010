using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Field
  {
    private Cell[][] _playingField;

    public Cell[][] PlayingField
    {
      get
      {
        return _playingField;
      }
      set
      {
        _playingField = value;
      }
    }

  }
}
