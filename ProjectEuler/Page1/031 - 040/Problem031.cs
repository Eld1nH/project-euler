using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Coin sums
    public class Problem031
    {

        public static string Algorithm()
        {
            int target = 200;
            long result = 0;

            for (int a = target; a >= 0; a -= 200)
            {
                for (int b = a; b >= 0; b -= 100)
                {
                    for (int c = b; c >= 0; c -= 50)
                    {
                        for (int d = c; d >= 0; d -= 20)
                        {
                            for (int e = d; e >= 0; e -= 10)
                            {
                                for (int f = e; f >= 0; f -= 5)
                                {
                                    for (int g = f; g >= 0; g -= 2)
                                    {
                                        result++;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result.ToString();
        }
    }
}
