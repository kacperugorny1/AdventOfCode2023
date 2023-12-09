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
            var input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long result = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                List<List<int>> hist = new();
                hist.Add(line.Split(" ").ToList().ConvertAll(x => Int32.Parse(x)));
                hist.Last().ForEach(u => Console.Write(u + " "));
                Console.WriteLine();
                while (true)
                {
                    hist.Add(new());
                    for (int i = 0; i < hist[^2].Count() - 1;++i)
                    {
                        hist.Last().Add(hist[^2][i + 1] - hist[^2][i]);
                        Console.Write(hist.Last().Last() + " ");
                    }
                    Console.WriteLine();
                    if (hist.Last().All(u => u == 0)) break;
                }
                hist.Last().Add(0);
                for(int i = hist.Count() - 2; i >= 0; --i)
                {
                    hist[i].Add(hist[i + 1].Last() + hist[i].Last());
                }
                result += hist[0].Last();

            }


            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}