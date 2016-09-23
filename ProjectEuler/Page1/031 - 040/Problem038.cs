using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Pandigital multiples
    public class Problem038
    {

        public static string Algorithm()
        {
            long result = 0;

            for (long i = 9387; i >= 9234; i--)
            {
                result = Convert.ToInt64(i.ToString() + "" + (i * 2).ToString());
                if (IsPandigital(result))
                {
                    break;
                }
            }

            return result.ToString();
        }

        private static bool IsPandigital(long n)
        {
            bool[] digits = new bool[10];

            while (n > 0)
            {
                long rem = n % 10;
                if (digits[rem]) return false;
                digits[rem] = true;
                n /= 10;
            }

            return true;
        }
    }
}
