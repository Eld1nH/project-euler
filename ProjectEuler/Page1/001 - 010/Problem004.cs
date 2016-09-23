using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._001___010
{
    // Largest palindrome product
    public class Problem004
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int a = 999; a >= 900; a--)
            {
                for (int b = a; b < 1000; b++)
                {
                    int n = a * b;
                    if (IsPalindrome(n, 10))
                    {
                        if (n > result)
                            result = n;
                    }
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
