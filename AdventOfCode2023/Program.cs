﻿using System;

namespace AdventOfCode2023
{ 
    internal class Program
    {

        static void Main(string[] args)
        {
            const int red = 12;
            const int blue = 14;
            const int green = 13;
            List<int> Values = new();
            ulong sum = 0;
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");

            foreach (string line in input)
            {
                int[] values = new int[3] { 0, 0, 0 };
                var draws = line.Split(":").Last().Split(";");
                foreach(string draw in draws)
                {
                    var color = draw.Split(",");
                    for (int j = 0; j < color.Length; j++)
                    {
                        int i = 0;
                        if (color[j].Length == 0) continue;
                        while (color[j][i + 1] <= 57) i++;
                        int limit = color[j][i + 1] switch
                        {
                            'r' => values[0],
                            'b' => values[1],
                            'g' => values[2],
                            _ => 0
                        };
                        int vall = Int32.Parse(color[j].Substring(1, i - 1));
                        if (vall > limit)  {
                            if (color[j][i + 1] == 'r') values[0] = vall;
                            else if (color[j][i + 1] == 'b') values[1] = vall;
                            else values[2] = vall;
                        }


                    }
                }
                Values.Add(values[0] * values[1] * values[2]);
            }
            foreach (uint val in Values)
                sum += val;
            Console.WriteLine(sum);
        }




        static void ReadInputCin()
        {

            string? line = "";
            while (true)
            {
                line = Console.ReadLine();
                if (line == "" || line == null || line == "\n")
                    break;
                //CODE
            }
        }

        static void ReadInputFile()
        {

            var input = File.ReadLines("FILENAME");
            
            foreach(string line in input)
            {
               
            }
        }
    }
}