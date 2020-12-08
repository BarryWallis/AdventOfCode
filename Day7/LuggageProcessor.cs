using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day7
{
    internal class LuggageProcessor
    {
        // Set of all bags seen.
        private readonly HashSet<Bag> _bags = new();

        /// <summary>
        /// Create a new luggage processor.
        /// </summary>
        /// <param name="streamReader">The stream to read the bags and their contents from.</param>
        public LuggageProcessor(StreamReader streamReader)
        {
            #region Precondition
            Debug.Assert(!streamReader.EndOfStream);
            #endregion

            while (!streamReader.EndOfStream)
            {
                string? line = streamReader.ReadLine();
                Debug.Assert(line is not null);
                if (!_bags.Add(Bag.Parse(line)))
                {
                    throw new InvalidDataException($"Attempt to define duplicate bag.");
                }
            }

            #region Postcondition
            Debug.Assert(_bags.Count > 0);
            #endregion
        }

        /// <summary>
        /// Determine how many different bags the given bag can be in.
        /// </summary>
        /// <param name="bagDescriptions">The description of a bag.</param>
        /// <returns></returns>
        internal int HowManyBags(string bagName)
        {
            int numberOfBags = 0;
            foreach (Bag bag in _bags)
            {
                numberOfBags += CountBags(bag, bagName);
            }

            return numberOfBags;
        }

        private int CountBags(Bag bag, string bagName)
        {
            int returnValue = 0;
            foreach (string containedBagName in bag.CanContain.Keys)
            {

                if (containedBagName == bagName)
                {
                    returnValue = 1;
                    break;
                }
                else
                {
                    returnValue = CountBags(_bags.First(b => b.Name == containedBagName), bagName);
                    if (returnValue == 1)
                    {
                        break;
                    }
                }
            }

            return returnValue;
        }
    }
}