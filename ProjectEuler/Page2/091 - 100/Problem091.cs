using System;
using System.Diagnostics;

namespace ProjectEuler.Page2._091___100
{
    // Right triangles with integer coordinates
    public class Problem091
    {

        public static string Algorithm()
        {
            int size = 50;
            int result = size * size * 3;
            for (int x = 1; x <= size; x++)
            {
                for (int y = 1; y <= size; y++)
                {
                    int fact = GCD(x, y);
                    result += Math.Min(y * fact / x, (size - x) * fact / y) * 2;
                }
            }

            return result.ToString();
        }

        private static int GCD(int a, int b)
        {
            int r;

            while (b != 0)
            {
                r = a % b;
                a = b;
                b = r;
            }

            return a;
        }
    }
}
