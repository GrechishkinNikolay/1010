using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ModelHelp : Model
  {
    /// <summary>
    /// Текст справки
    /// </summary>
    private const string HELP_TEXT =
"1010! или Block Puzzle — это увлекательная головоломка. " +
"Концепция проста: на доске 10X10 объединяйте блоки " +
"пазла и очищайте игровое поле, стратегически размещая " +
"блоки для создания линий как горизонтальных, так и " +
"вертикальных. Перемещение фигур осуществляется с " +
"помощью стрелок, вставлять фигуру на enter, выход в " +
"главное меню - esc. Очки начисляются за составление " +
"линий и за размещение фугуры. Игра будет продолжаться, " +
"пока на поле есть место для текущей фигуры.";
    public string HelpText
    {
      get { return HELP_TEXT; }
    }

  }
}