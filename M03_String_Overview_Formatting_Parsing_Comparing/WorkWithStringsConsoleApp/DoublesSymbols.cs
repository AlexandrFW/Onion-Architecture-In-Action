using System;

namespace WorkWithStringsConsoleApp
{
    internal static class DoublesSymbols
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
                throw new ArgumentException("Error! Parameter sFirstString cannot be null or whitespace...");

            if (string.IsNullOrWhiteSpace(sSecondString))
                throw new ArgumentException("Error! Parameter sSecondString cannot be null or whitespace...");

            var arrCharsOfSecondStrings = sSecondString.ToCharArray();

            string sResult = sFirstString;
            var arrCharsOfFirstStrings = sResult.ToCharArray(); 

            int i = 0;

            while(i < arrCharsOfFirstStrings.Length)
            {
                if (arrCharsOfFirstStrings[i] != ' ')
                {
                    for (int j = 0; j < arrCharsOfSecondStrings.Length; j++)
                    {
                        if (arrCharsOfSecondStrings[j] != ' ')
                        {
                            if (arrCharsOfFirstStrings[i] == arrCharsOfSecondStrings[j])
                            {
                                i++;
                                sResult = sResult.Insert(i, arrCharsOfSecondStrings[j].ToString());
                                arrCharsOfFirstStrings = sResult.ToCharArray();
                                break;
                            }
                        }
                    }
                }
                else i++;

                i++;
            }

            return sResult;
        }
    }
}