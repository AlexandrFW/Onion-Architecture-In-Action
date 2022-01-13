using System.Text;
using System;

namespace UnitTestingConsoleApp
{
    public static class SumTwoBigNumbers
    {
		/// <summary>
		/// Calculate sum of two Big numbers presented as strings
		/// </summary>
		/// <param name="sFirstBigNum">First big number</param>
		/// <param name="sSecondBigNum">Second big number</param>
		/// <returns>Sum of two big numbers</returns>
		/// <exception cref="ArgumentException"></exception>
        public static string CalcSumOfTwoBigNumbers(string sFirstBigNum, string sSecondBigNum)
        {
			if (string.IsNullOrWhiteSpace(sFirstBigNum))
				throw new ArgumentException($"Parameter { nameof(sFirstBigNum) } cannot be null or whitespace");

			if (string.IsNullOrWhiteSpace(sSecondBigNum))
				throw new ArgumentException($"Parameter { nameof(sSecondBigNum) } cannot be null or whitespace");

            var sum = new StringBuilder();

            int carry = 0;

			if (sFirstBigNum.Length != sSecondBigNum.Length)
			{
				var maxLength = Math.Max(sFirstBigNum.Length, sSecondBigNum.Length);
				sFirstBigNum = sFirstBigNum.PadLeft(maxLength, '0');
				sSecondBigNum = sSecondBigNum.PadLeft(maxLength, '0');
			}

			for (int i = sFirstBigNum.Length - 1; i >= 0; i--)
			{
				if (!char.IsDigit(sFirstBigNum[i]))
					throw new Exception($"Char \'{ sFirstBigNum[i] }\' in the sFirstBigNum at index { i } is not a digit");

				if (!char.IsDigit(sSecondBigNum[i]))
					throw new Exception($"Char \'{ sSecondBigNum[i] }\' in the sSecondBigNum at index { i } is not a digit");

				var digitSum = (sFirstBigNum[i] - '0') + (sSecondBigNum[i] - '0') + carry;

				if (digitSum > 9)
				{
					carry = 1;
					digitSum -= 10;
				}
				else
				{
					carry = 0;
				}

				sum.Insert(0, digitSum);
			}

			if (carry == 1)
				sum.Insert(0, carry);

			return sum.ToString();
		}
    }
}