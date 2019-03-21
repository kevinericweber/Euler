using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem23 : answerBaseClass
    {

        public override string GetAnswer()
        {
            // before changing this function to use some nifty LINQ, just beware:
            // I always tried a variety of creative ways of solving it with LINQ
            // (such as matching the list against itself)
            // the end result was actually much slower than the 'dumber' way below
            // and by switching to this method, I cut the run-time in about half.

            int ceiling = 28123;

            List<int> abundants = GetAbundants(ceiling);

            bool[] isAbundantSum = new bool[ceiling + 1];

            for (int i = 0; i < abundants.Count; i++)
            {
                for (int j = 0; j < abundants.Count; j++)
                {
                    int val = abundants[i] + abundants[j];
                    if (val <= ceiling) isAbundantSum[val] = true;
                }
            }

            int runningTotal = 0;
            for (int i = 1; i <= ceiling; i++)
            {
                if (!isAbundantSum[i]) runningTotal += i;
            }
            return runningTotal.ToString();
        }

        private List<int> GetAbundants(int maxVal)
        {
            List<int> retVal = new List<int>();

            for (int i = 1; i <= maxVal; i++)
            {
                if (IsAbundant(i))
                    retVal.Add(i);
            }
            return retVal;
        }

        private bool IsAbundant(int testVal)
        {
            List<long> allFactors = Shared.GetAllFactors(testVal);
            long factorSum = allFactors.Sum() - testVal;
            if (factorSum > testVal) return true;
            return false;
        }


        

    }
}
