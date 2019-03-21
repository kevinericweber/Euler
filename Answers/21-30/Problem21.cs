using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem21 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<long> amicables = new List<long>();
            long[] knownDValues = new long[10001];

            for (int numToCheck = 1; numToCheck < 10000; numToCheck++)
            {
                long currentDValue = GetDValue(numToCheck);
                knownDValues[numToCheck] = currentDValue;
                if (currentDValue < numToCheck)
                {
                    if (knownDValues[currentDValue] == numToCheck)
                    {
                        amicables.Add(numToCheck);
                        amicables.Add(currentDValue);
                    }
                }
            }

            return amicables.Sum().ToString();
        }

        private long GetDValue(long input)
        {
            List<long> factors = Shared.GetAllFactors(input);
            return factors.Where(n => n != input).Sum();
        }
    }
}
