using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public class Problem50 : answerBaseClass
    {
        public override string GetAnswer()
        {

            List<int> millionPrimes = Primality.GetPrimeListWithMaxValue(1000000);

            PossibleAnswer bestAnswerSoFar = GetBestAnswerForStartSlot(millionPrimes, 0);

            int totalSlotsAvail = millionPrimes.Count;

            for (int i = 1; i < totalSlotsAvail; i++)
            {
                int relevantPrime = millionPrimes[i];
                int playspace = 1000000 - bestAnswerSoFar.finalSum;
                if (relevantPrime * bestAnswerSoFar.numberOfPrimes * 2 > playspace)
                    return bestAnswerSoFar.ToString();
                if (relevantPrime * bestAnswerSoFar.numberOfPrimes > 1000000)
                    return bestAnswerSoFar.ToString();
                PossibleAnswer bestAnswerForSlot = GetBestAnswerForStartSlot(millionPrimes, i);
                if (bestAnswerForSlot.numberOfPrimes > bestAnswerSoFar.numberOfPrimes)
                    bestAnswerSoFar = bestAnswerForSlot;
            }

            return millionPrimes.Count.ToString();
        }


        private PossibleAnswer GetBestAnswerForStartSlot(List<int> millionPrimes, int slot)
        {
            PossibleAnswer bestAnswerSoFar = new PossibleAnswer(0, 0, 0);

            int totalSlotsAvail = millionPrimes.Count;
            int startPrime = millionPrimes[slot];
            int runningSum = 0;
            int currentPrimeNum;
            int currentSlot = slot;

            while (currentSlot < totalSlotsAvail && runningSum < 1000000)
            {
                currentPrimeNum = millionPrimes[currentSlot];
                runningSum += currentPrimeNum;
                if (millionPrimes.Contains(runningSum))
                    bestAnswerSoFar = new PossibleAnswer(startPrime, currentSlot - slot + 1, runningSum);
                currentSlot++;
            }
            return bestAnswerSoFar;
        }

        private class PossibleAnswer
        {
            public int startingPrime;
            public int numberOfPrimes;
            public int finalSum;
            public PossibleAnswer(int start, int count, int sum)
            {
                this.startingPrime = start;
                this.numberOfPrimes = count;
                this.finalSum = sum;
            }

            public override string ToString()
            {
                return this.finalSum.ToString();
            }
        }
    }
}
