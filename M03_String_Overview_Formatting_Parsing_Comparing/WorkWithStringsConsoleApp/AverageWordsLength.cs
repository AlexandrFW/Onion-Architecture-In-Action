using System;

namespace WorkWithStringsConsoleApp
{
    public static class AverageWordsLength
    {
        /// <summary>
        /// Calculate an average of all words of given string without eliminating punctuation symbols
        /// </summary>
        /// <param name="sPhrase">String of words which average should be calculated</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">sPhrase cannot be null</exception>
        public static double CalculateAverageWordsLength(string sPhrase)
        {
            if (string.IsNullOrWhiteSpace(sPhrase))
                throw new ArgumentException("Parameter cannot be null or whitespace");

            var arrChars = sPhrase.ToCharArray();
            for (int i = 0; i < arrChars.Length; i++)
            {
                if (char.IsPunctuation(arrChars[i]))
                {
                    arrChars[i] = ' ';
                }
            }

            var sPhraseWithoutPunctuation = new string(arrChars);
            var arrSplitedSource = sPhraseWithoutPunctuation.Split(' ');

            double nAmountOfSupportedElements = 0;
            double nSumOfElemntsLegth = 0;

            foreach(var item in arrSplitedSource)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    nAmountOfSupportedElements++;
                    nSumOfElemntsLegth += item.Length;
                }
            }

            return nSumOfElemntsLegth / nAmountOfSupportedElements; 
        }
    }
}