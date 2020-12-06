using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Day6
{
    internal record CustomsDeclaration
    {
        // The questins that each person answered yes to.
        private readonly List<string> _people = new();

        /// <summary>
        /// Read a new customs declaration from the input stream.
        /// </summary>
        /// <param name="streamReader">The stream to read the customs declarations from.</param>
        public CustomsDeclaration(StreamReader streamReader)
        {
            #region Preconditions
            Debug.Assert(!streamReader.EndOfStream);
            #endregion

            string? line;
            while (!string.IsNullOrWhiteSpace(line = streamReader.ReadLine()))
            {
                _people.Add(line);
            }

            #region Postconditions
            Debug.Assert(_people.Count > 0);
            #endregion
        }

        /// <summary>
        /// Return the number of discrete questions answered yes on the customs declaration form.
        /// </summary>
        /// <returns>The number of discrete questions answered yes.</returns>
        internal int YesQuestions()
        {
            List<char> collectedYesQuestions = new(26);
            for (char c = 'a'; c <= 'z'; c++)
            {
                collectedYesQuestions.Add(c);
            }

            foreach (string person in _people)
            {
                collectedYesQuestions = collectedYesQuestions.Intersect(person).ToList();
            }

            return collectedYesQuestions.Count;
        }
    }
}