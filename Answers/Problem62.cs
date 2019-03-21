using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem62 : answerBaseClass
    {
        public override string GetAnswer()
        {

            int answer = 0;

            int root = 1;
            List<OriginCubePair> pairsWithSameNumberOfDigits = new List<OriginCubePair>();
            int curPairsLen = -1;
            while (answer == 0)
            {
                OriginCubePair newPair = new OriginCubePair(root);
                if (newPair.sortedDigits.Length != curPairsLen)
                {
                    answer = CheckAnswer(pairsWithSameNumberOfDigits);
                    curPairsLen = newPair.sortedDigits.Length;
                    pairsWithSameNumberOfDigits.Clear();
                }
                pairsWithSameNumberOfDigits.Add(newPair);
                root++;
            }

            ulong retVal = (ulong)answer;
            retVal = retVal * retVal * retVal;
            return retVal.ToString();
            
        }

        private const int CountToSearchFor = 5;

        private int CheckAnswer(List<OriginCubePair> pairs)
        {
            if (pairs == null || pairs.Count() == 0) return 0;

            var groups = pairs.GroupBy(p => p.sortedDigits);

            var keys = groups.Where(g => g.Count() == CountToSearchFor).Select(g => g.Key);

            if (!keys.Any()) return 0;

            var validPairs = pairs.Where(p => keys.Contains(p.sortedDigits));
            return validPairs.Min(p => p.origin);
        }



        private class OriginCubePair
        {
            public int origin { get; private set; }
            public string sortedDigits { get; private set; }
            public OriginCubePair(int origin)
            {
                this.origin = origin;
                ulong cube = (ulong)origin;
                cube = cube * cube * cube;

                var sortedChars = cube.ToString().OrderBy(c => c).ToArray();
                this.sortedDigits = new string(sortedChars);
            }
        }


    }


}
