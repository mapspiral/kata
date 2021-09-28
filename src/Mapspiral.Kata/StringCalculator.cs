using System;
using System.IO;
using System.Linq;

namespace Mapspiral.Kata.Tests
{
    public sealed class StringCalculator
    {
        public int Add(string inputText)
        {
            var delimiter = ",";
            if (inputText.StartsWith("//"))
            {
                var parts = inputText.Split(Environment.NewLine);
                delimiter = parts.Length > 1 
                    ? parts[0][2..]
                    : throw new InvalidDataException();
                inputText = inputText.Substring(inputText.IndexOf(Environment.NewLine, StringComparison.Ordinal));
            }

            if (inputText == string.Empty)
            {
                return 0;
            }

            static int Parse(string part) => int.TryParse(part, out var parsedValue)
                ? parsedValue
                : throw new InvalidDataException();

            var parsedValues = inputText.Split(delimiter).Select(Parse).ToArray();

            var negativeValues = parsedValues.Where(v => v < 0);
            if (negativeValues.Any())
            {
                throw new InvalidDataException($"Negatives not allowed: {string.Join(',', negativeValues)}");
            }
            
            return parsedValues.Sum();
        }
    }
}