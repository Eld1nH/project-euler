using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page1._021___030
{
    // Number spiral diagonals
    public class Problem028
    {

        public static string Algorithm()
        {
            return SpiralDiagonalOfN(500).ToString();
        }

        private static long SpiralDiagonalOfN(long n)
        {
            if (n == 0)
                return 1;

            long w = 2 * n + 1;
            return ((w * w) + ((w * w) - (w - 1)) + ((w * w) - ((w - 1) * 2)) + ((w * w) - ((w - 1) * 3)) + SpiralDiagonalOfN(n - 1));
        }
    }
}
