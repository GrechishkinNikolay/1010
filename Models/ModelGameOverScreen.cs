using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ModelGameOverScreen : Model
  {
    private const char FIRST_VALID_NUMBER = '0';
    private const char LAST_VALID_NUMBER = '9';
    private const char FIRST_VALID_CHAR_RUS = 'а';
    private const char LAST_VALID_CHAR_RUS = 'я';
    private const char FIRST_VALID_CHAR_ENG = 'a';
    private const char LAST_VALID_CHAR_ENG = 'z';

    private LastGameResults _lastGameResults;

    public LastGameResults LastGameResults
    {
      get { return _lastGameResults; }
      set { _lastGameResults = value; }
    }

    public ModelGameOverScreen()
    {
      _lastGameResults = new LastGameResults();
    }

    public void AddSimbolToName(char parSimbol)
    {
      if (IsValidChar(parSimbol))
      {
        LastGameResults.Name += parSimbol;
      }
    }

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
