using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculator.Test.Unit
{
    [TestClass]
    public class InputConverterTest
    {
        private readonly InputConverter _inputConverter = new InputConverter();

        [TestMethod]
        public void ConvertsANumberInStringFormatIntoADouble()
        {
            double result = _inputConverter.ConvertInputToNumber("12");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailsToConvertInvalidStringToDouble()
        {
            double result = _inputConverter.ConvertInputToNumber("*");
        }
    }
}
