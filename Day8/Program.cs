using System;
using System.Diagnostics;
using System.IO;

namespace Day8
{
    internal class Program
    {
        /// <summary>
        /// Read a program from the given file, run it and output the value of the accumulator.
        /// </summary>
        /// <param name="args">The file containing the program.</param>
        private static void Main(string[] args)
        {
            #region Preconditions
            Debug.Assert(args.Length == 1);
            Debug.Assert(File.Exists(args[0]));
            #endregion

            GameConsole gameConsole = new(new StreamReader(args[0]));
            gameConsole.Run();
            Console.WriteLine(gameConsole.Accumulator);
        }
    }
}
