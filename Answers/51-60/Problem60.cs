using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem60 : answerBaseClass
    {
        public class pair : IComparable<pair>
        {
            public int x;
            public int y;
            public pair(int x, int y)
            {
                if (x > y) throw new Exception("Should only be lower, higher");
                this.x = x;
                this.y = y;
            }

            public int CompareTo(pair other)
            {
                if (this.x == other.x) return this.y.CompareTo(other.y);
                return this.x.CompareTo(other.x);
            }
            public override string ToString()
            {
                return x + "," + y;
            }
        }
        public override string GetAnswer()
        {

            List<int> primesList = Primality.GetPrimeListWithMaxValue(10000);  // note: tested with larger values to make sure


            SortedSet<pair> reflectivePairs = new SortedSet<pair>();
            foreach (int x in primesList)
            {
                foreach (int y in primesList)
                {
                    if (x < y)
                    {
                        if (DoTwoPrimesWork(x, y))
                        {
                            reflectivePairs.Add(new pair(x, y));
                        }
                    }
                }
            }


            var chainOfThree = reflectivePairs.Join(reflectivePairs, a => a.x, b => b.x, (c, d) => new { c, d }).Where(g => g.c.y < g.d.y).ToList();
            var circleOfThree = chainOfThree.Where(g => reflectivePairs.Contains(new pair(g.c.y, g.d.y))).Select(g => new { x = g.c.x, y = g.c.y, z = g.d.y }).ToList();

            var chainOfFour = circleOfThree.Join(circleOfThree, a => new { a.x, a.y }, b => new { b.x, b.y }, (c, d) => new { c, d }).Where(g => g.c.z < g.d.z).ToList();
            var circleOfFour = chainOfFour.Where(g => reflectivePairs.Contains(new pair(g.c.z, g.d.z))).Select(g => new { x = g.c.x, y = g.c.y, z = g.c.z, w = g.d.z }).ToList();

            var chainOfFive = circleOfFour.Join(circleOfFour, a => new { a.x, a.y, a.z }, b => new { b.x, b.y, b.z }, (c, d) => new { c, d }).Where(g => g.c.w < g.d.w).ToList();
            var circleOfFive = chainOfFive.Where(g => reflectivePairs.Contains(new pair(g.c.w, g.d.w))).Select(g => new { x = g.c.x, y = g.c.y, z = g.c.z, w = g.c.w, v = g.d.w }).ToList();



            return circleOfFive.Min(g => g.x + g.y + g.z + g.w + g.v).ToString();
        }



        private bool DoTwoPrimesWork(int primeA, int primeB)
        {
            int shrinkA = primeA;
            int shrinkB = primeB;
            int expandA = 1;
            int expandB = 1;

            while (shrinkA > 0)
            {
                shrinkA = shrinkA / 10;
                expandA = expandA * 10;
            }

            int testA = primeA + primeB * expandA;
            if (!Primality.isPrime(testA)) return false;
            while (shrinkB > 0)
            {
                shrinkB = shrinkB / 10;
                expandB = expandB * 10;
            }
            int testB = primeB + primeA * expandB;
            if (!Primality.isPrime(testB)) return false;
            return true;
        }


    }
}
