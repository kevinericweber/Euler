using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* PROBLEM 6 - Sum square difference
     * The sum of the squares of the first ten natural numbers is,
     *      1^2 + 2^2 + ... + 10^2 = 385
     * The square of the sum of the first ten natural numbers is,
     *      (1 + 2 + ... + 10)^2 = 55^2 = 3025
     * Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
     * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.
     */
    class Problem06 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerForLargestTerm(100).ToString();
        }

        public override bool KnownTestPasses()
        {
            int expected = 2640;
            int actual = GetAnswerForLargestTerm(10);
            return (expected == actual);
        }

        private int GetAnswerForLargestTerm(int largestTerm)
        {
            List<int> basicList = new List<int>();
            for (int i = 1; i <= largestTerm; i++) { basicList.Add(i); }

            int sumOfSquares = basicList.Sum(a => a * a);
            int sumQuared = basicList.Sum();
            sumQuared = sumQuared * sumQuared;

            return sumQuared - sumOfSquares;
        }


    }
}
