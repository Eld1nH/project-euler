using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Odd period square roots
    public class Problem064
    {

        public static string Algorithm()
        {
            long result = 0;
            int upperbound = 10000;

            for (int n = 2; n <= upperbound; n++)
            {
                int limit = (int)Math.Sqrt(n);
                if (limit * limit == n) continue;

                int period = 0;
                int d = 1;
                int m = 0;
                int a = limit;

                while (a != 2 * limit)
                {
                    m = d * a - m;
                    d = (n - m * m) / d;
                    a = (limit + m) / d;
                    period++;
                }

                if (period % 2 == 1) result++;
            }

            return result.ToString();
        }
    }
}
