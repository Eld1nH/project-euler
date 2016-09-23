using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Prime pair sets
    public class Problem060
    {

        private static long[] primes;

        public static string Algorithm()
        {
            long result = Int64.MaxValue;

            primes = ESieve(30000);
            List<long>[] pairs = new List<long>[primes.Length];

            for (int a = 1; a < primes.Length; a++)
            {
                if (primes[a] * 5 >= result) break;
                if (pairs[a] == null) pairs[a] = MakePairs(a);
                for (int b = a + 1; b < primes.Length; b++)
                {
                    if (primes[a] + primes[b] * 4 >= result) break;
                    if (!pairs[a].Contains(primes[b])) continue;
                    if (pairs[b] == null) pairs[b] = MakePairs(b);
                    for (int c = b + 1; c < primes.Length; c++)
                    {
                        if (primes[a] + primes[b] + primes[c] * 3 >= result) break;
                        if (!pairs[a].Contains(primes[c]) ||
                            !pairs[b].Contains(primes[c])) continue;
                        if (pairs[c] == null) pairs[c] = MakePairs(c);
                        for (int d = c + 1; d < primes.Length; d++)
                        {
                            if (primes[a] + primes[b] + primes[c] + primes[d] * 2 >= result) break;
                            if (!pairs[a].Contains(primes[d]) ||
                                !pairs[b].Contains(primes[d]) ||
                                !pairs[c].Contains(primes[d])) continue;
                            if (pairs[d] == null) pairs[d] = MakePairs(d);
                            for (int e = d + 1; e < primes.Length; e++)
                            {
                                if (!pairs[a].Contains(primes[e]) ||
                                    !pairs[b].Contains(primes[e]) ||
                                    !pairs[c].Contains(primes[e]) ||
                                    !pairs[d].Contains(primes[e])) continue;

                                long sum = primes[a] + primes[b] + primes[c] + primes[d] + primes[e];
                                if (sum >= result) continue;
                                result = sum;
                            }
                        }
                    }
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

        private static long Concat(long a, long b)
        {
            long c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }

            return a + b;
        }

        private static List<long> MakePairs(int a)
        {
            List<long> pairs = new List<long>();
            for (int b = a + 1; b < primes.Length; b++)
            {
                if (IsPrime(Concat(primes[a], primes[b])) &&
                    IsPrime(Concat(primes[b], primes[a])))
                    pairs.Add(primes[b]);
            }
            return pairs;
        }
    }
}
