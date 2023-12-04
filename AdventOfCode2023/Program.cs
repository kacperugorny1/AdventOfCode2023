using System;

namespace AdventOfCode2023
{ 
    internal class Program
    {
        // Helpful stuff : Convert.ToInt(), Int32.Parse/TryParse, var val = x switch { 'a' => 2, blbl}, char - '0' = numvalue
        // Contains, substring, split , last, first

        static void Main(string[] args)
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
            for(int i = 0; i < map.Count; i++)
                for(int j = 0; j < map[i].Length; j++)
                {
                    ulong num1 = 0;
                    ulong num2 = 0;
                    if (map[i][j] != '*')
                        continue;
                    for(int x = i - 1; x <= i + 1; ++x){
                        for(int y = j - 1; y <= j + 1; ++y) {
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