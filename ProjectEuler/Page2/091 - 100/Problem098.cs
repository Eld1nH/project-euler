using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page2._091___100
{
    // Anagramic squares
    public class Problem098
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/words.txt";
        private static int[] squares;

        public static string Algorithm()
        {
            long result = 0;

            List<int> squareList = new List<int>();
            for (int i = 2; i < 31700; i++)
            {
                squareList.Add(i * i);
            }
            squares = squareList.ToArray();

            string[] input = File.ReadAllText(filename).Replace("\"", "").Split(',');
            char[][] sort = new char[input.Length][];

            for (int i = 0; i < input.Length; i++)
            {
                sort[i] = input[i].ToCharArray();
                Array.Sort(sort[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i + 1; j < input.Length; j++)
                {
                    if (sort[i].Length != sort[j].Length) continue;
                    bool equal = true;
                    for (int k = 0; k < sort[i].Length; k++)
                    {
                        equal = sort[i][k] == sort[j][k];
                        if (!equal) break;
                    }

                    if (equal)
                    {
                        int pairvalue = AnagramSquare(input[i], input[j]);

                        if (pairvalue > result)
                            result = pairvalue;
                    }
                }
            }

            return result.ToString();
        }

        private static int AnagramSquare(string a, string b)
        {
            int max = 0;
            char[] w1array = a.ToCharArray();
            char[] w2array = b.ToCharArray();

            for (int i = 0; i < squares.Length; i++)
            {
                int squareLength = squares[i].ToString().Length;

                if (squareLength < a.Length) continue;
                if (squareLength > a.Length) break;

                bool match = true;
                int square = squares[i];
                Dictionary<char, int> map = new Dictionary<char, int>();

                for (int j = w1array.Length - 1; j >= 0; j--)
                {
                    int digit = square % 10;
                    square /= 10;

                    if (map.ContainsKey(w1array[j]))
                    {
                        if (map[w1array[j]] == digit)
                        {
                            continue;
                        }
                        else
                        {
                            match = false;
                            break;
                        }
                    }

                    if (map.ContainsValue(digit))
                    {
                        match = false;
                        break;
                    }

                    map.Add(w1array[j], digit);
                }

                if (!match) continue;

                int w2value = 0;
                if (map[w2array[0]] == 0)
                {
                    match = false;
                }
                else
                {
                    for (int j = 0; j < w2array.Length; j++)
                    {
                        w2value = w2value * 10 + map[w2array[j]];
                    }
                }

                if (!match) continue;
                if (Array.BinarySearch(squares, w2value) > -1)
                {
                    int maxPair = Math.Max(w2value, squares[i]);
                    max = Math.Max(max, maxPair);
                }
            }

            return max;
        }
    }
}
