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
            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
        static void day2p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long result = 0;
            List<(string place, string left, string right, int id)> paths = new();
            List<int> locations = new();
            List<(long len, long rep)> reps = new();
            List<(long result, int location)> historyZ = new();
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
                if (line[2] == 'A')
                {
                    locations.Add(paths.Count());
                    historyZ.Add(new());
                    reps.Add((0, 0));
                }
                paths.Add((line.Substring(0, 3), line.Substring(7, 3), line.Substring(12, 3), paths.Count));
            }
            while (true)
            {
                result++;
                char n = nav[0];
                nav = nav.Substring(1) + n;
                for (int i = 0; i < locations.Count(); ++i)
                {
                    locations[i] = paths.Find(u =>
                    {
                        if (n == 'R') return u.place == paths[locations[i]].right;
                        else return u.place == paths[locations[i]].left;
                    }).id;
                    if (paths[locations[i]].place[2] == 'Z')
                    {
                        if (historyZ[i].result == 0)
                        {
                            historyZ[i] = (result, locations[i]);
                        }
                        else
                        {
                            if (reps[i].len == 0)
                            {

                                Console.WriteLine(result + " " + i);
                                Console.WriteLine(locations[i]);
                                if (historyZ[i].location == locations[i])
                                {
                                    reps[i] = (historyZ[i].result, result - historyZ[i].result);
                                    //Console.WriteLine(result);
                                }
                            }
                        }

                    }
                }
                if (!reps.Exists(u => u.len == 0)) break;
            }
            Console.WriteLine("hello");
            List<long> len = new(new long[reps.Count]);
            for (int i = 0; i < reps.Count; i++)
            {
                len[i] += reps[i].len;
                Console.WriteLine(reps[i].rep);
            }
            stopwatch.Stop();
            Console.WriteLine($"Result = for the result paste it to LCM calculator");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
