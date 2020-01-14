using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControllerWindowsForms;
using Models;
using ViewsConsole;

namespace ControllersConsole
{
  public class ControllerMenuConsole : ConsoleController
  {
    public ModelMenu _model;
    public ViewMenuConsole _view;
    public override EWindows Execute()
    {
      _model = new ModelMenu();
      _view = new ViewMenuConsole(_model);
      _model.IsRunning = true;
      EWindows? nextWindow = null;
      while (nextWindow == null)
      {
        ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
        switch (keyPressedInfo.Key)
        {
          case ConsoleKey.UpArrow:
            _model.MoveMenuPointerUp();
            break;
          case ConsoleKey.DownArrow:
            _model.MoveMenuPointerDown();
            break;
          case ConsoleKey.Escape:
            nextWindow = EWindows.Exit;
            break;
          case ConsoleKey.Enter:
            _model.IsRunning = false;
            nextWindow = (EWindows)_model.SelectedMenuItem;
            break;
        }
      }
      return (EWindows)nextWindow;
    }
  }
}
