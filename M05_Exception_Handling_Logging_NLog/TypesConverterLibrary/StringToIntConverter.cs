using System;
using Microsoft.Extensions.Logging;

namespace TypesConverterLibrary
{
    public class StringToIntConverter
    {
        private readonly ILogger _logger;

        public StringToIntConverter(ILogger logger)
        {
            _logger = logger;
            _logger.LogInformation("ILogger conveyed to the StringToIntConverter constructer as a dependancy");
        }

        public int ConvertToInt(string sInputValue)
        {
            if (string.IsNullOrWhiteSpace(sInputValue))
                throw new ArgumentException("Input parameter {0} should not be empty string or whitespace", nameof(sInputValue));

            try
            {
                _logger.LogInformation("Start converting string to int");
                var nResult = IntParse(sInputValue);
                _logger.LogInformation("String converted to Int successfully. Result is {0}", nResult);

                return nResult;
                
            }
            catch (FormatException e)
            {
                _logger.LogError("Error has occured during string to int convertion\r\nMessage: {0}\r\nStackTrace: {1}", e.Message, e.StackTrace);
                throw;
            }            
        }

        private int IntParse(string sValue)
        {
            int nResult = 0;
            int nOffsetFromChar_1_To_Integer_1_In_ASCII = 48;

            for (int i = 0; i < sValue.Length; i++)
            {
                if (!char.IsDigit(sValue[i]))
                    throw new FormatException(string.Format("The given string contains not digit item at index {0}, value is {1} ", i, sValue[i]));

                nResult = 10 * nResult + (sValue[i] - nOffsetFromChar_1_To_Integer_1_In_ASCII);
            }

            return nResult;
        }
    }
}