using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day3
{
    /// <summary>
    /// A forest that is populated with trees and open space.
    /// </summary>
    internal class Forest
    {
        private readonly List<List<bool>> _forest = new();

        public int Length => _forest.Count;

        /// <summary>
        /// Create a new Forest. The forest extends infitely to the right by duplicating itself (simulated by wrapping 
        /// around). 
        /// </summary>
        /// <param name="forestFile">The stream to read the Forest from. '.' mean empty space and '#' mean a tree. One line 
        /// per row.</param>
        /// <exception cref="EndOfStreamException">An empty line or the end of the input was unexecptedly found.</exception>
        /// <exception cref="InvalidDataException">All line lengths must be the same.</exception>
        public Forest(StreamReader forestFile)
        {
            int lineLength = 0;
            do
            {
                string? line = forestFile.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    throw new EndOfStreamException();
                }

                if (lineLength == 0)
                {
                    lineLength = line.Length;
                }
                else if (line.Length != lineLength)
                {
                    throw new InvalidDataException("All line lengths must be the same");
                }

                _forest.Add(ParseLine(line));
            } while (!forestFile.EndOfStream);

            Debug.Assert(Length > 0);
            foreach (List<bool> item in _forest)
            {
                Debug.Assert(item.Count == _forest[0].Count);
            }
        }

        /// <summary>
        /// Parse a string as a row of the forest. An entry contains true if there is a tree there; otherwise false.
        /// </summary>
        /// <param name="line">The row of the forest.</param>
        /// <returns>A List<bool> where <see langword="true"/> means there is a tree there and <see langword="false"/> means 
        /// there isn't.</bool></returns>
        /// <exception cref="ArgumentNullException"><paramref name="line"/> must be provided.</exception>
        private static List<bool> ParseLine(string line)
        {
            #region Preconditions
            if (string.IsNullOrEmpty(line))
            {
                throw new ArgumentNullException(nameof(line));
            }
            #endregion

            List<bool> forestLine = new(line.Length);
            foreach (char c in line)
            {
                forestLine.Add(c == '#');
            }

            Debug.Assert(forestLine.Count == line.Length);
            return forestLine;
        }

        /// <summary>
        /// Is the given <paramref name="row"/> and <paramref name="column"/> empty?
        /// </summary>
        /// <param name="row">The row to check.</param>
        /// <param name="column">The column to check.</param>
        /// <returns>True if the space is empty; otherwise false.</returns>
        /// <exception cref="ArgumentException">The <paramref name="row"/> or <paramref name="column"/> is not within the 
        /// forest.</exception>
        internal bool IsEmpty(int row, int column)
        {
            #region Preconditions
            if (!RowInsideForest(row))
            {
                throw new ArgumentException("Must be within the forest", nameof(row));
            }

            if (!ColumnInsideForest(column))
            {
                throw new ArgumentException("Must be within the forest", nameof(column));
            }
            #endregion

            return _forest[row][column] == false;
        }

        /// <summary>
        /// Does the given <paramref name="row"/> and <paramref name="column"/> contain a tree?
        /// </summary>
        /// <param name="row">The row to check.</param>
        /// <param name="column">The column to check.</param>
        /// <returns>True if the space hs a tree; otherwise false.</returns>
        internal bool HasTree(int row, int column)
        {
            #region Preconditions
            if (!RowInsideForest(row))
            {
                throw new ArgumentException("Must be within the forest", nameof(row));
            }

            if (!ColumnInsideForest(column))
            {
                throw new ArgumentException("Must be within the forest", nameof(column));
            }
            #endregion

            return ForestContents(row, column) == true;
        }

        /// <summary>
        /// Return the contents of the cell at <paramref name="row"/> and <paramref name="column"/>.
        /// </summary>
        /// <param name="row">The row requested.</param>
        /// <param name="column">The column requested.</param>
        /// <returns>The cell at the requested <paramref name="row"/> and <paramref name="column"/></returns>
        private bool ForestContents(int row, int column) => _forest[row][column % _forest[row].Count];

#pragma warning disable CA1822 // Mark members as static
        private bool ColumnInsideForest(int column) => column >= 0;
#pragma warning restore CA1822 // Mark members as static

        private bool RowInsideForest(int row) => row >= 0 && row < Length;
    }
}