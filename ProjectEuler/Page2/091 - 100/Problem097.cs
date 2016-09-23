using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Large non-Mersenne prime
    public class Problem097
    {

        public static string Algorithm()
        {
            long mod = 10000000000;
            BigInteger result = 28433 * BigInteger.ModPow(2, 7830457, mod) + 1;
            result %= mod;
            return result.ToString();
        }
    }
}
