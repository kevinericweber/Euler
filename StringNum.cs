using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    // you may be thinking... "what?!"
    // Why on earth is this fool making his own math library to deal with very large numbers?!
    // Hasn't he heard of the BigInteger library, or any other existing solutions?
    // ... well, to be honest, it almost felt like cheating.
    // When the problem is, "Add these 50-digit numbers together", it seems kinda silly
    // to just plug them into BigInteger and perform a '+' operation.
    // Plus, well, writing a janky math library sounded kind of fun!  :-)
    public class StringNum
    {
        private string reversedDigits;
        public StringNum(string stringNum)
        {
            this.reversedDigits = new string(stringNum.Reverse().ToArray());
        }
        public static StringNum Add(StringNum a, StringNum b)
        {
            string result = "";

            int aLength = a.reversedDigits.Length;
            int bLength = b.reversedDigits.Length;

            int maxLen = aLength;
            if (bLength > maxLen) maxLen = bLength;
            maxLen++;

            int carry = 0;
            for (int digit = 0; digit < maxLen; digit++)
            {
                int aN = 0;
                if (digit < aLength) aN = a.reversedDigits[digit] - '0';
                int bN = 0;
                if (digit < bLength) bN = b.reversedDigits[digit] - '0';

                int value = aN + bN + carry;
                carry = 0;
                while (value >= 10)
                {
                    carry++;
                    value -= 10;
                }
                result += (char)('0' + value);
            }
            result = result.TrimEnd('0');
            string nonReversed = new string(result.Reverse().ToArray());
            return new StringNum(nonReversed);
        }

        public static StringNum Multiply(StringNum a, int b)
        {
            string result = "";

            int aLength = a.reversedDigits.Length;
            int carry = 0;
            for (int digit = 0; digit <= aLength; digit++)
            {
                int aN = 0;
                if (digit < aLength) aN = a.reversedDigits[digit] - '0';

                int value = aN * b + carry;
                carry = value / 10;
                value = value % 10;

                result += (char)('0' + value);
            }
            while (carry != 0)
            {
                int value = carry % 10;
                carry = carry / 10;
                result += (char)('0' + value);
            }
            result = result.TrimEnd('0');
            string nonReversed = new string(result.Reverse().ToArray());
            return new StringNum(nonReversed);
        }

        public override string ToString()
        {
            return new string(reversedDigits.Reverse().ToArray());
        }
    }

}
