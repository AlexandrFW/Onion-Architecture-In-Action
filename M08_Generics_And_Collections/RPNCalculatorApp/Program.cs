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
                Console.WriteLine(RPN.CalculateReversePolishNotation("5 1 2 + 4 * + 3 - +"));
                Console.Write("Enter a reverse polish notation expression: "); 
                Console.WriteLine($"Result is {RPN.CalculateReversePolishNotation(Console.ReadLine())}");                

                Console.WriteLine("Press \"Y\" to continue or \"N\" to exit");
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Y)
                    continue;

                if (key.Key == ConsoleKey.N)
                    break;
            }

            Console.ReadKey();
        }
    }
}