using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem48 : answerBaseClass
    {
        public override string GetAnswer()
        {
            BigInteger cumulResult = 0;
            for (int pow = 1; pow <= 1000; pow++)
            {
                BigInteger part = GetLastTenDigitsOfSelfPower(pow);
                cumulResult = AddAndGetLastTenDigits(cumulResult, part);
            }

            return cumulResult.ToString();
        }

        private BigInteger GetLastTenDigitsOfSelfPower(int x)
        {
            return GetLastTenDigitsOfWithGivenPow(x, x);
        }

        private BigInteger GetLastTenDigitsOfWithGivenPow(int x, int pow)
        {
            if (pow == 0) return 1;
            if (pow == 1) return x;

            int curPow = 1;
            BigInteger curResult = x;
            while (curPow * 2 <= pow)
            {
                curResult = curResult * curResult;
                curPow = curPow * 2;
            }
            BigInteger recursiveResult = GetLastTenDigitsOfWithGivenPow(x, pow - curPow);
            return MultiplyAndGetLastTenDigits(curResult, recursiveResult);
        }

        private BigInteger MultiplyAndGetLastTenDigits(BigInteger a, BigInteger b)
        {
            BigInteger product = a * b;
            return product % 10000000000;
        }

        private BigInteger AddAndGetLastTenDigits(BigInteger a, BigInteger b)
        {
            BigInteger sum = a + b;
            return sum % 10000000000;
        }
    }
}
