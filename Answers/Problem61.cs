using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem61 : answerBaseClass
    {
        private List<int>[] matchingNums;

        private void populateLists()
        {
            matchingNums = new List<int>[6];
            Func<int, int>[] generators = new Func<int, int>[6];

            generators[0] = n => n * (n + 1) / 2;
            generators[1] = n => n * n;
            generators[2] = n => n * (3 * n - 1) / 2;
            generators[3] = n => n * (2 * n - 1);
            generators[4] = n => n * (5 * n - 3) / 2;
            generators[5] = n => n * (3 * n - 2);

            for (int g = 0; g < 6; g++)
            {
                matchingNums[g] = new List<int>();
                for (int n = 1; n < 150; n++)
                {
                    int x = generators[g](n);
                    if (x > 999 && x < 10000) matchingNums[g].Add(x);
                }
            }
        }

        public override string GetAnswer()
        {
            populateLists();
            List<int[]> possibilities = GetPossibilities();

            int[] finalPossibility = GetFinalPossibility(possibilities);
            string retVal = TranslatePossibilityToAnswer(finalPossibility);

            return retVal;
        }

        private List<int[]> GetPossibilities()
        {
            List<int[]> retVal = new List<int[]>();
            for (int a = 10; a <= 98; a++)
            {
                for (int b = a + 1; b < 99; b++)
                {
                    byte matchA = GetMatchStatus(a, b);
                    if (matchA != 0)
                    {
                        for (int c = a + 1; c < 99; c++)
                        {
                            byte matchB = GetMatchStatus(b, c);
                            if (matchB != 0)
                            {
                                for (int d = a + 1; d < 99; d++)
                                {
                                    byte matchC = GetMatchStatus(c, d);
                                    if (matchC != 0)
                                    {
                                        for (int e = a + 1; e < 99; e++)
                                        {
                                            byte matchD = GetMatchStatus(d, e);
                                            if (matchD != 0)
                                            {
                                                for (int f = a + 1; f < 99; f++)
                                                {
                                                    byte matchE = GetMatchStatus(e, f);
                                                    byte matchF = GetMatchStatus(f, a);
                                                    if (matchE != 0 && matchF != 0)
                                                    {
                                                        retVal.Add(new int[6] { a, b, c, d, e, f });
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return retVal;
        }

        private int[] GetFinalPossibility(List<int[]> possibilities)
        {
            List<int[]> finalPoss = new List<int[]>();
            foreach (int[] possibility in possibilities)
            {
                if (IsPossibilityGood(possibility))
                    finalPoss.Add(possibility);
            }

            return finalPoss[0];
        }

        private bool IsPossibilityGood(int[] possibility)
        {
            int[] chains = new int[6];
            chains[0] = GetMatchStatus(possibility[0], possibility[1]);
            chains[1] = GetMatchStatus(possibility[1], possibility[2]);
            chains[2] = GetMatchStatus(possibility[2], possibility[3]);
            chains[3] = GetMatchStatus(possibility[3], possibility[4]);
            chains[4] = GetMatchStatus(possibility[4], possibility[5]);
            chains[5] = GetMatchStatus(possibility[5], possibility[0]);

            if (chains.Where(x => x == 2).Count() > 1) return false;
            if (chains.Where(x => x == 4).Count() > 1) return false;
            if (chains.Where(x => x == 8).Count() > 1) return false;
            if (chains.Where(x => x == 16).Count() > 1) return false;
            if (chains.Where(x => x == 32).Count() > 1) return false;
            int chainResult = chains[0] | chains[1] | chains[2] | chains[3] | chains[4] | chains[5];

            if (chainResult != 1 + 2 + 4 + 8 + 16 + 32)
                return false;


            return true;
        }

        private string TranslatePossibilityToAnswer(int[] possibility)
        {
            int sum = (possibility[0] * 100 + possibility[1]) +
                (possibility[1] * 100 + possibility[2]) +
                (possibility[2] * 100 + possibility[3]) +
                (possibility[3] * 100 + possibility[4]) +
                (possibility[4] * 100 + possibility[5]) +
                (possibility[5] * 100 + possibility[0]);
            return sum.ToString();
        }

        private byte GetMatchStatus(int numPartA, int numPartB)
        {
            return GetMatchStatus(numPartA * 100 + numPartB);
        }

        private byte GetMatchStatus(int num)
        {
            byte retVal = 0;
            if (matchingNums[0].Contains(num)) retVal |= 1;
            if (matchingNums[1].Contains(num)) retVal |= 2;
            if (matchingNums[2].Contains(num)) retVal |= 4;
            if (matchingNums[3].Contains(num)) retVal |= 8;
            if (matchingNums[4].Contains(num)) retVal |= 16;
            if (matchingNums[5].Contains(num)) retVal |= 32;
            return retVal;
        }
    }
}
