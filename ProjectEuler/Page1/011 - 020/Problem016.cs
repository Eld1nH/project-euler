using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Power digit sum
    public class Problem016
    {

        public static string Algorithm()
        {
            long result = 0;

            char[] n = BigInteger.Pow(2, 1000).ToString().ToCharArray();

            for (int i = 0; i < n.Length; i++)
            {
                result += Convert.ToInt64(n[i].ToString());
            }

            return result.ToString();
        }
    }
}
