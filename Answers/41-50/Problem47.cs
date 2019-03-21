using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Euler
{
    class Problem47 : answerBaseClass
    {
        public override string GetAnswer()
        {
            long samplePoint = 0;
            long solution = 0;
            
            
            while (solution == 0)
            {
                samplePoint += 4;
                if (IsSamplePointRelevant(samplePoint))
                {
                    if (AreSubsamplePointsRelevant(samplePoint))
                    {
                        solution = CheckForSolution(samplePoint);
                        if (solution != 0) return solution.ToString();
                    }
                }
            } 

            return "";
        }

        private long CheckForSolution(long x)
        {
            int seqCount = 0;
            long firstFound = 0;
            for (long place = x - 3; place <= x + 3; place++)
            {
                if (IsSamplePointRelevant(place))
                {
                    seqCount++;
                    if (firstFound == 0) firstFound = place;
                    if (seqCount == 4) return firstFound;
                }
                else
                {
                    seqCount = 0;
                    firstFound = 0;
                }
            }
            return 0;
        }

        private bool IsSamplePointRelevant(long x)
        {
            return GetNumberOfDistinctPrimeFactors(x) == 4;
        }

        private bool AreSubsamplePointsRelevant(long x)
        {
            if (IsSamplePointRelevant(x - 2)) return true;
            if (IsSamplePointRelevant(x + 2)) return true;
            return false;
        }

        private int GetNumberOfDistinctPrimeFactors(long x)
        {
            List<long> primeFactors = Shared.GetPrimeFactors(x);
            return primeFactors.Distinct().Count() - 1;  // reduce by 1 to remove the '1' entry in the list.
        }
    }
}
