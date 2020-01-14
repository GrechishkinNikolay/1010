using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// Конструктор
    /// </summary>
    /// <param name="parModel">Модель окна</param>
		public GameOverView(GameOverModel parModel) : base(parModel)
    {
      _graphics = KernelGraphics.Instance;
      Redraw();
    }

    /// <summary>
    /// Перерисовка окна
    /// </summary>
    public override void Redraw()
    {
      int middleX = ViewSettings.SCREEN_WIDTH_SYMBOLS / 2;
      int middleY = ViewSettings.SCREEN_HEIGHT_SYMBOLS / 2;

      PrintScore(middleX, middleY);
      PrintNickname(middleX, middleY);
      _graphics.Flush();
    }

    /// <summary>
    /// Вывод счета игрока
    /// </summary>
    /// <param name="parMiddleX">Середина окна по X</param>
    /// <param name="parMiddleY">Середина окна по Y</param>
    private void PrintScore(int parMiddleX, int parMiddleY)
    {
      string str = $"Счет: {_model.Score}";

      int offsetX = -str.Length / 2;
      int x = parMiddleX + offsetX;

      int y = parMiddleY + SCORE_Y_OFFSET;

      _graphics.PrintString((short)x, (short)y, str);
    }

    /// <summary>
    /// Вывод ника игрока
    /// </summary>
    /// <param name="parMiddleX">Середина окна по X</param>
    /// <param name="parMiddleY">Середина окна по Y</param>
    private void PrintNickname(int parMiddleX, int parMiddleY)
    {
      string str = $"Введите ник: {_model.Nickname}";

      int offsetX = -str.Length / 2;
      int x = parMiddleX + offsetX;

      int y = parMiddleY + NICKNAME_Y_OFFSET;

      _graphics.PrintString((short)x, (short)y, str);
    }
  }
}
