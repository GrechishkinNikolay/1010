using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
  /// <summary>
  /// Абстрактный создатель контроллеров
  /// </summary>
  public abstract class ControllerCreator
  {
    /// <summary>
    /// Получить контроллер
    /// </summary>
    /// <param name="parEWindows">Тип окна</param>
    /// <returns>Контроллер</returns>
    public abstract Controller GetController(EWindows parEWindows);
  }
}
