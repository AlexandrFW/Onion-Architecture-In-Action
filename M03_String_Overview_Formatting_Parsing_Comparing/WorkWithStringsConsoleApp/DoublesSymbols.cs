using System;
using System.Collections.Generic;
using System.Text;

namespace WorkWithStringsConsoleApp
{
    public static class DoublesSymbols
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFirstString">String paramters where characters should be doubled</param>
        /// <param name="sSecondString">String parameter where characters should be given for check</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Given parameters cannot be null or whitespace</exception>
        public static string DoublesAllSymbolsInFirstStringIfContainsInSecond(string sFirstString, string sSecondString)
        {
            if (string.IsNullOrWhiteSpace(sFirstString))
                throw new ArgumentException($"Parameter { nameof(sFirstString) } cannot be null or whitespace");

            if (string.IsNullOrWhiteSpace(sSecondString))
                throw new ArgumentException($"Parameter { nameof(sFirstString) } cannot be null or whitespace");

            var hashSetOfSecondStringChars = new HashSet<char>(sSecondString.ToCharArray());

            int i = 0;
            var resultStringBuilder = new StringBuilder(sFirstString.Trim());
            while (i < resultStringBuilder.Length)
            {
                if (resultStringBuilder[i] != ' ')
                {
                    if (hashSetOfSecondStringChars.Contains(resultStringBuilder[i]))
                    {
                        resultStringBuilder.Insert(i + 1, resultStringBuilder[i]);
                        i++;
                    }
                }
                else i++;

                i++;
            }

            return resultStringBuilder.ToString().Trim();
        }
    }
}