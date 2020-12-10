using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> adapters = new();
            adapters.Add(0);
            adapters.InsertRange(1, new StreamReader(args[0]).ReadToEnd()
                                                      .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                                                      .Select(s => int.Parse(s)));
                
            adapters.Sort();
            adapters.Add(adapters[^1] + 3);
            int ones = 0;
            int threes = 0;
            int other = 0;
            for (int i = 1; i < adapters.Count; i++)
            {
                switch (adapters[i] - adapters[i - 1])
                {
                    case 1:
                        ones += 1;
                        break;
                    case 3:
                        threes += 1;
                        break;
                    default:
                        Debug.Fail($"Found {other} joltage differences of other.");
                        break;
                }
            }

            Console.WriteLine(ones * threes);
        }
    }
}
