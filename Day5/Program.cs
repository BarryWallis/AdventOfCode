using System;
using System.IO;

namespace Day5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StreamReader streamReader = new(args[0]);
            BoardingPassScanner boardingPassScanner = new(streamReader);
            Console.WriteLine(boardingPassScanner.FindHighestBoardingPass());
        }
    }
}
