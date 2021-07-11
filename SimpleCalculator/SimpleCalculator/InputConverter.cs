using System;

namespace SimpleCalculator
{
    public class InputConverter
    {
        public double ConvertInputToNumber(string argTextInput)
        {
            bool success = double.TryParse(argTextInput, out double converted);

            if (success)
            {
                return converted;
            }
            else
            {
                throw new ArgumentException("Expected a numeric value.");
            }
                
        }
    }
}
