﻿using Model;
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
    public static Form GameForm
    {
      get;
      set;
    }
    

    public ViewWindows()
    {
      GameForm = new Form();
      GameForm.Height = 400;
      GameForm.Width = 500;
      GameForm.FormBorderStyle = FormBorderStyle.FixedSingle;
      PanelDrawing = new Panel();
      PanelDrawing.Location = new Point(5, 5);
      GameForm.Controls.Add(PanelDrawing);
      Graphics targetgraphics = PanelDrawing.CreateGraphics();
      Rectangle targetrectangle = PanelDrawing.ClientRectangle;
      _bufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetgraphics, targetrectangle);
      FieldRectangles = new RectangleF[COUNT_ROW][];
      for (int i = 0; i < COUNT_ROW; i++)
      {
        FieldRectangles[i] = new RectangleF[COUNT_COLUMN];
      }
      IsGame = true;
      _DrawingThread = new Thread(RedrawCycle);
      _DrawingThread.IsBackground = true;
      Application.Run(GameForm);
    }

    public void RedrawCycle()
    {
      while (IsGame)
      {

      }
    }
  }
}
