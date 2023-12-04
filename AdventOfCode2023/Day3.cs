using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day3
    {
        static bool isNumber(char c)
        {
            return c >= '0' && c <= '9';
        }
        static void day3p1(string[] args)
        {
            List<List<char>> map = new();
            int sum = 0;
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");

            foreach (string line in input)
            {
                map.Add(line.ToList());
            }
            int start = 0;
            int end = 0;
            for (int i = 0; i < map.Count; i++)
                for (int j = 0; j < map[i].Count; j++)
                {
                    bool added = false;
                    if (map[i][j] - '0' < 0 || map[i][j] - '0' > 9)
                        continue;
                    start = j == 0 ? 0 : j - 1;
                    while (map[i].Count > j + 1 && map[i][j + 1] - '0' >= 0 && map[i][j + 1] - '0' <= 9) j++;
                    end = (j + 1 < map[i].Count) ? j + 1 : j;
                    j++;
                    if (map[i][start] != '.' && (map[i][start] < '0' || map[i][start] > '9'))
                    {
                        for (start = start; start <= (isNumber(map[i][end]) ? end : --end); start++)
                        {
                            if (!isNumber(map[i][start])) continue;
                            sum += (map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start));
                            Console.WriteLine((map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start)));
                        }
                        continue;
                    }
                    if (map[i][end] != '.' && (map[i][end] < '0' || map[i][end] > '9'))
                    {
                        for (start = start; start <= (isNumber(map[i][end]) ? end : --end); start++)
                        {
                            if (!isNumber(map[i][start])) continue;
                            sum += (map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start));
                            Console.WriteLine((map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start)));
                        }
                        continue;
                    }
                    for (int t = start; t <= end && i != 0; t++)
                    {
                        if (map[i - 1][t] == '.') continue;
                        if (map[i - 1][t] >= '0' && map[i - 1][t] <= '9') continue;
                        for (start = start; start <= (isNumber(map[i][end]) ? end : --end); start++)
                        {
                            if (!isNumber(map[i][start])) continue;
                            sum += (map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start));
                            Console.WriteLine((map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start)));
                        }
                        added = true;
                        break;
                    }
                    if (added) continue;
                    for (int t = start; t <= end && i != map.Count - 1; t++)
                    {
                        if (map[i + 1][t] == '.') continue;
                        if (map[i + 1][t] >= '0' && map[i + 1][t] <= '9') continue;
                        for (start = start; start <= (isNumber(map[i][end]) ? end : --end); start++)
                        {
                            if (!isNumber(map[i][start])) continue;
                            sum += (map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start));
                            Console.WriteLine((map[i][start] - '0') * Convert.ToInt32(Math.Pow(10, end - start)));
                        }
                        added = true;
                        break;
                    }
                    if (added) continue;

                }
            Console.WriteLine(sum);
        }
        static void day3p2(string[] args)
        {
            List<string> map = new();
            ulong sum = 0;
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");

            foreach (string line in input)
            {
                map.Add(line);
            }
            int start = 0;
            int end = 0;
            for (int i = 0; i < map.Count; i++)
                for (int j = 0; j < map[i].Length; j++)
                {
                    ulong num1 = 0;
                    ulong num2 = 0;
                    if (map[i][j] != '*')
                        continue;
                    for (int x = i - 1; x <= i + 1; ++x)
                    {
                        for (int y = j - 1; y <= j + 1; ++y)
                        {
                            if (!char.IsNumber(map[x][y])) continue;
                            start = y;
                            end = y;
                            while (start != 0 && char.IsNumber(map[x][start - 1])) start--;
                            while (end != map[x].Length - 1 && char.IsNumber(map[x][end + 1])) end++;
                            Console.WriteLine(map[x].Substring(start, end - start + 1));
                            if (num1 == 0)
                                num1 = ulong.Parse(map[x].Substring(start, end - start + 1));
                            else
                                num2 = ulong.Parse(map[x].Substring(start, end - start + 1));
                            y = end;
                        }
                    }
                    if (num1 != 0 && num2 != 0)
                        sum += num1 * num2;

                }
            Console.WriteLine(sum);
        }
    }
}
