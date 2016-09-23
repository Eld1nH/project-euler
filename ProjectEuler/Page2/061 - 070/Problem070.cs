using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Totient permutation
    public class Problem070
    {

        public static string Algorithm()
        {
            long result = 0;
            long phiResult = 0;
            long[] primes = ESieve(5000);
            long limit = 10000000;
            double minRatio = Double.PositiveInfinity;

            for (int i = 0; i < primes.Length; i++)
            {
                for (int j = i + 1; j < primes.Length; j++)
                {
                    long n = primes[i] * primes[j];
                    if (n > limit) break;

                    long phi = (primes[i] - 1) * (primes[j] - 1);
                    double ratio = (double)n / (double)phi;

                    if (ArePermutations(new long[] { n, phi }) && ratio < minRatio)
                    {
                        result = n;
                        phiResult = phi;
                        minRatio = ratio;
                    }
                }
            }

            return result.ToString();
        }

        private static bool ArePermutations(long[] numbers)
        {
            if (numbers.Length < 2) return false;

            int[] digits = null;

            for (int i = 0; i < numbers.Length; i++)
            {
                long temp = numbers[i];
                int[] d = new int[10];
                while (temp > 0)
                {
                    d[temp % 10]++;
                    temp /= 10;
                }

                if (digits == null)
                {
                    digits = d;
                }
                else
                {
                    for (int j = 0; j < d.Length; j++)
                    {
                        if (d[j] != digits[j])
                            return false;
                    }
                }
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
