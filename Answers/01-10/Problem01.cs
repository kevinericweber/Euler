using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* PROBLEM 1 - Multiples of 3 and 5
     * If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
     * Find the sum of all the multiples of 3 or 5 below 1000.
     */
    public class Problem01 : testableAnswer
    {
        public override string GetAnswer()
        {
            int value = GetAnswerWithMaxValue(999);
            return value.ToString();
        }

        public override bool KnownTestPasses()
        {
            int expectedValue = 60;
            int actualValue = GetAnswerWithMaxValue(16);
            return (expectedValue == actualValue);
        }

        private int GetAnswerWithMaxValue(int maxValue)
        {
            int threes = GetSumOfAllMultiples(3, maxValue);
            int fives = GetSumOfAllMultiples(5, maxValue);
            int fifteens = GetSumOfAllMultiples(15, maxValue);

            return (threes + fives - fifteens);
        }

        private int GetSumOfAllMultiples(int multiple, int max)
        {
            int cnt = max / multiple;
            return (cnt + cnt * cnt) / 2 * multiple;
        }
    }
}
