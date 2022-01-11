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
            _logger.LogInformation("StringToIntConverter got the ILogger as a dependancy in a consructor");
        }

        public int ConvertToInt(string sInputValue)
        {
            if (string.IsNullOrWhiteSpace(sInputValue))
                throw new ArgumentException($"Input parameter { nameof(sInputValue) } should not be empty string or whitespace");

            try
            {
                _logger.LogInformation("Start converting string to int");
                var nResult = IntParse(sInputValue);
                _logger.LogInformation($"String converted to Int successfully. Result is { nResult }");

                return nResult;
                
            }
            catch (FormatException e)
            {
                _logger.LogError("Error has occured during string to int convertion\r\nMessage: {0}\r\nStackTrace: {1}", new object[] { e.Message, e.StackTrace });
                throw;
            }            
        }

        private int IntParse(string sValue)
        {
            int nResult = 0;

            for (int i = 0; i < sValue.Length; i++)
            {
                if (!char.IsDigit(sValue[i]))
                    throw new FormatException($"The given string contains not digit item at index { i }, value is \"{ sValue[i] }\" ");

                nResult = 10 * nResult + (sValue[i] - 48);
            }

            return nResult;
        }
    }
}