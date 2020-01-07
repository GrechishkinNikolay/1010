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
  public class ViewMenuWindows : IViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _drawingThread;
    /// <summary>
    /// Прямоугольники 
    /// </summary>
    public RectangleF[] MenuItemRectangles
    {
      get;
      set;
    }
    private Font ScoreFont { get; set; }
    public FontFamily ScoreFontFamily { get; set; }
    public ModelMenu ModelMenu { get; set; }
    public Form Form { get; set; }

    public ViewMenuWindows(ModelMenu parModelMenu)
    {
      ModelMenu = parModelMenu;
      if (Application.OpenForms.Count == 0)
      {
        Form = new Form();
      }
      else
      {
        Form = Application.OpenForms[0];
      }
      Form.Height = 500;
      Form.Width = 345;
      Form.FormBorderStyle = FormBorderStyle.FixedSingle;

      Graphics targetgraphics = Form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, Form.Width, Form.Height));
      MenuItemRectangles = new RectangleF[ModelMenu.MenuItems.Capacity];
      for (int i = 0; i < MenuItemRectangles.Length; i++)
      {
        MenuItemRectangles[i] = new RectangleF();
        MenuItemRectangles[i].Width = 120;
        MenuItemRectangles[i].Height = 50;
        MenuItemRectangles[i].X = Form.Width / 2 - (MenuItemRectangles[i].Width / 2);
        MenuItemRectangles[i].Y = 90 * i + 40;
      }
      ModelMenu.IsMenu = true;
      ScoreFontFamily = new FontFamily("Impact");
      ScoreFont = new Font(ScoreFontFamily, 30);
      _drawingThread = new Thread(RedrawCycle);
      _drawingThread.IsBackground = true;
      _drawingThread.Start();
      if (Application.OpenForms.Count == 0)
      {
        Thread the = new Thread(() => { Application.Run(Form); });
        the.Start();
      }
    }
    public void RunForm()
    {
      if (Form.InvokeRequired)
      {
        Form.Invoke(_redrawFormElements);
      }
      else
      {
        _redrawFormElements();
      }
      Application.Run(Form);
    }
    public void ShowMenuItems()
    {
      _bufferedGraphics.Graphics.DrawRectangles(Pens.White, MenuItemRectangles);
      _bufferedGraphics.Graphics.FillRectangle(Brushes.Chocolate, MenuItemRectangles[ModelMenu.SelectedMenuItem]);
    }
    public void RedrawCycle()
    {
      while (ModelMenu.IsMenu)
      {
        _bufferedGraphics.Graphics.Clear(Color.Black);
        ShowMenuItems();
        _bufferedGraphics.Render();
      }
    }

  }


}
