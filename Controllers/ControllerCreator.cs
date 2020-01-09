using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
  public abstract class ControllerCreator
  {
    public abstract Controller GetController(EWindows parEWindows);
  }
}
