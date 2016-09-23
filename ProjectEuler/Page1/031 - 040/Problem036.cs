using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Double-base palindromes
    public class Problem036
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 1; i < 1000000; i += 2)
            {
                if (IsPalindrome(i, 10) && IsPalindrome(i, 2))
                {
                    result += i;
                }
            }

            return result.ToString();
        }

        private static bool IsPalindrome(int n, int b)
        {
            int reverse = 0;
            int number = n;

            while (number > 0)
            {
                reverse = b * reverse + number % b;
                number /= b;
            }
            return n == reverse;
        }
    }
}
