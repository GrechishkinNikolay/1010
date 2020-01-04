using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  class ControllerManager
  {
    private static ControllerManager _instance = null;
    private ControllerManager() { }
    public static ControllerManager GetInstance()
    {
      if (_instance == null)
        _instance = new ControllerManager();
      return _instance;
    }
  }
}
