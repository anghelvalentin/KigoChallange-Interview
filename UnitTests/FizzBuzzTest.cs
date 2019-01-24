using KigoChallange.Services;
using KigoChallange.Services.Signatures;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class FizzBuzzTest : IDisposable
    {

        IFizzBuzz _fizzBuzz;
        StringWriter _stringWriter;
        public FizzBuzzTest()
        {
            _stringWriter = new StringWriter(new StringBuilder());
            _fizzBuzz = new FizzBuzz(_stringWriter);
        }

        [Fact]
        public void TestPrintNumbers_NotEqual()
        {
            string expectedText = "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz ";
            _fizzBuzz.PrintNumbers(20);

            Assert.NotEqual(expectedText, _stringWriter.ToString());
        }

        [Fact]
        public void TestPrint_CheckThreeRule()
        {
            string expectedText = "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz ";

            _fizzBuzz.PrintNumbers(20);

            Assert.Equal(expectedText, _stringWriter.ToString());
        }


        [Fact]
        public void TestPrint_CheckNumbersWithReport()
        {
            string expectedText = @"1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz 
fizz: 4
buzz: 3
fizzbuzz: 1
lucky: 2
integer: 10
";

            _fizzBuzz.PrintNumbersWithReport(20);

            Assert.Equal(expectedText, _stringWriter.ToString());
        }

        public void Dispose()
        {
            _stringWriter.Close();
        }
    }
}
