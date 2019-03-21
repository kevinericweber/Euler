using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
     * Find the sum of all the primes below two million.
     */
    class Problem10 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerWithMaxPrime(2000000).ToString();
        }

        public override bool KnownTestPasses()
        {
            long actual = 17;
            long expected = GetAnswerWithMaxPrime(10);
            return (expected == actual);
        }

        private long GetAnswerWithMaxPrime(int maxPrime)
        {
            List<int> primes = PrimeGenerator.GetPrimeListWithMaxValue(maxPrime);
            return primes.Sum(a => (long)a);
        }
    }
}
