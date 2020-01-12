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
  class ControllerHelpWindows : ControllerWindows
  {
    private ModelHelp _modelHelp;
    private ViewHelpWindows _viewHelp;
    public ControllerHelpWindows()
    {
      _modelHelp = new ModelHelp();
      _viewHelp = new ViewHelpWindows(_modelHelp);
      _modelHelp.IsRunning = true;
      _viewHelp._form.KeyDown += OnKeyDown;
    }

    public void RecordsWindowClosing()
    {
      _modelHelp.IsRunning = false;
      _viewHelp._form.KeyDown -= OnKeyDown;
    }

    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape:
          RecordsWindowClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        default:
          break;
      }
    }
  }
}
