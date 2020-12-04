using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace Day3
{
    internal class Program
    {
        private static StreamReader? _forestFile;
        private static readonly List<Slope> _slopes = new();

        private static void Main(string[] args)
        {
            Initialize(args);
            ForestProcessor forestProcessor = new(_forestFile!);
            long numberOfTrees = forestProcessor.CountTreesOnPath(_slopes);
            Console.WriteLine(numberOfTrees);

        }

        /// <summary>
        /// Parse the command-line arguments for the program. On return all parameters have been initialized. 
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <exception cref="ArgumentException">Incorrect number of arguments.</exception>
        private static void Initialize(string[] args)
        {
            if (args.Length >= 3 && ((args.Length % 2) != 1))
            {
                throw new ArgumentException($"?Format: Day3 filename.txt <rightSteps downSteps>...");
            }

            _forestFile = new StreamReader(args[0]);

            for (int i = 1; i < args.Length; i += 2)
            {
                int right = int.Parse(args[i]);
                int down = int.Parse(args[i + 1]);
                _slopes.Add(new Slope(right, down));
            }

            Debug.Assert(_forestFile is not null);
            Debug.Assert(_slopes.Count > 0);
        }
    }
}
