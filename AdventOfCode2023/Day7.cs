using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day7
    {
        static void day7p1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<(List<int> cards, List<int> hand, int bet)> crd = new();
            long result = 0;
            int leng = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                crd.Add((new(new int[14]), new(), int.Parse(line.Substring(6))));
                List<int> h = new();
                for (int i = 0; i < 5; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        int num = line[i] - '0' - 2;
                        crd.Last().cards[num]++;
                        crd.Last().hand.Add(num);
                    }
                    else
                    {
                        int num = line[i] switch
                        {
                            'T' => 10,
                            'J' => 11,
                            'Q' => 12,
                            'K' => 13,
                            'A' => 14
                        } - 2;
                        crd.Last().cards[num]++;
                        crd.Last().hand.Add(num);
                    }

                }
            }
            leng = crd.Count();
            var fives = crd.FindAll(card => card.cards.Contains(5));
            fives.Sort((i1, i2) =>
            {
                return -i1.hand[0].CompareTo(i2.hand[0]);
            });
            foreach (var x in fives) result += x.bet * leng--;
            var fours = crd.FindAll(card => card.cards.Contains(4));
            fours.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in fours) result += x.bet * leng--;
            var house = crd.FindAll(card => card.cards.Contains(3) && card.cards.Contains(2));
            house.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in house) result += x.bet * leng--;
            var threes = crd.FindAll(card => card.cards.Contains(3) && !card.cards.Contains(2));
            threes.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in threes) result += x.bet * leng--;
            var twopairs = crd.FindAll(card => card.cards.Contains(2) && card.cards.Count(u => u == 2) == 2);
            twopairs.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in twopairs) result += x.bet * leng--;
            var pairs = crd.FindAll(card => card.cards.Contains(2) && card.cards.Count(u => u == 2) == 1 && !card.cards.Contains(3));
            pairs.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in pairs) result += x.bet * leng--;
            var high = crd.FindAll(card => card.cards.Contains(1) && !card.cards.Contains(4) && !card.cards.Contains(3) && !card.cards.Contains(2));
            high.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in high) result += x.bet * leng--;






            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
        static void day7p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<(List<int> cards, List<int> hand, int bet)> crd = new();
            long result = 0;
            int leng = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                crd.Add((new(new int[14]), new(), int.Parse(line.Substring(6))));
                List<int> h = new();
                for (int i = 0; i < 5; i++)
                {
                    if (char.IsDigit(line[i]))
                    {
                        int num = line[i] - '0' - 1;
                        crd.Last().cards[num]++;
                        crd.Last().hand.Add(num);
                    }
                    else
                    {
                        int num = line[i] switch
                        {
                            'T' => 10,
                            'J' => 1,
                            'Q' => 11,
                            'K' => 12,
                            'A' => 13
                        } - 1;
                        crd.Last().cards[num]++;
                        crd.Last().hand.Add(num);
                    }

                }
                int ind = crd.Last().cards.Skip(1).ToList().IndexOf(crd.Last().cards.Skip(1).Max()) + 1;
                for (int i = 0; i < crd.Last().cards[0]; ++i)
                {
                    crd.Last().cards[ind]++;
                }
                crd.Last().cards[0] = 0;
            }
            leng = crd.Count();
            var fives = crd.FindAll(card => card.cards.Contains(5));
            fives.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in fives) result += x.bet * leng--;
            var fours = crd.FindAll(card => card.cards.Contains(4));
            fours.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in fours) result += x.bet * leng--;
            var house = crd.FindAll(card => card.cards.Contains(3) && card.cards.Contains(2));
            house.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in house) result += x.bet * leng--;
            var threes = crd.FindAll(card => card.cards.Contains(3) && !card.cards.Contains(2));
            threes.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in threes) result += x.bet * leng--;
            var twopairs = crd.FindAll(card => card.cards.Contains(2) && card.cards.Count(u => u == 2) == 2);
            twopairs.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in twopairs) result += x.bet * leng--;
            var pairs = crd.FindAll(card => card.cards.Contains(2) && card.cards.Count(u => u == 2) == 1 && !card.cards.Contains(3));
            pairs.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in pairs) result += x.bet * leng--;
            var high = crd.FindAll(card => card.cards.Contains(1) && !card.cards.Contains(4) && !card.cards.Contains(3) && !card.cards.Contains(2));
            high.Sort((i1, i2) =>
            {
                for (int i = 0; i < 5; ++i)
                {
                    if (i1.hand[i].CompareTo(i2.hand[i]) != 0)
                        return -i1.hand[i].CompareTo(i2.hand[i]);
                }
                return 0;
            });
            foreach (var x in high) result += x.bet * leng--;






            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}
