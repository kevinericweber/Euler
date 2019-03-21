using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem49 : answerBaseClass
    {

        public override string GetAnswer()
        {

            int second, third;

            List<int> primes = Primality.GetPrimeListWithMaxValue(10000);
            SortedSet<int> unsortedPrimes = new SortedSet<int>(primes);

            foreach (int first in primes.Where(i => i < 5000))
            {
                for (int addAmt = 2; addAmt < 4500; addAmt++)
                {
                    second = first + addAmt;
                    if (unsortedPrimes.Contains(second))
                    {
                        third = second + addAmt;
                        if (unsortedPrimes.Contains(third))
                        {
                            if (areThreeNumsPermutations(first, second, third))
                            {
                                if (first != 1487)
                                {
                                    return first.ToString() + second.ToString() + third.ToString();
                                }
                            }
                        }
                    }

                }
            }
            throw new Exception("Answer Not Found?!?!");
        }

        private bool areThreeNumsPermutations(int a, int b, int c)
        {
            char[] charArrA = a.ToString().OrderBy(x => x).ToArray();
            string strA = new string(charArrA);

            char[] charArrB = b.ToString().OrderBy(x => x).ToArray();
            string strB = new string(charArrB);
            if (!strA.Equals(strB)) return false;

            char[] charArrC = c.ToString().OrderBy(x => x).ToArray();
            string strC = new string(charArrC);
            if (!strB.Equals(strC)) return false;

            return true;
        }


    }
}
