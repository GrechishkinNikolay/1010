using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ModelRecordsScreen : Model
  {
    private ScoreManager _scoresManager = new ScoreManager();

    public List<KeyValuePair<string, int>> SortedScores
    {
      get
      {
        return _scoresManager.GetScores().OrderByDescending(i => i.Value).ToList();
      }
    }
  }
}
