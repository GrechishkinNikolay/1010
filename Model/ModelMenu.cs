using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class ModelMenu
  {
    /// <summary>
    /// Выбранный пункт меню
    /// </summary>
    private int _selectedMenuItem;
    /// <summary>
    /// Свойство выбранного пункта меню
    /// </summary>
    public int SelectedMenuItem
    {
      get { return _selectedMenuItem; }
      set
      {
        if (value >= 0 && value <= 3)
        {
          _selectedMenuItem = value;
        }
      }
    }


  }
}
