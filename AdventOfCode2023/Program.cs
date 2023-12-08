using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace AdventOfCode2023
{
    internal class Program
    {
        // Helpful stuff : Convert.ToInt(), Int32.Parse/TryParse, var val = x switch { 'a' => 2, blbl}, char - '0' = numvalue
        // Contains, substring, split , last, first

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
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
                    reps.Add((0,0));
                }
                paths.Add((line.Substring(0, 3), line.Substring(7, 3), line.Substring(12, 3), paths.Count));
            }
            while (true)
            {
                result++;
                char n = nav[0];
                nav = nav.Substring(1) + n;
                for(int i = 0; i < locations.Count(); ++i)
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
                            historyZ[i]=(result, locations[i]);
                        }
                        else
                        {
                            if (reps[i].len == 0)
                            {

                                Console.WriteLine(result + " " + i);
                                Console.WriteLine(locations[i]);
                                if ( historyZ[i].location == locations[i])
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
                Console.WriteLine(len[i]);
                Console.WriteLine(reps[i].rep);
            }
            while (true)
            {
                for(int i = 0; i < reps.Count; i++)
                {
                    if (len[i] < len.Max())
                     len[i] += reps[i].rep;
                }
                if (len.All(x => x == len[0])) break;
            }
            result = len[0];
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}