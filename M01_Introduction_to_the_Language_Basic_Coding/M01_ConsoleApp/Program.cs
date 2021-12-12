using ArrayHelper;
using RectangleHelper;
using System;


namespace M01_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start "M01. Introduction to the Language. Basic Coding" homework result
            PrintModuleTitle(); 

            // Array Bubble sort
            PrintArrayBubbleSortExample();

            // Calculation sum of all positive elements of two dimentional array
            PrintCalcSumAllPositiveElementsOfTwoDimensionalArray();

            // Perimeter and square of rectangle calculation result
            PrintPerimeterAndSquareOfRectangleCalcResult(); 


            Console.ReadKey();
        }


        private static void PrintModuleTitle()
        {
            Console.WriteLine("M01. Introduction to the Language. Basic Coding\r\n");
            Console.WriteLine("Start using ArrayHelper to show how the Bubble sort work.");
            Console.WriteLine("\r\n");
        }

        private static void PrintArrayBubbleSortExample()
        {
            // Sort array ascending

            Console.WriteLine("Create an array of integers and sort it ascending using the Bubble sort\r\n");

            int[] arrArrayToSortAsc = new int[] { 2, 4, 1, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Before sort\r");
            Console.Write("[{0}]", string.Join(", ", arrArrayToSortAsc));
            Console.WriteLine("\r\n");

            arrArrayToSortAsc = ArrayBubbleSort.BubbleSortAsc(arrArrayToSortAsc);
            Console.WriteLine("After sort\r");
            Console.Write("[{0}]", string.Join(", ", arrArrayToSortAsc));
            Console.WriteLine("\r\n");
            Console.WriteLine("Array arrArrayToSort has been sorted ascending");

            // Sort array descending

            Console.WriteLine("Create an array of integers and sort it descending using the Bubble sort\r\n");

            int[] arrArrayToSortDesc = new int[] { 2, 4, 1, 3, 8, 5, 7, 6, 9, 0 };
            Console.WriteLine("Before sort\r");
            Console.Write("[{0}]", string.Join(", ", arrArrayToSortDesc));
            Console.WriteLine("\r\n");

            arrArrayToSortDesc = ArrayBubbleSort.BubbleSortDesc(arrArrayToSortDesc);
            Console.WriteLine("After sort\r");
            Console.Write("[{0}]", string.Join(", ", arrArrayToSortDesc));
            Console.WriteLine("\r\n");
            Console.WriteLine("Array arrArrayToSort has been sorted descending");

            Console.WriteLine("\r\n");
        }

        private static void PrintCalcSumAllPositiveElementsOfTwoDimensionalArray()
        {
            // Sum all even elements of an given two-dimencional array
            Console.WriteLine("Sum all positive elements of a two-dimensional array\r\n");

            Console.WriteLine("\r");
            int[,] arrTwoDimentionalArray = new int[,] { { 1, 2 }, { 23, 4 }, { 5, 46 }, { 27, 8 }, { -4, 2 }, { 3, -7 }, { -15, 6 }, { 7, 85 } };            
            int nSumAllPositiveElements = ArrayCalc.SumAllPositiveElementsOfTwoDimensionalArray(arrTwoDimentionalArray);

            // Print the sum if a two-dimensional array has been given
            if (nSumAllPositiveElements > 0)
                Console.WriteLine($"Sum of all positive elements of presented two dimension array is { nSumAllPositiveElements } \r\n");
            else
                Console.WriteLine($"Warning { nSumAllPositiveElements }: there is no any two-dimensional array has given \r\n");

            Console.WriteLine("\r\n");
            Console.WriteLine("\r\n");
        }

        private static void PrintPerimeterAndSquareOfRectangleCalcResult()
        {
            // Second part of homework - using RectangleHelper
            Console.WriteLine("Start using RectangleHelper to show how the Bubble sort work.");
            Console.WriteLine("\r\n");

            int nFirstSideOfRectangle = 23;
            int nSecondSideOfRecangle = 35;

            Console.WriteLine("Rectangle parameters:");
            Console.WriteLine($"First side length: { nFirstSideOfRectangle }");
            Console.WriteLine($"Second side length: { nSecondSideOfRecangle }");

            Console.WriteLine("\r\n");

            Console.WriteLine("Calculate the perimeter of a rectangle:");
            Console.WriteLine($"Perimeter is: { RectangleCalc.RectanglePerimeterCalc(nFirstSideOfRectangle, nSecondSideOfRecangle) }");

            Console.WriteLine("\r\n");

            Console.WriteLine("Calculate the square of a rectangle:");
            Console.WriteLine($"Square is: { RectangleCalc.RectangleSquareCalc(nFirstSideOfRectangle, nSecondSideOfRecangle) }");
        }
    }
}