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
  class ControllerGameOverWindows : ControllerWindows
  {
    private ModelGameOverScreen _modelGameOverScreen;
    private ViewGameOverWindows _viewGameOverWindows;
    public ControllerGameOverWindows()
    {
      _modelGameOverScreen = new ModelGameOverScreen();
      _viewGameOverWindows = new ViewGameOverWindows(_modelGameOverScreen);
      _modelGameOverScreen.IsRunning = true;
      _viewGameOverWindows._form.KeyDown += OnKeyDown;
    }

    public void GamePlayClosing()
    {
      _modelGameOverScreen.IsRunning = false;
      _viewGameOverWindows._form.KeyDown -= OnKeyDown;
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          GamePlayClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        case Keys.Escape:
          GamePlayClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        default:
          break;
      }
    }
  }
}

