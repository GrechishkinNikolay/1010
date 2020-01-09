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
    public const int FORM_WIDTH = 330;
    public const int FORM_HEIGHT = 400;
    private StringFormat _textFormat;
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _RunFormThread;
    private Thread _RedrawThread;
    private delegate void _dRedraw();
    private _dRedraw _redrawCicle;
    /// <summary>
    /// Прямоугольники 
    /// </summary>
    public RectangleF[] MenuItemRectangles
    {
      get;
      set;
    }
    private Font Font { get; set; }
    public FontFamily ScoreFontFamily { get; set; }
    public ModelMenu ModelMenu { get; set; }
    public Form _form { get; set; }

    public ViewMenuWindows(ModelMenu parModelMenu)
    {
      ModelMenu = parModelMenu;
      MenuItemRectangles = new RectangleF[ModelMenu.MenuItems.Capacity];
      for (int i = 0; i < MenuItemRectangles.Length; i++)
      {
        MenuItemRectangles[i] = new RectangleF();
        MenuItemRectangles[i].Width = 120;
        MenuItemRectangles[i].Height = 50;
        MenuItemRectangles[i].X = FORM_WIDTH / 2 - (MenuItemRectangles[i].Width / 2);
        MenuItemRectangles[i].Y = 90 * i + 40;
      }
      ModelMenu.IsMenu = true;
      ScoreFontFamily = new FontFamily("Impact");
      Font = new Font(ScoreFontFamily, 20);
      _textFormat = new StringFormat();
      _textFormat.Alignment = StringAlignment.Center;
      _textFormat.LineAlignment = StringAlignment.Center;
      _redrawCicle = RedrawCycle;

      if (Application.OpenForms.Count == 0)
      {
        _RunFormThread = new Thread(new ThreadStart(InitForm));
        _RunFormThread.IsBackground = true;
        _RunFormThread.Start();
      }
      else
      {
        TakeAlreadyCreatedForm();
      }
      while (Application.OpenForms.Count == 0) { }
      _RedrawThread = new Thread(new ThreadStart(RedrawCycle));
      _RedrawThread.IsBackground = true;
      _RedrawThread.Start();
    }
    public void InitForm()
    {
      _form = new Form();
      _form.Height = FORM_HEIGHT;
      _form.Width = FORM_WIDTH;
      _form.FormBorderStyle = FormBorderStyle.None;
      _form.StartPosition = FormStartPosition.CenterScreen;
      Graphics targetgraphics = _form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, _form.Width, _form.Height));
      Application.Run(_form);
    }
    public void TakeAlreadyCreatedForm()
    {
      _form = Application.OpenForms[0];
      Graphics targetgraphics = _form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, _form.Width, _form.Height));
    }
    public void ShowMenuItems()
    {
      _bufferedGraphics.Graphics.DrawRectangles(Pens.White, MenuItemRectangles);
      _bufferedGraphics.Graphics.FillRectangle(Brushes.Chocolate, MenuItemRectangles[ModelMenu.SelectedMenuItem]);
      for (int i = 0; i < ModelMenu.MenuItems.Capacity; i++)
      {
        _bufferedGraphics.Graphics.DrawString(ModelMenu.MenuItems[i], Font, Brushes.White, MenuItemRectangles[i], _textFormat);
      }
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
