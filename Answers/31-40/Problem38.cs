using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem38 : answerBaseClass
    {
        public override string GetAnswer()
        {
            /*
             * Okay, some logic up front (since this code won't make any sense as-is.
             * The restrictive part of the problem isn't that all 9 digits must be used.
             * Instead, the restrictive part is the summation engine and the given value 9:(1,2,3,4,5) = 918273645
             * Which means our answer has to be at least that good - which means our short number has to start with a 9.
             * If our short number starts with a 9, it can't be 2 digits (2 digits + 3 digits + 3 digits != 9.)
             * It can't be 3 digits (3 digits + 4 digits != 9)
             * It *CAN* be 4 digits (4 digits + 5 digits == 9)
             * And if it's 1 digit, it has to be 9:(1,2,3,4,5) [value already given.]
             * So we're simply looking for a 4-digit number, which when combined with its 2x, has all 9 digits.
             * And since we're looking for the largest, we can just start counting down from 9876 to 9182.
             *   (oh, and I manually tested 9182 to make sure I don't have to worry about a near-tie.)
             */

            for (int i = 9876; i > 9182; i--)
            {
                string combined = i.ToString() + (i * 2).ToString();
                if (IsPanglacial(combined))
                {
                    return combined;
                }
            }
            return "918273645"; // 9:(1,2,3,4,5)
        }

        public bool IsPanglacial(string test)
        {
            for (char i = '1'; i <= '9'; i++)
            {
                if (!test.Contains(i)) return false;
            }
            return true;
        }
    }
}
