using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;

namespace ModelsTest
{
  [TestClass]
  public class ModelGameOverScreenTests
  {
    [TestMethod]
    public void IsValidChar_Symbol_R_TrueReturned()
    {
      // Тестируемое значение
      char symbol = 'R';
      PrivateObject privateObject = new PrivateObject(typeof(ModelGameOverScreen));

      // Результат теста
      bool actual = (bool)privateObject.Invoke("IsValidChar", symbol);

      // Проверка утверждения
      Assert.IsTrue(actual);
    }

    [TestMethod]
    public void IsValidChar_SymboSpace_FalseReturned()
    {
      // Тестируемое значение
      char symbol = ' ';
      PrivateObject privateObject = new PrivateObject(typeof(ModelGameOverScreen));

      // Результат теста
      bool actual = (bool)privateObject.Invoke("IsValidChar", symbol);

      // Проверка утверждения
      const bool expected = false;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValidChar_Symbol_3_TrueReturned()
    {
      // Тестируемое значение
      char symbol = '3';
      PrivateObject privateObject = new PrivateObject(typeof(ModelGameOverScreen));

      // Результат теста
      bool actual = (bool)privateObject.Invoke("IsValidChar", symbol);

      // Проверка утверждения
      const bool expected = true;
      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void IsValidChar_Symbol_r_TrueReturned()
    {
      // Тестируемое значение
      char symbol = 'r';
      PrivateObject privateObject = new PrivateObject(typeof(ModelGameOverScreen));

      // Результат теста
      bool actual = (bool)privateObject.Invoke("IsValidChar", symbol);

      // Проверка утверждения
      Assert.IsTrue(actual);
    }

    [TestMethod]
    public void DeleteSymbolTest()
    {
      // Тестируемое значение
      string Name = "Kolay";
      ModelGameOverScreen modelGameOverScreen = new ModelGameOverScreen();
      modelGameOverScreen.LastGameResults.Name = Name;

      // Результат теста
      modelGameOverScreen.DeleteSymbol();
      string actual = modelGameOverScreen.LastGameResults.Name;

      // Проверка утверждения
      string expected = "Kola";
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void DeleteSymbol_EmptyString_Test()
    {
      // Тестируемое значение
      string Name = "";
      ModelGameOverScreen modelGameOverScreen = new ModelGameOverScreen();
      modelGameOverScreen.LastGameResults.Name = Name;

      // Результат теста
      modelGameOverScreen.DeleteSymbol();
      string actual = modelGameOverScreen.LastGameResults.Name;

      // Проверка утверждения
      string expected = "";
      Assert.AreEqual(expected, actual);
    }
    [TestMethod]
    public void AddSymbolToNameTest()
    {
      // Тестируемое значение
      string Name = "Kola";
      char symbol = 'y';
      ModelGameOverScreen modelGameOverScreen = new ModelGameOverScreen();
      modelGameOverScreen.LastGameResults.Name = Name;

      // Результат теста
      modelGameOverScreen.AddSymbolToName(symbol);
      string actual = modelGameOverScreen.LastGameResults.Name;

      // Проверка утверждения
      string expected = "Kolay";
      Assert.AreEqual(expected, actual);
    }
  }
}
