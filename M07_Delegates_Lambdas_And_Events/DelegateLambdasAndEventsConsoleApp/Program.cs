using System;
using System.Linq;

namespace DelegateLambdasAndEventsConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("M07. Delegates. Lambdas And Events");

            var matrix = new int[,] { { 1, 9, 5 },
                                      { 4, 7, 8 },
                                      { 3, 6, 2 } }; 

            Console.WriteLine("Matrix before sort");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + ", ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            int[] arrProposedStrategies = new int[] { 0, 1, 2, 3, 4, 5, 6 }; // For checking user input with proposed sort strategy

            int nUserChose = -1;
            do
            {
                PrintUserWelcomeInfo();

                string sUserInput = Console.ReadLine();

                if (sUserInput.Length > 1)
                {
                    Console.WriteLine($"Your input is not a number {sUserInput} or exceeded proposed range. You must enter a proposed number value!");
                    nUserChose = 1;
                    continue;
                }

                var IsParsed = int.TryParse(sUserInput, out nUserChose);

                if (IsParsed)
                {
                    if (arrProposedStrategies.Contains(nUserChose))
                    {
                        Console.Clear();

                        StrategyMatrixSort(matrix, nUserChose);
                    }
                    else
                    {
                        Console.WriteLine("You must enter a proposed number value!");
                    }
                }
                else
                {
                    Console.WriteLine($"Your input is not a number {sUserInput}. You must enter a proposed number value!");
                    nUserChose = 1;
                }

            } while (nUserChose > 0);

            #region Events

            Console.WriteLine("Events");
            Console.WriteLine();
            Console.WriteLine("Please, enter the delay value after which the publisher will inform all subscribers");

            int delay = int.Parse(Console.ReadLine());

            var subscriber1 = new Subscriber("S1");
            var subscriber2 = new Subscriber("S2");
            var subscriber3 = new Subscriber("S3");
            var subscriber4 = new Subscriber("S4");
            var subscriber5 = new Subscriber("S5");

            var countDown = new Countdown(delay);
            countDown.OnCounted += subscriber1.countDown_Progress;
            countDown.OnCounted += subscriber2.countDown_Progress;
            countDown.OnCounted += subscriber3.countDown_Progress;
            countDown.OnCounted += subscriber4.countDown_Progress;
            countDown.OnCounted += subscriber5.countDown_Progress;
            countDown.Count();

            Console.ReadKey();

            countDown.OnCounted -= subscriber1.countDown_Progress;
            countDown.OnCounted -= subscriber2.countDown_Progress;
            countDown.OnCounted -= subscriber3.countDown_Progress;
            countDown.OnCounted -= subscriber4.countDown_Progress;
            countDown.OnCounted -= subscriber5.countDown_Progress;
            countDown = null;

            subscriber1 = null;
            subscriber2 = null;
            subscriber3 = null;
            subscriber4 = null;
            subscriber5 = null;

            #endregion
        }

        private static void PrintUserWelcomeInfo()
        {
            Console.WriteLine();
            Console.WriteLine("Please,");
            Console.WriteLine("Enter 1 to sort the matrix by comparing sum of rows' elements (ascending)");
            Console.WriteLine("Enter 2 to sort the matrix by comparing sum of rows' elements (descending)");
            Console.WriteLine("Enter 3 to sort the matrix by comparing min of rows' elements (ascending)");
            Console.WriteLine("Enter 4 to sort the matrix by comparing min of rows' elements (descending)");
            Console.WriteLine("Enter 5 to sort the matrix by comparing max of rows' elements (ascending)");            
            Console.WriteLine("Enter 6 to sort the matrix by comparing max of rows' elements (descending)");
            Console.WriteLine("Enter 0 to exit");
        }

        public static void StrategyMatrixSort(int[,] matrix, int nStrategy)
        {
            switch (nStrategy)
            {
                case 1:
                    MatrixSort.Sort(matrix, true, MatrixSort.CompareByRowSum);
                    Console.WriteLine("Matrix after sort by sum of row's elements (ascending)");
                    break;

                case 2:
                    MatrixSort.Sort(matrix, false, MatrixSort.CompareByRowSum);
                    Console.WriteLine("Matrix after sort by sum of row's elements (descending)");
                    break;

                case 3:
                    MatrixSort.Sort(matrix, true, MatrixSort.CompareByRowMin);
                    Console.WriteLine("Matrix after sort by min of row's elements (ascending)");
                    break;

                case 4:
                    MatrixSort.Sort(matrix, false, MatrixSort.CompareByRowMin);
                    Console.WriteLine("Matrix after sort by min of row's elements (descending)");
                    break;

                case 5:
                    MatrixSort.Sort(matrix, true, MatrixSort.CompareByRowMax);
                    Console.WriteLine("Matrix after sort by max of row's elements (ascending)");
                    break;

                case 6:
                    MatrixSort.Sort(matrix, false, MatrixSort.CompareByRowMax);
                    Console.WriteLine("Matrix after sort by max of row's elements (descending)");
                    break;

                default:
                    Console.WriteLine("There is no sorting algorithm at this way");
                    break;
            };

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + ", ");
                }
                Console.WriteLine();
            }
        }
    }
}