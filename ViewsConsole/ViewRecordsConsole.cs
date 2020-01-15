using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewsConsole
{
  /// <summary>
  /// Представление окна рекордов
  /// </summary>
  public class ViewRecordsConsole : ConsoleView
  {
    /// <summary>
    /// Максимальное оличество выводимых игроков в таблице рекордов
    /// </summary>
    private const int MAX_PLAYERS_COUNT = 10;
    /// <summary>
    /// Отрисовщик
    /// </summary>
    private readonly KernelGraphics _graphics;
    /// <summary>
    /// Модель
    /// </summary>
    private ModelRecordsScreen _model;
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModel">Модель окна</param>
		public ViewRecordsConsole(ModelRecordsScreen parModel)
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
      PrintHighscoresTable();
      _graphics.Flush();
    }

    /// <summary>
    /// Вывод таблицы рекордов
    /// </summary>
    private void PrintHighscoresTable()
    {
      List<KeyValuePair<string, int>> sortedHighscores = _model.SortedScores;

      int numberScoreEntries = Math.Min(MAX_PLAYERS_COUNT, sortedHighscores.Count);

      _graphics.PrintString(9, 2, "Игрок      Счет");

      for (int i = 0; i < numberScoreEntries; i++)
      {
        KeyValuePair<string, int> item = sortedHighscores[i];

        string nick = item.Key;
        int score = item.Value;

        _graphics.PrintString(8, (short)(i + 4), nick);
        _graphics.PrintString(21, (short)(i + 4), score.ToString());
      }
    }
  }
}
