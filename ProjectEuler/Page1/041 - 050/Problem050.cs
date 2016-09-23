using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Consecutive prime sum
    public class Problem050
    {

        public static string Algorithm()
        {
            long result = 0;

            int limit = 1000000;
            long[] primes = ESieve(limit);
            long[] primeSum = new long[primes.Length + 1];
            int numPrimes = 0;

            primeSum[0] = 0;
            for (int i = 0; i < primes.Length; i++)
            {
                primeSum[i + 1] = primeSum[i] + primes[i];
            }

            for (int i = numPrimes; i < primeSum.Length; i++)
            {
                for (int j = i - (numPrimes + 1); j >= 0; j--)
                {
                    if (primeSum[i] - primeSum[j] > limit) break;

                    if (Array.BinarySearch(primes, primeSum[i] - primeSum[j]) >= 0)
                    {
                        numPrimes = i - j;
                        result = primeSum[i] - primeSum[j];
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
    }
}
