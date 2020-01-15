using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewsConsole;

namespace ControllersConsole
{
  /// <summary>
  /// Базовый абстрактный класс контроллеров для консоли
  /// </summary>
  public abstract class ConsoleController
  {
    /// <summary>
    /// Выплонить контроллер
    /// </summary>
    /// <returns></returns>
    public abstract EWindows Execute();
  }
}
