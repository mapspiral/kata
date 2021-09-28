using System;
using System.IO;

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
            
            return int.TryParse(inputText, out var parsedValue)
                ? parsedValue
                : throw new InvalidDataException();
        }
    }
}