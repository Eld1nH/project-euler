using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Digit canceling fractions
    public class Problem033
    {

        public static string Algorithm()
        {
            long den = 1;
            long nom = 1;

            for (int i = 1; i < 10; i++)
            {
                for (int d = 1; d < i; d++)
                {
                    for (int n = 1; n < d; n++)
                    {
                        if ((n * 10 + i) * d == n * (i * 10 + d))
                        {
                            den *= d;
                            nom *= n;
                        }
                    }
                }
            }

            den /= GCD(nom, den);
            return den.ToString();
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
