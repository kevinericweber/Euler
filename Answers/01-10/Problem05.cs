using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* PROBLEM 5 - Smallest multiple
     * 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
     * What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
     */
    class Problem05 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerForLargestDivisor(20).ToString();
        }

        private int GetAnswerForLargestDivisor(int largestDivisor)
        {
            List<int> allPrimesBelow20 = PrimeGenerator.GetPrimeListWithMaxValue(largestDivisor);
            List<int> primesToLargestPowerStillBelow20 = allPrimesBelow20.Select(
                    a =>
                        (int)Math.Pow(a,
                            (int)(Math.Log(largestDivisor) / Math.Log(a))
                    )).ToList();
            int smallestAnswer = primesToLargestPowerStillBelow20.Aggregate((a, b) => a * b);
            return smallestAnswer;
        }

        public override bool KnownTestPasses()
        {
            int expected = 2520;
            int actual = GetAnswerForLargestDivisor(10);
            return (expected == actual);
        }
    }
}
