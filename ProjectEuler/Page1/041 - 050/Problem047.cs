using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Distinct primes factors
    public class Problem047
    {

        public static string Algorithm()
        {
            long result = 0;

            int target = 4;
            int factorTarget = 4;
            int count = 1;
            int n = 2 * 3 * 5 * 7;
            long[] primes = ESieve(n * target);

            result = n;

            while (count < target)
            {
                n++;
                long[] factors = GetPrimeFactors(n, primes);
                if (factors.Length == factorTarget)
                {
                    if (count == 0) result = n;
                    count++;
                }
                else if (factors.Length != factorTarget && count > 0)
                {
                    result = 0;
                    count = 0;
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

        private static long[] GetPrimeFactors(long n, long[] primes)
        {
            List<long> factors = new List<long>();

            for (int i = 0; i < primes.Length; i++)
            {
                while (n % primes[i] == 0)
                {
                    n /= primes[i];
                    if (!factors.Contains(primes[i])) factors.Add(primes[i]);
                }

                if (n == 1) break;
            }

            return factors.ToArray<long>();
        }
    }
}
