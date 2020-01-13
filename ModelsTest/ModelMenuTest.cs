using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace ModelsTest
{
  [TestClass]
  public class ModelMenuTest
  {
    [TestMethod]
    public void MoveMenuPointerUpTestWhenAtTheTop()
    {
      // Тестируемое значение
      int active= 0;
      ModelMenu modelMenu = new ModelMenu();
      modelMenu.SelectedMenuItem = active;

      // Результат теста
      modelMenu.MoveMenuPointerUp();
      int actual = modelMenu.SelectedMenuItem;

      // Проверка утверждения
      int expected = 0;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MoveMenuPointerDownTest()
    {
      // Тестируемое значение
      int active = 0;
      ModelMenu modelMenu = new ModelMenu();
      modelMenu.SelectedMenuItem = active;

      // Результат теста
      modelMenu.MoveMenuPointerDown();
      int actual = modelMenu.SelectedMenuItem;

      // Проверка утверждения
      int expected = 1;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void MoveMenuPointerUpTest()
    {
      // Тестируемое значение
      int active = 2;
      ModelMenu modelMenu = new ModelMenu();
      modelMenu.SelectedMenuItem = active;

      // Результат теста
      modelMenu.MoveMenuPointerUp();
      int actual = modelMenu.SelectedMenuItem;

      // Проверка утверждения
      int expected = 1;
      Assert.AreEqual(expected, actual);
    }
  
    [TestMethod]
    public void MoveMenuPointerDownTestWhenBelow()
    {
      // Тестируемое значение
      int active = 3;
      ModelMenu modelMenu = new ModelMenu();
      modelMenu.SelectedMenuItem = active;

      // Результат теста
      modelMenu.MoveMenuPointerDown();
      int actual = modelMenu.SelectedMenuItem;

      // Проверка утверждения
      int expected = 3;
      Assert.AreEqual(expected, actual);
    }
  }
}
