using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._081___090
{
    // Path sum: four ways
    public class Problem083
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/matrix.txt";

        public static string Algorithm()
        {
            int[,] grid = ReadInput(filename);
            int minval = GetMinValue(grid);
            int gridSize = grid.GetLength(0);
            int[,] g = new int[gridSize, gridSize];
            int[,] h = new int[gridSize, gridSize];
            int[,] searched = new int[gridSize, gridSize];

            SortedList<Tuple<int, int>, Tuple<int, int>> openList = new SortedList<Tuple<int, int>, Tuple<int, int>>();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    h[i, j] = minval * (2 * (gridSize - 1) + 1 - i - j);
                    g[i, j] = int.MaxValue;
                }
            }

            g[0, 0] = grid[0, 0];
            openList.Add(new Tuple<int, int>(g[0, 0] + h[0, 0], 0), new Tuple<int, int>(0, 0));

            while (searched[gridSize - 1, gridSize - 1] < 2)
            {
                Tuple<int, int> current = openList.ElementAt(0).Value;
                openList.RemoveAt(0);
                int ci = current.Item1;
                int cj = current.Item2;
                searched[current.Item1, current.Item2] = 2;

                for (int k = 0; k < 4; k++)
                {
                    int cinew = 0;
                    int cjnew = 0;

                    switch (k)
                    {
                        case 0: // Up
                            cinew = ci - 1;
                            cjnew = cj;
                            break;
                        case 1: // Down
                            cinew = ci + 1;
                            cjnew = cj;
                            break;
                        case 2: // Right
                            cinew = ci;
                            cjnew = cj + 1;
                            break;
                        case 3: // Left
                            cinew = ci;
                            cjnew = cj - 1;
                            break;
                    }

                    if (cinew >= 0 && cinew < gridSize &&
                        cjnew >= 0 && cjnew < gridSize &&
                        searched[cinew, cjnew] < 2)
                    {
                        if (g[cinew, cjnew] > g[ci, cj] + grid[cinew, cjnew])
                        {
                            g[cinew, cjnew] = g[ci, cj] + grid[cinew, cjnew];

                            if (searched[cinew, cjnew] == 1)
                            {
                                int index = openList.IndexOfValue(new Tuple<int, int>(cinew, cjnew));
                                openList.RemoveAt(index);
                            }
                            int l = 0;
                            while (openList.ContainsKey(new Tuple<int, int>(g[cinew, cjnew] + h[cinew, cjnew], l))) l++;
                            openList.Add(new Tuple<int, int>(g[cinew, cjnew] + h[cinew, cjnew], l), new Tuple<int, int>(cinew, cjnew));
                            searched[cinew, cjnew] = 1;
                        }
                    }
                }
            }

            return (g[g.GetLength(0) - 1, g.GetLength(1) - 1]).ToString();
        }

        private static int[,] ReadInput(string filename)
        {
            int[,] output = new int[80, 80];
            string[] lines = File.ReadAllLines(filename).Distinct().ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');
                for (int j = 0; j < split.Length; j++)
                {
                    output[j, i] = Convert.ToInt32(split[j]);
                }
            }

            return output;
        }

        private static int GetMinValue(int[,] grid)
        {
            int result = Int32.MaxValue;
            for (int y = 0; y < grid.GetLength(1); y++)
                for (int x = 0; x < grid.GetLength(0); x++)
                    if (grid[x, y] < result)
                        result = grid[x, y];
            return result;
        }

        private static void PrintArray(int[,] array)
        {
            for (int y = 0; y < array.GetLength(0); y++)
            {
                Debug.WriteLine("");
                for (int x = 0; x < array.GetLength(1); x++)
                {
                    string spaces = "";
                    for (int i = 0; i < 7 - array[x, y].ToString().Length; i++)
                        spaces += " ";
                    Debug.Write(spaces + array[x, y]);
                }
            }
        }
    }
}
