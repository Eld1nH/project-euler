using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Powerful digit sum
    public class Problem056
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int a = 99; a > 0; a--)
            {
                for (int b = 99; b > 0; b--)
                {
                    BigInteger n = BigInteger.Pow(a, b);
                    if (((int)BigInteger.Log10(n)) * 9 < result) break;
                    long s = DigitSum(n);
                    if (s > result) result = s;
                }
            }

            return result.ToString();
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
