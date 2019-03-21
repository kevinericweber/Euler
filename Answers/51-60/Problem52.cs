using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem52 : answerBaseClass
    {
        public override string GetAnswer()
        {
            
            for (int i = 2; i <= 10; i++)
            {
                string possibility = findAnswer(i);
                if (possibility != "") return possibility;
            }
            return "Not enough digits considered";
        }

        private string findAnswer(int digits)
        {
            int lowBound = (int)Math.Pow(10, digits);
            int highBound = lowBound * 10 / 6;

            for (int attempt = lowBound; attempt <= highBound; attempt++)
            {
                if (IsSolutionValid(attempt)) return attempt.ToString();
            }
            return "";
        }

        private bool IsSolutionValid(int numToTry)
        {
            if (!IsMultipleOkay(numToTry, 2)) return false;
            if (!IsMultipleOkay(numToTry, 3)) return false;
            if (!IsMultipleOkay(numToTry, 4)) return false;
            if (!IsMultipleOkay(numToTry, 5)) return false;
            if (!IsMultipleOkay(numToTry, 6)) return false;

            return true;
        }

        private bool IsMultipleOkay(int numToTry, int multiple)
        {
            string sortedA = new string(numToTry.ToString().OrderBy(c => c).ToArray());
            string sortedB = new string((numToTry*multiple).ToString().OrderBy(c => c).ToArray());
            return sortedA == sortedB;
        }
    }


}
