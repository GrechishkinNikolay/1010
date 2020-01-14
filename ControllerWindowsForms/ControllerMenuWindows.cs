using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  /// <summary>
  /// Контроллер окна меню
  /// </summary>
  public class ControllerMenuWindows : ControllerWindows
  {
    /// <summary>
    /// Представление окна меню
    /// </summary>
    private ViewMenuWindows _viewWindows;
    /// <summary>
    /// Модель меню
    /// </summary>
    private ModelMenu _modelMenu;
    /// <summary>
    /// Конструктор
    /// </summary>
    public ControllerMenuWindows()
    {
      _modelMenu = new ModelMenu();
      _viewWindows = new ViewMenuWindows(_modelMenu);
     _viewWindows._form.KeyDown += OnKeyDown;
    }
    /// <summary>
    /// Завершить работу с окном меню
    /// </summary>
    public void MenuClosing()
    {
      _modelMenu.IsMenu = false;
      _viewWindows._form.KeyDown -= OnKeyDown;
    }
    /// <summary>
    /// Обработчик нажатия на клавиши
    /// </summary>
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Enter:
          MenuClosing();
          ModelMenu.ClickOnSelectedMenuItem();
          break;
        case Keys.Escape:
          ControllerManager.GetInstance().NextWindow = EWindows.Exit;
          break;
        case Keys.Up:
          _modelMenu.MoveMenuPointerUp();
          break;
        case Keys.Down:
          _modelMenu.MoveMenuPointerDown();
          break;
        default:
          break;
      }
    }
  }
}
