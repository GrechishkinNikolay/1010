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
  class ViewRecordsWindow : IViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _bufferedGraphics = null;
    private Thread _drawingThread;
    private const int COUNT_COLUMN = 2;
    public const int COUNT_ROW = 10;
    /// <summary>
    /// Прямоугольники 
    /// </summary>
    public RectangleF[][] FieldRectangles
    {
      get;
      set;
    }
    private Font ScoreFont { get; set; }
    public FontFamily ScoreFontFamily { get; set; }
    public ModelRecordsScreen ModelRecordsScreen { get; set; }
    public Form _form
    {
      get;
      set;
    }


    public ViewRecordsWindow(ModelRecordsScreen parModelRecordsScreen)
    {
      //ModelRecordsScreen = parModelRecordsScreen;
      //FieldRectangles = new RectangleF[COUNT_ROW][];
      //for (int i = 0; i < COUNT_ROW; i++)
      //{
      //  FieldRectangles[i] = new RectangleF[COUNT_COLUMN];
      //}
      //for (int i = 0; i < FieldRectangles.Length; i++)
      //{
      //  for (int j = 0; j < FieldRectangles[i].Length; j++)
      //  {
      //    FieldRectangles[i][j].Width = 50;
      //    FieldRectangles[i][j].Height = 35;
      //    FieldRectangles[i][j].X = FORM_WIDTH / 2 - (MenuItemRectangles[i].Width / 2);
      //    FieldRectangles[i][j].Y = 32 * i + 60;
      //  }
      //}
      //ScoreFontFamily = new FontFamily("Impact");
      //ScoreFont = new Font(ScoreFontFamily, 30);
      //InitForm();
      //_drawingThread = new Thread(RedrawCycle);
      //_drawingThread.IsBackground = true;
      //_drawingThread.Start();
    }

    public void InitForm()
    {
      _form = Application.OpenForms[0];
      Graphics targetgraphics = _form.CreateGraphics();
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, new Rectangle(0, 0, _form.Width, _form.Height));
    }
    
    public void DrawScore()
    {
     // _bufferedGraphics.Graphics.DrawString("Score: " + ModelRecordsScreen.Score, ScoreFont, Brushes.Chocolate, 10, 10);
    }

    public void RedrawCycle()
    {
      //while (ModelRecordsScreen.IsGame)
      //{
      //  _bufferedGraphics.Graphics.Clear(Color.Black);
      //  DrawField();
      //  DrawActiveFigure();
      //  DrawScore();
      //  _bufferedGraphics.Render();
      //}
    }
  }
}
