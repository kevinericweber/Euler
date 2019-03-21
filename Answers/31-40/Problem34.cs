using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem34 : answerBaseClass
    {
        public override string GetAnswer()
        {

            List<long> answers = new List<long>();

            long[] facts = new long[10];
            for (int i = 0; i < 10; i++)
                facts[i] = Shared.GetSmallFactorial(i);


            int maxNum = 2540160;

            for (int trial = 10; trial <= maxNum; trial++)
            {
                string trialStr = trial.ToString();
                long sum = trialStr.Select(c => facts[c - '0']).Sum();
                if (sum == trial)
                    answers.Add(trial);
            }


            return answers.Sum().ToString();
        }
    }
}
