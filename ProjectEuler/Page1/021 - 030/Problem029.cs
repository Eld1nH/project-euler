using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Distinct powers
    public class Problem029
    {

        public static string Algorithm()
        {
            List<BigInteger> results = new List<BigInteger>();

            for (int a = 2; a <= 100; a++)
            {
                for (int b = 2; b <= 100; b++)
                {
                    BigInteger value = BigInteger.Pow(a, b);

                    if (!results.Contains(value))
                        results.Add(value);
                }
            }

            return results.Count().ToString();
        }
    }
}
