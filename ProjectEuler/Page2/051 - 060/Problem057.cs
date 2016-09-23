using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Square root convergents
    public class Problem057
    {

        public static string Algorithm()
        {
            long result = 0;

            BigInteger nom = 3;
            BigInteger den = 2;
            for (int i = 1; i < 1000; i++)
            {
                nom += den * 2;
                den = nom - den;

                if ((int)BigInteger.Log10(nom) > (int)BigInteger.Log10(den)) result++;
            }

            return result.ToString();
        }
    }
}
