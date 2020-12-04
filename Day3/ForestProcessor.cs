using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day3
{
    internal class ForestProcessor
    {
        private readonly Forest _forest;

        /// <summary>
        /// Create a new ForestProcessor.
        /// </summary>
        /// <param name="forestFile">The file to instantiate the Forest from.</param>
        public ForestProcessor(StreamReader forestFile) => _forest = new Forest(forestFile);

        /// <summary>
        /// Count the number of trees on the path. The method ends when the path gets to the bottom of the forest.
        /// </summary>
        /// <param name="rightSteps">The number of steps right per slope.</param>
        /// <param name="downSteps">THe number of steps down per slope.</param>
        /// <returns>THe number of trees encountered.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="rightSteps"/> is non-positive or 
        /// <paramref name="downSteps"/> is not greater than zero.</exception>
        /// <exception cref="InvalidOperationException">Starting space is not empty.</exception>
        internal long CountTreesOnPath(List<Slope> slopes)
        {
            #region Preconditions
            if (slopes.Count < 1)
            {
                throw new ArgumentException("Must have slopes", nameof(slopes));
            }
            #endregion

            long product = 1;
            foreach (Slope slope in slopes)
            {
                int row = 0;
                int column = 0;
                int numberOfTrees = 0;
                do
                {
                    numberOfTrees += _forest.HasTree(row, column) ? 1 : 0;
                    column += slope.RightSteps;
                    row += slope.DownSteps;
                } while (row < _forest.Length);
                product *= numberOfTrees;
            }

            Debug.Assert(product >= 1);
            return product;
        }
    }
}