using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day1
    {
        static void day1p1(string[] args)
        {
            Dictionary<string, int> map = new Dictionary<string, int>()
            {
                {"one", 1 },
                {"two", 2 },
                {"three", 3 },
                {"four", 4 },
                {"five", 5 },
                {"six", 6 },
                {"seven", 7 },
                {"eight", 8 },
                {"nine", 9 },
                {"zero", 0 }
            };
            int first_digit = 0;
            int last_digit = 0;
            int digits = 0;
            long sum = 0;
            string? line = "";
            string num = "";
            while (true)
            {
                line = Console.ReadLine();
                if (line == "" || line == null || line == "\n")
                    break;

                foreach (char c in line)
                {
                    num += c;
                    if (c - 48 >= 0 && c - '0' <= 9)
                    {
                        digits++;
                        if (first_digit == 0)
                            first_digit = c - '0';
                        else
                            last_digit = c - '0';
                    }
                    if (num.Length >= 3)
                    {
                        if (map.ContainsKey(num.Substring(num.Length - 3)))
                        {
                            if (first_digit == 0)
                                first_digit = map[num.Substring(num.Length - 3)];
                            else
                                last_digit = map[num.Substring(num.Length - 3)];
                            digits++;
                        }

                    }
                    if (num.Length >= 4)
                    {
                        if (map.ContainsKey(num.Substring(num.Length - 4)))
                        {
                            if (first_digit == 0)
                                first_digit = map[num.Substring(num.Length - 4)];
                            else
                                last_digit = map[num.Substring(num.Length - 4)];
                            digits++;

                        }
                    }
                    if (num.Length >= 5)
                    {
                        if (map.ContainsKey(num.Substring(num.Length - 5)))
                        {
                            if (first_digit == 0)
                                first_digit = map[num.Substring(num.Length - 5)];
                            else
                                last_digit = map[num.Substring(num.Length - 5)];
                            digits++;
                        }
                    }

                }
                if (digits == 1)
                    last_digit = first_digit;
                sum += first_digit * 10 + last_digit;
                Console.WriteLine(first_digit * 10 + last_digit);
                first_digit = 0;
                last_digit = 0;
                digits = 0;
            }
            Console.WriteLine(sum);
        }
        static void day2p2(string[] args)
        {
            int first_digit = 0;
            int last_digit = 0;
            int digits = 0;
            long sum = 0;
            string? line = "";
            while (true)
            {
                line = Console.ReadLine();
                if (line == "" || line == null || line == "\n")
                    break;

                foreach (char c in line)
                {
                    if (c - 48 >= 0 && c - '0' <= 9)
                    {
                        digits++;
                        if (first_digit == 0)
                            first_digit = c - '0';
                        else
                            last_digit = c - '0';
                    }

                }
                if (digits == 1)
                    last_digit = first_digit;
                sum += first_digit * 10 + last_digit;
                Console.WriteLine(first_digit * 10 + last_digit);
                first_digit = 0;
                last_digit = 0;
                digits = 0;
            }
            Console.WriteLine(sum);
        }

    }
}
