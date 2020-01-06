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
      _modelMenu.IsMenu = true;
      _viewWindows.Form.KeyDown += OnKeyDown;
    }
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          //_modelMenu.ClickOnSelectedMenuItem(); ToDo
          ControllerManager.GetInstance().NextWindow = EWindows.GamePlay;
          break;
        case Keys.Escape:
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
