using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using NUnit.Framework;
using System;

namespace TypesConverterLibrary.Test
{
    public class UnitTests
    {
        [Test]
        [TestCase("56", 56)]
        public void M05_Task_1_String_To_Int_Converted(string sGivenStringVal, int nExpectedResult)
        {
            // Arrange
            var loggerMoq = Mock.Of<ILogger<Program>>();
            var cStringConverter = new StringToIntConverter(loggerMoq);

            // Act
            var sReturnedInt = cStringConverter.ConvertToInt(sGivenStringVal);

            // Assert
            Assert.That(sReturnedInt, Is.EqualTo(nExpectedResult));
        }

        [Test]
        [TestCase("")]
        public void M05_Task_1_String_To_Int_Converted_Throws_ArgumentException_If_Given_String_Empty(string sGivenStringVal)
        {
            // Arrange
            var loggerMoq = Mock.Of<ILogger<Program>>();
            var StringConverter = new StringToIntConverter(loggerMoq);

            // Assert
            Assert.That(() => StringConverter.ConvertToInt(sGivenStringVal), Throws.ArgumentException);
        }

        [Test]
        [TestCase("45467a")]
        public void M05_Task_1_String_To_Int_Converted_Throws_FormatException_If_Given_String_Is_Not_In_Correct_Format(string sGivenStringVal)
        {
            // Arrange
            var loggerMoq = Mock.Of<ILogger<Program>>();
            var StringConverter = new StringToIntConverter(loggerMoq);

            // Assert
            Assert.That(() => StringConverter.ConvertToInt(sGivenStringVal), Throws.InstanceOf<FormatException>());
        }
    }
}