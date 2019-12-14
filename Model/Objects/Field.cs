using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Field
  {
    public Cell[][] PlayingField
    {
      get;
      set;
    }

    public Field(int parRowCount, int parColomnCount)
    {
      PlayingField = new Cell[parRowCount][];
      for (int i = 0; i < PlayingField.Length; i++)
      {
        PlayingField[i] = new Cell[parColomnCount];
        for (int j = 0; j < PlayingField[i].Length; j++)
        {
          PlayingField[i][j] = new Cell(false);
        }
      }
    }
  }
}