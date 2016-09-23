using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Lychrel numbers
    public class Problem055
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int i = 10; i < 10000; i++)
            {
                long n = i;
                long r = ReverseNumber(n);
                int c = 0;
                while (!IsPalindrome(n + r, 10))
                {
                    if (c >= 50)
                    {
                        result++;
                        break;
                    }
                    n = n + r;
                    r = ReverseNumber(n);
                    c++;
                }
            }

            return result.ToString();
        }

        private static long ReverseNumber(long n)
        {
            long reverse = 0;
            long number = n;

            while (number > 0)
            {
                reverse = 10 * reverse + number % 10;
                number /= 10;
            }
            return reverse;
        }

        private static bool IsPalindrome(long n, long b)
        {
            long reverse = 0;
            long number = n;

            while (number > 0)
            {
                reverse = b * reverse + number % b;
                number /= b;
            }
            return n == reverse;
        }
    }
}
