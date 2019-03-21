using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem58 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int primesFound = 3;
            int nonPrimesFound = 2;

            int sideLen = 3;
            int[] candidates = new int[3];
            while (primesFound * 9 > nonPrimesFound)
            {
                sideLen += 2;

                nonPrimesFound++; // bottom right diagonal will always be non-prime: it's a perfect square.

                int totalWithSideLen = sideLen * sideLen;
                candidates[0] = totalWithSideLen - sideLen + 1;
                candidates[1] = candidates[0] - sideLen + 1;
                candidates[2] = candidates[1] - sideLen + 1;

                foreach (int candidate in candidates)
                {
                    if (Primality.isPrime(candidate))
                        primesFound++;
                    else
                        nonPrimesFound++;
                }

            }

            return sideLen.ToString();
        }
    }
}
