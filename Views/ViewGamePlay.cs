using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Views
{
  /// <summary>
  /// Интерфейс игрового окна
  /// </summary>
  public interface IViewGamePlay
  {
    void DrawField();
    void DrawActiveFigure();
    void DrawScore();
    void RedrawCycle();
  }
}
