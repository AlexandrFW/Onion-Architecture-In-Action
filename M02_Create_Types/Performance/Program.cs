using System;
using System.Diagnostics;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ArraysDimension = 100000;

            Console.WriteLine("M02. Create Types\r\n");

            Console.WriteLine("Task 2\r\n");

            Random rnd = new();

            Process proc = Process.GetCurrentProcess();

            var timer = new Stopwatch();

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            // Test with classes

            proc.Refresh();
            long lMemoryUsageBefore = proc.PrivateMemorySize64;

            C[] arrC = new C[ArraysDimension];
           
            Console.WriteLine($"Memory usage before array of C classes initialization = { lMemoryUsageBefore }");           

            for (int i = 0; i < arrC.Length - 1; i++)
            {
                arrC[i] = new C() { _i = rnd.Next(0, 99999) };
            }

            proc.Refresh();
            long lMemoryUsageAfter = proc.PrivateMemorySize64;
            Console.WriteLine($"Memory usage after array of C classes initialization = { lMemoryUsageAfter }");
            Console.WriteLine($"Memory usage delta on the array of C classes = { (lMemoryUsageAfter - lMemoryUsageBefore) / 1024 } kBytes");

            timer.Start();

            Array.Sort(arrC);

            timer.Stop();

            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine($"Time taken after array with classes sort = { timeTaken.ToString(@"m\:ss\.fff") }ms"); // ms

            Console.WriteLine("\r\n");

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            // Test with struct

            proc.Refresh();
            lMemoryUsageBefore = proc.PrivateMemorySize64;

            S[] arrS = new S[ArraysDimension];
            
            Console.WriteLine($"Memory usage before array of S structs initialization = { lMemoryUsageBefore }");

            for (int i = 0; i < arrS.Length - 1; i++)
            {
                arrS[i] = new S() { _i = rnd.Next(0, 99999) };
            }

            proc.Refresh();
            lMemoryUsageAfter = proc.PrivateMemorySize64;
            Console.WriteLine($"Memory usage after array of S structs initialization = { lMemoryUsageAfter }");
            Console.WriteLine($"Memory usage delta on the array of S structs = { (lMemoryUsageAfter - lMemoryUsageBefore) / 1024 } kBytes");

            timer.Start();

            Array.Sort(arrS);

            timer.Stop();

            timeTaken = timer.Elapsed;
            Console.WriteLine($"Time taken after array with structs sort =  { timeTaken.ToString(@"m\:ss\.fff") }ms"); // ms

            Console.ReadKey();
        }
    }
}