using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Su Doku
    public class Problem096
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/sudoku.txt";

        public static string Algorithm()
        {
            long result = 0;
            List<int[,]> grids = ReadInput(filename);

            for (int i = 0; i < grids.Count; i++)
            {
                int[,] grid = grids[i];
                bool[,] set = new bool[9, 9];

                for (int a = 0; a < 9; a++)
                    for (int b = 0; b < 9; b++)
                        if (grid[a, b] != 0)
                            set[a, b] = true;

                int x = 0;
                int y = 0;
                while (y < 9)
                {
                    if (!set[x, y])
                    {
                        grid[x, y] = GetNextPossibility(grid, x, y);

                        if (grid[x, y] == 0)
                        {
                            x = x - 1 < 0 ? ((--y + 1) / (y + 1)) * 8 : x - 1;
                            while (set[x, y])
                                x = x - 1 < 0 ? ((--y + 1) / (y + 1)) * 8 : x - 1;
                            continue;
                        }
                    }
                    x = x + 1 > 8 ? 0 * ++y : x + 1;
                }

                result += Convert.ToInt32("" + grid[0, 0] + grid[1, 0] + grid[2, 0]);
            }

            return result.ToString();
        }

        private static int GetNextPossibility(int[,] grid, int x, int y)
        {
            int min = grid[x, y] + 1;

            if (min > 9)
                return 0;

            bool[] pos = new bool[10];
            for (int i = 1; i < pos.Length; i++)
                pos[i] = true;

            for (int a = 0; a < 9; a++)
            {
                pos[grid[a, y]] = false;
                pos[grid[x, a]] = false;
            }

            int x1 = (int)(x / 3) * 3;
            int y1 = (int)(y / 3) * 3;
            for (int y2 = y1; y2 < y1 + 3; y2++)
                for (int x2 = x1; x2 < x1 + 3; x2++)
                    pos[grid[x2, y2]] = false;

            for (int a = min; a < pos.Length; a++)
                if (pos[a])
                    return a;

            return 0;
        }

        private static List<int[,]> ReadInput(string filename)
        {
            List<int[,]> output = new List<int[,]>();
            string[] lines = File.ReadAllLines(filename).ToArray();

            int[,] grid = new int[9, 9];
            int column = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("Grid"))
                {
                    grid = new int[9, 9];
                    column = 0;
                    continue;
                }

                int n = Convert.ToInt32(lines[i]);
                int row = 8;

                while (n != 0)
                {
                    grid[row, column] = n % 10;
                    n /= 10;
                    row--;
                }

                column++;

                if (column == 8)
                {
                    output.Add(grid);
                }
            }

            return output;
        }
    }
}
