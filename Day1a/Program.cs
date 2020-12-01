﻿using System;

namespace Day1a
{
    /*
     * Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently,
     * something isn't quite adding up.
     * 
     * Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.
     * 
     * For example, suppose your expense report contained the following:
     * 
     * 1721
     * 979
     * 366
     * 299
     * 675
     * 1456
     * 
     * In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579,
     * so the correct answer is 514579.
     */
    internal class Program
    {
        private static void Main()
        {
            const int sum = 2020;
            int? result = ExpenseReports.Process(sum);
            Console.WriteLine(result is not null ? result.ToString() : $"No expense reports sum to {sum}");
        }
    }
}
