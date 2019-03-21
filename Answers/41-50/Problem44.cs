using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem44 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int termCount;
            int prevTC;

            termCount = 10;
            prevTC = 1;
            while (termCount < 10000000)
            {
                string possibility = TryToFindAnswer(termCount, prevTC);
                if (possibility != "") return possibility;
                prevTC = termCount;
                termCount = termCount * 10;
            }
            return "Not enough possibilities tested";
        }

        private string TryToFindAnswer(int termCount, int previousTermCount)
        {
            SortedList<long, long> pentagonal = Shared.GetSortedPentagonalList(termCount+2);

            PossibleResult bestSoFar = new PossibleResult(0, pentagonal.Keys[termCount]);
            PossibleResult noFind = new PossibleResult(0, pentagonal.Keys[termCount]);
            
            int combinedSlot = previousTermCount;

            while (combinedSlot < termCount)
            {
                for (int lowSlot = combinedSlot / 2; lowSlot >= 0; lowSlot--)
                {
                    int highSlot = combinedSlot - lowSlot;
                    
                    long pA = pentagonal.Keys[lowSlot];
                    long pB = pentagonal.Keys[highSlot];

                    if (pB - pA > bestSoFar.score)
                        break;
                    if (pentagonal.ContainsKey(pB - pA))
                    {
                        if (pentagonal.ContainsKey(pB + pA))
                        {
                            if (pB - pA < bestSoFar.score) bestSoFar = new PossibleResult(pA, pB);
                        }
                    }
                }

                if (pentagonal.Keys[combinedSlot + 1] - pentagonal.Keys[combinedSlot] > bestSoFar.score)
                {
                    if (bestSoFar.score == noFind.score) return "";
                    return bestSoFar.score.ToString();
                }

                combinedSlot++;
            }
            if (bestSoFar.score == noFind.score) return "";
            return bestSoFar.score.ToString();
        }

        private class PossibleResult
        {
            public long lowPent;
            public long highPent;
            public long score;
            public PossibleResult(long low, long high)
            {
                this.lowPent = low;
                this.highPent = high;
                this.score = high - low;
            }
            
        }

    }


}
