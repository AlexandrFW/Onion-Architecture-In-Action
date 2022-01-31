using System;
using System.Collections.Generic;
using System.Text;

namespace ReversePolishNotationCalcLibrary
{
    public static class RPN
    {
        private static bool IsDelimeter(char c)
        {
            if ((" =".IndexOf(c) != -1))
                return true;

            return false;
        }

        private static bool IsOperator(char с)
        {
            if (("+-/*^()".IndexOf(с) != -1))
                return true;

            return false;
        }

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

            var output = new StringBuilder();  
            var operatorsStack = new Stack<char>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                if (IsDelimeter(input[i]))
                    continue;  

                if (char.IsDigit(input[i]))  
                {
                    // Reads whole number till a delimeter or operator
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        output.Append(input[i]); // add each digit of the number to output
                        i++;

                        if (i == input.Length) 
                            break; 
                    }

                    output.Append(" ");  
                    i--; // Return to one symbol back before the delimeter
                }

                if (IsOperator(input[i]))  
                {
                    if (input[i] == '(') 
                        operatorsStack.Push(input[i]);  
                    else if (input[i] == ')') 
                    {
                        var symbol = operatorsStack.Pop();

                        while (symbol != '(')
                        {
                            output.Append(symbol.ToString() + ' ');
                            symbol = operatorsStack.Pop();
                        }
                    }
                    else // If another operator
                    {
                        if (operatorsStack.Count > 0) 
                            if (GetPriority(input[i]) <= GetPriority(operatorsStack.Peek())) 
                                output.Append(operatorsStack.Pop().ToString() + " ");

                        operatorsStack.Push(char.Parse(input[i].ToString()));

                    }
                }
            }

            // Generate output
            while (operatorsStack.Count > 0)
                output.Append(operatorsStack.Pop() + " ");

            return output.ToString();  
        }

        public static double CalculateReversePolishNotation(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            double result = 0;  
            var temp = new Stack<double>(); 

            for (int i = 0; i < input.Length; i++) 
            {
                if (char.IsDigit(input[i]))
                {
                    var a = string.Empty;

                    // Read whole number
                    while (!IsDelimeter(input[i]) && !IsOperator(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (IsOperator(input[i])) 
                {
                    try
                    {
                        var a = temp.Pop();
                        var b = temp.Pop();

                        switch (input[i]) 
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
            return temp.Pop(); 
        }
    }
}