using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjectEuler.Page3._101___110
{

    // Triangle containment
    public class Problem102
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/triangles.txt";

        public static string Algorithm()
        {
            short result = 0;

            List<Tuple<int, int, int, int, int, int>> triangles = ReadInput(filename);

            for (int i = triangles.Count - 1; i >= 0; i--)
            {
                Tuple<int, int, int, int, int, int> coords = triangles[triangles.Count - 1 - i];
                if (OriginInTriangle(coords.Item1, coords.Item2, coords.Item3, coords.Item4, coords.Item5, coords.Item6))
                    result++;
            }

            return result.ToString();
        }

        public static bool OriginInTriangle(int ax, int ay, int bx, int by, int cx, int cy)
        {
            int s = ay * cx - ax * cy;
            int t = ax * by - ay * bx;

            if ((s < 0) != (t < 0))
                return false;

            int A = -by * cx + ay * (cx - bx) + ax * (by - cy) + bx * cy;
            if (A < 0.0)
            {
                s = -s;
                t = -t;
                A = -A;
            }

            return s > 0 && t > 0 && (s + t) < A;
        }

        private static List<Tuple<int, int, int, int, int, int>> ReadInput(string filename)
        {
            string[] lines = File.ReadAllLines(filename).ToArray();
            List<Tuple<int, int, int, int, int, int>> result = new List<Tuple<int, int, int, int, int, int>>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] split = lines[i].Split(',');
                result.Add(new Tuple<int, int, int, int, int, int>(Convert.ToInt32(split[0]), Convert.ToInt32(split[1]), Convert.ToInt32(split[2]), 
                                                                   Convert.ToInt32(split[3]), Convert.ToInt32(split[4]), Convert.ToInt32(split[5])));
            }
            return result;
        }
    }
}
