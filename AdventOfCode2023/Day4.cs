using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day4
    {
        static void day4p1(string[] args)
        {
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            int sum = 0;
            foreach (string line in input)
            {
                int points = 0;
                List<string> temp;
                List<string> winning;
                List<string> yours;
                temp = line.Split(":").Last().Split("|").ToList();
                winning = temp.First().Split(" ").ToList();
                yours = temp.Last().Split(" ").ToList();
                foreach (string el in yours)
                {
                    if (el == "") continue;
                    if (winning.Contains(el)) points++;
                }
                if (points > 0)
                    points = Convert.ToInt32(Math.Pow(2, points - 1));
                sum += points;
            }
            Console.WriteLine(sum);
        }
        static void day4p2(string[] args)
        {
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<int> instances = new() { 0 };
            for (int i = 0; i < input.Count(); ++i)
                instances.Add(1);
            int instance = 0;
            long sum = 0;
            foreach (string line in input)
            {
                ++instance;
                int pairs = 0;
                List<string> temp;
                List<string> winning;
                List<string> yours;
                temp = line.Split(":").Last().Split("|").ToList();
                winning = temp.First().Split(" ").ToList();
                yours = temp.Last().Split(" ").ToList();
                foreach (string el in yours)
                {
                    if (el == "") continue;
                    if (winning.Contains(el)) pairs++;
                }
                for (int i = instance + 1; i <= instance + pairs; ++i) instances[i] += instances[instance];

            }
            foreach (int i in instances) sum += i;
            Console.WriteLine(sum);
        }
    }
}
