﻿using ControllerWindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartConsole
{
  class Program
  {
    static void Main(string[] args)
    {
      ControllerManager.GetInstance().Execute();
    }
  }
}
