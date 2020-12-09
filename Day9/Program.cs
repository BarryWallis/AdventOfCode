using System;
using System.IO;
using System.Linq;

namespace Day9
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            long[] xmasData = new StreamReader(args[0]).ReadToEnd().Split(Array.Empty<char>(),
                StringSplitOptions.RemoveEmptyEntries).ToList().Select(s => long.Parse(s)).ToArray();
            int preambleSize = int.Parse(args[1]);
            for (int i = preambleSize; i < xmasData.Length; i++)
            {
                bool foundSum;
                foundSum = CheckForSum(xmasData, preambleSize, i);
                if (!foundSum)
                {
                    Console.WriteLine(xmasData[i]);
                }
            }
        }

        private static bool CheckForSum(long[] xmasData, int preambleSize, int i)
        {
            bool foundSum = false;
            for (int j = i - preambleSize; j < i; j++)
            {
                for (int k = j + 1; k < i; k++)
                {
                    if (xmasData[j] + xmasData[k] == xmasData[i])
                    {
                        foundSum = true;
                        break;
                    }
                }

                if (foundSum)
                {
                    break;
                }
            }

            return foundSum;
        }
    }
}
