using ControllerWindowsForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartConsole
{
  /// <summary>
  /// Класс запуска программы
  /// </summary>
  class Program
  {
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    /// <param name="args">Параметры запуска</param>
    static void Main(string[] args)
    {
      ControllerManager.GetInstance().Execute();
    }
  }
}
