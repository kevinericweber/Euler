using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem41 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // small trick: any number where the digits add up to something divisible by 3, is also divisible by 3
            // (aka, 3456 is divisible by 3, since 3+4+5+6=18, and 18 is divisible by 3.)
            // Because of this, we know that N (the number of digits) MUST be 1, 4, or 7 - because N = 2/3/5/6/8/9
            // will all produce pandigital numbers that are divisble by 3.


            int sevenDigits = checkDigitCount(7);
            if (sevenDigits != 0) return sevenDigits.ToString();
            int fourDigits = checkDigitCount(4);
            if (fourDigits != 0) return fourDigits.ToString();
            return checkDigitCount(1).ToString();
        }

        private int checkDigitCount(int digitCount)
        {
            int largestPrime = 0;
            Func<List<int>, int> DigitListToNumFunc = l => l.Aggregate((a, b) => a * 10 + b);

            List<int> digits = new List<int>();
            for (int i = 1; i <= digitCount; i++)
                digits.Add(i);

            IEnumerable<List<int>> allCombos = Shared.GetAllPermutations(digits);

            foreach(List<int> permut in allCombos)
            {
                int actualNum = DigitListToNumFunc(permut);
                if (Primality.isPrime(actualNum))
                    if (actualNum > largestPrime)
                        largestPrime = actualNum;
            }
            return largestPrime;

            
        }

    }
}
