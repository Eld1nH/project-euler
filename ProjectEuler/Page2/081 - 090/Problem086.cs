using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Cuboid route
    public class Problem086
    {

        public static string Algorithm()
        {
            int result = 2;
            int count = 0;
            int target = 1000000;

            while (count < target)
            {
                result++;
                for (int wh = 3; wh <= 2 * result; wh++)
                {
                    double sqrt = Math.Sqrt(wh * wh + result * result);
                    if (sqrt == (int)(sqrt))
                    {
                        count += (wh <= result) ? wh / 2 : 1 + (result - (wh + 1) / 2);
                    }
                }
            }

            return result.ToString();
        }
    }
}
