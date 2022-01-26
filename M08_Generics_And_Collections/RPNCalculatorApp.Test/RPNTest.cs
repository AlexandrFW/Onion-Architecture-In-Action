using NUnit.Framework;
using ReversePolishNotationCalcLibrary;

namespace RPNCalculatorApp.Test
{
    public class RPNTest
    {
        [Test]
        [TestCase("5 + ((1 + 2) * 4) - 3", ExpectedResult = 14)] // 5 1 2 + 4 * 3 - +  result of privat method GetExpression(string input)
        [TestCase("", ExpectedResult = 0)]
        public double Should_Return_14_From_Given_Normal_Expression(string expression)
        {
            // Assert
            return RPN.CalculateNormalExpresion(expression);
        }

        [Test]
        [TestCase("5 1 2 + 4 * + 3 -", ExpectedResult = 14)]  
        [TestCase("5 1 2 + 4 * 3 - +", ExpectedResult = 14)]  
        [TestCase("", ExpectedResult = 0)]
        public double Should_Return_14_From_Given_RPN_Expression(string expression)
        {
            // Assert
            return RPN.CalculateReversePolishNotation(expression);
        }
    }
}