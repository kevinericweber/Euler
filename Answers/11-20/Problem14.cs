using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* The following iterative sequence is defined for the set of positive integers:
     * n → n/2 (n is even
     * n → 3n + 1 (n is odd)
     * Using the rule above and starting with 13, we generate the following sequence:
     * 13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
     * It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.
     * Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
     * Which starting number, under one million, produces the longest chain?
     * NOTE: Once the chain starts the terms are allowed to go above one million.
    */
    class Problem14 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerWithMaxStartValue(999999).ToString();
        }


        private int GetAnswerWithMaxStartValue(int maxStartValue)
        {
            int[] numberCountInKnownSequence = new int[maxStartValue + 2];
            numberCountInKnownSequence[1] = 1;
            numberCountInKnownSequence[2] = 2;

            int largestSequenceLengthFound = 0;
            int numberFoundWithLargestSequence = 0;

            for (int i = 3; i < maxStartValue; i++)
            {
                PartialSequence partialSequence = FindStepsToLowerNumber(i);
                numberCountInKnownSequence[i] =
                        numberCountInKnownSequence[partialSequence.lowerNumberThatWasReached]
                        + partialSequence.stepsToReachALowerNumber;
                if (numberCountInKnownSequence[i] > largestSequenceLengthFound)
                {
                    largestSequenceLengthFound = numberCountInKnownSequence[i];
                    numberFoundWithLargestSequence = i;
                }
            }
            return numberFoundWithLargestSequence;

        }

        private PartialSequence FindStepsToLowerNumber(int slot)
        {
            if (slot % 2 == 0)
                return new PartialSequence(1, slot / 2);

            long current = slot;
            int num = 0;
            while (current >= slot)
            {
                if (current % 2 == 0)
                    current = current / 2;
                else
                    current = 3 * current + 1;
                num++;
            }
            return new PartialSequence(num, (int)current);
        }

        public override bool KnownTestPasses()
        {
            int expected = 27; // gathered from a table of collatz values, choosing 50 as max
            int actual = GetAnswerWithMaxStartValue(50);
            return (expected == actual);
        }

        private class PartialSequence
        {
            public int stepsToReachALowerNumber;
            public int lowerNumberThatWasReached;
            public PartialSequence(int iter, int slot)
            {
                this.stepsToReachALowerNumber = iter;
                this.lowerNumberThatWasReached = slot;
            }
        }
    }
}
