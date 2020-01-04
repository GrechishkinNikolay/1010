using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class ModelMenu
  {
    public List<String> MenuItems { get; private set; } = new List<string>(3) { "Играть", "Справка", "Выход" };
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
    public void MoveMenuPointerUp()
    {
      if (_selectedMenuItem != 0)
      {
        _selectedMenuItem--;
      }
    }
    public void MoveMenuPointerDown()
    {
      if (_selectedMenuItem != 2)
      {
        _selectedMenuItem++;
      }
    }
  }
}
