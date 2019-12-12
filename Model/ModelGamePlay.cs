﻿using Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public class ModelGamePlay
  {
    private const int COUNT_ROW = 10;
    private const int COUNT_COLUMN = 10;

    private Field _gameField;
    private FiguresShapes _figuresShapes;
    public Coordinates _pointerCoordinates { get; set; }


    public Field GameField
    {
      get
      {
        return _gameField;
      }
      set
      {
        _gameField = value;
      }
    }

    public ModelGamePlay()
    {
      _gameField = new Field(COUNT_ROW, COUNT_COLUMN);
      _figuresShapes = new FiguresShapes(FigureCodeKeeper.FiguresCodes);
    }

  }
}
