using System;
using System.IO;

namespace WorkWithStringsConsoleApp
{
    internal static class ExtractPhoneNumber
    {
        private static string _data_for_text_file =
            "Bla bla bla my number is +7 (921) 345-67-89 kekeke" + "\r\n" +
            "Blo Blo blo +375 (34) 444-7843 ololo";

        private static readonly string _s_path = Environment.CurrentDirectory + @"\text.txt";
        private static readonly string _s_path_for_numbers = Environment.CurrentDirectory + @"\numbers.txt";

        static ExtractPhoneNumber()
        {
            // Write predefined demo data to the text.txt file
            CreateAndFillTextFile(_s_path, _data_for_text_file);
        }

        private static void CreateAndFillTextFile(string sPath, string data)
        { 
            File.WriteAllText(sPath, data);
        }

        private static string GetRawData(string sPath)
        {
            return File.ReadAllText(sPath);
        }

        /// <summary>
        /// Getting data from the source text.txt file
        /// </summary>
        /// <returns></returns>
        public static string GetDataFromTextFile()
        {
            return GetRawData(_s_path);
        }

        /// <summary>
        /// This method extract phone numbers with accordance predefined templates
        /// </summary>
        public static void ExtractAndWriteNumbersToSpecialFile()
        {
            var sData = GetRawData(_s_path);

            var arr = sData.ToCharArray();
            var s = "";

            for (int i = 0; i < arr.Length; i++)
            {
                if (char.IsDigit(arr[i]))
                    s += arr[i];

                if (arr[i] == '\r')
                    s += ";";
            }

            var arrNumbers = s.Split(';');
            var sResult = "";
            foreach (var item in arrNumbers)
            {
                if (!string.IsNullOrWhiteSpace(item))
                {
                    sResult += item.Substring(0, 1) switch
                    {
                        "7" => string.Format("{0:+# (###) ###-####}", Convert.ToInt64(item)),
                        "3" => string.Format("{0:+### (##) ###-####}", Convert.ToInt64(item)),
                        _ => "\r\n",
                    };
                }
            }

            // Write extracted phone numbers to the Numbers.txt file
            CreateAndFillTextFile(_s_path_for_numbers, sResult);
        }

        /// <summary>
        /// Get all phone numbers from nubmbers.txt after its was extracted 
        /// </summary>
        /// <returns></returns>
        public static string GetExtractedPhoneNumbers()
        {
            return GetRawData(_s_path_for_numbers); 
        }
    }
}