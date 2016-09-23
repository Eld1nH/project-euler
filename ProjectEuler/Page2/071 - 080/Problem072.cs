using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Counting fractions
    public class Problem072
    {

        public static string Algorithm()
        {
            long result = 0;
            int limit = 1000000;
            int[] phi = Enumerable.Range(0, limit + 1).ToArray();
            for (int i = 2; i <= limit; i++)
            {
                if (phi[i] == i)
                {
                    for (int j = i; j <= limit; j += i)
                    {
                        phi[j] = phi[j] / i * (i - 1);
                    }
                }
                result += phi[i];
            }

            return result.ToString();
        }
    }
}
