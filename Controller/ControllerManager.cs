using ControllerWindowsForms;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;
using ViewWindowsForms;

namespace Controller
{
  public class ControllerManager
  { 
    private ControllerWindows _controllerWindows;
    /// <summary>
    /// Объект менеджера
    /// </summary>
    private static ControllerManager _instance = null;
    /// <summary>
    /// Приватный конструктор
    /// </summary>
    private ControllerManager() { }
    /// <summary>
    /// Метод получения экземпляра 
    /// </summary>
    /// <returns></returns>
    public static ControllerManager GetInstance()
    {
      if (_instance == null)
        _instance = new ControllerManager();
      return _instance;
    }

    bool exitGame = false;

    public void Start()
    {

      //while (!exitGame)
      //{
      //  controller.Execute();
      //  switch (controller.ExitState) { case ...: controller = ...; }
      //}
      _instance._controllerWindows = new ControllerMenuWindows();
    }
  }
}
