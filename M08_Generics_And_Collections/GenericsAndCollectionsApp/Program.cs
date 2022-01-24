using GenericsAndCollectionsExampleLibrary;
using System;

namespace GenericsAndCollectionsApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M08. Generics And Collections");

            Console.WriteLine();

            Console.WriteLine("Test binary search generic method with int type");
            //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] array = { "1", "d2", "asd3", "4we", "5", "6", "dfr7", "8", "str" };

            Array.Sort(array);

            PrintArray(array);

            Console.WriteLine();

            string needToBeFound = "asd3";
            Console.WriteLine($"We are looking for {needToBeFound}");
            int result = GenericsExamples.BinarySearch(array, needToBeFound, new ComparatorString()); //for array of Int new ComparatorInt());
            Console.WriteLine($"Result of binary search is: element position at index {result}");

            Console.WriteLine();

            Console.WriteLine("Create a generator that will generate 10 Fibonacci numbers");
            var generator = new FibonacciSequinceYieldExamples(10);

            foreach (var num in generator)
            {
                Console.Write(num + ", ");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Queue with Iterator");

            CustomQueue<Person> queuePeson = new CustomQueue<Person>();
            queuePeson.Enqueue(new Person() { FirstName = "Андрей", LastName = "Сидоров" });
            queuePeson.Enqueue(new Person() { FirstName = "Виталий", LastName = "Петров" });
            queuePeson.Enqueue(new Person() { FirstName = "Дмитрий", LastName = "Иванов" });

            var queueIterator = new CustomIterator<Person>(queuePeson);

            while (!queueIterator.IsDone)
            {
                var p = queueIterator.Current;
                Console.WriteLine(p.FirstName + " " + p.LastName);

                queueIterator.MoveNext();
            }

            Console.WriteLine();

            Console.WriteLine("Stack with Iterator");

            CustomStack<Person> stackPerson = new CustomStack<Person>();
            stackPerson.Push(new Person() { FirstName = "Сергей", LastName = "Афанасьев" });
            stackPerson.Push(new Person() { FirstName = "Анатолий", LastName = "Григорьев" });
            stackPerson.Push(new Person() { FirstName = "Пётр", LastName = "Владимиров" });

            var stackIterator = new CustomIterator<Person>(stackPerson);

            while (!stackIterator.IsDone)
            {
                var p = stackIterator.Current;
                Console.WriteLine(p.FirstName + " " + p.LastName);

                stackIterator.MoveNext();
            }

            Console.ReadKey();
        }

        private static void PrintArray<T>(T[] array)
        {
            foreach(var item in array)
                Console.Write(item + ", ");
        }

        private class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}