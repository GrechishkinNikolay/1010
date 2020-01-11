using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerWindowsForms
{
  class ControllerGameOverWindows : ControllerWindows
  {
    private ModelGameOverScreen _modelGameOverScreen;
    private ViewGamePlayWindows _viewWindows;
    public ControllerGamePlayWindows()
    {
      _modelGameOverScreen = new ModelGamePlay();
      _viewWindows = new ViewGamePlayWindows(_modelGameOverScreen);
      _modelGameOverScreen.IsGame = true;
      _viewWindows._form.KeyDown += OnKeyDown;
    }

    public void GamePlayClosing()
    {
      _modelGameOverScreen.IsGame = false;
      _viewWindows._form.KeyDown -= OnKeyDown;
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          _modelGameOverScreen.PutTheFigure();
          break;
        case Keys.Escape:
          GamePlayClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        case Keys.Left:
          _modelGameOverScreen.MoveFigureLeft();
          break;
        case Keys.Up:
          _modelGameOverScreen.MoveFigureUp();
          break;
        case Keys.Right:
          _modelGameOverScreen.MoveFigureRight();
          break;
        case Keys.Down:
          _modelGameOverScreen.MoveFigureDown();
          break;
        default:
          break;
      }
    }
  }
}

