using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Counting rectangles
    public class Problem085
    {

        public static string Algorithm()
        {
            long result = 0;
            int target = 2000000;
            int check = Int32.MaxValue;

            int x = 2000;
            int y = 1;

            while (x >= y)
            {
                int rects = x * (x + 1) * y * (y + 1) / 4;

                if (check > Math.Abs(rects - target))
                {
                    result = x * y;
                    check = Math.Abs(rects - target);
                }

                if (rects > target)
                    x--;
                else
                    y++;
            }          

            return result.ToString();
        }
    }
}
