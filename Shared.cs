using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    
    public static class Shared
    {
        
        public static List<long> GetPrimeFactors(long number)
        {
            // Okay, there's one *very* important thing to do when breaking a number into its prime factors:
            // divide out the original number whenever you find a factor.  Otherwise, you'll be looping 
            // all the way up to Sqrt(origNum).  If you divide out the factors as you find them, you'll often
            // drastically reduce the amount of work you have to do (main exception: prime numbers.)

            List<long> retVal = new List<long>();
            if (number == 1) return new List<long> { 1 };
            if (number == 2) return new List<long> { 1, 2 };
            
            if (number % 2 == 0)
            {
                retVal.Add(2);
                retVal.AddRange(GetPrimeFactors(number / 2));
                return retVal;
            }

            long boundary = (long)Math.Sqrt(number);

            for (long i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    retVal.Add(i);
                    retVal.AddRange(GetPrimeFactors(number / i));
                    return retVal;
                }
            }
            return new List<long> { number, 1 };  // aka, number was prime
        }

        public static List<long> GetAllFactors(long number)
        {
            List<long> primeFactors = Shared.GetPrimeFactors(number).Where(n => n >= 1).ToList();

            if (primeFactors.Count() <= 1) return new List<long> { 1 };

            List<long> retVal = new List<long> { 1 };

            while (primeFactors.Count() >= 1)
            {
                long numToMultBy = primeFactors[0];
                List<long> numsToAdd = retVal.Select(n => n * numToMultBy).ToList();
                retVal.AddRange(numsToAdd);
                retVal = retVal.Distinct().OrderBy(n => n).ToList();
                primeFactors.RemoveAt(0);
            }

            return retVal;
        }

    }
    
}
