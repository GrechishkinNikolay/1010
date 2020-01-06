using Controllers;
using ControllerWindowsForms;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewWindowsForms;

namespace ControllerWindowsForms 
{
  public class ControllerManager : Controller
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

    public override EWindows Execute()
    {
      //while (!exitGame)
      //{
      //  controller.Execute();
      //  switch (controller.ExitState) { case ...: controller = ...; }
      //}
      _instance._controllerWindows = new ControllerGamePlayWindows();
      return EWindows.Exit;
    }
  }
}
