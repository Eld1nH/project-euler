using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Almost equilateral triangles
    public class Problem094
    {

        public static string Algorithm()
        {
            long x = 2;
            long y = 1;
            long limit = 1000000000;
            long result = 0;

            while (true)
            {
                long aThree = 2 * x - 1;
                long areaThree = y * (x - 2);
                if (aThree > limit) break;

                if (aThree > 0 && areaThree > 0 && aThree % 3 == 0 && areaThree % 3 == 0)
                {
                    long a = aThree / 3;
                    long area = areaThree / 3;
                    result += 3 * a + 1;
                }

                aThree = 2 * x + 1;
                areaThree = y * (x + 2);

                if (aThree > 0 && areaThree > 0 && aThree % 3 == 0 && areaThree % 3 == 0)
                {
                    long a = aThree / 3;
                    long area = areaThree / 3;
                    result += 3 * a - 1;
                }

                long nx = 2 * x + y * 3;
                long ny = y * 2 + x;

                x = nx;
                y = ny;
            }

            return result.ToString();
        }
    }
}
