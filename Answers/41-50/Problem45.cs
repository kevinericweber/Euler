using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem45 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // first up, all Hexagonal numbers are also Triangle numbers (feed 2x-1=n into n(n+1)/2 and you get n(2n-1) )

            BigInteger curP = 1;
            BigInteger curH = 1;
            BigInteger curPVal = Pentagonal(curP);
            BigInteger curHVal = Hexagonal(curH);
            while (curP < 100000000)
            {
                if (curPVal == curHVal)
                    if (curPVal > 40755)
                        return curPVal.ToString();

                if (curPVal > curHVal)
                {
                    // need to increase our H num
                    curH++;
                    curHVal = Hexagonal(curH);
                }
                else
                {
                    curP++;
                    curPVal = Pentagonal(curP);
                }
            }

            return "";
        }

        private BigInteger Pentagonal(BigInteger n)
        {
            return (n * (3 * n - 1)) / 2;
        }

        private BigInteger Hexagonal(BigInteger n)
        {
            return n * (2 * n - 1);
        }
    }
}
