using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Идентификаторы окон
  /// </summary>
  public enum EWindows : byte
  {
    /// <summary>
    /// Окно игры
    /// </summary>
    GamePlay,
    /// <summary>
    /// Окно рекордов
    /// </summary>
    Records,
    /// <summary>
    /// Окно справки
    /// </summary>
    Help,
    /// <summary>
    /// Выход из игры
    /// </summary>
    Exit,
    /// <summary>
    /// Окно ввода имени
    /// </summary>
    GameOver,
    /// <summary>
    /// Окно меню
    /// </summary>
    Menu
  }
}
