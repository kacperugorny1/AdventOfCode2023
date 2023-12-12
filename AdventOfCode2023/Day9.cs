using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day9
    {
        static void day9p1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long result = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                List<List<int>> hist = new();
                hist.Add(line.Split(" ").ToList().ConvertAll(x => Int32.Parse(x)));
                while (true)
                {
                    hist.Add(new());
                    for (int i = 0; i < hist[^2].Count() - 1; ++i)
                    {
                        hist.Last().Add(hist[^2][i + 1] - hist[^2][i]);
                    }
                    if (hist.Last().All(u => u == 0)) break;
                }
                hist.Last().Add(0);
                for (int i = hist.Count() - 2; i >= 0; --i)
                {
                    hist[i].Add(hist[i + 1].Last() + hist[i].Last());
                }
                result += hist[0].Last();

            }


            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
        static void day9p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long result = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                List<List<int>> hist = new();
                hist.Add(line.Split(" ").ToList().ConvertAll(x => Int32.Parse(x)));

                while (true)
                {
                    hist.Add(new());
                    for (int i = 0; i < hist[^2].Count() - 1; ++i)
                    {
                        hist.Last().Add(hist[^2][i + 1] - hist[^2][i]);
                    }
                    if (hist.Last().All(u => u == 0)) break;
                }
                hist.Last().Insert(0, 0);
                for (int i = hist.Count() - 2; i >= 0; --i)
                {
                    hist[i].Insert(0, hist[i].First() - hist[i + 1].First());
                }
                result += hist[0].First();

            }

            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
