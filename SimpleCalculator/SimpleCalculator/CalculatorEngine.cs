using System;

namespace SimpleCalculator
{
    public class CalculatorEngine
    {
        public double Calculate(double argFirstNum, double argSecondNum, string argOperation)
        {
            double result;

            switch (argOperation.ToLower())
            {
                case "+": 
                case "add":
                    result = argFirstNum + argSecondNum;
                    break;
                case "-":
                case "minus":
                    result = argFirstNum - argSecondNum;
                    break;
                case "*":
                case "multiply":
                    result = argFirstNum * argSecondNum;
                    break;
                case "/":
                case "divide":
                    result = argFirstNum / argSecondNum;
                    break;
                default:
                    throw new InvalidOperationException("Operation not recognised.");
            }
            
            return result;

        }
    }
}
