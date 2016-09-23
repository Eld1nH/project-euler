using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {

        private const long ToNano = 1000000000;

        private const long Runs = long.MaxValue;
        private const long Timeout = 30; //seconds

        public static void Main(string[] args)
        {
            var functions = new List<Func<string>>
            {
                Page1._041___050.Problem043.Algorithm
            };

            for (var i = functions.Count - 1; i >= 0; i--)
            {
                Execute(functions[functions.Count - 1 - i]);
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        public static void Execute(Func<string> function)
        {
            if (function.Method.DeclaringType != null)
            {
                var split = function.Method.DeclaringType.ToString().Split('.');
                Console.WriteLine(split[split.Length - 1] + "." + function.Method.Name);
            }

            var first = new Stopwatch();
            first.Start();
            Console.WriteLine("Result: " + function());
            first.Stop();
            Console.WriteLine("First Run: {0} ns", (ToNano * first.ElapsedTicks / Stopwatch.Frequency));

            long runsDone = Runs;
            long totalElapsed = 0;
            for (long i = 0; i < Runs; i++)
            {
                var clock = new Stopwatch();
                clock.Start();
                function();
                clock.Stop();
                totalElapsed += clock.ElapsedTicks;
                
                if ((totalElapsed / Stopwatch.Frequency) < Timeout) 
                    continue;

                runsDone = i + 1;
                break;
            }

            double timePast = ToNano * totalElapsed / (double)Stopwatch.Frequency;
            Console.WriteLine("Total: {0} ns\r\nRuns: {1}", timePast, runsDone);
            Console.WriteLine("Average: {0} ns", (Math.Ceiling(timePast / runsDone)));
        }
    }
}