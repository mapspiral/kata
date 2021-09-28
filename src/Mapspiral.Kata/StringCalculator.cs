using System;
using System.IO;
using System.Linq;

namespace Mapspiral.Kata.Tests
{
    public sealed class StringCalculator
    {
        public int Add(string inputText)
        {
            if (inputText == string.Empty)
            {
                return 0;
            }

            static int Parse(string part) => int.TryParse(part, out var parsedValue)
                ? parsedValue
                : throw new InvalidDataException();

            return inputText.Split(',').Select(Parse).Sum();
        }
    }
}