using Controller;
using ControllerWindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartBlockPuzzle
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      ControllerManager controllerManager = ControllerManager.GetInstance();
      controllerManager.Execute();
      //ControllerGamePlayWindows controllerWindows = new ControllerGamePlayWindows();
    }
  }
}
