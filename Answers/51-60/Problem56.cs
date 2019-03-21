using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem56 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int bestDigitSum = 0;
            int bestA = 0;
            int bestB = 0;
            for (int a = 99; a > 0; a--)
            {
                BigInteger amount = new BigInteger(a);
                for (int b = 2; b < 100; b++)
                {
                    amount = amount * a;
                    int curDigitSum = GetDigitSum(amount);
                    if (curDigitSum > bestDigitSum)
                    {
                        bestDigitSum = curDigitSum;
                        bestA = a;
                        bestB = b;
                    }
                }
                if (amount.ToString().Length * 9 < bestDigitSum)
                {
                    // at this point, a^99 isn't long enough, even at all 9's, to beat our current best.  Exit out!
                    return bestDigitSum.ToString();
                }
            }
            return bestDigitSum.ToString();
        }

        private int GetDigitSum(BigInteger num)
        {
            int retVal = 0;
            string strVer = num.ToString();
            foreach (char c in strVer)
                retVal += (c - '0');
            return retVal;
        }
    }
}
