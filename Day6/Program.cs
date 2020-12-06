using System;
using System.IO;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new(args[0]);
            CustomsDeclarationScanner customsDeclarationScanner = new CustomsDeclarationScanner(streamReader);
            Console.WriteLine(customsDeclarationScanner.Scan());
        }
    }
}
