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

    public void GameOverClosing()
    {
      _modelGameOverScreen.IsRunning = false;
      _viewGameOverWindows._form.KeyDown -= OnKeyDown;
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      char buffer = Convert.ToChar(e.KeyValue);
      InputLanguage l = InputLanguage.CurrentInputLanguage;
      if (e.KeyCode == Keys.Enter)
      {
        if (!String.IsNullOrEmpty(_modelGameOverScreen.LastGameResults.Name))
        {
          _modelGameOverScreen.ScoreManager.UpdateScore(_modelGameOverScreen.LastGameResults.Name, _modelGameOverScreen.LastGameResults.Score);
        }
        GameOverClosing();
        ControllerManager.GetInstance().NextWindow = EWindows.Menu;
      }
      if (e.KeyCode != Keys.Back)
      {
        if (e.Shift)
        {
          _modelGameOverScreen.AddSimbolToName(buffer);
        }
        else
        {
          _modelGameOverScreen.AddSimbolToName(Char.ToLower(buffer));
        }
      }
      if (e.KeyCode == Keys.Back)
      {
        _modelGameOverScreen.DeleteSymbol();
      }

    }
  }
}

