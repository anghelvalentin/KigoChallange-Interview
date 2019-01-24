using KigoChallange;
using KigoChallange.Services;
using KigoChallange.Services.Signatures;
using System;
using System.IO;
using System.Text;
using Xunit;


namespace UnitTests
{
    public class StringHelperTest
    {
        StringHelper _stringHelper;

        public StringHelperTest()
        {
            _stringHelper = new StringHelper();
        }

        [Theory]
        [InlineData("one two three", 2, "two")]
        [InlineData("one;two three", 2, "three")]
        [InlineData("one                     two  three", 2, "two")]
        public void GetWordFromText_PositiveTest(string text, int position, string expectedValue)
        {
            string actualValue = _stringHelper.GetWordFromText(text, position);
            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void GetWordFromText_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _stringHelper.GetWordFromText("one two three", 0));
        }


        [Fact]
        public void GetWordFromText_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stringHelper.GetWordFromText(null, 1));
        }

        [Fact]
        public void GetWordFromText_EmptyTextNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stringHelper.GetWordFromText("", 1));
        }

        [Fact]
        public void GetWordFromText_ArgumentOutOfBoundsException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _stringHelper.GetWordFromText("one two  three", 4));
        }

        [Theory]
        [InlineData("one", "eno")]
        [InlineData("abcd dcba", "abcd dcba")]
        [InlineData("ana are mere", "erem era ana")]
        public void Reverse_PositiveTest(string text, string expectedValue)
        {
            string actualValue = _stringHelper.Reverse(text);
            Assert.Equal(expectedValue, actualValue);
        }


        [Fact]
        public void Reverse_NullException()
        {
            Assert.Throws<ArgumentNullException>(() => _stringHelper.Reverse(null));
        }
    }
}
