using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._071___080
{
    // Square root digital expansion
    public class Problem080
    {

        public static string Algorithm()
        {
            long result = 0;
            int j = 1;

            for (int i = 1; i <= 100; i++)
            {
                if (j * j == i)
                {
                    j++;
                    continue;
                }
                result += DigitSum(Squareroot(i, 100));
            }

            return result.ToString();
        }

        private static BigInteger Squareroot(int n, int digits)
        {
            BigInteger limit = BigInteger.Pow(10, digits + 1);
            BigInteger a = 5 * n;
            BigInteger b = 5;

            while (b < limit)
            {
                if (a >= b)
                {
                    a -= b;
                    b += 10;
                }
                else
                {
                    a *= 100;
                    b = (b / 10) * 100 + 5;
                }
            }

            return b / 100;
        }

        private static long DigitSum(BigInteger n)
        {
            char[] c = n.ToString().ToCharArray();
            long s = 0;
            for (int i = 0; i < c.Length; i++)
            {
                s += Convert.ToInt64(c[i].ToString());
            }
            return s;
        }
    }
}
