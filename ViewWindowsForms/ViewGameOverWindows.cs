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
  public class ViewGameOverWindows : IViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _drawingThread;
    private StringFormat _textFormat;
    /// <summary>
    /// Поле ввода 
    /// </summary>
    public Rectangle InputRectangle
    {
      get;
      set;
    }
    private Font ScoreFont { get; set; }
    public FontFamily ScoreFontFamily { get; set; }
    public ModelGameOverScreen ModelGameOverScreen { get; set; }
    public Form _form
    {
      get;
      set;
    }

    public ViewGameOverWindows(ModelGameOverScreen parModelGameOverScreen)
    {
      ModelGameOverScreen = parModelGameOverScreen;

      InputRectangle = new Rectangle(30, 110, 200, 35);
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
      _bufferedGraphics.Graphics.DrawString("Enter your name:", ScoreFont, Brushes.Chocolate, 65, 40);
    }
    public void DrawInputField()
    {
      _bufferedGraphics.Graphics.DrawRectangle(Pens.White, InputRectangle);
     // _bufferedGraphics.Graphics.DrawString(nick, ScoreFont, Brushes.Chocolate, InputRectangle, _textFormat);
    }

    public void RedrawCycle()
    {
      while (ModelGameOverScreen.IsRunning)
      {
        _bufferedGraphics.Graphics.Clear(Color.Black);
        DrawTitle();
        DrawInputField();
        _bufferedGraphics.Render();
      }
    }
  }
}
