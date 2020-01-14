using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ControllersConsole
{
  public class ControllerGameOverConsole : ConsoleController
  {
    //  /// <summary>
    //  /// Отображение окна
    //  /// </summary>
    //  private GameOverView _view;

    //  /// <summary>
    //  /// Запуск контроллера
    //  /// </summary>
    //  /// <returns>окно, на которое нужно перейти после выполнения метода</returns>
    //  public override Window Execute()
    //  {
    //    _model = new GameOverModel();
    //    _view = new GameOverView(_model);

    //    bool exit = false;
    //    while (!exit)
    //    {
    //      ConsoleKeyInfo keyPressedInfo = Console.ReadKey(true);
    //      ConsoleKey keyPressed = keyPressedInfo.Key;

    //      char? keyAsChar = ConsoleKeyToChar(keyPressed);

    //      if (keyPressed == ConsoleKey.Enter)
    //      {
    //        exit = true;
    //      }
    //      else if (keyAsChar != null)
    //      {
    //        _model.Nickname.Append(keyAsChar);
    //        _view.Redraw();
    //      }
    //    }

    //    _model.UpdatePlayerScore();

    //    return Window.MainMenu;
    //  }

    //  /// <summary>
    //  /// Преобразует константу из перечисление ConsoleKey в char, если это возможно,
    //  /// иначе возвращает null
    //  /// </summary>
    //  /// <param name="parKey">Константа ConsoleKey, которая будет преобразовываться</param>
    //  /// <returns>константа ConsoleKey, преобразованная в char, если это возможно,
    //  /// иначе null</returns>
    //  private char? ConsoleKeyToChar(ConsoleKey parKey)
    //  {
    //    bool alphaKey = parKey >= ConsoleKey.A && parKey <= ConsoleKey.Z;
    //    bool numericKey = parKey >= ConsoleKey.D0 && parKey <= ConsoleKey.D9;

    //    char? result = null;
    //    if (alphaKey)
    //    {
    //      int offset = (int)parKey - (int)ConsoleKey.A;
    //      result = (char)('A' + offset);
    //    }
    //    else if (numericKey)
    //    {
    //      int offset = (int)parKey - (int)ConsoleKey.D0;
    //      result = (char)('0' + offset);
    //    }

    //    return result;
    //  }
    public override EWindows Execute()
    {
      throw new NotImplementedException();
    }
  }
}
