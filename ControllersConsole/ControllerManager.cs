using Controllers;
using ControllersConsole;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControllerWindowsForms
{
  /// <summary>
  /// Менеджер контроллеров окон
  /// </summary>
  public class ControllerManager : Controller
  {
    /// <summary>
    /// Объект-заглушка для синхронизации потоков
    /// </summary>
    private readonly Object _lockNextWindow = new Object();
    /// <summary>
    /// Нужно ли поменять окно
    /// </summary>
    public volatile bool _changeWindow = false;
    /// <summary>
    /// Объект менеджера
    /// </summary>
    private static ControllerManager _instance = null;
    /// <summary>
    /// Приватный конструктор
    /// </summary>
    private ControllerManager() { }
    /// <summary>
    /// Метод получения экземпляра менеджера окон
    /// </summary>
    /// <returns></returns>
    public static ControllerManager GetInstance()
    {
      if (_instance == null)
        _instance = new ControllerManager();
      return _instance;
    }
    ///// <summary>
    ///// Метод выполнения менеджера контроллеров
    ///// </summary>
    //public EWindows Execute()
    //{
    //  ControllerWindows controllerWindows = new ControllerMenuWindows();
    //  ModelMenu.OnSelectMenuItem += SelectMenuItem;
    //  ModelGamePlay.OnLose += Losing;
    //  ModelGamePlay.OnLoseToMenu += GoToMenu;
    //  while (true)
    //  {
    //    while (!_changeWindow)
    //    {
    //      Thread.Sleep(100);
    //    }
    //    _changeWindow = false;
    //    if (NextWindow == EWindows.Exit)
    //    {
    //      break;
    //    }
    //    controllerWindows = ControllerWindows.CreateController(NextWindow);
    //    if (NextWindow == EWindows.Menu)
    //    {
    //      ModelMenu.OnSelectMenuItem += SelectMenuItem;
    //    }
    //  }
    //  return EWindows.Exit;
    //}
    /// <summary>
    /// Запуск контроллера
    /// </summary>
    /// <returns>Window.Terminate</returns>
    public EWindows Execute()
    {
      ConsoleController controller = new ControllerMenuConsole();
      EWindows nextWindow;

      while (true)
      {
        nextWindow = controller.Execute();
        if (nextWindow == EWindows.Exit)
        {
          break;
        }
        controller = ControllerWindows.CreateController(nextWindow);
      }

      return EWindows.Exit;
    }
  }
}
