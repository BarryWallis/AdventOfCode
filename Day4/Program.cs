using System;

namespace Day4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PassportScanner passportScanner = new(args[0]);
            int validPassports = passportScanner.ScanPassports();
            Console.WriteLine(validPassports);
        }
    }
}
