using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Non-abundant sums
    public class Problem023
    {

        public static string Algorithm()
        {
            long result = 0;

            int maxValue = 28123;
            long[] primelist = ESieve((int)Math.Sqrt(maxValue));
            List<int> abundents = new List<int>();

            for (int i = 2; i <= maxValue; i++)
            {
                if (SumOfPrimeFactors(i, primelist) > i)
                {
                    abundents.Add(i);
                }
            }

            bool[] isAbundantSums = new bool[maxValue + 1];
            for (int a = 0; a < abundents.Count; a++)
            {
                for (int b = a; b < abundents.Count; b++)
                {
                    if (abundents[a] + abundents[b] <= maxValue)
                        isAbundantSums[abundents[a] + abundents[b]] = true;
                    else
                        break;
                }
            }

            for (int i = 1; i <= maxValue; i++)
            {
                if (isAbundantSums[i] == false)
                {
                    result += i;
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

        private static long SumOfPrimeFactors(long number, long[] primelist)
        {
            long n = number;
            long sum = 1;
            long p = primelist[0];
            long j;
            long i = 0;

            while (p * p <= n && n > 1 && i < primelist.Length)
            {
                p = primelist[i];
                i++;
                if (n % p == 0)
                {
                    j = p * p;
                    n = n / p;
                    while (n % p == 0)
                    {
                        j = j * p;
                        n = n / p;
                    }
                    sum = sum * (j - 1) / (p - 1);
                }
            }

            if (n > 1)
            {
                sum *= n + 1;
            }
            return sum - number;
        }
    }
}
