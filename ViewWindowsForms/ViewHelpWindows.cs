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
    class ViewHelpWindows : IViewWindows
  {
    private const int OUTPUT_PLAYERS_COUNT = 10;
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _drawingThread;
    private StringFormat _textFormat;
    /// <summary>
    /// Список отсортированных рекордов 
    /// </summary>
    public List<KeyValuePair<string, int>> SortedScores { get; set; }
    /// <summary>
    /// Прямоугольники 
    /// </summary>
    public RectangleF LabelRectangle { get; set; }
    private Font ScoreFont { get; set; }
    public FontFamily ScoreFontFamily { get; set; }

    public ModelHelpScreen ModelRecordsScreen { get; set; }
    public Form _form
    {
      get;
      set;
    }

    public ViewRecordsWindow(ModelRecordsScreen parModelRecordsScreen)
    {
      ModelRecordsScreen = parModelRecordsScreen;

      SortedScores = ModelRecordsScreen.SortedScores;
      NumberScores = Math.Min(OUTPUT_PLAYERS_COUNT, SortedScores.Count);

      LabelRectangle = new RectangleF[NumberScores][];
      for (int i = 0; i < NumberScores; i++)
      {
        LabelRectangle[i] = new RectangleF[COUNT_COLUMN];
      }
      for (int i = 0; i < LabelRectangle.Length; i++)
      {
        for (int j = 0; j < LabelRectangle[i].Length; j++)
        {
          LabelRectangle[i][j].Width = 120;
          LabelRectangle[i][j].Height = 35;
          LabelRectangle[i][j].X = 45 + j * 120;
          LabelRectangle[i][j].Y = 35 * i + 40;
        }
      }
      ScoreFontFamily = new FontFamily("Impact");
      ScoreFont = new Font(ScoreFontFamily, 20);
      _textFormat = new StringFormat();
      _textFormat.Alignment = StringAlignment.Center;
      _textFormat.LineAlignment = StringAlignment.Center;

      InitForm();
      _drawingThread = new Thread(RedrawCycle);
      _drawingThread.IsBackground = true;
      _drawingThread.Start();
    }

    public void InitForm()
    {
      _form = Application.OpenForms[0];
      Graphics targetgraphics = _form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, _form.Width, _form.Height));
    }

    public void DrawTitle()
    {
      _bufferedGraphics.Graphics.DrawString("Players records", ScoreFont, Brushes.Chocolate, 70, 5);
    }
    public void DrawScores()
    {
      for (int i = 0; i < NumberScores; i++)
      {
        KeyValuePair<string, int> item = SortedScores[i];

        string nick = item.Key;
        int score = item.Value;

        _bufferedGraphics.Graphics.DrawRectangles(Pens.White, LabelRectangle[i]);
        _bufferedGraphics.Graphics.DrawString(nick, ScoreFont, Brushes.Chocolate, LabelRectangle[i][0], _textFormat);
        _bufferedGraphics.Graphics.DrawString(score.ToString(), ScoreFont, Brushes.Chocolate, LabelRectangle[i][1], _textFormat);
      }
    }

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
