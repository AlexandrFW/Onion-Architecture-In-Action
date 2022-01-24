using ReversePolishNotationCalcLibrary;
using System;

namespace RPNCalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M08. Reverse Polish Notation Calculator!");

            while (true)  
            {
                Console.Write("Enter a standart expression: "); 
                Console.WriteLine($"Result is {RPN.Calculate(Console.ReadLine())}");  

                Console.WriteLine("Press \"Y\" to continue or \"N\" to exit");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                    continue;
                else if (key.Key == ConsoleKey.N)
                    break;
            }

            Console.ReadKey();
        }
    }
}