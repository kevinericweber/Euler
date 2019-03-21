using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* n! means n × (n − 1) × ... × 3 × 2 × 1
     * For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800
     * and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
     * Find the sum of the digits in the number 100!
     */
    class Problem20 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerForFactorial(100).ToString();
        }

        public override bool KnownTestPasses()
        {
            int expected = 27;
            int actual = GetAnswerForFactorial(10);
            return (expected == actual);
        }

        private int GetAnswerForFactorial(int factorial)
        {
            StringNum num = new StringNum("1");

            for (int i = 2; i <= factorial; i++)
            {
                num = StringNum.Multiply(num, i);
            }

            string finalFactorial = num.ToString();

            int answer = 0;
            foreach (char c in finalFactorial)
            {
                answer += (c - '0');
            }
            
            return answer;

        }
    }
}
