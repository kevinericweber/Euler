using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem36 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<int> decPals = GetDecimalPalindromes();

            IEnumerable<int> bothPals = decPals.Where(n => IsBinaryPalindome(n));

            return bothPals.Sum().ToString();
        }

        private List<int> GetDecimalPalindromes()
        {
            List<int> retVal = new List<int>();
            for (int coreDigits = 1; coreDigits <= 999; coreDigits++)
            {
                if (coreDigits % 10 == 0) continue;

                string coreStr = coreDigits.ToString();
                string reverseCoreStr = new string(coreStr.Reverse().ToArray());
                string coreStrNoFirstDigit = coreStr.Substring(1);
                retVal.Add(int.Parse(reverseCoreStr + coreStr));
                retVal.Add(int.Parse(reverseCoreStr + coreStrNoFirstDigit));

                for (int zeroesToAdd = 1; zeroesToAdd <= 6 - (2*coreStr.Length); zeroesToAdd++)
                {
                    retVal.Add(int.Parse(reverseCoreStr + new string('0', zeroesToAdd) + coreStr));
                }
            }
            return retVal;
        }

        private bool IsBinaryPalindome(int num)
        {
            string binStr = Convert.ToString(num, 2);
            string binStrRev = new string(binStr.Reverse().ToArray());

            if (binStr == binStrRev) return true;
            return false;
        }
    }
}
