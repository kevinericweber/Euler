using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* 2^15 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.
     * What is the sum of the digits of the number 2^1000?
     */
    public class Problem16 : testableAnswer 
    {
        public override string GetAnswer()
        {
            return GetAnswerForSpecificPower(1000).ToString();
        }

        public override bool KnownTestPasses()
        {
            long expected = 26;
            long actual = GetAnswerForSpecificPower(15);
            return (expected == actual);
        }

        private long GetAnswerForSpecificPower(int powerOfTwo)
        {
            // I couldn't figure out any mathematical trick to derive this other than
            // simply multiplying out the number 2^1000 and then checking.
            // Also, once again, using BigInteger seemed way too much like cheating
            // (pretty sure these problems were written before the BigInteger library was available?)
            StringNum myVal = new StringNum("2");
            for (int i = 2; i <= powerOfTwo; i++)
            {
                myVal = StringNum.Add(myVal, myVal);
            }

            string result = myVal.ToString();
            int charSum = 0;
            foreach (char c in result)
            {
                charSum += (c - '0');
            }

            return charSum;
        }
    }
}
