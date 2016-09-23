using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Cube digit pairs
    public class Problem090
    {

        public static string Algorithm()
        {
            long result = 0;
            List<List<int>> combs = GenerateCombinations(6, 10);

            for (int i = 0; i < combs.Count; i++)
            {
                if (combs[i][0] != 0) break;
                for (int j = i + 1; j < combs.Count; j++)
                {
                    if (ValidateCombination(combs[i], combs[j])) result++;
                }
            }

            return result.ToString();
        }

        private static List<List<int>> GenerateCombinations(int k, int n)
        {

            List<List<int>> combs = new List<List<int>>();
            List<int> comb = new List<int>();
            for (int i = 0; i < k; i++)
            {
                comb.Add(i);
            }
            while (true)
            {
                combs.Add(comb);           
                comb = new List<int>(comb);

                if (combs[combs.Count - 1][k - 1] == 9) 
                    combs[combs.Count - 1][k - 1] = 6;

                int i = k - 1;
                comb[i]++;
                while ((i > 0) && (comb[i] >= n - k + 1 + i))
                {
                    i--;
                    comb[i]++;
                }

                if (comb[0] > n - k)
                    break;

                for (i = i + 1; i < k; i++)
                    comb[i] = comb[i - 1] + 1;
            }

            return combs;
        }

        private static bool ValidateCombination(List<int> d1, List<int> d2)
        {

            int[,] combs = { { 0, 1 }, { 0, 4 }, { 0, 6 }, { 1, 6 }, { 2, 5 }, { 3, 6 }, { 4, 6 }, { 6, 4 }, { 8, 1 } };

            bool valid = true;
            for (int i = 0; i < combs.GetLength(0); i++)
            {
                if (!((d1.Contains(combs[i, 0]) && d2.Contains(combs[i, 1])) ||
                   (d2.Contains(combs[i, 0]) && d1.Contains(combs[i, 1]))))
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }
    }
}
