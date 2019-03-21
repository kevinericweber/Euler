using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem40 : answerBaseClass
    {
        public override string GetAnswer()
        {
            //TestThisStupidThingOut();

            int retInt =
                GetDN(1) +
                GetDN(10) +
                GetDN(100) +
                GetDN(1000) +
                GetDN(10000) +
                GetDN(100000) +
                GetDN(1000000);
            
            return retInt.ToString();
        }


        private int GetDN(int digitNum)
        {
            int tenPow = 1;
            int numAtPow = 9;
            int lenAtPow = 1;
            while (digitNum > lenAtPow * numAtPow)
            {
                digitNum -= (lenAtPow * numAtPow);
                tenPow = tenPow * 10;
                lenAtPow++;
                numAtPow = numAtPow * 10;
            }

            int numsSkipped = (digitNum-1) / lenAtPow;

            digitNum -= (numsSkipped * lenAtPow);

            int numToLookAt = tenPow + numsSkipped;

            int retVal = numToLookAt.ToString()[digitNum - 1] - '0';

            return retVal;
        }


        private void TestThisStupidThingOut()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < 1200; i++)
            {
                sb.Append(i.ToString());
            }
            string assembled = sb.ToString();

            int max = assembled.Length;

            for (int i = 1; i <= max; i++)
            {
                int actual = assembled[i - 1] - '0';
                int expected = GetDN(i);
                if (actual != expected)
                    throw new Exception("Something did not work...");
            }
        }
    }
}
