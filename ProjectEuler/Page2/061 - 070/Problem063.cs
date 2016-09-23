using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Powerful digit counts
    public class Problem063
    {

        public static string Algorithm()
        {
            long result = 0;
            long lower = 0;
            long n = 1;

            while (lower < 10)
            {
                lower = (long)Math.Ceiling(Math.Pow(10, (n - 1.0) / n));
                result += 10 - lower;
                n++;
            }

            return result.ToString();
        }
    }
}
