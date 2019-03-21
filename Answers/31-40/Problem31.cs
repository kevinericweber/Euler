using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem31 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<int> coinAmounts = new List<int>();

            coinAmounts.Add(1);
            coinAmounts.Add(2);
            coinAmounts.Add(5);
            coinAmounts.Add(10);
            coinAmounts.Add(20);
            coinAmounts.Add(50);
            coinAmounts.Add(100);
            coinAmounts.Add(200);

            int targetTotal = 200;

            long result = GetPossibilities(coinAmounts, targetTotal);

            return result.ToString();
        }

        private long GetPossibilities(List<int> coinsAllowed, int target)
        {
            if (target == 0) return 1;
            List<int> coinsSmallEnough = coinsAllowed.Where(i => i <= target).OrderBy(i=>-i).ToList();
            if (coinsSmallEnough.Count() == 0) return 0;
            if (coinsSmallEnough.Count() == 1)
            {
                int lastAmt = coinsSmallEnough[0];
                if (target % lastAmt == 0) return 1;
                return 0;
            }
            
            int largest = coinsSmallEnough[0];
            long possibilitiesUsingLargest = GetPossibilities(coinsSmallEnough, target - largest);
            coinsSmallEnough.RemoveAt(0);
            long possibilitiesNotUsingLargest = GetPossibilities(coinsSmallEnough, target);
            return possibilitiesNotUsingLargest + possibilitiesUsingLargest;
        }

    }
}
