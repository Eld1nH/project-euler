using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._041___050
{
    // Self powers
    public class Problem048
    {

        public static string Algorithm()
        {
            BigInteger result = 0;

            for (int i = 1; i <= 1000; i++)
            {
                result += BigInteger.Pow(i, i);
            }

            return (result % 10000000000).ToString();
        }
    }
}
