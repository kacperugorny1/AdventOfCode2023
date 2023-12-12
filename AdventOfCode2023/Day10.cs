using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023
{
    internal class Day10
    {
        static void day10p1(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<List<char>> map = new();
            (int x, int y) coords = new();
            int x1 = 0;
            int y1 = 0;
            char before1 = 'd';
            int x2 = 0;
            int y2 = 0;
            char before2 = 'r';
            long result = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                var list = line.ToList();
                map.Add(list);
                if (list.Contains('S'))
                {
                    coords.y = list.IndexOf('S');
                    coords.x = map.Count - 1;
                }
            }
            /*if (map[coords.x - 1][coords.y] == '|' && map[coords.x - 1][coords.y] == '|') map[coords.x][coords.y] = '|';
            else if (map[coords.x][coords.y - 1] == '-' && map[coords.x][coords.y + 1] == '-') map[coords.x][coords.y] = '-';
            else if (map[coords.x - 1][coords.y] == '|' && map[coords.x][coords.y + 1] == '-') map[coords.x][coords.y] = 'F';
            else if (map[coords.x - 1][coords.y] == '|' && map[coords.x][coords.y - 1] == '-') map[coords.x][coords.y] = '7';
            else if (map[coords.x + 1][coords.y] == '|' && map[coords.x][coords.y + 1] == '-') map[coords.x][coords.y] = 'L';
            else if (map[coords.x + 1][coords.y] == '|' && map[coords.x][coords.y - 1] == '-') map[coords.x][coords.y] = 'J';
            */
            map[coords.x][coords.y] = 'L';
            x2 = x1 = coords.x;
            y2 = y1 = coords.y;

            while (true)
            {
                int x3 = x1, x4 = x2, y3 = y1, y4 = y2;
                if (map[x1][y1] == '-')
                {
                    y1 = (before1 == 'r') ? y1 + 1 : y1 - 1;
                    before1 = before1 == 'r' ? 'r' : 'l';
                }
                else if (map[x1][y1] == '|')
                {
                    x1 = (before1 == 'u') ? x1 - 1 : x1 + 1;
                    before1 = before1 == 'u' ? 'u' : 'd';
                }
                else if (map[x1][y1] == 'F')
                {
                    y1 = (before1 == 'u') ? y1 + 1 : y1;
                    x1 = (before1 == 'u') ? x1 : x1 + 1;
                    before1 = before1 == 'u' ? 'r' : 'd';
                }
                else if (map[x1][y1] == '7')
                {
                    y1 = (before1 == 'u') ? y1 - 1 : y1;
                    x1 = (before1 == 'u') ? x1 : x1 + 1;
                    before1 = before1 == 'u' ? 'l' : 'd';
                }
                else if (map[x1][y1] == 'L')
                {
                    y1 = (before1 == 'd') ? y1 + 1 : y1;
                    x1 = (before1 == 'd') ? x1 : x1 - 1;
                    before1 = before1 == 'd' ? 'r' : 'u';
                }
                else if (map[x1][y1] == 'J')
                {
                    y1 = (before1 == 'd') ? y1 - 1 : y1;
                    x1 = (before1 == 'd') ? x1 : x1 - 1;
                    before1 = before1 == 'd' ? 'l' : 'u';
                }


                if (map[x2][y2] == '-')
                {
                    y2 = (before2 == 'r') ? y2 + 1 : y2 - 1;
                    before2 = before2 == 'r' ? 'r' : 'l';
                }
                else if (map[x2][y2] == '|')
                {
                    x2 = (before2 == 'u') ? x2 - 1 : x2 + 1;
                    before2 = before2 == 'u' ? 'u' : 'd';
                }
                else if (map[x2][y2] == 'F')
                {
                    y2 = (before2 == 'u') ? y2 + 1 : y2;
                    x2 = (before2 == 'u') ? x2 : x2 + 1;
                    before2 = before2 == 'u' ? 'r' : 'd';
                }
                else if (map[x2][y2] == '7')
                {
                    y2 = (before2 == 'u') ? y2 - 1 : y2;
                    x2 = (before2 == 'u') ? x2 : x2 + 1;
                    before2 = before2 == 'u' ? 'l' : 'd';
                }
                else if (map[x2][y2] == 'L')
                {
                    y2 = (before2 == 'd') ? y2 + 1 : y2;
                    x2 = (before2 == 'd') ? x2 : x2 - 1;
                    before2 = before2 == 'd' ? 'r' : 'u';
                }
                else if (map[x2][y2] == 'J')
                {
                    y2 = (before2 == 'd') ? y2 - 1 : y2;
                    x2 = (before2 == 'd') ? x2 : x2 - 1;
                    before2 = before2 == 'd' ? 'l' : 'u';
                }

                map[x3][y3] = 'x';
                map[x4][y4] = 'x';
                //Console.WriteLine($"Coords1 x:{x1} y:{y1} bf:{before1}  Coords2: x:{x2} y:{y2} bf:{before2}");
                result++;
                if (x1 == x2 && y1 == y2) break;

            }
            /*map[x1][y1] = 'x';
            map[x2][y2] = 'x';
            map.ForEach(u => {
                u.ForEach(z =>
                {
                    Console.Write(z);
                });
            }
            );
            */
            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");
        }
        static void day10p2(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            var input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");
            //input = File.ReadLines("C:\\Users\\Kacpi\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\inputtest.txt");
            List<List<char>> map = new();
            (int x, int y) coords = new();
            int x1 = 0;
            int y1 = 0;
            char before1 = 'd';
            int x2 = 0;
            int y2 = 0;
            char before2 = 'r';
            bool mark = false;
            long result = 0;
            stopwatch.Start();
            foreach (string line in input)
            {
                var list = line.ToList();
                map.Add(list);
                if (list.Contains('S'))
                {
                    coords.y = list.IndexOf('S');
                    coords.x = map.Count - 1;
                }
            }
            /*if (map[coords.x - 1][coords.y] == '|' && map[coords.x - 1][coords.y] == '|') map[coords.x][coords.y] = '|';
            else if (map[coords.x][coords.y - 1] == '-' && map[coords.x][coords.y + 1] == '-') map[coords.x][coords.y] = '-';
            else if (map[coords.x - 1][coords.y] == '|' && map[coords.x][coords.y + 1] == '-') map[coords.x][coords.y] = 'F';
            else if (map[coords.x - 1][coords.y] == '|' && map[coords.x][coords.y - 1] == '-') map[coords.x][coords.y] = '7';
            else if (map[coords.x + 1][coords.y] == '|' && map[coords.x][coords.y + 1] == '-') map[coords.x][coords.y] = 'L';
            else if (map[coords.x + 1][coords.y] == '|' && map[coords.x][coords.y - 1] == '-') map[coords.x][coords.y] = 'J';
            */
            map[coords.x][coords.y] = 'L';
            x2 = x1 = coords.x;
            y2 = y1 = coords.y;

            while (true)
            {
                int x3 = x1, x4 = x2, y3 = y1, y4 = y2;
                if (map[x1][y1] == '-')
                {
                    y1 = (before1 == 'r') ? y1 + 1 : y1 - 1;
                    before1 = before1 == 'r' ? 'r' : 'l';
                }
                else if (map[x1][y1] == '|')
                {
                    x1 = (before1 == 'u') ? x1 - 1 : x1 + 1;
                    before1 = before1 == 'u' ? 'u' : 'd';
                }
                else if (map[x1][y1] == 'F')
                {
                    y1 = (before1 == 'u') ? y1 + 1 : y1;
                    x1 = (before1 == 'u') ? x1 : x1 + 1;
                    before1 = before1 == 'u' ? 'r' : 'd';
                }
                else if (map[x1][y1] == '7')
                {
                    y1 = (before1 == 'u') ? y1 - 1 : y1;
                    x1 = (before1 == 'u') ? x1 : x1 + 1;
                    before1 = before1 == 'u' ? 'l' : 'd';
                }
                else if (map[x1][y1] == 'L')
                {
                    y1 = (before1 == 'd') ? y1 + 1 : y1;
                    x1 = (before1 == 'd') ? x1 : x1 - 1;
                    before1 = before1 == 'd' ? 'r' : 'u';
                }
                else if (map[x1][y1] == 'J')
                {
                    y1 = (before1 == 'd') ? y1 - 1 : y1;
                    x1 = (before1 == 'd') ? x1 : x1 - 1;
                    before1 = before1 == 'd' ? 'l' : 'u';
                }


                if (map[x2][y2] == '-')
                {
                    y2 = (before2 == 'r') ? y2 + 1 : y2 - 1;
                    before2 = before2 == 'r' ? 'r' : 'l';
                }
                else if (map[x2][y2] == '|')
                {
                    x2 = (before2 == 'u') ? x2 - 1 : x2 + 1;
                    before2 = before2 == 'u' ? 'u' : 'd';
                }
                else if (map[x2][y2] == 'F')
                {
                    y2 = (before2 == 'u') ? y2 + 1 : y2;
                    x2 = (before2 == 'u') ? x2 : x2 + 1;
                    before2 = before2 == 'u' ? 'r' : 'd';
                }
                else if (map[x2][y2] == '7')
                {
                    y2 = (before2 == 'u') ? y2 - 1 : y2;
                    x2 = (before2 == 'u') ? x2 : x2 + 1;
                    before2 = before2 == 'u' ? 'l' : 'd';
                }
                else if (map[x2][y2] == 'L')
                {
                    y2 = (before2 == 'd') ? y2 + 1 : y2;
                    x2 = (before2 == 'd') ? x2 : x2 - 1;
                    before2 = before2 == 'd' ? 'r' : 'u';
                }
                else if (map[x2][y2] == 'J')
                {
                    y2 = (before2 == 'd') ? y2 - 1 : y2;
                    x2 = (before2 == 'd') ? x2 : x2 - 1;
                    before2 = before2 == 'd' ? 'l' : 'u';
                }

                map[x3][y3] = 'x';
                map[x4][y4] = 'x';
                if (x1 == x2 && y1 == y2) break;

            }
            map[x1][y1] = 'x';
            map[x2][y2] = 'x';
            int add = 0;
            func(0, 0, ref map);
            map.ForEach(u =>
            {
                u.ForEach(z =>
                {
                    if (z != '0' && z != 'x') result++;
                    Console.Write(z);
                });
                Console.WriteLine();
            });

            stopwatch.Stop();
            Console.WriteLine($"Result = {result}");
            Console.WriteLine($"Elapsed time is {stopwatch.ElapsedMilliseconds} ms");

            static void func(int i, int j, ref List<List<char>> map)
            {
                if (map[i][j] == 'z') return;

                map[i][j] = '0';
                if (i > 0 && map[i - 1][j] != '0') func(i - 1, j, ref map);
                if (i < map.Count - 1 && map[i + 1][j] != '0') func(i + 1, j, ref map);
                if (j > 0 && map[i][j - 1] != '0') func(i, j - 1, ref map);
                if (i < map[1].Count - 1 && map[i][j + 1] != '0') func(i, j + 1, ref map);
            }
        }
    }
}
