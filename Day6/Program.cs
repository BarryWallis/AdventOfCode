using System;
using System.IO;

namespace Day6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StreamReader streamReader = new(args[0]);
            CustomsDeclarationScanner customsDeclarationScanner = new(streamReader);
            Console.WriteLine(customsDeclarationScanner.Scan());
        }
    }
}
