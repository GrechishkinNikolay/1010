using Controllers;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewWindowsForms;

namespace ControllerWindowsForms
{
  /// <summary>
  /// Контроллер окна геймплея
  /// </summary>
  public class ControllerGamePlayWindows : ControllerWindows
  {
    /// <summary>
    /// Модель окна геймплея
    /// </summary>
    private ModelGamePlay _modelGamePlay;
    /// <summary>
    /// Представление окна геймплея
    /// </summary>
    private ViewGamePlayWindows _viewWindows;
    /// <summary>
    /// Конструктор
    /// </summary>
    public ControllerGamePlayWindows()
    {
      _modelGamePlay = new ModelGamePlay();
      _viewWindows = new ViewGamePlayWindows(_modelGamePlay);
      _modelGamePlay.IsRunning = true;
      _viewWindows._form.KeyDown += OnKeyDown;
    }
    /// <summary>
    /// Завершение работы с окном геймплея
    /// </summary>
    public void GamePlayClosing()
    {
      _modelGamePlay.IsRunning = false;
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
          if (_modelGamePlay.PutTheFigure())
          {
            GamePlayClosing();
          }
          break;
        case Keys.Escape:
          GamePlayClosing();
          ControllerManager.GetInstance().NextWindow = EWindows.Menu;
          break;
        case Keys.Left:
          _modelGamePlay.MoveFigureLeft();
          break;
        case Keys.Up:
          _modelGamePlay.MoveFigureUp();
          break;
        case Keys.Right:
          _modelGamePlay.MoveFigureRight();
          break;
        case Keys.Down:
          _modelGamePlay.MoveFigureDown();
          break;
        default:  
          break;
      }
    }
  }
}
