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
      
            }


            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}