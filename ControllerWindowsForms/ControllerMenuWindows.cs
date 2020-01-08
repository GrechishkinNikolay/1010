using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  public class ControllerMenuWindows : ControllerWindows
  {
    private ViewMenuWindows _viewWindows;
    private ModelMenu _modelMenu;

    public ControllerMenuWindows()
    {
      _modelMenu = new ModelMenu();
      _viewWindows = new ViewMenuWindows(_modelMenu);
     _viewWindows._form.KeyDown += OnKeyDown;
    }
    public void AppClosing()
    {
      _modelMenu.IsMenu = false;
      _viewWindows._form.KeyDown -= OnKeyDown;
      Application.ExitThread();
    }
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          _modelMenu.ClickOnSelectedMenuItem();
          break;
        case Keys.Escape:
          ControllerManager.GetInstance().NextWindow = EWindows.Exit;
          break;
        case Keys.Up:
          _modelMenu.MoveMenuPointerUp();
          break;
        case Keys.Down:
          _modelMenu.MoveMenuPointerDown();
          break;
        default:
          break;
      }
    }
  }
}
