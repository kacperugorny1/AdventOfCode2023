using System;

namespace AdventOfCode2023
{ 
    internal class Program
    {

        static void Main(string[] args)
        {
            var input = File.ReadLines("C:\\Users\\Kacper1\\Desktop\\c#\\AdventOfCode2023\\AdventOfCode2023\\input.txt");

            foreach (string line in input)
            {
                Console.WriteLine(line);
            }
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