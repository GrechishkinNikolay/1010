using Controller.Delegates;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  public class ControllerGamePlay
  {
    private ModelGamePlay _modelGamePlay;
    public event dMoveRight OnClickButtonRight;
    public event dMoveLeft OnClickButtonLeft;
    public event dMoveUp OnClickButtonUp;
    public event dMoveDown OnClickButtonDown;

    public ControllerGamePlay(ModelGamePlay parModel)
    {
      _modelGamePlay = parModel;
    }


  }
}

class Handler_I
{
  public void Message()
  {
    Console.WriteLine("Пора действовать, ведь уже 71!");
  }
}

class Handler_II
{
  public void Message()
  {
    Console.WriteLine("Точно, уже 71!");
  }
}

class ClassCounter  //Это класс - в котором производится счет.
{
  public delegate void MethodContainer();
  public event MethodContainer onCount;

  public void Count()
  {
    for (int i = 0; i < 100; i++)
    {
      if (i == 71)
      {
        onCount();
      }
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    ClassCounter Counter = new ClassCounter();
    Handler_I Handler1 = new Handler_I();
    Handler_II Handler2 = new Handler_II();

    //Подписались на событие
    Counter.onCount += Handler1.Message;
    Counter.onCount += Handler2.Message;
  }
}