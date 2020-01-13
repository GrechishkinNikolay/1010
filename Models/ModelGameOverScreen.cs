using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Модель окна проигрыша
  /// </summary>
  public class ModelGameOverScreen : Model
  {
    /// <summary>
    /// Первая допустимая цифра
    /// </summary>
    private const char FIRST_VALID_NUMBER = '0';
    /// <summary>
    /// Последняя допустимая цифра
    /// </summary>
    private const char LAST_VALID_NUMBER = '9';
    /// <summary>
    /// Первая допустимая русская буква
    /// </summary>
    private const char FIRST_VALID_CHAR_RUS = 'а';
    /// <summary>
    /// Последняя допустимая русская цифра
    /// </summary>
    private const char LAST_VALID_CHAR_RUS = 'я';
    /// <summary>
    /// Первая допустимая английская буква
    /// </summary>
    private const char FIRST_VALID_CHAR_ENG = 'a';
    /// <summary>
    /// Последняя допустимая английская цифра
    /// </summary>
    private const char LAST_VALID_CHAR_ENG = 'z';
    /// <summary>
    /// Информация о результатах последнего игрока 
    /// </summary>
    private LastGameResults _lastGameResults;
    /// <summary>
    /// Свойство информации о результатах последнего игрока 
    /// </summary>
    public LastGameResults LastGameResults
    {
      get { return _lastGameResults; }
      set { _lastGameResults = value; }
    }
    /// <summary>
    /// Конструктор
    /// </summary>
    public ModelGameOverScreen()
    {
      _lastGameResults = new LastGameResults();
    }
    /// <summary>
    /// Добавить вводимый символ к имени 
    /// </summary>
    /// <param name="parSimbol">Вводимый символ</param>
    public void AddSimbolToName(char parSimbol)
    {
      if (IsValidChar(parSimbol))
      {
        LastGameResults.Name += parSimbol;
      }
    }
    /// <summary>
    /// Удалить последний символ из имени игрока
    /// </summary>
    public void DeleteSymbol()
    {
      if (LastGameResults.Name.Length != 0)
      {
        LastGameResults.Name = LastGameResults.Name.Substring(0, LastGameResults.Name.Length - 1);
      }
    }
    /// <summary>
    /// Проверка символа на допустимость
    /// </summary>
    private bool IsValidChar(char parValue)
    {
      char buffer = char.ToLower(parValue);
      bool numeric = parValue >= FIRST_VALID_NUMBER &&
          parValue <= LAST_VALID_NUMBER;
      bool rusAlpha = buffer >= FIRST_VALID_CHAR_RUS &&
          buffer <= LAST_VALID_CHAR_RUS;
      bool engAlpha = buffer >= FIRST_VALID_CHAR_ENG &&
          buffer <= LAST_VALID_CHAR_ENG;
      return numeric || rusAlpha || engAlpha;
    }
  }
}
