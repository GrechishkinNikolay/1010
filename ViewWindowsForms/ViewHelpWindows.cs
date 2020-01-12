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
  public class ViewHelpWindows : IViewWindows
  {
    private const int OUTPUT_PLAYERS_COUNT = 10;
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _drawingThread;
    private StringFormat _textFormat;
    private Font ScoreFont { get; set; }
    public FontFamily ScoreFontFamily { get; set; }

    public ModelHelp ModelHelp { get; set; }
    public Form _form
    {
      get;
      set;
    }
    public Rectangle TextHelpRectangle { get; set; }

    public ViewHelpWindows(ModelHelp parModelHelp)
    {
      ModelHelp = parModelHelp;
      ScoreFontFamily = new FontFamily("Impact");
      ScoreFont = new Font(ScoreFontFamily, 14);
      TextHelpRectangle = new Rectangle(0, 0, 330, 400);
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

    public void DrawHelpText()
    {
      _bufferedGraphics.Graphics.DrawRectangle(Pens.Black, TextHelpRectangle);
      _bufferedGraphics.Graphics.DrawString(ModelHelp.HelpText, ScoreFont, Brushes.Chocolate, TextHelpRectangle, _textFormat);
    }

    public void RedrawCycle()
    {
      while (ModelHelp.IsRunning)
      {
        _bufferedGraphics.Graphics.Clear(Color.Black);
        DrawHelpText();
        _bufferedGraphics.Render();
      }
    }
  }
}
