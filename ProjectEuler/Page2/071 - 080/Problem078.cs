using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Coin partitions
    public class Problem078
    {

        public static string Algorithm()
        {
            List<int> p = new List<int>();
            p.Add(1);

            int n = 1;
            while (true)
            {
                int i = 0;
                int pentagonal = 1;
                p.Add(0);

                while (pentagonal <= n)
                {
                    int sign = (i % 4 > 1) ? -1 : 1;
                    p[n] += sign * p[n - pentagonal];
                    p[n] %= 1000000;
                    i++;

                    int j = (i % 2 == 0) ? i / 2 + 1 : -(i / 2 + 1);
                    pentagonal = j * (3 * j - 1) / 2;
                }

                if (p[n] == 0) break;
                n++;
            }

            return n.ToString();
        }
    }
}
