using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class CalculatorEngineTest
    {
        private readonly CalculatorEngine _calculatorEngine = new CalculatorEngine();

        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "add");

            Assert.AreEqual(3, result);
        }
        
        [TestMethod]
        public void AddsTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "+");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "Minus");

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void SubtractsTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 1;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "-");

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 2;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "MULTIPLY");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void MultipliesTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 2;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "*");

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForNonSymbolOperation()
        {
            int number1 = 6;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "dIVIde");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void DividesTwoNumbersAndReturnsValidResultForSymbolOperation()
        {
            int number1 = 6;
            int number2 = 2;
            double result = _calculatorEngine.Calculate(number1, number2, "/");

            Assert.AreEqual(3, result);
        }
    }
}
