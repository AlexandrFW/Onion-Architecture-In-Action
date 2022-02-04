using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Language_Integrated_Query_App.Test
{
    public class StudentListFilterTest
    {
        [Test]
        public void Get_All_Students_Test()
        {
            // Act
            Program.Load();
            var students = Program.GetAllStudents().OrderBy(s => s);
            var filteredMock = mockStudents.OrderBy(s => s);

            // Assert
            Assert.That(students.SequenceEqual(filteredMock), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(source_for_test_filter_method))]
        public void Filter_Students_With_Any_Parameters_Test(IEnumerable<Student> filteredStudentsLocal, string input)
{
            // Act
            Program.Load();
            var students = Program.GetAllStudents();
            var filteredList = Program.FilterData(students, input);

            // Assert
            Assert.That(filteredList.SequenceEqual(filteredStudentsLocal), Is.True);
        }

        [Test]
        [TestCaseSource(nameof(source_for_test_sort))]
        public void Check_Sort_Function_Test(IEnumerable<Student> studentsLocal, string input)
        {
            // Act
            Program.Load();
            var students = Program.GetAllStudents();
            var filteredList = Program.FilterData(students, input);

            // Assert
            Assert.That(filteredList.SequenceEqual(studentsLocal), Is.True);
        }
        

        static readonly IEnumerable<Student> mockStudents = new List<Student>()
        {
            new Student()
            {
                First_Name = "Ivan",
                Last_Name = "Petrov",
                Test_Name = "Maths",
                Mark = 5,
                Date_Pass = new DateTime(2021, 06, 21, 15, 0, 0)
            },
             new Student()
            {
                First_Name = "Peotor",
                Last_Name = "Sidorov",
                Test_Name = "PE",
                Mark = 4,
                Date_Pass = new DateTime(2021, 06, 21, 15, 30, 0) 
            },
            new Student()
            {
                First_Name = "Andrey",
                Last_Name = "Vasilev",
                Test_Name = "Maths",
                Mark = 4,
                Date_Pass = new DateTime(2021, 06, 21, 12, 20, 0)  
            },
            new Student()
            {
                First_Name = "Svetlana",
                Last_Name = "Petrova",
                Test_Name = "Maths",
                Mark = 5,
                Date_Pass = new DateTime(2021, 06, 20, 14, 20, 0) 
            },
            new Student()
            {
                First_Name = "Danil",
                Last_Name = "Kostrov",
                Test_Name = "Geography",
                Mark = 4,
                Date_Pass = new DateTime(2021, 06, 19, 15, 30, 0)  
            },
            new Student()
            {
                First_Name = "Artem",
                Last_Name = "Nosov",
                Test_Name = "Biology",
                Mark = 3,
                Date_Pass = new DateTime(2021, 06, 19, 15, 10, 0) 
            },
            new Student()
            {
                First_Name = "Dmitry",
                Last_Name = "Vetrov",
                Test_Name = "PE",
                Mark = 4,
                Date_Pass = new DateTime(2021, 06, 22, 16, 30, 0) 
            }
        };

        static readonly object[] source_for_test_filter_method = new object[]
         { 
             new object[] { mockStudents.Where(m => m.Mark == 4), "-mark 4" },
             new object[] { mockStudents.Where(m => m.First_Name == "Ivan"), "-name Ivan" },
             new object[] { mockStudents.Where(m => m.Test_Name == "Maths"), "-test Maths" },
             new object[] { mockStudents.Where(n => n.First_Name == "Andrey").Where(m => m.Test_Name == "Maths"), "-name Andrey -test Maths" },
             new object[] { mockStudents.Where(n => n.First_Name == "Ivan").Where(m => m.Test_Name == "Maths"), "-name Ivan-test Maths" },
             new object[] { mockStudents.Where(n => n.First_Name == "Ivan").Where(m => m.Test_Name == "Maths"), "-name Ivan-test Maths" },

             new object[] { mockStudents.Where(n => n.Date_Pass >= Convert.ToDateTime("20/06/2021"))
                                        .Where(m => m.Date_Pass <= Convert.ToDateTime("20/07/2021")), "-datefrom 20/06/2021 -dateto 20/07/2021" },

             new object[] { mockStudents.Where(n => n.Date_Pass >= Convert.ToDateTime("20.06.2021"))
                                        .Where(m => m.Date_Pass <= Convert.ToDateTime("20.07.2021")), "-datefrom 20.06.2021 -dateto 20.07.2021" },

             new object[] { mockStudents.Where(n => n.Date_Pass >= (DateTime.TryParse("2006.2021", out DateTime date) ? date : Convert.ToDateTime("20.07.2021").AddDays(-60)))
                                        .Where(m => m.Date_Pass <= Convert.ToDateTime("20.07.2021")), "-datefrom 2006.2021 -dateto 20.07.2021" },

             new object[] { mockStudents.Where(m => m.Date_Pass <= Convert.ToDateTime("20/07/2021")), "-dateto 20/07/2021" },

             new object[] { mockStudents.Where(n => n.First_Name == "Ivan")
                                        .Where(n => n.Test_Name == "Maths")
                                        .Where(n => n.Mark >= 3)
                                        .Where(n => n.Mark <= 5)
                                        .Where(m => m.Date_Pass >= Convert.ToDateTime("20/05/2021"))
                                        .Where(n => n.Date_Pass <= Convert.ToDateTime("22/07/2021")), "-name Ivan -test Maths -minmark 3 -maxmark 5 -datefrom 20/05/2021 -dateto 22/07/2021" },

             new object[] { mockStudents.Where(m => m.Test_Name == "PE"), "------test PE" },
             new object[] { new List<Student>(), "-nameeeeee Artem" }
         };

        static readonly object[] source_for_test_sort = new object[] 
        {
            new object[] { mockStudents.OrderBy(m => m.First_Name), "-sort name asc" },
            new object[] { mockStudents.OrderByDescending(m => m.First_Name), "-sort name desc" },
            new object[] { mockStudents.OrderBy(m => m.Last_Name), "-sort lastname asc" },
            new object[] { mockStudents.OrderByDescending(m => m.Last_Name), "-sort lastname desc" },
            new object[] { mockStudents.OrderBy(m => m.Test_Name), "-sort test asc" },
            new object[] { mockStudents.OrderByDescending(m => m.Test_Name), "-sort test desc" },
            new object[] { mockStudents.OrderBy(m => m.Mark), "-sort mark asc" },
            new object[] { mockStudents.OrderByDescending(m => m.Mark), "-sort mark desc" },
            new object[] { mockStudents.OrderBy(m => m.Date_Pass), "-sort date asc" },
            new object[] { mockStudents.OrderByDescending(m => m.Date_Pass), "-sort date desc" }
        };

        private class StudentComparator : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student x, Student y)
            {
                return x.CompareTo(y);
            }
        }
    }
}