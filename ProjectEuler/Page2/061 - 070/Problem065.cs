using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Convergents of e
    public class Problem065
    {

        public static string Algorithm()
        {
            int upperbound = 100;

            BigInteger d = 1;
            BigInteger n = 2;

            for (int i = 2; i <= upperbound; i++)
            {
                BigInteger temp = d;
                int c = (i % 3 == 0) ? 2 * (i / 3) : 1;
                d = n;
                n = c * d + temp;
            }

            return DigitSum(n).ToString();
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
