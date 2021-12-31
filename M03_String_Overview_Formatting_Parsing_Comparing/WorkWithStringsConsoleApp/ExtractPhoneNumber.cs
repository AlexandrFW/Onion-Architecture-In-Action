using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WorkWithStringsConsoleApp
{
    internal static class ExtractPhoneNumber
    {
        private static readonly string _s_path = Environment.CurrentDirectory + @"\text.txt";
        private static readonly string _s_path_for_numbers = Environment.CurrentDirectory + @"\numbers.txt";

        private static void CreateAndFillTextFile(string data)
        { 
            File.WriteAllText(_s_path_for_numbers, data);
        }

        private static string GetRawData() //string sPath)
        {
            return AppResources.text;
        }

        /// <summary>
        /// Getting data from the source text.txt file
        /// </summary>
        /// <returns></returns>
        public static string GetDataFromTextFile()
        {
            return GetRawData();
        }

        /// <summary>
        /// This method extract phone numbers with accordance predefined templates
        /// </summary>
        public static void ExtractAndWriteNumbersToFile()
        {
            var sData = GetRawData();// _s_path);

            var r = new Regex(@"\+?\d{0,3}([\-\.\s]?)([\(\s])\d{0,3}([\)\s])([\-\.\s]?)\d{0,4}([\-\.\s]?)\d{0,8}([\-\.\s]?)\d{0,3}", RegexOptions.Multiline);
            var sResultBuilder = new StringBuilder();

            var matches = r.Matches(sData);
            foreach(var match in matches)
            {
                sResultBuilder.Append((match as Match).Value);
            }

            // Write extracted phone numbers to the Numbers.txt file
            CreateAndFillTextFile(sResultBuilder.ToString());
        }

        /// <summary>
        /// Get all phone numbers from nubmbers.txt after its was extracted 
        /// </summary>
        /// <returns></returns>
        public static string GetExtractedPhoneNumbers()
        {
            return File.ReadAllText(_s_path_for_numbers);
        }
    }
}