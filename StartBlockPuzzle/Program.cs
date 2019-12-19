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
      Application.Run(new );
    }
  }
}
class Program
{
  private static void Main(string[] args)
  {
    ThreadsTest threadsTest = new ThreadsTest();
    threadsTest.Execute();
  }
}

class ThreadsTest
{
  private volatile bool IsRunning;

  public void Execute()
  {
    IsRunning = true;
    Thread th = new Thread(ThreadLoop);
    th.IsBackground = true;

    Console.WriteLine("MAIN: Starting thread");
    th.Start();

    Console.WriteLine("MAIN: Waiting");
    Thread.Sleep(1000);

    Console.WriteLine("MAIN: Stopping thread");
    IsRunning = false;

    Console.WriteLine("MAIN: Waiting for keypress to exit");
    Console.ReadKey();
  }
  private void ThreadLoop()
  {
    Console.WriteLine("THREAD: Starting");
    while (IsRunning)
    {
      Console.WriteLine("THREAD: Doing something");
      Thread.Sleep(100);
    }
    Console.WriteLine("THREAD: Exiting");
  }
}
