using System;

namespace Day3
{
    internal record Slope
    {
        internal int RightSteps { get; }
        internal int DownSteps { get; }

        /// <summary>
        /// The slope of descent through the forest.
        /// </summary>
        /// <param name="right">The number of steps to the right. Must be non-negative.</param>
        /// <param name="down">The number of steps down. Must be positive.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="right"/> must be non-negative and 
        /// <paramref name="down"/> must be positive.</exception>
        public Slope(int right, int down)
        {
            #region Preconditions
            if (right < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(right), $"Must be non-negative: {right}");
            }

            if (down <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(down), $"Must be positive: {down}");
            }
            #endregion

            RightSteps = right;
            DownSteps = down;
        }
    }
}
