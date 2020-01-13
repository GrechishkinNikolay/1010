using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Модель меню
  /// </summary>
  public class ModelMenu : Model
  {
    /// <summary>
    /// Делегат выбора элемента меню
    /// </summary>
    public delegate void _menuItemSelection();
    /// <summary>
    /// Событие выбора элемента меню
    /// </summary>
    public static event _menuItemSelection OnSelectMenuItem;
    /// <summary>
    /// Выбранный пункт меню
    /// </summary>
    public static int _selectedMenuItem;
    /// <summary>
    /// Активно ли окно меню
    /// </summary>
    public bool IsMenu { get; set; }
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
    /// <summary>
    /// Вызов события нажатия на элемент меню
    /// </summary>
    public static void ClickOnSelectedMenuItem()
    {
      OnSelectMenuItem?.Invoke();
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
