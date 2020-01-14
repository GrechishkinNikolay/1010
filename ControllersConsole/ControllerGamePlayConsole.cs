using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ViewsConsole;

namespace ControllersConsole
{
  public class ControllerGamePlayConsole : ConsoleController
  {
    /// <summary>
    /// Отображение окна
    /// </summary>
    public ViewGamePlayConsole _view;
    public ModelGamePlay _model;
    /// <summary>
    /// Запуск контроллера
    /// </summary>
    /// <returns>окно, на которое нужно перейти после выполнения метода</returns>
    public override EWindows Execute()
    {
      _model = new ModelGamePlay();
      _view = new ViewGamePlayConsole(_model);
      _model.IsRunning = true;
      ModelGamePlay.OnLose += GameOver;

      while (_model.IsRunning)
      {
        ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
        switch (keyPressedInfo.Key)
        {
          case ConsoleKey.UpArrow:
            _model.MoveFigureUp();
            break;
          case ConsoleKey.DownArrow:
            _model.MoveFigureDown();
            break;
          case ConsoleKey.RightArrow:
            _model.MoveFigureRight();
            break;
          case ConsoleKey.LeftArrow:
            _model.MoveFigureLeft();
            break;
          case ConsoleKey.Escape:
            _model.IsRunning = false;
            _model.InvokeLose();
            break;
        }
      }
      // ToDo
      return EWindows.Menu;
    }

    /// <summary>
    /// Обработчик события завершения игры
    /// </summary>
    private void GameOver()
    {
      ReadKeyInterrupter.InterruptRead();
    }
  }
}
