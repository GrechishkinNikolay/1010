using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewWindowsForms
{
  public interface IViewWindows
  {
    void RedrawCycle();
    Form Form { get; set; }
  }
}
