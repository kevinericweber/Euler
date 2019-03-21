using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem39 : answerBaseClass
    {
        public override string GetAnswer()
        {
            // Okay, general approach: we're going to find 'unscaled' right triangles - aka, right triangles
            // whose sides don't share a common factor.  After we get that, we can simply get their perimeters.
            // Finally, loop from 1-1000 and see how many perimeters divide into it.

            List<RightTriangle> triangles = GetUnscaledRightTriangles(1000);
            List<int> perimeters = triangles.Select(x => x.GetPerimeter()).ToList();

            int bestPerimeter = 0;
            int bestPCount = 0;

            for (int p = 3; p < 1000; p++)
            {
                int pCount = perimeters.Where(x => p % x == 0).Count();
                if (pCount > bestPCount)
                {
                    bestPCount = pCount;
                    bestPerimeter = p;
                }
            }

            return bestPerimeter.ToString();
        }


        private List<RightTriangle> GetUnscaledRightTriangles(int maxPerim)
        {
            List<RightTriangle> retVal = new List<RightTriangle>();
            // using following method to generate triangles: [x2-y2]2 + [2xy]2 = [x2+y2]2
            int maxXOrY = (int)Math.Sqrt(maxPerim);

            for (int x = 2; x <= maxXOrY; x++)
            {
                for (int y = 1; y < x; y++)
                {
                    RightTriangle baseTri = GenerateFromXY(x, y);
                    if (!retVal.Any(m => m.a == baseTri.a && m.b == baseTri.b))
                        if (baseTri.GetPerimeter() <= maxPerim)
                            retVal.Add(baseTri);
                }
            }
            return retVal;
        }

        private RightTriangle GenerateFromXY(int x, int y)
        {
            int s1 = x * x - y * y;
            int s2 = 2 * x * y;
            int c = x * x + y * y;
            if (s1 < s2) return new RightTriangle(s1, s2, c);
            return new RightTriangle(s2, s1, c);
        }
        
        private List<RightTriangle> ExpandMultiples(RightTriangle baseTri, int maxPerim)
        {
            List<RightTriangle> retVal = new List<RightTriangle>();
            retVal.Add(baseTri);
            int multiple = 2;
            while (true)
            {
                RightTriangle newTri = new RightTriangle(multiple * baseTri.a, multiple * baseTri.b, multiple * baseTri.c);
                if (newTri.GetPerimeter() <= maxPerim)
                    retVal.Add(newTri);
                else
                    return retVal;
            }
        }


        private class RightTriangle
        {
            public int a, b, c;
            public RightTriangle(int a, int b, int c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                ReduceIfPossible();
            }
            private void ReduceIfPossible()
            {
                List<long> aFactors = Shared.GetPrimeFactors(a);
                List<long> bFactors = Shared.GetPrimeFactors(b);
                Func<List<long>, List<long>, IEnumerable<long>> matchingFunc =
                        (m, n) => m.Where(x => n.Contains(x) && x != 1);
                IEnumerable<long> matches = matchingFunc.Invoke(aFactors, bFactors);

                if (matches.Count() == 0)  return;

                int commonFactor = (int)matches.First();
                this.a = this.a / commonFactor;
                this.b = this.b / commonFactor;
                this.c = this.c / commonFactor;
                ReduceIfPossible();
            }
            public RightTriangle Flip()
            {
                return new RightTriangle(b, a, c);
            }
            public int GetPerimeter()
            {
                return a + b + c;
            }
        }
    }
}
