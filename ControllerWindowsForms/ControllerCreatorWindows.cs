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
          return new ControllerGamePlayWindows();
        case EWindows.GameOver:
          return new ControllerGameOverWindows();
        case EWindows.Records:
          return new ControllerRecordsWindows();
        case EWindows.Help:
          return new ControllerHelpWindows();
        default:
          throw new ArgumentException($"No controller \"{parEWindows.ToString()}\"");
      }
    }
  }
}
