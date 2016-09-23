using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Combinatoric selections
    public class Problem053
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int n = 23; n <= 100; n++)
            {
                for (int r = n; r > 0; r--)
                {
                    BigInteger a = Factorize(n) / (Factorize(r) * Factorize(n - r));
                    if (a > 1000000)
                        result++;
                }
            }

            return result.ToString();
        }

        private static BigInteger Factorize(BigInteger n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorize(n - 1);
        }
    }
}
