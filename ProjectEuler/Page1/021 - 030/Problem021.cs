using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Amicable numbers
    public class Problem021
    {

        public static string Algorithm()
        {
            long result = 0;
            int a, b;
            for (int i = 2; i < 10000; i++)
            {
                a = SumOfProperDivisors(i);
                b = (a > i) ? SumOfProperDivisors(a) : 0;
                if (b == i)
                {
                    result += i + a;
                }
            }

            return result.ToString();
        }

        public static int SumOfProperDivisors(int n)
        {
            int sum = 0;
            List<int> divisors = new List<int>();
            int sqrt = (int)Math.Sqrt(n) + 1;
            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0 && !divisors.Contains(i))
                {
                    divisors.Add(i);
                    int quotient = n / i;
                    if (quotient != n && !divisors.Contains(quotient)) divisors.Add(quotient);
                }
            }

            for (int i = 0; i < divisors.Count; i++)
            {
                sum += divisors[i];
            }

            return sum;
        }
    }
}
