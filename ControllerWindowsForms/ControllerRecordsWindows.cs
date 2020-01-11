using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerWindowsForms
{
  class ControllerRecordsWindows : ControllerWindows
  {
    private ModelGamePlay _modelGamePlay;
    private ViewGamePlayWindows _viewWindows;
    public ControllerGamePlayWindows()
    {
      _modelGamePlay = new ModelGamePlay();
      _viewWindows = new ViewGamePlayWindows(_modelGamePlay);
      _modelGamePlay.IsGame = true;
      _viewWindows._form.KeyDown += OnKeyDown;
    }

    public void GamePlayClosing()
    {
      _modelGamePlay.IsGame = false;
      _viewWindows._form.KeyDown -= OnKeyDown;
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          _modelGamePlay.PutTheFigure();
          break;
        case Keys.Escape:
          GamePlayClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        case Keys.Left:
          _modelGamePlay.MoveFigureLeft();
          break;
        case Keys.Up:
          _modelGamePlay.MoveFigureUp();
          break;
        case Keys.Right:
          _modelGamePlay.MoveFigureRight();
          break;
        case Keys.Down:
          _modelGamePlay.MoveFigureDown();
          break;
        default:
          break;
      }
    }
  }
  
}
