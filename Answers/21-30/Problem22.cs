using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem22 : answerBaseClass
    {
        public override string GetAnswer()
        {
            string file = System.IO.File.ReadAllText(@"p022_names.txt");

            long runningTotal = 0;

            List<string> names = file.Split(',').Select(s => s.Trim('"')).ToList();
            names.Sort();

            int cnt = names.Count();

            for (int i = 0; i < cnt; i++)
            {
                int nameScore = GetNameScore(names[i]);
                int score = nameScore * (i+1);
                runningTotal += score;
            }

            return runningTotal.ToString();
        }

        private int GetNameScore(string name)
        {
            int retVal = 0;
            string upps = name.ToUpper();
            foreach(char c in upps)
            {
                retVal += (c - 'A' + 1);
            }
            return retVal;
        }

        
    }
}
