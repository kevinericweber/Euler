using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    
    public static class PrimeGenerator
    {
        private static SortedSet<int> _knownOrderedPrimes = new SortedSet<int>();
        private static int _largestKnownOrderedPrime = 0;

        public static int largestKnownOrderedPrime { get { return _largestKnownOrderedPrime; } }
        public static bool IsKnownPrime(int valToExamine)
        {
            if (valToExamine > _largestKnownOrderedPrime)
                StartAddingToKnowns(valToExamine);
            return _knownOrderedPrimes.Contains(valToExamine);
        }
        
        public static List<int> GetPrimeListWithMaxValue(int max)
        {
            if (max > _largestKnownOrderedPrime)
                StartAddingToKnowns(max);

            return _knownOrderedPrimes.Where(n => n <= max).ToList();
        }

        private static void StartAddingToKnowns(int maxToEvaluateTo)
        {
            long curChunkMax;
            long newChunkMax;
            List<int> prevPrimes;
            List<int> newPrimes = new List<int>();
            //List<int> primes = knownOrderedPrimes.ToList();
            if (_largestKnownOrderedPrime < 4)
            {
                curChunkMax = 3;
                prevPrimes = new List<int>() { 2, 3 };
            }
            else
            {
                prevPrimes = _knownOrderedPrimes.ToList();
                curChunkMax = prevPrimes.Max();
            }

            while (true)
            {
                newChunkMax = curChunkMax * curChunkMax;
                if (newChunkMax > maxToEvaluateTo) newChunkMax = maxToEvaluateTo;
                int maxRelevantPrime = (int)Math.Sqrt(newChunkMax) + 1;
                List<int> relevantPrevPrimes = prevPrimes.Where(n => n <= maxRelevantPrime).ToList();
                for (int i = (int)curChunkMax + 2; i <= newChunkMax; i += 2)
                {
                    if (!relevantPrevPrimes.Any(p => i % p == 0))
                        newPrimes.Add(i);
                }
                if (!newPrimes.Any())
                {
                    _knownOrderedPrimes = new SortedSet<int>(prevPrimes);
                    _largestKnownOrderedPrime = _knownOrderedPrimes.Max();
                    return;
                }
                curChunkMax = newChunkMax;
                prevPrimes.AddRange(newPrimes);
                newPrimes.Clear();
            }

        }

        public static List<int> GetPrimeListWithNTerms(int numberOfTerms)
        {
            while (_knownOrderedPrimes.Count() < numberOfTerms)
                StartAddingToKnowns(_largestKnownOrderedPrime * 2);

            return _knownOrderedPrimes.Take(numberOfTerms).ToList();
        }
    }

}
