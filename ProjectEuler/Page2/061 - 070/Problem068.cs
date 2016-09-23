using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Magic 5-gon ring
    public class Problem068
    {

        private static int[] p = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static string result = "";

        public static string Algorithm()
        {
            p = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            result = "";

            while (true)
            {
                if (!GetNextPerm()) break;
                if (CheckResult())
                {
                    string candidate = "" + p[0] + p[1] + p[2] + p[3] + p[2] + p[4] + p[5] + p[4] + p[6] + p[7] + p[6] + p[8] + p[9] + p[8] + p[1];
                    if (candidate.CompareTo(result) > 0) result = candidate;
                }
            }
            return result;
        }

        private static bool GetNextPerm()
        {
            int N = p.Length;
            int i = N - 1;

            while (p[i - 1] >= p[i])
            {
                i--;
                if (i < 1) return false;
            }

            int j = N;
            while (p[j - 1] <= p[i - 1])
            {
                j = j - 1;
            }

            Swap(i - 1, j - 1);

            i++;
            j = N;

            while (i < j)
            {
                Swap(i - 1, j - 1);
                i++;
                j--;
            }
            return true;
        }

        private static void Swap(int i, int j)
        {
            int k = p[i];
            p[i] = p[j];
            p[j] = k;
        }

        public static bool CheckResult()
        {
            if (p[1] == 10 ||
                p[2] == 10 ||
                p[4] == 10 ||
                p[6] == 10 ||
                p[8] == 10) return false;

            if (p[0] > p[3] ||
                p[0] > p[5] ||
                p[0] > p[7] ||
                p[0] > p[9]) return false;


            if (p[0] + p[1] + p[2] != p[3] + p[2] + p[4]) return false;
            if (p[0] + p[1] + p[2] != p[5] + p[4] + p[6]) return false;
            if (p[0] + p[1] + p[2] != p[7] + p[6] + p[8]) return false;
            if (p[0] + p[1] + p[2] != p[9] + p[8] + p[1]) return false;

            return true;
        }
    }
}
