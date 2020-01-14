using ViewsConsole;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ViewsConsole
{
  public class ViewMenuConsole : ConsoleView
  {
    /// <summary>
    /// Цвет не выделенного пункта меню
    /// </summary>
    private const ConsoleColor UNSELECTED_MENU_ITEM_COLOR = ConsoleColor.White;
    /// <summary>
    /// Цвет выделенного пункта меню
    /// </summary>
    private const ConsoleColor SELECTED_MENU_ITEM_COLOR = ConsoleColor.Yellow;
    public ModelMenu _model;
    /// <summary>
    /// Поток отрисовки
    /// </summary>
    private Thread _RedrawThread;
    /// <summary>
    /// Отрисовщик
    /// </summary>
    private readonly KernelGraphics _graphics;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModel">Модель окна</param>
		public ViewMenuConsole(ModelMenu parModel)
    {
      _model = parModel;
      _graphics = KernelGraphics.Instance;

      _RedrawThread = new Thread(new ThreadStart(Redraw));
      _RedrawThread.IsBackground = true;
      _RedrawThread.Start();
    }

    /// <summary>
    /// Перерисовка окна
    /// </summary>
    public void Redraw()
    {
      DrawMenuItems();
      _graphics.Flush();
      Thread.Sleep(1000 / FPS);
    }

    /// <summary>
    /// Вывод пунктов меню
    /// </summary>
    private void DrawMenuItems()
    {
      int middleX = _graphics.SCREEN_WIDTH_SYMBOLS / 2;
      int middleY = _graphics.SCREEN_HEIGHT_SYMBOLS / 2;

      int menuItemsOffsetY = (int)Math.Ceiling(_model.MenuItems.Count / 2.0f);
      int y = middleY - menuItemsOffsetY;

      for (int i = 0; i < _model.MenuItems.Count; i++)
      {

        int itemOffsetX = _model.MenuItems[i].Length / 2;
        int x = middleX - itemOffsetX;

        bool itemSelected = _model.SelectedMenuItem == i;
        ConsoleColor color = itemSelected ? SELECTED_MENU_ITEM_COLOR : UNSELECTED_MENU_ITEM_COLOR;

        _graphics.PrintString((short)x, (short)y, _model.MenuItems[i], color);

        y++;
      }
    }
  }
}

