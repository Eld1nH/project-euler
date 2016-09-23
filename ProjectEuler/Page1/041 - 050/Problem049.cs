using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Prime permutations
    public class Problem049
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int a = 1000; a < 10000; a++)
            {
                if (!IsPrime(a)) continue;

                int maxAdd = (int)Math.Ceiling((double)((10000 - a) / 2));
                for (int i = 1; i <= maxAdd; i++)
                {
                    int b = a + i;
                    int c = b + i;

                    if (!IsPrime(b) || !IsPrime(c)) continue;

                    if (ArePermutations(a, b) && ArePermutations(a, c))
                    {
                        result = Convert.ToInt64("" + a + b + c);
                        if (result != 148748178147) break;
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

        private static bool ArePermutations(int a, int b)
        {
            if (a.ToString().Length != b.ToString().Length) return false;
            if (a == b) return false;

            int target = a.ToString().Length;
            char[] aDigits = a.ToString().ToCharArray();
            char[] bDigits = b.ToString().ToCharArray();

            int[] aCountDigits = new int[10];
            int[] bCountDigits = new int[10];
            for (int i = 0; i < aDigits.Length; i++)
            {
                int n = Convert.ToInt32(aDigits[i].ToString());
                int m = Convert.ToInt32(bDigits[i].ToString());
                aCountDigits[n]++;
                bCountDigits[m]++;
            }

            for (int i = 0; i < aCountDigits.Length; i++)
            {
                if (aCountDigits[i] != bCountDigits[i]) return false;
            }

            return true;
        }
    }
}
