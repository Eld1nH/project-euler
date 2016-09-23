using System.Collections.Generic;

namespace ProjectEuler.Page2._091___100
{
    // Square digit chains
    public class Problem092
    {

        public static string Algorithm()
        {
            long result = 0;
            int limit = 10000000;

            for (int i = 1; i < limit; i++)
            {
                long n = i;
                while (n != 1 && n != 89)
                {
                    n = SquareDigitSum(n);
                }

                if (n == 89)
                    result++;
            }

            return result.ToString();
        }

        private static long SquareDigitSum(long n)
        {
            long a = 0;
            while (n != 0)
            {
                a += (n % 10) * (n % 10);
                n /= 10;
            }
            return a;
        }
    }
}
