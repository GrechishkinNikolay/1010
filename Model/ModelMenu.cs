using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class ModelMenu : Model
  {
    public bool IsMenu { get; set; }
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
    /// <summary>
    /// Список пунктов меню
    /// </summary>
    public List<String> MenuItems { get; private set; } = new List<string>(3) { "Играть", "Справка", "Выход" };
    /// <summary>
    /// Переместить указатель меню вверх
    /// </summary>
    public void MoveMenuPointerUp()
    {
      if (_selectedMenuItem != 0)
      {
        _selectedMenuItem--;
      }
    }
    public void ClickOnSelectedMenuItem()
    {

    }
    /// <summary>
    /// Переместить указатель меню вниз
    /// </summary>
    public void MoveMenuPointerDown()
    {
      if (_selectedMenuItem != 2)
      {
        _selectedMenuItem++;
      }
    }
  }
}
