using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem30 : answerBaseClass
    {
        int[] digitsToPower = new int[10];

        public override string GetAnswer()
        {
            int powerToLookFor = 5;
            
            PopulateDigitsToPower(powerToLookFor);

            int maxIter = GetMaxPossibleIterValue();

            int totalSum = 0;
            for (int trial = 2; trial <= maxIter; trial++)
            {
                if (DoesNumberPass(trial))
                    totalSum += trial;
            }

            return totalSum.ToString();
        }


        private int GetMaxPossibleIterValue()
        {
            int maxDigitVal = digitsToPower.Max();
            int digitsToTry = 1;
            while (Math.Pow(10, digitsToTry - 1) < maxDigitVal * digitsToTry)
                digitsToTry++;
            return maxDigitVal * (digitsToTry - 1);
        }

        private void PopulateDigitsToPower(int power)
        {
            for (int i = 0; i < 10; i++)
                digitsToPower[i] = (int)Math.Pow(i, power);
        }

        private bool DoesNumberPass(int num)
        {
            List<int> digits = num.ToString().Select(c => c - '0').ToList();

            int sum = digits.Sum(n => digitsToPower[n]);

            if (sum == num) return true;
            return false;
        }
    }
}
