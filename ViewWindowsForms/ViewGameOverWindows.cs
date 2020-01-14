﻿using Models;
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
  /// Представление окна проигрыша
  /// </summary>
  public class ViewGameOverWindows : IViewWindows
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
    /// Поле ввода 
    /// </summary>
    public Rectangle InputRectangle { get; set; }
    /// <summary>
    /// Шрифт
    /// </summary>
    private Font ScoreFont { get; set; }
    /// <summary>
    /// Семейство шрифтов
    /// </summary>
    public FontFamily ScoreFontFamily { get; set; }
    /// <summary>
    /// Модель окна проигрыша
    /// </summary>
    public ModelGameOverScreen ModelGameOverScreen { get; set; }
    /// <summary>
    /// Форма
    /// </summary>
    public Form _form { get; set; }
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parModelGameOverScreen"></param>
    public ViewGameOverWindows(ModelGameOverScreen parModelGameOverScreen)
    {
      ModelGameOverScreen = parModelGameOverScreen;

      InputRectangle = new Rectangle(60, 110, 205, 35);
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
    /// Отрисовать надпись "Enter your name:"
    /// </summary>
    public void DrawTitle()
    {
      _bufferedGraphics.Graphics.DrawString("Enter your name:", ScoreFont, Brushes.Chocolate, 65, 40);
    }
    /// <summary>
    /// Отрисовать поле ввода
    /// </summary>
    public void DrawInputField()
    {
      _bufferedGraphics.Graphics.DrawRectangle(Pens.White, InputRectangle);
      _bufferedGraphics.Graphics.DrawString(ModelGameOverScreen.LastGameResults.Name, ScoreFont, Brushes.Chocolate, InputRectangle, _textFormat);
    }
    /// <summary>
    /// Метод перерисовки 
    /// </summary>
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
