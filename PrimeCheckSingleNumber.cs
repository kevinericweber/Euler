using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{

    public static class PrimeCheckSingleNumber
    {
        //public static bool isPrime(int number)
        //{
        //    // if we've previously examined this in the generator, might as well use that data!
        //    if (number <= PrimeGenerator.largestKnownOrderedPrime)
        //        return PrimeGenerator.IsKnownPrime(number);


        //    if (number == 1) return false;
        //    if (number == 2) return true;

        //    if (number % 2 == 0) return false;

        //    int boundary = (int)Math.Sqrt(number);

        //    for (int i = 3; i <= boundary; i += 2)
        //    {
        //        if (number % i == 0) return false;
        //    }
        //    return true;
        //}

        //public static bool isPrime(ulong number)
        //{
        //    // if we've previously examined this in the generator, might as well use that data!
        //    if (number <= (ulong)PrimeGenerator.largestKnownOrderedPrime)
        //        return PrimeGenerator.IsKnownPrime((int)number);

        //    if (number == 1) return false;
        //    if (number == 2) return true;

        //    if (number % 2 == 0) return false;

        //    ulong boundary = (ulong)Math.Sqrt(number);

        //    for (ulong i = 3; i <= boundary; i += 2)
        //    {
        //        if (number % i == 0) return false;
        //    }
        //    return true;
        //}

        private static bool isPrime(dynamic number)
        {
            // if we've previously examined this in the generator, might as well use that data!
            if (number <= PrimeGenerator.largestKnownOrderedPrime)
                return PrimeGenerator.IsKnownPrime((int)number);

            if (number == 1) return false;
            if (number == 2) return true;

            if (number % 2 == 0) return false;

            ulong boundary = (ulong)Math.Sqrt(number);

            for (ulong i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
