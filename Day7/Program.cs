using System;
using System.IO;

namespace Day7
{
    class Program
    {
        /// <summary>
        /// Determine how many bags can contain a given bag.
        /// </summary>
        /// <param name="args">args[0]: The input filename.<br> 
        /// args[1..^0]: The description of the bag.</br></param>
        static void Main(string[] args)
        {
            StreamReader streamReader = new(args[0]);
            LuggageProcessor luggageProcessor = new(streamReader);
            Console.WriteLine(luggageProcessor.HowManyBagsInside(args[1] + " " + args[2]));
        }
    }
}
