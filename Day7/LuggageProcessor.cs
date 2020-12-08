using System;
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
        /// <param name="bagName">The name of a bag.</param>
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

        /// <summary>
        /// Determine how many bags must be inside the given bag.
        /// </summary>
        /// <param name="bagName">The name of a bag.</param>
        /// <returns>The umber of bags inside <paramref name="bagName"/>.</returns>
        internal int HowManyBagsInside(string bagName) => CountBagsInside(_bags.First(b => b.Name == bagName)) - 1;

        /// <summary>
        /// Return the number of bags inside the <paramref name="bag"/>.
        /// </summary>
        /// <param name="bag">The bag to count the number of bags inside.</param>
        /// <returns>The number of bags inside.</returns>
        private int CountBagsInside(Bag bag)
        {
            int count = 1;
            //if (bag.CanContain.Count == 0)
            //{
            //    count = 0;
            //}
            //else
            //{
                foreach (KeyValuePair<string, int> containedBag in bag.CanContain)
                {
                    count += containedBag.Value * CountBagsInside(_bags.First(b => b.Name == containedBag.Key));
                }
            //}
            return count;
        }

        /// <summary>
        /// Return the number of bags that contain the <paramref name="bagName"/>. 
        /// </summary>
        /// <param name="bag">The bag to check.</param>
        /// <param name="bagName">The name of the bag to check for.</param>
        /// <returns></returns>
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