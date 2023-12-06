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
        static void day6p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long time = 0;
            long dist = 0;
            long result = 0;
            int lineno = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    int j = i;
                    if (!char.IsDigit(line[i])) continue;
                    if (lineno == 0)
                    {
                        time *= 10;
                        time += line[i] - '0';
                    }
                    else
                    {
                        dist *= 10;
                        dist += line[i] - '0';
                    }
                }
                lineno++;
            }

            for (long j = 0; j < time; j++)
            {
                long dist_now = j * (time - j);
                if (dist_now > dist) result++;
            }

            Console.WriteLine(result);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
