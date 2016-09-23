using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Lexicographic permutations
    public class Problem024
    {
        private static int[] perm = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static string Algorithm()
        {
            int n = perm.Length;
            string result = "";
            int remain = 1000000 - 1;
            
            List<int> numbers = new List<int>();
            for (int i = 0; i < n; i++)
            {
                numbers.Add(i);
            }

            for (int i = 1; i < n; i++)
            {
                int j = remain / Factor(n - i);
                remain = remain % Factor(n - i);
                result = result + numbers[j];
                numbers.RemoveAt(j);
                if (remain == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                result = result + numbers[i];
            }

            return result;
        }

        private static int Factor(int i)
        {
            if (i < 1)
            {
                return 0;
            }

            int p = 1;
            for (int j = 1; j <= i; j++)
            {
                p *= j;
            }
            return p;
        }
    }
}
