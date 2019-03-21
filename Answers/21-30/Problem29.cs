using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem29 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int aMin = 2;
            int aMax = 100;
            int bMin = 2;
            int bMax = 100;

            int total = 0;
            for (int a = aMin; a <= aMax; a++)
            {
                int power = GetPerfectPower(a);

                total += (bMax - bMin + 1);
                
                if (power != 0)
                {
                    for (int b = bMin; b <= bMax; b++)
                    {
                        if (b * power <= bMax) total--;
                    }
                }
            }

            return total.ToString();
        }

        private int GetPerfectPower(int testNum)
        {
            List<long> primeFactors = Shared.GetPrimeFactors(testNum).Where(n => n != 1).ToList();

            long minFactor = primeFactors.Min();
            long maxFactor = primeFactors.Max();

            if (minFactor == testNum) return 0;
            if (minFactor == maxFactor) return primeFactors.Count();

            return 0;
        }
    }
}
