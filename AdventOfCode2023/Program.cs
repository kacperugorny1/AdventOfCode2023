using System;

namespace AdventOfCode2023
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
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
                //CODE
            }
        }
    }
}