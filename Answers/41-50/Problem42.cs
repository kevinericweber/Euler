using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem42 : answerBaseClass
    {
        public override string GetAnswer()
        {
            string file = System.IO.File.ReadAllText(@"p042_words.txt");

            


            string[] words = file.Replace("\"", "").Split(',');

            List<int> wordScores = words.Select(w => GetWordScore(w)).ToList();

            int maxScore = wordScores.Max();
            List<int> triangleNums = GetTriangleNums(maxScore);

            List<int> matches = wordScores.Where(n => triangleNums.Contains(n)).ToList();
            int matchCount = matches.Count();

            return matchCount.ToString();

        }

        private List<int> GetTriangleNums(int largestValueNeededToBeCovered)
        {
            List<int> retVal = new List<int>();
            retVal.Add(1);
            int term = 2;
            while (retVal.Max() < largestValueNeededToBeCovered)
            {
                retVal.Add((term * term + term) / 2);
                term++;
            }
            return retVal;
        }

        private static int GetWordScore(string word)
        {
            return word.Sum(c => GetCharScore(c));
        }
        private static int GetCharScore(char letter)
        {
            int score = letter - 'A' + 1;
            return score;
        }
    }
}
