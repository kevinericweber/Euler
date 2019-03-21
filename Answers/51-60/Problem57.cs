using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem57 : answerBaseClass
    {
        public override string GetAnswer()
        {
            BigInteger a = new BigInteger(1);
            BigInteger b = new BigInteger(2);

            int retVal = 0;
            for (int expansionNum = 1; expansionNum <= 1000; expansionNum++)
            {
                BigInteger top = a + b;
                if (top.ToString().Length > b.ToString().Length)
                    retVal++;

                BigInteger temp = a;
                a = b;
                b = 2 * b + temp;
            }

            return retVal.ToString();
        }
    }
}
