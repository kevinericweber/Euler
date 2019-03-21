using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Problem33 : answerBaseClass
    {
        public override string GetAnswer()
        {
            List<Fraction> answers = new List<Fraction>();
            for (int i = 11; i < 100; i++)
            {
                if (i % 10 != 0)
                {
                    for (int j = i+1; j < 100; j++)
                    {
                        if (PassesCriteria(i, j))
                            answers.Add(new Fraction(i, j));
                    }
                }
            }

            
            List<long> numeratorPrimeFactors = answers.Select(x => Shared.GetPrimeFactors(x.numerator)).SelectMany(d => d).ToList();
            List<long> denominatorPrimeFactors = answers.Select(x => Shared.GetPrimeFactors(x.denominator)).SelectMany(d => d).ToList();

            IEnumerable<long> intersect = numeratorPrimeFactors.Intersect(denominatorPrimeFactors);
            while (intersect.Count() != 0)
            {
                long numToRemove = intersect.First();
                numeratorPrimeFactors.Remove(numToRemove);
                denominatorPrimeFactors.Remove(numToRemove);
                intersect = numeratorPrimeFactors.Intersect(denominatorPrimeFactors);
            }

            return denominatorPrimeFactors.Aggregate((a, b) => a * b).ToString();
        }

        private bool PassesCriteria(int a, int b)
        {
            if (b > 100) return false;
            string aStr = a.ToString();
            string bStr = b.ToString();
            foreach(char c in aStr)
            {
                if (bStr.Contains(c))
                {
                    string newAStr = aStr.Replace(c.ToString(), "");
                    if (newAStr == "") newAStr = c.ToString();
                    int newA = int.Parse(newAStr);
                    string newBStr = bStr.Replace(c.ToString(), "");
                    if (newBStr == "") newBStr = c.ToString();
                    int newB = int.Parse(newBStr);
                    if (a * newB == b * newA) return true;
                }
            }
            return false;
        }

        private class Fraction
        {
            public int numerator;
            public int denominator;
            public Fraction(int num, int denom)
            {
                this.numerator = num;
                this.denominator = denom;
            }
            public override string ToString()
            {
                return numerator + "/" + denominator;
            }
        }
    }
}
