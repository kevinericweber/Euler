using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem35 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<int> circular = new List<int>();
            List<int> candidates = new List<int> { 2, 3, 5, 7 };
            for (int i = 11; i <= 999999; i += 2)
            {
                string testStr = i.ToString();
                if (!testStr.Contains("0"))
                    if (!testStr.Contains("2"))
                        if (!testStr.Contains("4"))
                            if (!testStr.Contains("5"))
                                if (!testStr.Contains("6"))
                                    if (!testStr.Contains("8"))
                                        candidates.Add(i);
            }

            while (candidates.FirstOrDefault() != 0)
            {
                int trialNum = candidates.First();
                List<int> allRots = GetAllRotations(trialNum);
                if (allRots.All(n => Primality.isPrime(n)))
                {
                    circular.AddRange(allRots);
                }
                allRots.ForEach(x => candidates.Remove(x));
            }
            

            return circular.Count().ToString();


        }



        private List<int> GetAllRotations(int num)
        {
            List<int> retVal = new List<int> { num };
            if (num < 10) return retVal;
            int rot = rotate(num);
            while (rot != num)
            {
                retVal.Add(rot);
                rot = rotate(rot);
            }
            return retVal;
        }
        

        private int rotate(int a)
        {
            if (a < 10) return a;
            string strA = a.ToString();
            string strB = strA.Substring(1) + strA.Substring(0, 1);
            return int.Parse(strB);
        }

    }
}
