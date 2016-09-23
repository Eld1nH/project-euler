using System.Globalization;

namespace ProjectEuler.Page1._041___050
{
    // Sub-string divisibility
    public class Problem043
    {

        public static string Algorithm()
        {
            long result = 0;
            const short ten = 10;
            
            for (short a = 986; a >= 17; a -= 17)
            {
                if (!IsPandigital(a)) continue;
                for (short i = 900; i >= 0; i -= 100)
                {
                    var b = (short)((a / ten) + i);
                    if (b % 13 != 0 || !IsPandigital(b)) continue;
                    for (short j = 900; j >= 0; j -= 100)
                    {
                        var c = (short)((b / ten) + j);
                        if (c % 11 != 0 || !IsPandigital(c)) continue;
                        for (short k = 900; k >= 0; k -= 100)
                        {
                            var d = (short)((c / ten) + k);
                            if (d % 7 != 0 || !IsPandigital(d)) continue;
                            for (short l = 900; l >= 0; l -= 100)
                            {
                                var e = (short)((d / ten) + l);
                                if (e % 5 != 0 || !IsPandigital(e)) continue;
                                for (short m = 900; m >= 0; m -= 100)
                                {
                                    var f = (short)((e / ten) + m);
                                    if (f % 3 != 0 || !IsPandigital(f)) continue;
                                    for (short n = 900; n >= 0; n -= 100)
                                    {
                                        var g = (short)((f / ten) + n);
                                        if (g % 2 != 0 || !IsPandigital(g)) continue;
                                        long p = (g * 1000000) + (d * 1000) + a;
                                        if (!IsPandigital(p)) continue;
                                        long pPan = MakePandigital(p);
                                        if (p == pPan) continue;
                                        result += pPan;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }

        private static bool IsPandigital(short n)
        {
            var digits = new bool[10];

            while (n > 0)
            {
                if (digits[n % 10]) return false;
                digits[n % 10] = true;
                n /= 10;
            }

            return true;
        }

        private static bool IsPandigital(long n)
        {
            var digits = new bool[10];

            while (n > 0)
            {
                if (digits[n % 10]) return false;
                digits[n % 10] = true;
                n /= 10;
            }

            return true;
        }

        private static long Concat(long a, long b)
        {
            long c = b;
            while (c > 0)
            {
                a *= 10;
                c /= 10;
            }

            return a + b;
        }

        private static long MakePandigital(long n)
        {
            var digits = new bool[10];
            long a = n;

            while (n > 0)
            {
                digits[n % 10] = true;
                n /= 10;
            }

            long b = 0;

            for (long i = 0; i < 10; i++)
            {
                if (digits[i])
                    continue;

                if (b != 0) 
                    return a;

                b = Concat(i, a);
            }

            return b == 0 ? a : b;
        }
    }
}
