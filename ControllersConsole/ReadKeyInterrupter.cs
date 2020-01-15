using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ControllersConsole
{
  /// <summary>
  /// Класс, позволяющий прерывать ввод с клавиатуры
  /// </summary>
  public static class ReadKeyInterrupter
  {
    /// <summary>
    /// Код клавиши F2
    /// </summary>
    private const int VK_F2 = 0x71;

    /// <summary>
    /// Код события KeyDown
    /// </summary>
    private const int WM_KEYDOWN = 0x100;

    /// <summary>
    /// Прерывает ввод с клавиатуры, симулируя нажатие на клавишу F2
    /// </summary>
    public static void InterruptRead()
    {
      IntPtr hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
      PostMessage(hWnd, WM_KEYDOWN, VK_F2, 0);
    }

    [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
    private static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);
  }
}
