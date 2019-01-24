using KigoChallange.Services.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KigoChallange.Services
{
    public class FizzBuzz : IFizzBuzz
    {
        private TextWriter _textWriter;

        public FizzBuzz(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        public void PrintNumbers(int N)
        {
            for (int i = 1; i <= N; i++)
            {
                if (i.ToString().Contains("3"))
                {
                    _textWriter.Write("lucky");
                }
                else if (i % 15 == 0)
                {
                    _textWriter.Write("fizzbuzz");
                }
                else if (i % 3 == 0)
                {
                    _textWriter.Write("fizz");
                }
                else if (i % 5 == 0)
                {
                    _textWriter.Write("buzz");
                }
                else
                {
                    _textWriter.Write(i);
                }
                _textWriter.Write(" ");
            }
        }


        public void PrintNumbersWithReport(int N)
        {
            _textWriter.Flush();
            PrintNumbers(N);
            string text = _textWriter.ToString();
            _textWriter.WriteLine();

            Dictionary<string, string> dictionaryRegPattern = new Dictionary<string, string>();
            dictionaryRegPattern.Add("fizz", @"(?<!\w)fizz(?!\w)");
            dictionaryRegPattern.Add("buzz", @"(?<!\w)buzz(?!\w)");
            dictionaryRegPattern.Add("fizzbuzz", @"(?<!\w)fizzbuzz(?!\w)");
            dictionaryRegPattern.Add("lucky", @"(?<!\w)lucky(?!\w)");
            dictionaryRegPattern.Add("integer", @"(?<!\w)\d+(?!\w)");
            foreach (var item in dictionaryRegPattern)
            {
                _textWriter.WriteLine(item.Key + ": " + Regex.Matches(text, item.Value).Count);
            }
        }
    }
}
