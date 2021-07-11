using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InputConverter inputConverter = new InputConverter();
                CalculatorEngine calculatorEngine = new CalculatorEngine();

                Console.WriteLine("Enter first number: ");
                string strFirst = Console.ReadLine();
                double dblFirst = inputConverter.ConvertInputToNumber(strFirst);

                Console.WriteLine("Enter second number: ");
                string strSecond = Console.ReadLine();
                double dblSecond = inputConverter.ConvertInputToNumber(strSecond);

                Console.WriteLine("Enter math operation: ");
                string operation = Console.ReadLine();

                double result = calculatorEngine.Calculate(dblFirst, dblSecond, operation);

                Console.WriteLine(result);
            }

            catch (Exception ex)
            {
                // TODO: Set up exception logging 
                Console.WriteLine(ex.Message);
            }

        }
    }
}
