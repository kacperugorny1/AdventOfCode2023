using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day6
    {
        static void day6p1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<int> times = new List<int>();
            List<int> dist = new();
            int result = 1;
            int lineno = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    int j = i;
                    if (!char.IsDigit(line[i]))
                        continue;
                    while (j < line.Length - 1 && char.IsDigit(line[j + 1])) j++;
                    if (lineno == 0)
                        times.Add(int.Parse(line.Substring(i, j - i + 1)));
                    else
                        dist.Add(int.Parse(line.Substring(i, j - i + 1)));
                    i = j + 1;

                }
                lineno++;
            }
            for (int i = 0; i < times.Count; i++)
            {
                int sum = 0;
                for (int j = 0; j < times[i]; j++)
                {
                    int dist_now = j * (times[i] - j);
                    if (dist_now > dist[i]) sum++;
                }
                result *= sum;
            }
            Console.WriteLine(result);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
