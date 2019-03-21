using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem46 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // okay, so here's our approach:
            // get a list of all the odd composite numbers below a certain threshhold
            // then, we copy this list into a possi
            
            int upperThreshhold = 1000000;
            SortedSet<int> oddComposites = new SortedSet<int>();
            for (int i = 9; i < upperThreshhold; i += 2)
            {
                if (!Primality.isPrime(i))
                    oddComposites.Add(i);
            }
            
            List<int> possibilities = new List<int>();
            possibilities.AddRange(oddComposites);

            int subtractNum = 0;
            Func<int, bool> IsStillOkay = (i) => oddComposites.Contains(i - subtractNum) || (i - subtractNum < 1);

            int loopThresh = (int)Math.Sqrt(upperThreshhold / 2 + 1);

            for (int sq = 1; sq <= loopThresh; sq++)
            {
                subtractNum = 2 * sq * sq;
                possibilities = possibilities.Where(i => IsStillOkay(i)).ToList();
            }
            //subtractNum = 8;
            //possibilities = possibilities.Where(i => IsStillOkay(i)).ToList();


            return possibilities.Min().ToString();
        }
    }
}
