using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWindowsForms
{
  /// <summary>
  /// Интерфейс представлений
  /// </summary>
  public interface IViewWindows
  {
    /// <summary>
    /// Метод перерисовки
    /// </summary>
    void RedrawCycle();
    /// <summary>
    /// Форма
    /// </summary>
    Form _form { get; set; }
  }
}
