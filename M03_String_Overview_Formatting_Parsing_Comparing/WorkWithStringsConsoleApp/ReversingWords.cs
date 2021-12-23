using System;

namespace WorkWithStringsConsoleApp
{
    internal static class ReversingWords
    {
        /// <summary>
        /// Reverse all words in a given sentance
        /// </summary>
        /// <param name="sSourceString">Given sentance where words will be reversed</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Given sentance cannot be null or whitespace</exception>
        public static string ReverseWords(string sSourceString)
        {
            if (string.IsNullOrWhiteSpace(sSourceString))
                throw new ArgumentException("Error! Parameter sSourceString cannot be null or whitespace...");

            var arrWords = sSourceString.Split(' ');

            string sResult = "";
            for(int i = arrWords.Length - 1; i >= 0; i--)
            {
                sResult += arrWords[i] + " ";
            }

            return sResult.Trim();
        }
    }
}