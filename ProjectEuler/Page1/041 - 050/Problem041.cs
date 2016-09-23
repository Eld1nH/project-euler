using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Pandigital prime
    public class Problem041
    {

        public static string Algorithm()
        {
            long result = 0;

            long[] primes = ESieve(7654321);

            for (int i = primes.Length - 1; i >= 0; i--)
            {
                if (IsPandigital(primes[i]))
                {
                    result = primes[i];
                    break;
                }
            }

            return result.ToString();
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

        private static bool IsPandigital(long n)
        {
            bool[] digits = new bool[10];

            while (n > 0)
            {
                long rem = n % 10;
                if (digits[rem]) return false;
                digits[rem] = true;
                n /= 10;
            }

            return true;
        }
    }
}
