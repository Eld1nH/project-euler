using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._011___020
{
    // Factorial digit sum
    public class Problem020
    {

        public static string Algorithm()
        {
            long result = 0;

            BigInteger fact = 100;
            for (int i = 99; i > 1; i--)
                fact *= i;

            char[] factDigits = fact.ToString().ToCharArray();
            for (int i = 0; i < factDigits.Length; i++)
                result += Convert.ToInt64(factDigits[i].ToString());

            return result.ToString();
        }
    }
}
