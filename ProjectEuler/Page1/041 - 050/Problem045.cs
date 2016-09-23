using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Triangular, pentagonal and hexagonal
    public class Problem045
    {

        public static string Algorithm()
        {
            long result = 0;

            long i = 285;
            bool found = false;

            while (!found)
            {
                i++;
                long t = i * (i + 1) / 2;

                if (IsPentagonal(t) && IsHexagonal(t))
                {
                    result = t;
                    break;
                }
            }

            return result.ToString();
        }

        private static bool IsPentagonal(long n)
        {
            double root = (Math.Sqrt(24 * n + 1) + 1) / 6;
            return IsNaturalNumber(root);
        }

        private static bool IsHexagonal(long n)
        {
            double root = (Math.Sqrt(8 * n + 1) + 1) / 4;
            return IsNaturalNumber(root);
        }

        private static bool IsNaturalNumber(double n)
        {
            return n == (long)n;
        }
    }
}
