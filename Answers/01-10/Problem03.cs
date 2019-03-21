using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* PROBLEM 3 - Largest Prime Factor
     *  The prime factors of 13195 are 5, 7, 13 and 29.
     * What is the largest prime factor of the number 600851475143 ?
     */

    public class Problem03 : testableAnswer
    {
        public override string GetAnswer()
        {
            long numToLookAt = 600851475143;
            return GetLargestFactor(numToLookAt).ToString();
        }

        public override bool KnownTestPasses()
        {
            long expected = 29;
            long actual = GetLargestFactor(13195);
            return (expected == actual);
        }

        private long GetLargestFactor(long numToLookAt)
        {
            List<long> factors = Shared.GetPrimeFactors(numToLookAt);
            return factors.Max();
        }
    }
}
