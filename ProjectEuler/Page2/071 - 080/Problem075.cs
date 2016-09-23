using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Singular integer right triangles
    public class Problem075
    {

        public static string Algorithm()
        {
            long result = 0;

            int limit = 1500000;
            int[] triangles = new int[limit + 1];

            int mlimit = (int)Math.Sqrt(limit / 2);

            for (long m = 2; m < mlimit; m++)
            {
                for (long n = 1; n < m; n++)
                {
                    if (((n + m) % 2) == 1 && GCD(n, m) == 1)
                    {
                        long a = m * m + n * n;
                        long b = m * m - n * n;
                        long c = 2 * m * n;
                        long p = a + b + c;
                        while (p <= limit)
                        {
                            triangles[p]++;
                            if (triangles[p] == 1) result++;
                            if (triangles[p] == 2) result--;
                            p += a + b + c;
                        }
                    }
                }
            }

            return result.ToString();
        }

        private static long GCD(long a, long b)
        {
            long r;

            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }

            return a;
        }
    }
}
