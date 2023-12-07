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
            //input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<(List<int> cards, List<int> hand, int bet) > crd = new();
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
            foreach(var x in fives) result += x.bet * leng--;
            var fours = crd.FindAll(card => card.cards.Contains(4));
            fours.Sort((i1, i2) =>
            {
                for(int i = 0; i < 5; ++i)
                {
                    if(i1.hand[i].CompareTo(i2.hand[i]) != 0)
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
            var pairs = crd.FindAll(card => card.cards.Contains(2)&& card.cards.Count(u=>u==2) == 1 && !card.cards.Contains(3));
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