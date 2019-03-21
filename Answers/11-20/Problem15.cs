using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    /* Starting in the top left corner of a 2×2 grid, and only being able to move to the right and down,
     * there are exactly 6 routes to the bottom right corner.
     * How many such routes are there through a 20×20 grid?
     */
    class Problem15 : testableAnswer
    {
        private long[,] lattice;

        public override string GetAnswer()
        {
            return GetAnswerForLatticeSize(20).ToString();
        }

        public override bool KnownTestPasses()
        {
            long expected = 6;
            long actual = GetAnswerForLatticeSize(2);
            return (expected == actual);
        }

        private long GetAnswerForLatticeSize(int size)
        {
            // one thing to keep in mind, that originally tripped me up is this:
            // the "grid" may be 20x20, but that actually means there are
            // 21 X positions and 21 Y positions.  So the values don't go
            // from 0-19 (like you'd expect for a "20-size" item), but 0-20.

            lattice = new long[size+1, size+1];
            return SolveForPoint(size, size);
        }

        private long SolveForPoint(int x, int y)
        {
            // Seems straight-forward at first glance: number of options is:
            //  NumberOfOptionsIfIGoDown + NumberOfOptionsIfIGoRight
            //  Problem is, that logic results in a number of stack calls equal to the answer
            //     (kind of like how Fibonacci(x) = { if (x<2) return 1; return Fibonacci(x-1) + Fibonacci(x-2); }
            //     takes a crazy amount of time for any large values of x.)
            // So, instead, once we evaluate a lattice point, we store it in memory.  That way, whenever
            // we need the value at that point, we don't need to recursively look it up again.
            if (x < 0 || y < 0) return 0;
            if (x == 0 || y == 0) return 1;
            if (lattice[x, y] != 0) return lattice[x, y];

            long result = SolveForPoint(x - 1, y) + SolveForPoint(x, y - 1);
            lattice[x, y] = result;
            return result;
        }
    }
}
