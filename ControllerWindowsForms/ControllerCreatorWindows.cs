using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerWindowsForms
{
  class ControllerCreatorWindows : ControllerCreator
  {
    public override Controller GetController(EWindows parEWindows)
    {
      switch (parEWindows)
      {
        case EWindows.Menu:
          return new ControllerMenuWindows();
        case EWindows.GamePlay:
          break;
        case EWindows.GameOver:
          break;
        case EWindows.Records:
          break;
        case EWindows.Help:
          break;
        case EWindows.Exit:
          break;
        default:
          break;
      }
    }
  }
}
