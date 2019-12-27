using Model;
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
  public class ViewWindows
  {
    private const int COUNT_COLUMN = 10;
    private const int COUNT_ROW = 10;
    /// <summary>
    /// Координаты правой границы
    /// </summary>
    private float _Right = 0.0F;
    /// <summary>
    /// Координаты нижней границы
    /// </summary>
    private float _Bottom = 0.0F;
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    Panel _PanelDrawing;
    public Panel PanelDrawing { get; set; }
    private BufferedGraphics _bufferedGraphics = null;
    private volatile bool _isGame;
    private Thread _DrawingThread;
    public bool IsGame
    {
      get { return _isGame; }
      set { _isGame = value; }
    }
    public RectangleF[][] FieldRectangles
    {
      get;
      set;
    }
    public ModelGamePlay ModelGamePlay { get; set; }
    public static Form GameForm
    {
      get;
      set;
    }


    public ViewWindows(ModelGamePlay parModelGamePlay)
    {
      ModelGamePlay = parModelGamePlay;
      GameForm = new Form();
      GameForm.Height = 440;
      GameForm.Width = 350;
      //GameForm.FormBorderStyle = FormBorderStyle.FixedSingle;

      Graphics targetgraphics = GameForm.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(
        targetgraphics,
        new Rectangle(0, 0, GameForm.Width, GameForm.Height));
      FieldRectangles = new RectangleF[COUNT_ROW][];
      for (int i = 0; i < COUNT_ROW; i++)
      {
        FieldRectangles[i] = new RectangleF[COUNT_COLUMN];
      }
      for (int i = 0; i < FieldRectangles.Length; i++)
      {
        for (int j = 0; j < FieldRectangles[i].Length; j++)
        {
          FieldRectangles[i][j].Width = 30;
          FieldRectangles[i][j].Height = 30;
          FieldRectangles[i][j].X = 32 * i + 5;
          FieldRectangles[i][j].Y = 32 * j + 60;
        }
      }
      IsGame = true;
      _DrawingThread = new Thread(RedrawCycle);
      _DrawingThread.IsBackground = true;
      _DrawingThread.Start();
      Application.Run(GameForm);
    }

    public void ShowField()
    {
      for (int i = 0; i < FieldRectangles.Length; i++)
      {
        for (int j = 0; j < FieldRectangles[i].Length; j++)
        {
          _bufferedGraphics.Graphics.DrawRectangle(Pens.Gray, Rectangle.Ceiling(FieldRectangles[i][j]));
        }
      }
    }

    public void RedrawCycle()
    {
      while (IsGame)
      {
        _bufferedGraphics.Graphics.Clear(Color.Black);

        ShowField();
        _bufferedGraphics.Render();
      }
    }
  }
}
