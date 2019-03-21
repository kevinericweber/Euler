using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    // [Relatively useless info omitted]
    // How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)?
    class Problem19 : testableAnswer
    {
        public override string GetAnswer()
        {
            int answer = 0;
            DateTime currentSundayToExamine = new DateTime(1901, 1, 1);
            DateTime endOfRange = new DateTime(2000, 12, 31);

            while (currentSundayToExamine.DayOfWeek != DayOfWeek.Sunday)
                currentSundayToExamine = currentSundayToExamine.AddDays(1);

            while (currentSundayToExamine <= endOfRange)
            {
                if (currentSundayToExamine.Day == 1) answer++;

                currentSundayToExamine = currentSundayToExamine.AddDays(7);
            }

            return answer.ToString();
        }


        private string GetAnswerUsingAlternativeMethod()
        {
            // overkill - to program two different ways of doing it, just to have unit testing
            // that said... I was having fun and liked the two different ways of doing the same problem.
            int occurrances = 0;
            DateTime start = new DateTime(1901, 1, 1);
            DateTime end = new DateTime(2000, 12, 31);

            DateTime current = start;
            while (current < end)
            {
                if (current.DayOfWeek == DayOfWeek.Sunday) occurrances++;
                current = current.AddMonths(1);
            }
            return occurrances.ToString();
        }

        public override bool KnownTestPasses()
        {
            string expected = GetAnswerUsingAlternativeMethod();
            string actual = GetAnswer();
            return (expected.Equals(actual));
        }

    }
}
