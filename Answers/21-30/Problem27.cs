using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem27 : answerBaseClass
    {

        public override string GetAnswer()
        {
            // n^2 + a*n + b
            // b MUST be prime (because for n=0, b's the only term used)
            //      We'll assume b is odd (why it can't be 2 or -2 later on)
            // n^2 + a*n MUST generate sequences that are always even
            //    if it toggles back and forth even/odd, then the terms generated will be even/odd
            //    (hint: there aren't many prime numbers that are even, so the #-in-a-row will be a bit constrained.)
            // n^2 toggles back and forth even/odd, so a*n must do so as well (so that the two, added together, are always even.)
            // aka, a must be odd.
            // (b can't be even, since the equation either toggles even/odd (bad), is always even (b=even,a=odd), or always odd (a,b=odd)
            
            int bestA = 0; int bestB = 0; int bestVal = 0;

            
            for (int b = -999; b < 1000; b += 2)
            {
                if (Primality.isPrime(Math.Abs(b)))
                {
                    for (int a = -999; a < 1000; a += 2)
                    {
                        int testVal = GetNumberOfSequentialPrimes(a, b);
                        if (testVal >= bestVal)
                        {
                            bestA = a;
                            bestB = b;
                            bestVal = testVal;
                        }
                    }
                }
            }
            return (bestA * bestB).ToString();
        }

        

        private int GetNumberOfSequentialPrimes(int a, int b)
        {
            int n = 0;
            while (true)
            {
                int x = n * n + a * n + b;
                x = Math.Abs(x);
                if (!Primality.isPrime(x)) return n;
                n++;
            }
        }
    }
}
