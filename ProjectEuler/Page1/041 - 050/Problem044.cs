using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Pentagon numbers
    public class Problem044
    {

        public static string Algorithm()
        {
            long result = 0;

            bool found = false;
            int i = 1;

            while (!found)
            {
                i++;
                int n = i * (3 * i - 1) / 2;

                for (int j = i - 1; j > 0; j--)
                {
                    int m = j * (3 * j - 1) / 2;
                    if (IsPentagonal(n - m) && IsPentagonal(n + m))
                    {
                        result = n - m;
                        found = true;
                        break;
                    }
                }
            }

            return result.ToString();
        }

        private static bool IsPentagonal(long n)
        {
            double root = (Math.Sqrt(24 * n + 1) + 1) / 6;
            return IsNaturalNumber(root);
        }

        private static bool IsNaturalNumber(double n)
        {
            return n == (long)n;
        }
    }
}
