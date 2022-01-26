using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationCalcLibrary
{
    public static class RPN
    {
        // True if the given char is delimeter
        private static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;

            return false;
        }

        // True if the given char is operator
        private static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;

            return false;
        }

        // Return operator priority
        private static byte GetPriority(char s)
        {
            return s switch
            {
                '(' => 0,
                ')' => 1,
                '+' => 2,
                '-' => 3,
                '*' => 4,
                '/' => 4,
                '^' => 5,
                _ => 6,
            };
        }

        public static double CalculateNormalExpresion(string input)
        {
            Console.WriteLine($"Reverse Polish Notation expresion is \"{GetExpression(input)}\"");
            return CalculateReversePolishNotation(GetExpression(input)); 
        }

        private static string GetExpression(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var output = new StringBuilder();//string.Empty; // expression
            var operStack = new Stack<char>(); // operators stack

            for (int i = 0; i < input.Length; i++) // process each symbol
            {
                // If delimeter, continue
                if (IsDelimeter(input[i]))
                    continue;  

                // If digit read whole number
                if (char.IsDigit(input[i]))  
                {
                    // Reads to a delimeter or operator
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output.Append(input[i]); // add each digit of the number to output
                        i++; // goes to next symbol

                        if (i == input.Length) // goes out if last symbol
                            break; 
                    }

                    output.Append(" ");  
                    i--; // Return to one symbol back before the delimeter
                }

                // If operator
                if (IsOperator(input[i]))  
                {
                    if (input[i] == '(') // If open bracket push to stack
                        operStack.Push(input[i]);  
                    else if (input[i] == ')') //If closing bracket push to stack
                    {
                        //Put all data prior to open bracket
                        var s = operStack.Pop();

                        while (s != '(')
                        {
                            output.Append(s.ToString() + ' ');
                            s = operStack.Pop();
                        }
                    }
                    else // If another operator
                    {
                        if (operStack.Count > 0) // If stack contains elements
                            if (GetPriority(input[i]) <= GetPriority(operStack.Peek())) // If operator priority is less or equals to operator at stack haed
                                output.Append(operStack.Pop().ToString() + " ");             // than add the last operator from stack to the output

                        operStack.Push(char.Parse(input[i].ToString())); // If stack is empty or operator priority is greater than previous add operator to the head of the stack

                    }
                }
            }

            // After all symbols are passed get all elements from stack which left  
            while (operStack.Count > 0)
                output.Append(operStack.Pop() + " ");

            return output.ToString();  
        }

        public static double CalculateReversePolishNotation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            double result = 0;  
            var temp = new Stack<double>(); //Stack for solution

            for (int i = 0; i < input.Length; i++) // for each symbols
            {
                // If a digit read whole number and push the head of the stack
                if (char.IsDigit(input[i]))
                {
                    var a = string.Empty;

                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i]; // Add
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i])) // If operator
                {
                    // Get the two last values from stack
                    try
                    {
                        var a = temp.Pop();// : throw new InvalidOperationException("Operands is over. Nothing to operate. Check if your expression is correct");
                        var b = temp.Pop();

                        switch (input[i]) // process that values with accordance to an operator
                        {
                            case '+': result = b + a; break;
                            case '-': result = b - a; break;
                            case '*': result = b * a; break;
                            case '/': result = b / a; break;
                            case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                        }
                        temp.Push(result);
                    }
                    catch (InvalidOperationException e)
                    {
                        throw new InvalidOperationException($"Operands {e.Message} Nothing to operate. Check if your expression is correct");
                    }
                }
            }
            return temp.Pop(); // Return results of all calculations
        }
    }
}