using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem24 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<int> nums = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            string result = FindPermutation(nums, 999999);
            return result;
        }


        private string FindPermutation(List<int> digitsThatCanBeUsed, long targetItemZeroIndexed)
        {

            int numberOfPossibilities = digitsThatCanBeUsed.Count();

            if (numberOfPossibilities == 1) return digitsThatCanBeUsed[0].ToString();
            if (numberOfPossibilities <= 0) return "";

            long numberOfPermutationsAfterFirstDigit = Shared.GetSmallFactorial(numberOfPossibilities - 1);

            int slotOfFirstDigitWeWillUse = (int)(targetItemZeroIndexed / numberOfPermutationsAfterFirstDigit);
            long newTarget = targetItemZeroIndexed % numberOfPermutationsAfterFirstDigit;

            if (slotOfFirstDigitWeWillUse >= numberOfPossibilities) throw new Exception("There aren't enough lexiographic permutations to get your answer");

            string curNum = digitsThatCanBeUsed[slotOfFirstDigitWeWillUse].ToString();

            List<int> remainingDigits = new List<int>();
            remainingDigits.AddRange(digitsThatCanBeUsed);
            remainingDigits.RemoveAt(slotOfFirstDigitWeWillUse);

            return curNum + FindPermutation(remainingDigits, newTarget);
        }
    }
}
