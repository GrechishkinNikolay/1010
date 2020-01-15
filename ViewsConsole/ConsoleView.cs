using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsConsole
{
  /// <summary>
  /// Базовый абстрактный класс представления консоли
  /// </summary>
  public abstract class ConsoleView
  {
    /// <summary>
    /// Число обновлений в секунду
    /// </summary>
    public int FPS = 60;
    /// <summary>
    /// Метод перерисовки
    /// </summary>
    public abstract void Redraw();
  }
}
