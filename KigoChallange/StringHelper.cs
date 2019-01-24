using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KigoChallange
{
    public class StringHelper
    {
        public string GetWordFromText(string text, int position)
        {
            if (position < 1)
            {
                throw new ArgumentException("Position must be greater than 0");
            }
            else if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException("Text parameter is not instantiate or is emtpy");
            }

            string[] lines = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (!(lines.Length >= position))
            {
                throw new ArgumentOutOfRangeException("You are out of range. The string doesn't contain so much words");
            }
            return lines[position - 1];
        }

        public string Reverse(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("Text is not instantiate or is empty");
            }
            StringBuilder reverseTextBuilder = new StringBuilder(text.Length);
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverseTextBuilder.Append(text[i]);
            }
            return reverseTextBuilder.ToString();
        }
    }
}
