using System;
using Xunit;

namespace Mapspiral.Kata.Tests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Should_Construct()
        {
            var sut = new StringCalculator().Add(string.Empty);
        }
    }
}
