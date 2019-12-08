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
    public Field(int parRowCount, int parColomnCount)
    {
      _playingField = new Cell[parRowCount][];
      for (int i = 0; i < _playingField.Length; i++)
      {
        _playingField[i] = new Cell[parColomnCount];
        for (int j = 0; j < _playingField[i].Length; j++)
        {
          _playingField[i][j] = new Cell(false);
        }
      }
    }
  }
}