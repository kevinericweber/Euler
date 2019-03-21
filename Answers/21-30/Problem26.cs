using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Euler
{
    class Problem26 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // okay, this algorithm requires knowledge of a specific trick: repeating
            // sequences can always be phrased in the form of X/9, X/99, X/999, X/9999, X/99999, etc
            // so if your number is .0633506335063350633506335... (06335 is repeating)
            // then the number is actually 06335/99999.
            // Also, we need to strip out any multiples of 2 and 5.  They won't give a better answer
            // (if 2X is an answer, so is 2 - multiplying by 2 doesn't make the cycle length any longer)
            // and without that restrction, we don't have to worry about a leading digit like 1/6 = 0.1[6]
            

            List<int> possibleAnswers = new List<int>();
            int largestOfPossibilities = 0;

            for (int i = 3; i < 1000; i += 2)
            {
                if (i % 5 != 0) possibleAnswers.Add(i);
            }

            BigInteger niner = new BigInteger(9);  // okay, I finally broke down and used BigInteger.  Sigh.

            while (possibleAnswers.Count() > 0)
            {
                List<int> possibilitiesStillNotDivisibleByAllNines = new List<int>();
                largestOfPossibilities = possibleAnswers.Max();
                foreach (int i in possibleAnswers)
                {
                    if (niner % i != 0)
                        possibilitiesStillNotDivisibleByAllNines.Add(i);
                }
                possibleAnswers.Clear();
                possibleAnswers.AddRange(possibilitiesStillNotDivisibleByAllNines);
                niner = niner * 10 + 9;
            }

            return largestOfPossibilities.ToString();

        }
        
    }
}
