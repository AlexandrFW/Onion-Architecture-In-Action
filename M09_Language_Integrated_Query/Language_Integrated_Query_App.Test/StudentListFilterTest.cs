using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace Language_Integrated_Query_App.Test
{
    public class StudentListFilterTest
    {
        [Test]
        public void Get_All_Students_Test()
        {
            // Act
            Program.Load();
            var students = Program.GetAllStudents();
            int count = students.Count;

            // Assert
            Assert.That(count, Is.EqualTo(mockStudents.Count));
        }

        [Test]
        [TestCase("-mark 4", ExpectedResult = 4)]
        [TestCase("-name Ivan", ExpectedResult = 1)]
        [TestCase("-test Maths", ExpectedResult = 3)]
        [TestCase("-name Andrey -test Maths", ExpectedResult = 1)]
        [TestCase("-name Ivan-test Maths", ExpectedResult = 1)]
        [TestCase("-datefrom 20/06/2021 -dateto 20/07/2021", ExpectedResult = 5)]
        [TestCase("-datefrom 20.06.2021 -dateto 20.07.2021", ExpectedResult = 5)]
        [TestCase("-datefrom 2006.2021 -dateto 20.07.2021", ExpectedResult = 7)]
        [TestCase("-dateto 20/07/2021", ExpectedResult = 7)]
        [TestCase("-name Ivan -test Maths -minmark 3 -maxmark 5 -datefrom 20/05/2021 -dateto 22/07/2021", ExpectedResult = 1)]
        [TestCase("-nameeeeee Artem", ExpectedResult = 7)]//-name Ivan -test Maths -minmark 3 -maxmark 5 -datefrom 20/05/2021 -dateto 22/07/2021 -sort name asc
        [TestCase("------test PE", ExpectedResult = 2)]
        public int Filter_Students_With_Any_Parameters_Test(string input)
{
            // Act
            Program.Load();
            var students = Program.GetAllStudents();
            var filteredList = Program.FilterData(students, input);
            int count = filteredList.Count;

            // Assert
            return count;
        }

        [Test]
        [TestCase("-sort name asc")]
        [TestCase("-sort name desc")]
        public void Check_Sort_Function_Test(string input)
        {
            // Act
            Program.Load();
            var students = Program.GetAllStudents();
            students.Sort(new StudentComparator());
            mockStudents.Sort(new StudentComparator());

            // Assert
            Assert.That(students, Is.EqualTo(mockStudents));
        }

        readonly List<Student> mockStudents = new List<Student>()
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

        private class StudentComparator : IComparer<Student>
        {
            int IComparer<Student>.Compare(Student x, Student y)
            {
                return x.CompareTo(y);
            }
        }
    }
}