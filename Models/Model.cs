using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  /// <summary>
  /// Базовый класс модели
  /// </summary>
  public class Model
  {
    /// <summary>
    /// Менеджер рекордов
    /// </summary>
    protected static ScoreManager _scoresManager = new ScoreManager();
    /// <summary>
    /// Активно ли окно
    /// </summary>
    public volatile bool _isRunning;
    /// <summary>
    /// Свойство менеджера рекордов
    /// </summary>
    public ScoreManager ScoreManager
    {
      get
      {
        return _scoresManager;
      }
    }
    /// <summary>
    /// Список отсортированных рекордов
    /// </summary>
    public List<KeyValuePair<string, int>> SortedScores
    {
      get
      {
        return _scoresManager.GetScores().OrderByDescending(i => i.Value).ToList();
      }
    }
    /// <summary>
    /// Активно ли окно
    /// </summary>
    public  bool IsRunning
    {
      get
      {
        return _isRunning;
      }
      set
      {
        _isRunning = value;
      }
    }
  }
}
