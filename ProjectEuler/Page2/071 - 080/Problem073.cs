using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Counting fractions in a range
    public class Problem073
    {

        public static string Algorithm()
        {
            long result = 0; 
            int limit = 12000;
            int a = 1;
            int b = 3;
            int c = 4000;
            int d = 11999;

            while (!(c == 1 && d == 2))
            {
                result++;
                int k = (limit + b) / d;
                int e = k * c - a;
                int f = k * d - b;
                a = c;
                b = d;
                c = e;
                d = f;
            }

            return result.ToString();
        }
    }
}
