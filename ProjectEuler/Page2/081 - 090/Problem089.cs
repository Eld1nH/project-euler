using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjectEuler.Page2._081___090
{
    // Roman numerals
    public class Problem089
    {

        private static string filename = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/Assets/roman.txt";

        public static string Algorithm()
        {
            string roman = File.ReadAllText(filename);
            string pattern = "DCCCC|LXXXX|VIIII|CCCC|XXXX|IIII";
            string replace = "AA";
            long result = roman.Length - Regex.Replace(roman, pattern, replace).Length;
            return result.ToString();
        }
    }
}
