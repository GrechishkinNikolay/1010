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
  /// Представления окна справки
  /// </summary>
  public class ViewHelpWindows : IViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    /// <summary>
    /// Поток перерисовки
    /// </summary>
    private Thread _drawingThread;
    /// <summary>
    /// Форматная строка
    /// </summary>
    private StringFormat _textFormat;
    /// <summary>
    /// Шрифт
    /// </summary>
    private Font ScoreFont { get; set; }
    /// <summary>
    /// Семейство шрифтов
    /// </summary>
    public FontFamily ScoreFontFamily { get; set; }
    /// <summary>
    /// Модель окна справки
    /// </summary>
    public ModelHelp ModelHelp { get; set; }
    /// <summary>
    /// Форма
    /// </summary>
    public Form _form { get; set; }
    /// <summary>
    /// Прямоугольник для вывода текста справки
    /// </summary>
    public Rectangle TextHelpRectangle { get; set; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModelHelp">Модель окна справки</param>
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
    /// Отрисовка текста справки 
    /// </summary>
    public void DrawHelpText()
    {
      _bufferedGraphics.Graphics.DrawRectangle(Pens.Black, TextHelpRectangle);
      _bufferedGraphics.Graphics.DrawString(ModelHelp.HelpText, ScoreFont, Brushes.Chocolate, TextHelpRectangle, _textFormat);
    }
    /// <summary>
    /// Цикл перерисовки
    /// </summary>
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
