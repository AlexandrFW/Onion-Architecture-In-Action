using NUnit.Framework;

namespace WorkWithStringsConsoleApp.Test
{
    public class UnitTests
    {
        // M03 Unit tests

        [Test]
        [TestCase("Возвращает true, если символ является десятичной, или шестнадцатеричной цифрой!", 7.5555555555555554)]
        public void M03_Task_2_Average_Of_Words_Length_Is_Equals_To_Given(string sSentance, double nExpectedAverage)
        {
            // Act
            var sReturnedAverageVal = AverageWordsLength.CalculateAverageWordsLength(sSentance);

            // Assert
            Assert.That(nExpectedAverage, Is.EqualTo(sReturnedAverageVal));
        }

        [Test]
        public void M03_Task_2_Average_Of_Words_Length_Should_Throw_ArgumentException()
        {
            // Assert
            Assert.That(() => AverageWordsLength.CalculateAverageWordsLength(string.Empty), Throws.ArgumentException);
        }

        [Test]
        public void M03_Task_3_All_Charcter_In_First_String_Should_Doubled_By_Characters_In_Second_String()
        {
            // Arrange
            var sResultStringShouldBe = "oomg i loovee shreekk";
            var sFirstString = "omg i love shrek";
            var sSecondString = "o kek";

            // Act
            var sReturnedString = DoublesSymbols.DoublesAllSymbolsInFirstStringIfContainsInSecond(sFirstString, sSecondString);

            // Assert
            Assert.That(sReturnedString, Is.EqualTo(sResultStringShouldBe));
        }

        [Test]
        [TestCase("", "o kek")]
        [TestCase("omg i love shrek", "")]
        public void M03_Task_2_Doubled_Charcters_Should_Throws_ArgumentException_If_First_Or_Second_String_Empty(string sFirstString, string sSecondString)
        {
            // Assert
            Assert.That(() => DoublesSymbols.DoublesAllSymbolsInFirstStringIfContainsInSecond(sFirstString, sSecondString), Throws.ArgumentException);
        }

        [Test]
        [TestCase("18446744073709551615", "18446744073709551615", "36893488147419103230")]
        public void M03_Task_4_Sum_Of_Two_Big_Numbers_In_String_Format(string sFirstBigNum, string sSecondBigNum, string sExpectedSum)
        {
            // Act
            var sCalculatedSumOfTwoBigNumbers = SumTwoBigNumbers.CalcSumOfTwoBigNumbers(sFirstBigNum, sSecondBigNum);

            // Assert
            Assert.That(sExpectedSum, Is.EqualTo(sCalculatedSumOfTwoBigNumbers));
        }

        [Test]
        [TestCase("", "18446744073709551615")]
        [TestCase("18446744073709551615", "")]
        public void M03_Task_4_Sum_Of_Two_Big_Numbers_In_String_Format_Should_Throws_ArgumentException_If_First_Or_Second_String_Empty(string sFirstBigNum, string sSecondBigNum)
        {
            // Assert
            Assert.That(() => SumTwoBigNumbers.CalcSumOfTwoBigNumbers(sFirstBigNum, sSecondBigNum), Throws.ArgumentException);
        }

        [Test]
        [TestCase("The greatest victory is that which requires no battle", "battle no requires which that is victory greatest The")]
        public void M03_Task_5_Reversing_The_Words_Order_In_Sentance(string sGivenSentance, string sExpectedSentance)
        {
            // Act
            var sReversedString = ReversingWords.ReverseWords(sGivenSentance);

            // Assert
            Assert.That(sExpectedSentance, Is.EqualTo(sReversedString));
        }

        [Test]
        public void M03_Task_5_Reversing_The_Words_Order_In_Sentance_Should_Throws_ArgumentException_If_Given_String_Empty()
        {
            // Assert
            Assert.That(() => ReversingWords.ReverseWords(string.Empty), Throws.ArgumentException);
        }
    }
}