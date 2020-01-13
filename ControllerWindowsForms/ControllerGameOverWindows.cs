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
  /// Контроллер окна проигрыша
  /// </summary>
  class ControllerGameOverWindows : ControllerWindows
  {
    /// <summary>
    /// Модель окна проигрыша
    /// </summary>
    private ModelGameOverScreen _modelGameOverScreen;
    /// <summary>
    /// Представление окана проигрыша
    /// </summary>
    private ViewGameOverWindows _viewGameOverWindows;
    /// <summary>
    /// Конструктор
    /// </summary>
    public ControllerGameOverWindows()
    {
      _modelGameOverScreen = new ModelGameOverScreen();
      _viewGameOverWindows = new ViewGameOverWindows(_modelGameOverScreen);
      _modelGameOverScreen.IsRunning = true;
      _viewGameOverWindows._form.KeyDown += OnKeyDown;
    }
    /// <summary>
    /// Завершения работы с окном проигрыша
    /// </summary>
    public void GameOverClosing()
    {
      _modelGameOverScreen.IsRunning = false;
      _viewGameOverWindows._form.KeyDown -= OnKeyDown;
    }
    /// <summary>
    /// Обработчик нажатия на клавишу
    /// </summary>
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      char buffer = Convert.ToChar(e.KeyValue);
      InputLanguage l = InputLanguage.CurrentInputLanguage;
      if (e.KeyCode == Keys.Enter)
      {
        if (!String.IsNullOrEmpty(_modelGameOverScreen.LastGameResults.Name))
        {
          _modelGameOverScreen.ScoreManager.UpdateScore(_modelGameOverScreen.LastGameResults.Name, _modelGameOverScreen.LastGameResults.Score);
        }
        GameOverClosing();
        ControllerManager.GetInstance().NextWindow = EWindows.Menu;
      }
      if (e.KeyCode != Keys.Back)
      {
        if (e.Shift)
        {
          _modelGameOverScreen.AddSymbolToName(buffer);
        }
        else
        {
          _modelGameOverScreen.AddSymbolToName(Char.ToLower(buffer));
        }
      }
      if (e.KeyCode == Keys.Back)
      {
        _modelGameOverScreen.DeleteSymbol();
      }
    }
  }
}

