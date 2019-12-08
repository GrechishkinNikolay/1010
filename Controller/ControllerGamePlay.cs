using Controller.Delegates;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  public class ControllerGamePlay
  {
    private ModelGamePlay _modelGamePlay;
    public event dMoveRight OnClickButtonRight;
    public event dMoveLeft OnClickButtonLeft;
    public event dMoveUp OnClickButtonUp;
    public event dMoveDown OnClickButtonDown;

    public ControllerGamePlay(ModelGamePlay parModel)
    {
      _modelGamePlay = parModel;
    }


  }
}