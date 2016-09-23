using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._061___070
{
    // Cyclical figurative numbers
    public class Problem061
    {

        private static int[] solution;
        private static int[][] numbers;

        public static string Algorithm()
        {
            long result = 0;

            solution = new int[6];
            numbers = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                numbers[i] = GeneratePolygonals(i + 3);
            }

            for (int i = 0; i < numbers[5].Length; i++)
            {
                solution[5] = numbers[5][i];
                if (FindNext(5, 1)) break;
            }
            result = solution.Sum();

            return result.ToString();
        }

        private static bool FindNext(int last, int length)
        {
            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] != 0) continue;
                for (int j = 0; j < numbers[i].Length; j++)
                {
                    bool unique = true;
                    for (int k = 0; k < solution.Length; k++)
                    {
                        if (numbers[i][j] == solution[k])
                        {
                            unique = false;
                            break;
                        }
                    }

                    if (unique && ((numbers[i][j] / 100) == (solution[last] % 100)))
                    {
                        solution[i] = numbers[i][j];
                        if (length == 5)
                        {
                            if (solution[5] / 100 == solution[i] % 100) return true;
                        }
                        if (FindNext(i, length + 1)) return true;
                    }
                }
                solution[i] = 0;
            }
            return false;
        }

        private static int[] GeneratePolygonals(int poly)
        {
            List<int> result = new List<int>();
            int number = 0;
            int n = 0;
            while (number < 10000)
            {
                switch (poly)
                {
                    case 3:
                        number = n * (n + 1) / 2;
                        break;

                    case 4:
                        number = n * n;
                        break;

                    case 5:
                        number = n * (3 * n - 1) / 2;
                        break;

                    case 6:
                        number = n * (2 * n - 1);
                        break;

                    case 7:
                        number = n * (5 * n - 3) / 2;
                        break;

                    case 8:
                        number = n * (3 * n - 2);
                        break;
                }

                if (number >= 10000)
                    break;

                if (number > 999)
                    result.Add(number);

                n++;
            }

            return result.ToArray();
        }
    }
}
