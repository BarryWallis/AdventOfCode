using System;
using System.IO;

namespace Day2
{
    internal class PasswordChecker
    {
        /// <summary>
        /// Read passwords fron <paramref name="textReader"/> and determine how many are accceptable.
        /// </summary>
        /// <param name="textReader">The input stream.</param>
        /// <returns>The number of acceptable passwords.</returns>
        internal static int CheckPasswords(TextReader textReader)
        {
            int validPasswords = 0;
            string? line;
            while ((line = textReader.ReadLine()) is not null)
            {
                (PasswordValidator passwordValidator, string password) = SplitLine(line);
                validPasswords
                    += passwordValidator.IsPasswordValid(password) ? 1 : 0;
            }

            return validPasswords;
        }

        /// <summary>
        /// Split an input data line into its component parts. 
        /// </summary>
        /// <param name="line">The input data line.</param>
        /// <returns>(the password validation criteria, the password to check).</returns>
        private static (PasswordValidator passwordValidator, string password) SplitLine(string line)
        {
            string[] elements = line.Split(null);
            if (elements.Length != 3)
            {
                throw new FormatException($"Invalid input line: {line}");
            }

            string[] extents = elements[0].Split(new char[] { '-' });
            return extents.Length != 2
                ? throw new FormatException($"Invalid minimum / maximum specifier: {elements[0]}")
                : elements[1].Length != 2 || !char.IsLetter(elements[1][0]) || elements[1][1] != ':'
                ? throw new FormatException($"Invalid letter specification: {elements[1]}")
                : !int.TryParse(extents[0], out int minimumLength)
                ? throw new FormatException($"Invalid minimum length: {extents[0]}")
                : !int.TryParse(extents[1], out int maximumLength)
                ? throw new FormatException($"Invalid maximum length: {extents[1]}")
                : (new PasswordValidator(minimumLength, maximumLength, elements[1][0]), elements[2]);
        }
    }
}