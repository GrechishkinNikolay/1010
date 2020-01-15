using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ViewsConsole
{
  public class ViewGameOverConsole : ConsoleView
  {
    /// <summary>
    /// Отрисовщик
    /// </summary>
    private readonly KernelGraphics _graphics;
    /// <summary>
    /// Поток отрисовки
    /// </summary>
    private Thread _RedrawThread;
    private ModelGameOverScreen _model;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModel">Модель окна</param>
		public ViewGameOverConsole(ModelGameOverScreen parModel)
    {
      _graphics = KernelGraphics.Instance;
      _model = parModel;
      _RedrawThread = new Thread(new ThreadStart(Redraw));
      _RedrawThread.IsBackground = true;
      _RedrawThread.Start();
    }
    /// <summary>
    /// Перерисовка окна
    /// </summary>
    public override void Redraw()
    {
      while (_model.IsRunning)
      {
        PrintScore();
        PrintNickname();
        _graphics.Flush();
      }
      _graphics.Clear();
    }
    /// <summary>
    /// Вывод счета игрока
    /// </summary>
    private void PrintScore()
    {
      _graphics.PrintString(2, 6, "Счет: " + _model.LastGameResults.Score.ToString());
    }
    /// <summary>
    /// Вывод ника игрока
    /// </summary>
    private void PrintNickname()
    {
      _graphics.PrintString(2, 7, $"Введите ник: {_model.LastGameResults.Name}");
    }
  }
}
