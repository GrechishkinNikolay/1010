using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class Figure
  {
    private const int FIGURE_SIZE = 3;
    private Cell[][] _figureShape;
    private int _widthFigure;
    private int _heightFigure;

    public int HeightFigure
    {
      get
      {
        return _heightFigure;
      }
      set
      {
        _heightFigure = value;
      }
    }

    public int WidthFigure
    {
      get
      {
        return _widthFigure;
      }
      set
      {
        _widthFigure = value;
      }
    }

    public int FigureShape
    {
      get
      {
        return FigureShape;
      }
      set
      {
        FigureShape = value;
      }
    }

    public Figure(string parfigureCode)
    {
      for (int i = 0; i < parfigureCode.Length; i++)
      {
        for (int j = 0; j < FIGURE_SIZE; j++)
        {
          _figureShape[i][j].IsFull = (parfigureCode[FIGURE_SIZE * i + j] == '1');
          if (parfigureCode[FIGURE_SIZE * i + j] == '1')
          {
            _widthFigure = j + 1;
            _heightFigure = i + 1;
          }
        }
      }
    }
  }
}

