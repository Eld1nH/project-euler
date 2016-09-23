using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Goldbach's other conjecture
    public class Problem046
    {

        public static string Algorithm()
        {
            long result = 0;

            int i = 7;
            bool found = false;

            while (!found)
            {
                i += 2;
                if (!IsPrime(i))
                {
                    long[] primes = ESieve(i - 2);
                    bool noMatch = true;
                    for (int j = primes.Length - 1; j >= 0; j--)
                    {
                        long n = i - primes[j];
                        double x = Math.Sqrt(n / 2);
                        if (x % 1 == 0)
                        {
                            noMatch = false;
                            break;
                        }
                    }

                    if (noMatch)
                    {
                        result = i;
                        break;
                    }
                }
            }

            return result.ToString();
        }

        private static bool IsPrime(long input)
        {
            if (input <= 1)
                return false;

            long max = (long)Math.Sqrt(input);

            for (long i = 2; i <= max; i++)
            {
                if (input % i == 0)
                    return false;
            }

            return true;
        }

        private static long[] ESieve(int upperLimit)
        {
            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<long> numbers = new List<long>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);

            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray<long>();
        }
    }
}
