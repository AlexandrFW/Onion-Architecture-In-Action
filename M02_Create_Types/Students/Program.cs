using System;
using System.Collections.Generic;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M02. Create Types\r\n");

            Console.WriteLine("Task 1\r\n");

            var student1c1 = new Student("alexey.potapov@epam.com");
            var student2c1 = new Student("Ivan.Ofanasiev@epam.com");
            var student3c1 = new Student("Dmitry.Vasiliev@epam.com");

            var student1c2 = new Student("Alexey", "Potapov");
            var student2c2 = new Student("Ivan", "Ofanasiev");
            var student3c2 = new Student("dmitry", "vasiliev");

            string[] subjects = { "Information Technology", "PE", "Math", "Music", "History", "Art"};

            var studentSubjectDict = new Dictionary<Student, HashSet<string>>();
            studentSubjectDict[student1c1] = new HashSet<string>() { subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)] };
            studentSubjectDict[student2c1] = new HashSet<string>() { subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)] };
            studentSubjectDict[student3c1] = new HashSet<string>() { subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)] };
            studentSubjectDict[student1c2] = new HashSet<string>() { subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)] };
            studentSubjectDict[student2c2] = new HashSet<string>() { subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)] };
            studentSubjectDict[student3c2] = new HashSet<string>() { subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)], subjects[new Random().Next(0, 5)] };

            Console.WriteLine("Just 3 students in the Dictionary");

            foreach (var student in studentSubjectDict)
            {
                Console.WriteLine(student.Key.FullName);
            }

            Console.ReadKey();
        }
    }
}