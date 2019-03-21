using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem51 : answerBaseClass
    {
        public override string GetAnswer()
        {
            int desiredFamilySize = 8;

            for (int digitsToTry = 2; digitsToTry <= 8; digitsToTry++)
            {
                string possibleSolution = TryToFindSolution(digitsToTry, desiredFamilySize);
                if (possibleSolution != "") return possibleSolution;
            }
            return "Couldn't find the solution in the number of digits tried.";
        }

        private string TryToFindSolution(int numOfDigits, int desiredFamilySize)
        {
            List<int> primes = Primality.GetPrimeListWithMaxValue((int)Math.Pow(10, numOfDigits));
            List<string> primesStr = primes.Select(i => i.ToString()).ToList();

            string bestSoFar = "z";
            
            List<string> relevantPrimeStr = primesStr.Where(s => s.Length == numOfDigits).ToList();
            for (int obscureNum = 1; obscureNum < Math.Pow(2, numOfDigits) - 1; obscureNum++)
            {
                BitVector32 bv = new BitVector32(obscureNum);
                var groupings = relevantPrimeStr.GroupBy(s => ObscureChars(s, obscureNum)).Where(x => x.Key != "");
                var good = groupings.Where(x => x.Count() >= desiredFamilySize).ToList();
                if (good.Any())
                {
                    string possibleBest = good.Min(g => g.Min());
                    if (possibleBest.CompareTo(bestSoFar) < 0) bestSoFar = possibleBest;
                }
            }
            if (bestSoFar != "z") return bestSoFar;

            return "";
        }


        private string ObscureChars(string numAsString, int obscureNum)
        {
            int len = numAsString.Length;
            char[] retVal = new char[len];
            char blockedChar = ' ';
            for (int charNum = 0; charNum < len; charNum++)
            {
                int pow = 1 << charNum;
                if ((obscureNum & pow) == 0)
                {
                    if (blockedChar == ' ') blockedChar = numAsString[charNum];
                    if (numAsString[charNum] != blockedChar) return "";
                    retVal[charNum] = '*';
                }
                else
                    retVal[charNum] = numAsString[charNum];
            }
            return new string(retVal);
        }
    }
}
