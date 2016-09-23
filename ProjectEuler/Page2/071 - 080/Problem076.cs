using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Counting summations
    public class Problem076
    {

        public static string Algorithm()
        {
            int target = 100;
            int[] sums = new int[target + 1];
            sums[0] = 1;

            for (int i = 1; i <= 99; i++)
            {
                for (int j = i; j <= target; j++)
                {
                    sums[j] += sums[j - i];
                }
            }

            return sums[target].ToString();
        }
    }
}
