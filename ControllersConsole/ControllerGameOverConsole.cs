using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ViewsConsole;

namespace ControllersConsole
{
  /// <summary>
  /// Контроллер окна проигрыша
  /// </summary>
  public class ControllerGameOverConsole : ConsoleController
  {
    /// <summary>
    /// Отображение окна
    /// </summary>
    private ViewGameOverConsole _view;
    /// <summary>
    /// Модель
    /// </summary>
    public ModelGameOverScreen _model;
    /// <summary>
    /// Запуск контроллера
    /// </summary>
    /// <returns>окно, на которое нужно перейти после выполнения метода</returns>
    public override EWindows Execute()
    {
      _model = new ModelGameOverScreen();
      _view = new ViewGameOverConsole(_model);
      _model.IsRunning = true;

      while (_model.IsRunning)
      {
        ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
        ConsoleKey keyPressed = keyPressedInfo.Key;
        char symbol = keyPressedInfo.KeyChar;

        if (keyPressed == ConsoleKey.Enter)
        {
          _model.IsRunning = false;
        }
        else if (keyPressed == ConsoleKey.Backspace)
        {
          _model.DeleteSymbol();
        }
        else
        {
          _model.AddSymbolToName(symbol);
        }
      }
      if (!String.IsNullOrEmpty(_model.LastGameResults.Name))
      {
        _model.ScoreManager.UpdateScore(_model.LastGameResults.Name, _model.LastGameResults.Score);
      }
      return EWindows.Menu;
    }
  }
}
