using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
  public class ModelGameOverScreen : Model
  {
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
  }
}
