using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Arranged probability
    public class Problem100
    {

        public static string Algorithm()
        {
            long b = 15;
            long t = 21;
            long target = 1000000000000;

            while (t < target)
            {
                long bt = 3 * b + 2 * t - 2;
                long tt = 4 * b + 3 * t - 3;
                b = bt;
                t = tt;
            }

            return b.ToString();
        }
    }
}
