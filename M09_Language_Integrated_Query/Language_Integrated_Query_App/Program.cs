using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Language_Integrated_Query_App
{
    public class Program
    {
        private static List<Student> _students;
        private static bool _stopInteraction = false;
        private static Dictionary<string, string> _filterDictionary;

        static void Main(string[] args)
        {
            PrintTitle();
            PrintHowToCallHelp();
            PrintWelcomeToInput();

            Load();

            if (_students is not null)
            {
                while (!_stopInteraction)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        PrintTitle();
                        PrintHowToCallHelp();
                        PrintData(GetAllStudents());
                        PrintWelcomeToInput();
                    }
                    else
                    {
                        if(input == "help")
                        {
                            PrintHelp();

                            continue;                              
                        }

                        PrintTitle();
                        PrintHowToCallHelp();                        

                        var filteredData = FilterData(_students, input);
                        if (!filteredData.Any())
                        {
                            Console.WriteLine("Nothing to display with accordace entered criteria");
                            continue;
                        }

                        PrintData(filteredData);
                        PrintWelcomeToInput();
                    }
                }                
            }

            Console.ReadLine();
        }

        private static void PrintTitle()
        {
            Console.Clear();
            Console.WriteLine("M09. Language Integrated Query. LINQ!");
            Console.WriteLine();
        }

        private static void PrintHelp()
        {
            PrintTitle();
            PrintHowToCallHelp();

            Console.WriteLine("Please, use next parameters to filter the data");
            Console.WriteLine("\"-\" before each filter parameter (-) is required");
            Console.WriteLine("\" \" use whitespace to divide parameter from filter criteria");
            Console.WriteLine();
            Console.WriteLine("-name Ivan -- use for filter by first name");
            Console.WriteLine("-lastname Sidorov -- use for filter by last name");
            Console.WriteLine("-test Maths -- use for filter by major");
            Console.WriteLine("-mark 5 -- use for filter by grade");
            Console.WriteLine("-datefrom 01.01.2020 -- use for assign the start of a range");
            Console.WriteLine("-dateto 01.01.2020 -- use for assign the end of a range");
        }

        private static void PrintHowToCallHelp()
        {
            Console.WriteLine("Enter \"help\" to show \"How to use\"");
            Console.WriteLine();           
        }

        private static void PrintWelcomeToInput()
        {
            Console.WriteLine();
            Console.WriteLine("Enter filter criteria or just press the \"Enter\" to display unfiltered data");
            Console.WriteLine();
        }

        public static void Load()
        {
            var jsonStudents = Properties.Resources.Students;
            _students = JsonSerializer.Deserialize<List<Student>>(jsonStudents);
        }

        private static void PrintData(IEnumerable<Student> data)
        {
            foreach (var student in data)
            {
                Console.WriteLine(student.ToString());
            }
        }

        // -name Ivan -test Maths -minmark 3 -maxmark 5 -datefrom 20/05/2021 -dateto 22/07/2021 -sort name asc     
        public static IEnumerable<Student> FilterData(IEnumerable<Student> data, string input)
        {
            ParseFilterParameters(input);

            if (!_filterDictionary.Any())
                throw new InvalidOperationException("Nothing to display with accordace entered criteria");      

            IEnumerable<Student> query = data;

            DateTime datefrom;
            DateTime dateto;
            int mark;

            foreach (var item in _filterDictionary)
            {
                switch (item.Key)
                {
                    case "name":
                        query = query.Where(n => n.First_Name == item.Value);
                        break;

                    case "lastname":
                        query = query.Where(n => n.Last_Name == item.Value);
                        break;

                    case "mark":
                        if (int.TryParse(item.Value, out mark))
                            query = query.Where(n => n.Mark == mark);
                        break;

                    case "minmark":
                        if (int.TryParse(item.Value, out mark))
                            query = query.Where(n => n.Mark >= mark);
                        break;

                    case "maxmark":
                        if (int.TryParse(item.Value, out mark))
                            query = query.Where(n => n.Mark <= mark);
                        break;

                    case "datefrom":
                        if (DateTime.TryParse(item.Value, out datefrom))
                            query = query.Where(n => n.Date_Pass >= datefrom);
                            break;

                    case "dateto":
                        if (DateTime.TryParse(item.Value, out dateto))
                            query = query.Where(n => n.Date_Pass <= dateto);
                        break;

                    case "test":
                        query = query.Where(n => n.Test_Name == item.Value);
                        break;

                    case "sort":
                        var sort = item.Value.Split(' ');
                        if (sort.Length >= 2)
                        {
                            switch (sort[0])
                            {
                                case "name":
                                    if (sort[1] == "asc")
                                        query = query.OrderBy(n => n.First_Name);
                                    else
                                        query = query.OrderByDescending(n => n.First_Name);
                                    break;

                                case "lastname":
                                    if (sort[1] == "asc")
                                        query = query.OrderBy(n => n.Last_Name);
                                    else
                                        query = query.OrderByDescending(n => n.Last_Name);
                                    break;

                                case "date":
                                    if (sort[1] == "asc")
                                        query = query.OrderBy(n => n.Date_Pass);
                                    else
                                        query = query.OrderByDescending(n => n.Date_Pass);
                                    break;

                                case "test":
                                    if (sort[1] == "asc")
                                        query = query.OrderBy(n => n.Test_Name);
                                    else
                                        query = query.OrderByDescending(n => n.Test_Name);
                                    break;

                                case "mark":
                                    if (sort[1] == "asc")
                                        query = query.OrderBy(n => n.Mark);
                                    else
                                        query = query.OrderByDescending(n => n.Mark);
                                    break;                               
                            }
                        }
                        break;

                    default:
                        return new List<Student>();
                }
            }

            return query.ToList();
        }

        public static IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        private static void ParseFilterParameters(string sParameters)
        {
            _filterDictionary = new Dictionary<string, string>();

            string[] arrParameters = sParameters.Split('-');
            foreach (var filterParam in arrParameters)
            {
                var param = filterParam.Trim().Split(' ');
                if (param.Length <= 1)
                    continue;

                if (param.Length > 2)
                    _filterDictionary.Add(param[0], param[1] + " " + param[2]);
                else
                    _filterDictionary.Add(param[0], param[1]);
            }  
        }
    }
}