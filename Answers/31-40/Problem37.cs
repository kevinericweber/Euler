using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem37 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<ulong> answers = new List<ulong>();

            List<ulong> leftRemovable = Primality.GetPrimeListWithMaxValue(9).Select(n => (ulong)n).ToList();
            List<ulong> rightRemovable = Primality.GetPrimeListWithMaxValue(9).Select(n => (ulong)n).ToList();
            ulong curScalar = 10;
            while (answers.Count() < 11)
            {
                leftRemovable = GetNextStageLeftRemovable(leftRemovable, curScalar);
                rightRemovable = GetNextStageRightRemovable(rightRemovable);
                curScalar = curScalar * 10;

                answers.AddRange(leftRemovable.Where(n => rightRemovable.Contains(n)));
            }

            ulong finalAnswer = answers.Aggregate((a, b) => a + b);
            return finalAnswer.ToString();
        }

        private List<ulong> GetNextStageLeftRemovable(List<ulong> prevStage, ulong ScalarOfLeftDigit)
        {
            List<ulong> retVal = new List<ulong>();
            for (ulong leftDigit = 1; leftDigit <= 9; leftDigit++)
            {
                ulong amtToAdd = leftDigit * ScalarOfLeftDigit;
                retVal.AddRange(prevStage.Where(n => Primality.isPrime(amtToAdd + n)).Select(n => n + amtToAdd));
            }
            return retVal;
        }

        private List<ulong> GetNextStageRightRemovable(List<ulong> prevStage)
        {
            List<ulong> retVal = new List<ulong>();
            for (ulong rightDigit = 1; rightDigit <= 9; rightDigit++)
            {
                retVal.AddRange(prevStage.Where(n => Primality.isPrime(n * 10 + rightDigit)).Select(n => n * 10 + rightDigit));
            }
            return retVal;
        }
    }
}
