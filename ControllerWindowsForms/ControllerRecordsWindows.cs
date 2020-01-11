using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  class ControllerRecordsWindows : ControllerWindows
  {
    private ModelRecordsScreen _modelRecordsScreen;
    private ViewRecordsWindow _viewRecordsWindow;
    public ControllerRecordsWindows()
    {
      _modelRecordsScreen = new ModelRecordsScreen();
      _viewRecordsWindow = new ViewRecordsWindow(_modelRecordsScreen);
      _modelRecordsScreen.IsRunning = true;
      _viewRecordsWindow._form.KeyDown += OnKeyDown;
    }

    public void RecordsWindowClosing()
    {
      _modelRecordsScreen.IsRunning = false;
      _viewRecordsWindow._form.KeyDown -= OnKeyDown;
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
