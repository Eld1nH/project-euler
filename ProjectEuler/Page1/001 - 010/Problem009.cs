using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._001___010
{
    // Special pythagorean triplet
    public class Problem009
    {

        public static string Algorithm()
        {
            long result = 0;

            for (int a = 1; a < 1000; a++)
            {
                for (int b = a + 1; b < 1000; b++)
                {
                    double p = (double)Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if (p % 1 == 0)
                    {
                        int c = (int)p;
                        if (a + b + c == 1000)
                        {
                            return (a * b * c).ToString();
                        }
                    }
                }
            }
            
            return result.ToString();
        }
    }
}
