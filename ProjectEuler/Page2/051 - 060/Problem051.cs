using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Prime digit replacements
    public class Problem051
    {

        private static int[][] fiveDigitPattern = { new int[] { 1, 0, 0, 0, 1 },
                                                    new int[] { 0, 1, 0, 0, 1 },
                                                    new int[] { 0, 0, 1, 0, 1 },
                                                    new int[] { 0, 0, 0, 1, 1 } };
        private static int[][] sixDigitPattern = { new int[] { 1, 1, 0, 0, 0, 1 },
                                                   new int[] { 1, 0, 1, 0, 0, 1 },
                                                   new int[] { 1, 0, 0, 1, 0, 1 },
                                                   new int[] { 1, 0, 0, 0, 1, 1 },
                                                   new int[] { 0, 1, 1, 0, 0, 1 },
                                                   new int[] { 0, 1, 0, 1, 0, 1 },
                                                   new int[] { 0, 1, 0, 0, 1, 1 },
                                                   new int[] { 0, 0, 1, 1, 0, 1 },
                                                   new int[] { 0, 0, 1, 0, 1, 1 },
                                                   new int[] { 0, 0, 0, 1, 1, 1 } };

        public static string Algorithm()
        {
            long result = Int64.MaxValue;

            for (int i = 11; i < 1000; i += 2)
            {
                if (i % 5 == 0) continue;

                int[][] pattern = (i < 100) ? fiveDigitPattern : sixDigitPattern;

                for (int j = 0; j < pattern.GetLength(0); j++)
                {
                    for (int k = 0; k <= 2; k++)
                    {
                        if (pattern[j][0] == 0 && k == 0) continue;

                        int[] filled = FillPattern(pattern[j], i);
                        long candidate = GenerateNumber(k, filled);

                        if (candidate < result && IsPrime(candidate))
                        {
                            if (FamilySize(k, filled) == 8)
                                result = candidate;
                            break;
                        }
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

        private static int FamilySize(int n, int[] pattern)
        {
            int size = 1;

            for (int i = n + 1; i < 10; i++)
            {
                if (IsPrime(GenerateNumber(i, pattern))) size++;
            }

            return size;
        }

        private static long GenerateNumber(int n, int[] pattern)
        {
            long t = 0;

            for (int i = 0; i < pattern.Length; i++)
            {
                t *= 10;
                t += (pattern[i] == -1) ? n : pattern[i];
            }

            return t;
        }

        private static int[] FillPattern(int[] pattern, int n)
        {
            int[] filled = new int[pattern.Length];
            int t = n;

            for (int i = filled.Length - 1; i >= 0; i--)
            {
                if (pattern[i] == 1)
                {
                    filled[i] = t % 10;
                    t /= 10;
                }
                else
                {
                    filled[i] = -1;
                }
            }

            return filled;
        }
    }
}
