using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem53 : answerBaseClass
    {


        public override string GetAnswer()
        {
            double[] factorials = GetFactorialArray(100);

            int count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int r = 0; r <= n; r++)
                {
                    double nCr = factorials[n] / (factorials[r] * factorials[n - r]);
                    if (nCr > 1000000)
                        count++;
                }
            }

            return count.ToString();
        }

        public double[] GetFactorialArray(int numOfTerms)
        {
            double[] retVal = new double[numOfTerms + 1];
            retVal[0] = 1;
            retVal[1] = 1;
            
            for (int i = 2; i <= numOfTerms; i++)
            {
                retVal[i] = retVal[i - 1] * i;
            }
            return retVal;
        }
    }
}
