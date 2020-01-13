using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Поле
  /// </summary>
  public class Field
  {
    /// <summary>
    /// Клетки поля
    /// </summary>
    public Cell[][] PlayingField
    {
      get;
      set;
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRowCount">Число строк</param>
    /// <param name="parColomnCount">Число столбцов</param>
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