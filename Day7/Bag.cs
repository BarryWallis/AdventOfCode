using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7
{
    /// <summary>
    /// A bag is identified by its name and contains a Dictionary of the bags it can contain and how many of each. 
    /// </summary>
    internal record Bag(string Name, Dictionary<string, int> CanContain)
    { 
        /// <summary>
        /// Create a new bag that cannot contain any bags.
        /// </summary>
        /// <param name="name"></param>
        public Bag(string name) : this(name, new Dictionary<string, int>())
        {
        }

        /// <summary>
        /// Parse a line that looks like this: <br>{bag name1} bags contain {n} {bag name2}[, bag name3]... bag|</br>
        /// <br>Where {bag name} is an adjective followed by a noun denoting the color.</br>
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        internal static Bag Parse(string line)
        {
            // dotted blue bags contain 5 wavy green bags, 3 pale beige bags.
            //    0    1    2     3     4  5     6    7    8   9   10    11
            Bag returnValue;
            string[] words = line.Split(null);
            string bagName = words[0] + " " + words[1];
            if (words[4] == "no")
            {
                returnValue = new Bag(bagName);
            }
            else
            {
                Dictionary<string, int> canContains = new();
                for (int i = 4; i < words.Length; i += 4)
                {
                    canContains.Add(words[i + 1] + " " + words[i + 2], int.Parse(words[i]));
                }
                returnValue =  new Bag(bagName, canContains);
            }

            return returnValue;
        }

        public virtual bool Equals(Bag? other) => !(other is null) &&
                EqualityContract == other.EqualityContract &&
                Name == other.Name;

        public override int GetHashCode() => Name.GetHashCode();
    }
}
