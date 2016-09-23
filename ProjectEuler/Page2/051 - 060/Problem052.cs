using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._051___060
{
    // Permutated multiples
    public class Problem052
    {

        public static string Algorithm()
        {
            long result = 0;

            long i = 0;
            long max = 1;
            while (result == 0)
            {
                i++;

                if (ArePermutations(i, i * 2, i * 3, i * 4, i * 5, i * 6))
                    result = i;

                if (i == max)
                {
                    i = ((long)Math.Pow(10, i.ToString().Length)) - 1;
                    max = (i + 1) * 10 / 6;
                }
            }

            return result.ToString();
        }

        private static bool ArePermutations(long a, long b, long c, long d, long e, long f)
        {
            if (a.ToString().Length != b.ToString().Length ||
                a.ToString().Length != c.ToString().Length ||
                a.ToString().Length != d.ToString().Length ||
                a.ToString().Length != e.ToString().Length ||
                a.ToString().Length != f.ToString().Length) return false;
            if (a == b || a == c || a == d || a == e || a == f ||
                b == c || b == d || b == e || b == f || c == d ||
                c == e || c == f || d == e || d == f || e == f) return false;

            int target = a.ToString().Length;
            char[] aDigits = a.ToString().ToCharArray();
            char[] bDigits = b.ToString().ToCharArray();
            char[] cDigits = c.ToString().ToCharArray();
            char[] dDigits = d.ToString().ToCharArray();
            char[] eDigits = e.ToString().ToCharArray();
            char[] fDigits = f.ToString().ToCharArray();

            int[] aCountDigits = new int[10];
            int[] bCountDigits = new int[10];
            int[] cCountDigits = new int[10];
            int[] dCountDigits = new int[10];
            int[] eCountDigits = new int[10];
            int[] fCountDigits = new int[10];
            for (int i = 0; i < aDigits.Length; i++)
            {
                int m = Convert.ToInt32(aDigits[i].ToString());
                int n = Convert.ToInt32(bDigits[i].ToString());
                int o = Convert.ToInt32(cDigits[i].ToString());
                int p = Convert.ToInt32(dDigits[i].ToString());
                int q = Convert.ToInt32(eDigits[i].ToString());
                int r = Convert.ToInt32(fDigits[i].ToString());
                aCountDigits[m]++;
                bCountDigits[n]++;
                cCountDigits[o]++;
                dCountDigits[p]++;
                eCountDigits[q]++;
                fCountDigits[r]++;
            }

            for (int i = 0; i < aCountDigits.Length; i++)
            {
                if (aCountDigits[i] != bCountDigits[i] ||
                    aCountDigits[i] != cCountDigits[i] ||
                    aCountDigits[i] != dCountDigits[i] ||
                    aCountDigits[i] != eCountDigits[i] ||
                    aCountDigits[i] != fCountDigits[i]) return false;
            }

            return true;
        }
    }
}
