using System;
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
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void Should_Parse(string inputText, int expectedResult)
        {
            var sut = new StringCalculator();
            var result = sut.Add(inputText);
            result.Should().Be(expectedResult);
        }
    }
}
