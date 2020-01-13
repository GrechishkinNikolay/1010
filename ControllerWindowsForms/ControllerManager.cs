using Controllers;
using ControllerWindowsForms;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  /// <summary>
  /// Менеджер контроллеров окон
  /// </summary>
  public class ControllerManager : Controller
  {
    /// <summary>
    /// Перечисление переключения окон
    /// </summary>
    private EWindows _nextWindow;
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
    /// Следующее окно
    /// </summary>
    public EWindows NextWindow
    {
      get
      {
        lock (_lockNextWindow)
        {
          return _nextWindow;
        }
      }
      set
      {
        lock (_lockNextWindow)
        {
          _nextWindow = value;
          _changeWindow = true;
        }
      }
    }
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
    /// <summary>
    /// Обработчик нажатия на пункт меню 
    /// </summary>
    public void SelectMenuItem()
    {
      NextWindow = (EWindows)ModelMenu._selectedMenuItem;
      ModelMenu.OnSelectMenuItem -= SelectMenuItem;
    }
    /// <summary>
    /// Обработчик события проигрыша 
    /// </summary>
    public void Losing()
    {
      ModelGamePlay.OnLose -= Losing;
      NextWindow = EWindows.GameOver;
    }
    /// <summary>
    /// Обработчик события проигрыша и выхода в меню
    /// </summary>
    public void GoToMenu()
    {
      ModelGamePlay.OnLoseToMenu -= GoToMenu;
      NextWindow = EWindows.Menu;
    }
    /// <summary>
    /// Метод выполнения менеджера контроллеров
    /// </summary>
    public EWindows Execute()
    {
      ControllerWindows controllerWindows = new ControllerMenuWindows();
      ModelMenu.OnSelectMenuItem += SelectMenuItem;
      ModelGamePlay.OnLose += Losing;
      ModelGamePlay.OnLoseToMenu += GoToMenu;
      while (true)
      {
        while (!_changeWindow)
        {
          Thread.Sleep(100);
        }
        _changeWindow = false;
        if (NextWindow == EWindows.Exit)
        {
          break;
        }
        controllerWindows = ControllerWindows.CreateController(NextWindow);
        if (NextWindow == EWindows.Menu)
        {
          ModelMenu.OnSelectMenuItem += SelectMenuItem;
        }
      }
      return EWindows.Exit;
    }
  }
}
