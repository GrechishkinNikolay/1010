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
  /// Контроллер окна справки
  /// </summary>
  class ControllerHelpWindows : ControllerWindows
  {
    /// <summary>
    /// Модель окна справки
    /// </summary>
    private ModelHelp _modelHelp;
    /// <summary>
    /// Представление окна спраки
    /// </summary>
    private ViewHelpWindows _viewHelp;
    /// <summary>
    /// Конструктор
    /// </summary>
    public ControllerHelpWindows()
    {
      _modelHelp = new ModelHelp();
      _viewHelp = new ViewHelpWindows(_modelHelp);
      _modelHelp.IsRunning = true;
      _viewHelp._form.KeyDown += OnKeyDown;
    }
    /// <summary>
    /// Завершение работы с окном справки
    /// </summary>
    public void RecordsWindowClosing()
    {
      _modelHelp.IsRunning = false;
      _viewHelp._form.KeyDown -= OnKeyDown;
    }
    /// <summary>
    /// Обработчик нажатия на клавиши
    /// </summary>
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Escape:
          RecordsWindowClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        default:
          break;
      }
    }
  }
}
