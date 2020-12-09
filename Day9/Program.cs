using System;
using System.Globalization;
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
            long target = EncryptionWeaknessPart1(xmasData, preambleSize);
            Console.WriteLine(EncryptionWeaknessPart2(xmasData, target));
        }

        private static long EncryptionWeaknessPart2(long[] xmasData, long target)
        {
            long encryptionWeakness = 0;
            for (int i = 0; i < xmasData.Length; i++)
            {
                long smallest = xmasData[i];
                long largest = xmasData[i];
                long sum = xmasData[i];
                int j;
                for (j = i + 1; j < xmasData.Length && sum < target; j++)
                {
                    sum += xmasData[j];
                    smallest = xmasData[j] < smallest ? xmasData[j] : smallest;
                    largest = xmasData[j] > largest ? xmasData[j] : largest;
                }

                if (sum == target)
                {
                    encryptionWeakness = smallest + largest;
                    break;
                }
            }

            return encryptionWeakness;
        }

        private static long EncryptionWeaknessPart1(long[] xmasData, int preambleSize)
        {
            long target = 0;
            for (int i = preambleSize; i < xmasData.Length; i++)
            {
                bool foundSum;
                foundSum = CheckForSum(xmasData, preambleSize, i);
                if (!foundSum)
                {
                    target = xmasData[i];
                }
            }

            return target;
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
