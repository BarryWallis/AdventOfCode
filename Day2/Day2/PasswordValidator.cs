using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day2
{
    /// <summary>
    /// Ensure a given password has MinimumLength <= number of Letter <= MaximumLength
    /// </summary>
    record PasswordValidator(int MinimumLength, int MaximumLength, char Letter)
    {
        /// <summary>
        /// Test is password is valid.
        /// </summary>
        /// <param name="password">The password to test.</param>
        /// <returns>True if <paramref name="password"/> is MinimumLength <= number of Letter <= MaximumLength.</returns>
        public bool IsPasswordValid(string password)
        {
            int letterCount = password.Count(c => c == Letter);
            return letterCount >= MinimumLength && letterCount <= MaximumLength;
        }
    }
}
