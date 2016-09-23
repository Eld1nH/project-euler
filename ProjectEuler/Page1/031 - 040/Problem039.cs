using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._031___040
{
    // Integer right triangles
    public class Problem039
    {

        public static string Algorithm()
        {
            long result = 0;
            long highest = 0;

            for (int p = 2; p <= 1000; p += 2)
            {
                int triplets = 0;

                for (int a = 2; a < (p / 3); a++)
                {
                    if ((p * (p - 2 * a)) % (2 * (p - a)) == 0)
                    {
                        triplets++;
                    }
                }

                if (triplets > highest)
                {
                    highest = triplets;
                    result = p;
                }
            }

            return result.ToString();
        }
    }
}
