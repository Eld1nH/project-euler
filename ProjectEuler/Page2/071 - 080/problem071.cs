using Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Ordered fractions
    public class Problem071
    {

        public static string Algorithm()
        {
            long a = 3;
            long b = 7;
            long r = 0;
            long s = 1;

            for (int q = 1000000; q > 2; q--)
            {
                long p = (a * q - 1) / b;
                if (p * s > r * q)
                {
                    s = q;
                    r = p;
                }
            }

            return r.ToString();
        }
    }
}
