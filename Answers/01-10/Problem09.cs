using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
     * a^2 + b^2 = c^2
     * For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.
     * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
     * Find the product abc.
     */

    class Problem09 : testableAnswer
    {
        public override string GetAnswer()
        {
            return GetAnswerForSumValue(1000).ToString();
        }

        public override bool KnownTestPasses()
        {
            int expected = 60;
            int actual = GetAnswerForSumValue(12);
            return (expected == actual);
        }

        private int GetAnswerForSumValue(int sumValue)
        {
            // this code might seem weird at first, but it's a different way of generating pythagorean triplets
            // using the complex plane (instead of just trying a bunch of numbers and determining whether its a triplet.)

            // Take any X and Y, and look at the complex number x+yi
            // it has the same length/magnitude as x-yi.
            // So multiplying (x+yi)(x-yi) has the same length/magnitude as (x+yi)^2.
            // Also important: (x+yi)(x-yi) will result in a real number: x^2+y^2
            // So what does (x+yi)^2 equal?
            // Another complex number: x^2 - y^2 + i * 2xy
            // But we know the magnitude of it: x^2+y^2.
            // and you can get the magnitude of a complex number via real^2+complex^2=magnitude^2
            // ... so we get a triplet.
            //      One is the real value (x^2-y^2)
            //      Another is the complex value (2xy)
            //      And the last is the magnitude: x^2+y^2.

            // So by generating any x,y, we can get a pythagorean triplet out of it:
            //      a = x^2 - y^2
            //      b = 2xy
            //      c = x^2 + y^2

            int largestPossibleCValue = sumValue / 2;
            int largestPossibleYValue = (int)Math.Sqrt(largestPossibleCValue) + 1;
            for (int x = 0; x < largestPossibleYValue; x++)
            {
                for (int y = x + 1; y <= largestPossibleYValue; y++)
                {
                    int a = (y * y - x * x);
                    int b = (2 * x * y);
                    int c = (x * x + y * y);

                    if (a + b + c == sumValue)
                        return (a * b * c);
                }
            }
            throw new Exception("Not Found?!");

        }
    }
}
