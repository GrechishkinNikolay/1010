using Controllers.Delegates;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Views;

namespace Controllers
{
  public class ControllerGamePlay
  {
    private ModelGamePlay _modelGamePlay;
    private IViewGamePlay _viewGamePlay;

    public ControllerGamePlay(ModelGamePlay parModelGamePlay, IViewGamePlay parViewGamePlay)
    {
      _modelGamePlay = parModelGamePlay;
      _viewGamePlay = parViewGamePlay;
    }
  }
}