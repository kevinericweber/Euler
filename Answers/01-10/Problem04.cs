using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* PROBLEM 4 - Largest palindrome product
     *  A palindromic number reads the same both ways. The largest palindrome made from the
     * product of two 2-digit numbers is 9009 = 91 × 99.
     * Find the largest palindrome made from the product of two 3-digit numbers.
     */
    public class Problem04 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerNum().ToString();
        }

        private int GetAnswerNum()
        {
            int highestAnswer = 0;
            for (int first3DigitNumber = 998; first3DigitNumber >= 100; first3DigitNumber--)
            {
                for (int second3DigitNumber = 999; second3DigitNumber > first3DigitNumber; second3DigitNumber--)
                {
                    int mult = first3DigitNumber * second3DigitNumber;
                    if (second3DigitNumber == 999 && mult < highestAnswer) return highestAnswer;
                    // aka, if second=999, continuing with lower values of the first won't get us any higher
                    // (so we know we've already found the best answer.)

                    if (mult < highestAnswer)
                    {
                        // aka, no use looping through the rest of the inner loop - our values are too low!
                        if (second3DigitNumber == 999)
                            return highestAnswer; // however, if we're at second=999, no sense in searching any more at all!

                        // otherwise, break out, and start with a lower value of firstNum
                        break;
                    }

                    if (IsPalindrome(mult))
                    {
                        highestAnswer = mult;
                    }

                }
            }
            return highestAnswer;

        }

        private static bool IsPalindrome(long num)
        {
            string a = num.ToString();                      // maybe not most efficient, but easiest to read.
            string b = new string(a.Reverse().ToArray());   // if Problem04 took more than ~10 ms to run
            if (a.Equals(b)) return true;                   // I'd consider optimizing this function to speed it up
            return false;
        }

        public override bool KnownTestPasses()
        {
            // note: this doesn't actually test whether the answer is the largest.
            int actualAnswer = GetAnswerNum();
            if (!IsPalindrome(actualAnswer)) return false;
            List<long> factors = Shared.GetAllFactors(actualAnswer);
            var relevantFactors = factors.Where(x => x >= 100 && x <= 999);
            return (relevantFactors.Count() >= 2);
        }
    }
}
