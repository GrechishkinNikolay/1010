using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Views;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  /// <summary>
  /// Контроллер окна рекордов
  /// </summary>
  class ControllerRecordsWindows : ControllerWindows
  {
    /// <summary>
    /// Модель окна рекордов
    /// </summary>
    private ModelRecordsScreen _modelRecordsScreen;
    /// <summary>
    /// Представления окна рекордов
    /// </summary>
    private ViewRecordsWindow _viewRecordsWindow;
    /// <summary>
    /// Конструктор
    /// </summary>
    public ControllerRecordsWindows()
    {
      _modelRecordsScreen = new ModelRecordsScreen();
      _viewRecordsWindow = new ViewRecordsWindow(_modelRecordsScreen);
      _modelRecordsScreen.IsRunning = true;
      _viewRecordsWindow._form.KeyDown += OnKeyDown;
    }
    /// <summary>
    /// Завершение работы с окном рекордов
    /// </summary>
    public void RecordsWindowClosing()
    {
      _modelRecordsScreen.IsRunning = false;
      _viewRecordsWindow._form.KeyDown -= OnKeyDown;
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
