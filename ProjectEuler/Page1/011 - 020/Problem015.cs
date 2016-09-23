using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Lattice paths
    public class Problem015
    {

        public static string Algorithm()
        {
            BigInteger f40 = Factorize(40);
            BigInteger f20 = Factorize(20);

            return (f40 / (f20 * f20)).ToString();
        }

        public static BigInteger Factorize(BigInteger n)
        {
            if (n == 0 || n == 1)
                return 1;
            return n * Factorize(n - 1);
        }
    }
}
