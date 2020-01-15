using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ViewsConsole;

namespace ControllersConsole
{
  public class ControllerHelpConsole : ConsoleController
  {
    /// <summary>
    /// Отображение окна
    /// </summary>
    private ViewHelpConsole _view;
    private ModelHelp _model;
    /// <summary>
    /// Запуск контроллера
    /// </summary>
    /// <returns>окно, на которое нужно перейти после выполнения метода</returns>
		public override EWindows Execute()
    {
      _model = new ModelHelp();
      _view = new ViewHelpConsole(_model);
      _model.IsRunning = true;
      while (_model.IsRunning)
      {
        ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
        ConsoleKey keyPressed = keyPressedInfo.Key;

        switch (keyPressed)
        {
          case ConsoleKey.Escape:
            _model.IsRunning = false;
            break;
        }
      }
      return EWindows.Menu;
    }
  }
}
