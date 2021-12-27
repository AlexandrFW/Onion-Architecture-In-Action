using System;

namespace WorkWithStringsConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Module 3. M03_String_Overview_Formatting_Parsing_Comparing\r\n");

            Console.WriteLine("Task #1. M03_String_Overview_Formatting_Parsing_Comparing");
            var sTestString = "Возвращает true, если символ является десятичной, или шестнадцатеричной цифрой!";
            Console.WriteLine("Average of all words length is {0:F2}",  AverageWordsLength.CalculateAverageWordsLength(sTestString));

            Console.WriteLine();

            Console.WriteLine("Task #2. Double all charcters in the First string if its contains in the Second string");
            var sFirstString = "omg i love shrek";
            var sSecondString = "o kek";

            Console.WriteLine($"The First string is \"{ sFirstString }\"");
            Console.WriteLine($"The Second string is  \"{ sSecondString }\"");
            Console.WriteLine("Result string: {0}",DoublesSymbols.DoublesAllSymbolsInFirstStringIfContainsInSecond(sFirstString, sSecondString));

            Console.WriteLine();

            Console.WriteLine("Task #3. Double all charcters in the First string if its contains in the Second string");
            var sFirstBigNum = "18446744073709551615";
            var sSecondBigNum = "18446744073709551615";

            Console.WriteLine($"The First Big Number is \"{ sFirstBigNum }\"");
            Console.WriteLine($"The Second Big Number is  \"{ sSecondBigNum }\"");
            Console.WriteLine("Sum of two Big numbers is {0}", SumTwoBigNumbers.CalcSumOfTwoBigNumbers(sFirstBigNum, sSecondBigNum));

            Console.WriteLine();

            Console.WriteLine("Task #4. Revers all words in a given string");
            var sGivenString = "The greatest victory is that which requires no battle";
            Console.WriteLine($"String for reversing  \"{ sGivenString }\"");
            Console.WriteLine("Result of reversing string -> {0}", ReversingWords.ReverseWords(sGivenString));
            
            Console.WriteLine();

            Console.WriteLine("Task #5. Create file with temp string data and extract phone numbers from it");
            Console.WriteLine($"Working with files where located in the AppResources file");
            Console.WriteLine();
            Console.WriteLine($"Data from file -> Application resource file");
            Console.WriteLine(ExtractPhoneNumber.GetDataFromTextFile());
            ExtractPhoneNumber.ExtractAndWriteNumbersToFile();    // Process raw text data to find all phone number by predefined templates
            Console.WriteLine();
            Console.WriteLine($"Get all found phone numbers");
            Console.WriteLine(ExtractPhoneNumber.GetExtractedPhoneNumbers());

            Console.ReadKey();
        }
    }
}