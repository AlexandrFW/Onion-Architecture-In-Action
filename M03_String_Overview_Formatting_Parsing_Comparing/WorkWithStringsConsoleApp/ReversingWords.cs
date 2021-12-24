using System;
using System.Text;

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

            var sResult = new StringBuilder();
            for(int i = arrWords.Length - 1; i >= 0; i--)
            {
                sResult.Append(arrWords[i] + " ");
            }

            return sResult.ToString().Trim();
        }
    }
}