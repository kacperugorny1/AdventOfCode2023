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
            input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<int> times = new List<int>();
            List<int> dist = new();
            int result = 1;
            int lineno = 0;
            stopwatch.Start();
            foreach (string line in input)
            {      
                for(int i = 0; i < line.Length; i++)
                {
                    int j = i;
                    if (!char.IsDigit(line[i]))
                        continue;
                    while (j < line.Length - 1 && char.IsDigit(line[j + 1])) j++;
                    if(lineno == 0)
                        times.Add(int.Parse(line.Substring(i, j - i + 1)));
                    else
                        dist.Add(int.Parse(line.Substring(i, j - i + 1)));
                    i = j + 1;

                }
                lineno++;
            }
            for(int i = 0; i < times.Count; i++)
            {
                int sum = 0;
                for(int j = 0; j < times[i]; j++)
                {
                    int dist_now = j * (times[i] - j);
                    if (dist_now > dist[i]) sum++;
                }
                result*=sum;
            }
            Console.WriteLine(result);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}