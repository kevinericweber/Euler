using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem55 : answerBaseClass
    {
        public override string GetAnswer()
        {
            SortedSet<int> possibilities = new SortedSet<int>(Enumerable.Range(1, 10000));

            List<int> lychrel = new List<int>();

            while (possibilities.Any())
            {
                int numToCheck = possibilities.First();
                PossibilityCheckResult result = CheckPossibility(numToCheck);
                if (result.IsLychrel)
                {
                    lychrel.Add(numToCheck);
                    lychrel.AddRange(result.numbersToMarkAsSameStatus);
                }
                possibilities.Remove(numToCheck);
                foreach (int alsoRemove in result.numbersToMarkAsSameStatus)
                    possibilities.Remove(alsoRemove);
                
            }

            return lychrel.Count().ToString();
        }


        private PossibilityCheckResult CheckPossibility(int startingNum)
        {
            BigInteger curNum = startingNum;
            BigInteger reverseOfCur = GetReverse(curNum);
            List<int> numsWithSameStatus = new List<int>();
            int curIter = 0;
            while (curIter < 50)
            {
                curNum = curNum + reverseOfCur;
                reverseOfCur = GetReverse(curNum);

                if (curNum.Equals(reverseOfCur))
                    return new PossibilityCheckResult(false, numsWithSameStatus);

                if (curNum <= 10000)
                    numsWithSameStatus.Add((int)curNum);

                curIter++;
            }
            return new PossibilityCheckResult(true, numsWithSameStatus);
        }

        private BigInteger GetReverse(BigInteger start)
        {
            string strA = start.ToString();
            string strB = new string(strA.Reverse().ToArray());
            return BigInteger.Parse(strB);
        }

        private class PossibilityCheckResult
        {
            public bool IsLychrel;
            public List<int> numbersToMarkAsSameStatus;
            public PossibilityCheckResult(bool IsLychrel, List<int> numbersToMarkAsSameStatus)
            {
                this.IsLychrel = IsLychrel;
                this.numbersToMarkAsSameStatus = numbersToMarkAsSameStatus;
            }

        }



    }
}
