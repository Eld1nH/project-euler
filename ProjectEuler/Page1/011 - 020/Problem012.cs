using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Highly divisible triangular number
    public class Problem012
    {

        public static string Algorithm()
        {
            long result = 0;
            long n = 0;
            while (GetDivisors(result).Count <= 500)
            {
                result += ++n;
            }

            return result.ToString();
        }

        private static List<long> GetDivisors(long n)
        {
            List<long> divisors = new List<long>();
            divisors.Add(n);
            long sqrt = (long)Math.Sqrt(n) + 1;
            for (long i = 1; i <= sqrt; i++)
            {
                if (n % i == 0 && !divisors.Contains(i))
                {
                    divisors.Add(i);
                    long quotient = n / i;
                    if (quotient != n && !divisors.Contains(quotient)) divisors.Add(quotient);
                }
            }

            return divisors;
        }
    }
}
