using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
  public interface IViewGamePlay
  {
    void DrawField();
    void DrawActiveFigure();
    void DrawScore();
    void RedrawCycle();
  }
}
