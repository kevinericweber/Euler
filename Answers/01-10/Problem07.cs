using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{    
    /* By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.
     * What is the 10,001st prime number?
     */
    class Problem07 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetNthPrime(10001).ToString();
        }

        public override bool KnownTestPasses()
        {
            int actual = 13;
            int expected = GetNthPrime(6);
            return (actual == expected);
        }

        private int GetNthPrime(int term)
        {
            List<int> primes = PrimeGenerator.GetPrimeListWithNTerms(term);
            return primes.Max();
        }


    }
}
