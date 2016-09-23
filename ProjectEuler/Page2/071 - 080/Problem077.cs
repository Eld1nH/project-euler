using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Prime summations
    public class Problem077
    {

        public static string Algorithm()
        {
            int result = 2;
            int[] primes = ESieve(1000);

            while (true)
            {
                int[] sums = new int[result + 1];
                sums[0] = 1;

                for (int i = 0; i < primes.Length; i++)
                {
                    for (int j = primes[i]; j <= result; j++)
                    {
                        sums[j] += sums[j - primes[i]];
                    }
                }

                if (sums[result] > 5000) break;
                result++;
            }

            return result.ToString();
        }

        private static int[] ESieve(int upperLimit)
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

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);

            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray<int>();
        }
    }
}
