using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsConsole
{
  /// <summary>
  /// Представления справки
  /// </summary>
  public class ViewHelpConsole : ConsoleView
  {
    /// <summary>
    /// Отрисовщик
    /// </summary>
    private readonly KernelGraphics _graphics;
    /// <summary>
    /// Модель
    /// </summary>
    private ModelHelp _model;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModel">Модель окна</param>
		public ViewHelpConsole(ModelHelp parModel)
    {
      _model = parModel;
      _graphics = KernelGraphics.Instance;
      Redraw();
    }
    /// <summary>
    /// Перерисовка окна
    /// </summary>
    public override void Redraw()
    {
      PrintHelpText();
      _graphics.Flush();
    }
    /// <summary>
    /// Вывод справки
    /// </summary>
    private void PrintHelpText()
    {
      for (int i = 0; i < _model.HelpText.Length - 20; i++)
      {
        if (i % 32 == 0)
        {
        _graphics.PrintString(1, (short)(1 + (i / 32)), _model.HelpText.Substring(i,32));
        }
      }
      _graphics.PrintString(1, 15, _model.HelpText.Substring(446, 17));
    }
  }
}
