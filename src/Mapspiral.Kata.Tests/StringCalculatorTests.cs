using System;
using System.IO;
using System.Xml;
using FluentAssertions;
using Xunit;

namespace Mapspiral.Kata.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Should_Construct()
        {
            var sut = new StringCalculator();
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("0", 0)]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        [InlineData("1,2", 3)]
        [InlineData("2,1", 3)]
        [InlineData("10,1", 11)]
        [InlineData("3,5", 8)]
        [InlineData("1,2,3,4,5,6,7,8,9,10", 55)]
        [InlineData("\n1,2", 3)]
        [InlineData("1,\n2", 3)]
        [InlineData("1,2\n", 3)]
        [InlineData("\n1,\n2\n", 3)]
        public void Should_Parse(string inputText, int expectedResult)
        {
            var sut = new StringCalculator();
            var result = sut.Add(inputText);
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Should_HandleCustomDelimiter()
        {
            var inputText = "//;\n1;2";
            var expectedValue = 3;
            var sut = new StringCalculator();
            var result = sut.Add(inputText);
            result.Should().Be(expectedValue);
        }
        
        [Theory]
        [InlineData("-1,2", "Negatives not allowed: -1")]
        [InlineData("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void Should_HandleNegativeValues(string inputText, string errorMessage)
        {
            var sut = new StringCalculator();
            var exception = Assert.Throws<InvalidDataException>(() => sut.Add(inputText));
            exception.Message.Should().Be(errorMessage);
        }
        
        [Theory]
        [InlineData("1001,2", 2)]
        public void Should_IgnoreValuesGreaterThan1000(string inputText, int expectedValue)
        {
            var sut = new StringCalculator();
            var result = sut.Add(inputText);
            result.Should().Be(expectedValue);
        }
    }
}
