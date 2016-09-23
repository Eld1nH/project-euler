using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Longest Collatz sequence
    public class Problem014
    {

        public static string Algorithm()
        {
            long result = 1;
            int rTerms = 1;

            for (long i = 2; i < 1000000; i++)
            {
                int terms = 1;
                long n = i;
                while (n != 1)
                {
                    if (n % 2 == 0) n /= 2;
                    else n = 3 * n + 1;
                    terms++;
                }
                if (terms > rTerms)
                {
                    rTerms = terms;
                    result = i;
                }
            }

            return result.ToString();
        }
    }
}