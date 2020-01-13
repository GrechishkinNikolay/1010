using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWindowsForms
{
  /// <summary>
  /// Представление окна рекордов
  /// </summary>
  public class ViewRecordsWindow : IViewWindows
  {
    /// <summary>
    /// 
    /// </summary>
    private const int OUTPUT_PLAYERS_COUNT = 10;
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    /// <summary>
    /// Поток отрисовки
    /// </summary>
    private Thread _drawingThread;
    /// <summary>
    /// Число столбцов таблицы
    /// </summary>
    private const int COUNT_COLUMN = 2;
    /// <summary>
    /// Число строк таблицы
    /// </summary>
    private const int COUNT_ROW = 10;
    /// <summary>
    /// Форматная строка
    /// </summary>
    private StringFormat _textFormat;
    /// <summary>
    /// Число результатов
    /// </summary>
    private int NumberScores { get; set; }
    /// <summary>
    /// Список отсортированных рекордов 
    /// </summary>
    public List<KeyValuePair<string, int>> SortedScores { get; set; }
    /// <summary>
    /// Прямоугольники таблицы
    /// </summary>
    public RectangleF[][] TableRectangles { get; set; }
    /// <summary>
    /// Шрифт
    /// </summary>
    private Font ScoreFont { get; set; }
    /// <summary>
    /// Семейство шрифтов
    /// </summary>
    public FontFamily ScoreFontFamily { get; set; }
    /// <summary>
    /// Модель окна рекордов
    /// </summary>
    public ModelRecordsScreen ModelRecordsScreen { get; set; }
    /// <summary>
    /// Форма
    /// </summary>
    public Form _form { get; set; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModelRecordsScreen">Модель окна рекордов</param>
    public ViewRecordsWindow(ModelRecordsScreen parModelRecordsScreen)
    {
      ModelRecordsScreen = parModelRecordsScreen;

      SortedScores = ModelRecordsScreen.SortedScores;
      NumberScores = Math.Min(OUTPUT_PLAYERS_COUNT, SortedScores.Count);

      TableRectangles = new RectangleF[NumberScores][];
      for (int i = 0; i < NumberScores; i++)
      {
        TableRectangles[i] = new RectangleF[COUNT_COLUMN];
      }
      for (int i = 0; i < TableRectangles.Length; i++)
      {
        for (int j = 0; j < TableRectangles[i].Length; j++)
        {
          TableRectangles[i][j].Width = 120;
          TableRectangles[i][j].Height = 35;
          TableRectangles[i][j].X = 45 + j * 120;
          TableRectangles[i][j].Y = 35 * i + 40;
        }
      }
      ScoreFontFamily = new FontFamily("Impact");
      ScoreFont = new Font(ScoreFontFamily, 16);
      _textFormat = new StringFormat();
      _textFormat.Alignment = StringAlignment.Center;
      _textFormat.LineAlignment = StringAlignment.Center;

      InitForm();
      _drawingThread = new Thread(RedrawCycle);
      _drawingThread.IsBackground = true;
      _drawingThread.Start();
    }
    /// <summary>
    /// Инициализация формы
    /// </summary>
    public void InitForm()
    {
      _form = Application.OpenForms[0];
      Graphics targetgraphics = _form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, _form.Width, _form.Height));
    }
    /// <summary>
    /// Отрисвоать надпись "Players records"
    /// </summary>
    public void DrawTitle()
    {
      _bufferedGraphics.Graphics.DrawString("Players records", ScoreFont, Brushes.Chocolate, 95, 5);
    }
    /// <summary>
    /// Отрисовать результаты игровков
    /// </summary>
    public void DrawScores()
    {
      for (int i = 0; i < NumberScores; i++)
      {
        KeyValuePair<string, int> item = SortedScores[i];

        string nick = item.Key;
        int score = item.Value;

        _bufferedGraphics.Graphics.DrawRectangles(Pens.White, TableRectangles[i]);
        _bufferedGraphics.Graphics.DrawString(nick, ScoreFont, Brushes.Chocolate, TableRectangles[i][0], _textFormat);
        _bufferedGraphics.Graphics.DrawString(score.ToString(), ScoreFont, Brushes.Chocolate, TableRectangles[i][1], _textFormat);
      }
    }
    /// <summary>
    /// Цикл перерисвоки 
    /// </summary>
    public void RedrawCycle()
    {
      while (ModelRecordsScreen.IsRunning)
      {
        _bufferedGraphics.Graphics.Clear(Color.Black);
        DrawTitle();
        DrawScores();
        _bufferedGraphics.Render();
      }
    }
  }
}
