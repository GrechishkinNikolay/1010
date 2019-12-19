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
  class ViewWindows
  {
    /// <summary>
    /// Рисование с использованием технологии двойной буферизации
    /// </summary>
    private BufferedGraphics _BufferedGraphics = null;
    public RectangleF[][] FieldRectangles
    {
      get;
      set;
    }

    public Form GameForm
    {
      get;
      set;
    }
    private Thread thread;

    public ViewWindows()
    {
      GameForm = new Form();
      GameForm.FormBorderStyle = FormBorderStyle.FixedSingle;
      Graphics targetGraphics = _PanelDrawing.CreateGraphics();
      Rectangle targetRectangle = _PanelDrawing.ClientRectangle;
      _BufferedGraphics = BufferedGraphicsManager.Current.Allocate(targetGraphics, targetRectangle);
      FieldRectangles = new RectangleF[][];
    }
  }
}
