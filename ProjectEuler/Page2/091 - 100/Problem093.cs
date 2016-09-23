using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Arithmetic expressions
    public class Problem093
    {

        public static string Algorithm()
        {
            int[] result = null;
            int resultCount = 0;

            int[] comb = { 0, 1, 2, 3 };
            while (comb != null)
            {
                bool[] results = new bool[9 * 8 * 7 * 6];
                int[] perm = (int[])comb.Clone();

                while (perm != null)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                double? number = Operate(Operate(Operate(perm[0], perm[1], i), perm[2], j), perm[3], k);
                                if (number != null && number == (int)number && number < results.Length && number > 0)
                                    results[(int)number] = true;

                                number = Operate(Operate(perm[0], Operate(perm[1], perm[2], j), i), perm[3], k);
                                if (number != null && number == (int)number && number < results.Length && number > 0)
                                    results[(int)number] = true;

                                number = Operate(perm[0], Operate(Operate(perm[1], perm[2], j), perm[3], k), i);
                                if (number != null && number == (int)number && number < results.Length && number > 0)
                                    results[(int)number] = true;

                                number = Operate(perm[0], Operate(perm[1], Operate(perm[2], perm[3], k), j), i);
                                if (number != null && number == (int)number && number < results.Length && number > 0)
                                    results[(int)number] = true;

                                number = Operate(Operate(perm[0], perm[1], i), Operate(perm[2], perm[3], k), j);
                                if (number != null && number == (int)number && number < results.Length && number > 0)
                                    results[(int)number] = true;
                            }
                        }
                    }

                    int l = 1;
                    while (results[l])
                    {
                        l++;
                    }

                    if (l > resultCount)
                    {
                        result = (int[])comb.Clone();
                        resultCount = l;
                    }

                    perm = NextPermutation(perm);
                }
                comb = NextCombination(4, 10, comb);
            }

            string resultString = "";
            for (int i = 0; i < result.Length; i++)
            {
                resultString += result[i].ToString();
            }
            return resultString;
        }

        private static double? Operate(double? a, double? b, int op)
        {
            if (a == null || b == null) return null;
            switch (op)
            {
                case 0:
                    return a + b;
                case 1:
                    return a - b;
                case 2:
                    return a * b;
                case 3:
                    if (b == 0) return null;
                    return a * 1.0 / b;
            }
            return 0;
        }

        public static int[] NextCombination(int k, int n, int[] comb)
        {
            int i = k - 1;
            comb[i]++;
            while ((i > 0) && (comb[i] >= n - k + 1 + i))
            {
                i--;
                comb[i]++;
            }

            if (comb[0] > n - k)
                return null;

            for (i = i + 1; i < k; i++)
                comb[i] = comb[i - 1] + 1;


            return comb;
        }


        public static int[] NextPermutation(int[] perm)
        {

            bool nextExist = false;
            for (int k = 0; k < perm.Length - 1; k++)
            {
                if (perm[k] < perm[k + 1]) nextExist = true;
            }
            if (!nextExist) return null;

            int N = perm.Length;
            int i = N - 1;

            while (perm[i - 1] >= perm[i])
            {
                i = i - 1;
            }

            int j = N;
            while (perm[j - 1] <= perm[i - 1])
            {
                j = j - 1;
            }

            Swap(i - 1, j - 1, perm);

            i++;
            j = N;

            while (i < j)
            {
                Swap(i - 1, j - 1, perm);
                i++;
                j--;
            }

            return perm;
        }

        private static void Swap(int i, int j, int[] perm)
        {
            int k = perm[i];
            perm[i] = perm[j];
            perm[j] = k;
        }
    }
}
