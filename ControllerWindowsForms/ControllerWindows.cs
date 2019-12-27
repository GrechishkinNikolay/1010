using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public ControllerWindows()
    {
      ModelGamePlay modelGamePlay = new ModelGamePlay();
      ViewWindows viewWindows = new ViewWindows(modelGamePlay);
      viewWindows.IsGame = true;
    }
  }
}
