using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Prime power triplets
    public class Problem087
    {

        public static string Algorithm()
        {
            int limit = 50000000;
            long[] primes = ESieve(7071);
            long[][] powers = new long[3][];

            List<long> temp = new List<long>(primes);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < primes.Length; j++)
                {
                    temp[j] *= primes[j];
                }
                powers[i] = temp.ToArray();
            }

            SortedSet<long> numbers = new SortedSet<long>();
            for (int a = 0; a < primes.Length; a++)
            {
                for (int b = 0; b < primes.Length; b++)
                {
                    for (int c = 0; c < primes.Length; c++)
                    {
                        long n = powers[0][a] + powers[1][b] + powers[2][c];
                        if (n > limit) break;
                        numbers.Add(n);
                    }
                }
            }

            return numbers.Count.ToString();
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
