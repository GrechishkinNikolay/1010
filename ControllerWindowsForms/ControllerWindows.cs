using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  public class ControllerWindows
  {
    public ViewWindows ViewWindows
    {
      get;
      set;
    }
    private Thread _threadControl;
    private ModelGamePlay _modelGamePlay;
    private ViewWindows _viewWindows;
    public ControllerWindows()
    {
      _modelGamePlay = new ModelGamePlay();
      _viewWindows = new ViewWindows(_modelGamePlay);
      _modelGamePlay.IsGame = true;
      _viewWindows.GameForm.KeyDown += OnKeyDown;
      _viewWindows.RunForm();
    }
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        throw new Exception();
      }
    }
  }
}
