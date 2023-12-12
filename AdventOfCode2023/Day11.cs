using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day11
    {
        static void day11p1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            long result = 0;

            List<(int, int)> galaxies = new List<(int, int)>();

            int galaxy_x = 0;
            int galaxy_y = 0;

            stopwatch.Start();

            foreach (string line in input)
            {
                string temp = line;
                int tempp = 0;
                galaxy_y = line.Count();
                List<char> galx = line.ToList().FindAll(line => line != '.');
                if (galx.Count == 0) galaxy_x++;
                foreach (char c in galx)
                {
                    galaxies.Add((galaxy_x, tempp + temp.IndexOf(c)));
                    tempp += temp.IndexOf(c) + 1;
                    temp = temp.Substring(temp.IndexOf(c) + 1);

                }
                galaxy_x++;
            }
            for (int i = 0; i < galaxy_y; i++)
            {
                if (galaxies.Exists(u => u.Item2 == i)) continue;
                galaxy_y++;
                for (int j = 0; j < galaxies.Count; j++)
                {
                    if (galaxies[j].Item2 > i) galaxies[j] = (galaxies[j].Item1, galaxies[j].Item2 + 1);
                }
                i++;
            }

            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    result += ShortestPath(galaxies[i], galaxies[j]);
                }
            }


            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");

        }
        static int ShortestPath((int, int) g1, (int, int) g2)
        {
            return Math.Abs(g1.Item1 - g2.Item1) + Math.Abs(g1.Item2 - g2.Item2);
        }

        static void day11p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            ulong result = 0;

            List<(ulong, ulong)> galaxies = new();

            ulong galaxy_x = 0;
            ulong galaxy_y = 0;

            stopwatch.Start();

            foreach (string line in input)
            {
                string temp = line;
                ulong tempp = 0;
                galaxy_y = Convert.ToUInt64(line.Count());
                List<char> galx = line.ToList().FindAll(line => line != '.');
                if (galx.Count == 0) galaxy_x += 999999;
                foreach (char c in galx)
                {
                    galaxies.Add((galaxy_x, tempp + Convert.ToUInt64(temp.IndexOf(c))));
                    tempp += Convert.ToUInt64(temp.IndexOf(c)) + 1;
                    temp = temp.Substring(temp.IndexOf(c) + 1);

                }
                galaxy_x++;
            }
            for (ulong i = 0; i < galaxy_y; i++)
            {
                if (galaxies.Exists(u => u.Item2 == i)) continue;
                galaxy_y += 999999;
                for (int j = 0; j < galaxies.Count; j++)
                {
                    if (galaxies[j].Item2 > i) galaxies[j] = (galaxies[j].Item1, galaxies[j].Item2 + 999999);
                }
                i += 999999;
            }

            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    result += ShortestPath(galaxies[i], galaxies[j]);
                }
            }


            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");

        }
        static ulong ShortestPath((ulong, ulong) g1, (ulong, ulong) g2)
        {
            ulong a1 = g1.Item1 >= g2.Item1 ? g1.Item1 - g2.Item1 : g2.Item1 - g1.Item1;
            ulong a2 = g1.Item2 >= g2.Item2 ? g1.Item2 - g2.Item2 : g2.Item2 - g1.Item2;
            return a1 + a2;
        }
    }
}
