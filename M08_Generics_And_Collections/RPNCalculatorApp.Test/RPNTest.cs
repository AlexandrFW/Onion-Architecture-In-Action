using NUnit.Framework;
using ReversePolishNotationCalcLibrary;

namespace RPNCalculatorApp.Test
{
    public class RPNTest
    {
        
        [Test]
        [TestCase("5 + ((1 + 2) * 4) - 3")] // 5 1 2 + 4 * 3 - +  result of privat method GetExpression(string input)       
        public void Should_Return_14_From_Given_Expression(string expression)
        {
            // Assign
            var nExpectedResult = 14;

            // Assert
            Assert.That(RPN.Calculate(expression), Is.EqualTo(nExpectedResult));
        }

        [Test]
        [TestCase("")]
        public void Should_Return_0_From_Given_Expression(string expression)
        {
            // Assign
            var nExpectedResult = 0;

            // Assert
            Assert.That(RPN.Calculate(expression), Is.EqualTo(nExpectedResult));
        }
    }
}