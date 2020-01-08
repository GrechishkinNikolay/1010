using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ModelMenu : Model
  {
    public delegate void _closingWindow();
    private _closingWindow _dClosingWindow;
    public event _closingWindow onClosingWindow;

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
        if (value >= 0 && value <= MenuItems.Capacity)
        {
          _selectedMenuItem = value;
        }
      }
    }
    /// <summary>
    /// Список пунктов меню
    /// </summary>
    public List<String> MenuItems { get; private set; } = new List<string> { "Играть", "Рекорды", "Справка", "Выход" };
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
      onClosingWindow?.Invoke();
    }
    /// <summary>
    /// Переместить указатель меню вниз
    /// </summary>
    public void MoveMenuPointerDown()
    {
      if (_selectedMenuItem != MenuItems.Capacity - 1)
      {
        _selectedMenuItem++;
      }
    }
  }
}
