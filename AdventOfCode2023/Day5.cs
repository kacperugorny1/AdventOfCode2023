using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day5
    {
        static void day5p1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            int i = 0;
            List<(long, List<long>)> seeds = new();
            stopwatch.Start();
            foreach (string line in input)
            {
                if (line == "")
                {
                    foreach (var x in seeds)
                    {
                        if (x.Item2.Count < i)
                            x.Item2.Add(i == 1 ? x.Item1 : x.Item2.Last());
                    }
                    i++;
                    continue;
                }
                string[] parts;
                if (seeds.Count == 0)
                {
                    parts = line.Split(":").Last().Substring(1).Split(" ");
                    /*for (int k = 0; k < parts.Length; k+=2)
                    {
                        for(long j = 0; j < long.Parse(parts[k+1]); j++)
                        {
                            seeds.Add((long.Parse(parts[i]) + j, new List<long>()));
                        }
                    }*/
                    Console.WriteLine(seeds.Count);
                    foreach (string part in parts)
                        seeds.Add((long.Parse(part), new List<long>()));
                    continue;
                }
                if (char.IsLetter(line[0])) continue;

                parts = line.Split(" ");
                long destination = long.Parse(parts[0]);
                long source = long.Parse(parts[1]);
                long len = long.Parse(parts[2]);
                seeds.ForEach(u =>
                {
                    if (i == 1)
                    {
                        if (u.Item1 >= source && u.Item1 < source + len)
                            u.Item2.Add(u.Item1 - source + destination);
                    }
                    else
                    {
                        if (u.Item2[i - 2] >= source && u.Item2[i - 2] < source + len)
                            u.Item2.Add(u.Item2[i - 2] - source + destination);
                    }
                });



            }
            long min = Int32.MaxValue;
            foreach (var x in seeds)
            {
                if (min > x.Item2.Last())
                    min = x.Item2.Last();
            }
            stopwatch.Stop();
            Console.WriteLine(min);
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }

        static void day5p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();// need empty line on end of file
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            int i = 0;
            List<(long, long)> seedsRanges = new();
            List<(long, long, long)> mapping = new();
            string[] parts;
            stopwatch.Start();
            foreach (string line in input)
            {
                if (line == "")
                {

                    for (int j = 0; j < seedsRanges.Count; ++j)
                    {
                        var map = mapping.Find(u =>
                        {
                            return !(seedsRanges[j].Item1 >= u.Item2 + u.Item1 || seedsRanges[j].Item2 < u.Item1);
                        });
                        if (map.Item1 == 0 && map.Item2 == 0 && map.Item3 == 0)
                            continue;
                        if (seedsRanges[j].Item1 < map.Item1)
                        {
                            seedsRanges.Add((seedsRanges[j].Item1, map.Item1 - 1));
                            if (seedsRanges[j].Item2 >= map.Item2 + map.Item1)
                            {
                                seedsRanges.Add((map.Item2 + map.Item1, seedsRanges[j].Item2));
                                seedsRanges[j] = (map.Item3, map.Item2 + map.Item3 - 1);
                            }
                            else seedsRanges[j] = (map.Item3, map.Item3 + seedsRanges[j].Item2 - map.Item1);
                        }
                        else
                        {
                            if (seedsRanges[j].Item2 >= map.Item2 + map.Item1)
                            {
                                seedsRanges.Add((map.Item2 + map.Item1, seedsRanges[j].Item2));
                                seedsRanges[j] = (map.Item3 + seedsRanges[j].Item1 - map.Item1, map.Item2 + map.Item3 - 1);
                            }
                            else seedsRanges[j] = (map.Item3 + seedsRanges[j].Item1 - map.Item1, map.Item3 + seedsRanges[j].Item2 - map.Item1);
                        }
                    }
                    i++;
                    mapping = new();
                    continue;
                }
                if (i == 0)
                {
                    parts = line.Split(":").Last().Substring(1).Split(" ");
                    for (int k = 0; k < parts.Length; k += 2)
                    {
                        seedsRanges.Add((long.Parse(parts[k]), long.Parse(parts[k + 1]) + long.Parse(parts[k]) - 1));
                    }
                    //foreach (string part in parts)
                    //    seeds.Add((long.Parse(part), new List<long>()));
                    continue;
                }
                if (char.IsLetter(line[0])) continue;

                parts = line.Split(" ");
                long destination = long.Parse(parts[0]);
                long source = long.Parse(parts[1]);
                long len = long.Parse(parts[2]);
                mapping.Add((source, len, destination));


            }
            long min = Int32.MaxValue;
            foreach (var x in seedsRanges)
            {
                min = x.Item1 < min ? x.Item1 : min;
            }
            stopwatch.Stop();
            Console.WriteLine(min);
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
}
