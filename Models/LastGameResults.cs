using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Хранилище информации об игроке игравшем последним 
  /// </summary>
  public class LastGameResults
  {
    /// <summary>
    /// Счет игрока 
    /// </summary>
    private static int _score;
    /// <summary>
    /// Имя игрока 
    /// </summary>
    private static string _name;
    /// <summary>
    /// Свойство имени игрока
    /// </summary>
    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }
    /// <summary>
    /// Свойство счета игрока
    /// </summary>
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
