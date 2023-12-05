using System;
using System.Diagnostics;
namespace AdventOfCode2023
{
    //https://topaz.github.io/paste/#XQAAAQCvCQAAAAAAAAA6nMlWi076alCx9N1TsRv/nE/5+HEJqrfgdiKbnpiCU30HOqctQj7Jp3T1Xt0zuyBzJjB+ise8j8R3bmPwIDTyo8c++CYGfLfshnb0jcBhyL/6GbQ1a8Qtge1cQaPvZR3+xe3RZDpCKCOWiFPJPImoJaIv3pnwNtjg2obpk/dPK02M9A2hxkZd/N5weImKnXk5rvmjdEgOMfaRpJas/b+kM41Xpp7e/43hP/fTVinr/M3K2Kq8Gz0k43OrCba4eaSxjWl4lqI9Z58GkRGp+zttskYw5R707lpxp1bpHIKRYc5WoPlZp6pzW5zfyjTuDZ5oDMyvcve1HW2mTqtjVbh49A0soaVCTXNB343GcmTi4R81Zs09idT7fxw5EpuVztX7rgEUJK8z172X4cMvaNfoDmoADuXK0qHUFpxP8lmZjL/JRY+zyPto6KsCnOvRvuC8N7C4YjJDW3EfWy44sIEcbIuD1C1tDGXCHL+Z6xIoedxLAZ9BaEYTUHhgyoQBvfJtNt7N2VbhmIpFoMxe3Ir+YHPwWaLT/YpJHsJz2/B3/+OcwJ9eUF/8qXWIjRM8abM3HjM5Rx/vDalZoJQ0zRBu4vRYwhWIwUIH5mgRHVrVsMWambDbsmKfhFeJ+TUsMqY6AI2p4l6OsRG+4om2ccJ7V4SJXykFXOOfB4iazn9U02VWUiV1Ac+mnovRunLCMuN6KHITD0mH18+x7Le5r9Wv7kBO+KDGMIxowVAinxfdfeNgamFzGOFR/BEd89OmXr6ftGokpHfg7YiCaC/ISuidD+eBrdRs+db4xu2d/9sIlWR1jDcygVHCauYDFKo8lGgbYjOTVqaFG7XSylOc3UaZi6DUWB4OcUyEC59Eraugm5tYK2ih2FqaS9s38BI7vbQmJkWJ6qOPtTVO0nSK+sOTxAiVJBsGhqewUDlcgKtf2exY8c82uwaQNYokFQQsKSXuD+AYZFYw3ckTbonYYHz5OzHyWyIICFHNpT+NN65GVryDnvJDGrYkSrA1rlswD030o2k3KBGBv/shGUmO5QI45EXeRWZDJIdb8hmsk7u+SAQgcGr5+HzRivsOD/0DjSX4xaP/yXMGgA==
    internal class Program
    {
        // Helpful stuff : Convert.ToInt(), Int32.Parse/TryParse, var val = x switch { 'a' => 2, blbl}, char - '0' = numvalue
        // Contains, substring, split , last, first

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            int i = 0;
            List<(long,long)> seedsRanges = new();
            List<(long,long,long)> mapping = new();
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
                            return !(seedsRanges[j].Item1 >= u.Item2+u.Item1 || seedsRanges[j].Item2 < u.Item1);
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
                            else seedsRanges[j] = (map.Item3 + seedsRanges[j].Item1 - map.Item1,map.Item3 + seedsRanges[j].Item2 - map.Item1 );
                        }
                    }
                    i++;
                    mapping = new();
                    continue;
                }
                if (i == 0)
                {
                    parts = line.Split(":").Last().Substring(1).Split(" ");
                    for (int k = 0; k < parts.Length; k+=2)
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
            foreach(var x in seedsRanges)
            {
                min = x.Item1 < min ? x.Item1 : min;
            }
            stopwatch.Stop();
            Console.WriteLine(min);
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}