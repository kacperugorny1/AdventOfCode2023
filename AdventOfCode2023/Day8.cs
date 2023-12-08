using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day8
    {
        static void day8p1(string[] args) // slow 
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long result = 0;
            List<(string place, string left, string right)> paths = new();
            int location = 0;
            string nav = "";
            stopwatch.Start();
            foreach (string line in input)
            {
                if (line.Length == 0) continue;
                if (line.Length != 16)
                {
                    nav = line;
                    continue;
                }
                if (line.Substring(0, 3) == "AAA") location = paths.Count();
                paths.Add((line.Substring(0, 3), line.Substring(7, 3), line.Substring(12, 3)));
            }
            while (true)
            {
                result++;
                char n = nav[0];
                nav = nav.Substring(1) + n;
                location = paths.IndexOf(paths.Find(u =>
                {
                    if (n == 'R') return u.place == paths[location].right;
                    else return u.place == paths[location].left;
                }));
                if (paths[location].place == "ZZZ") break;
            }
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
