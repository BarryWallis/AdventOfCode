namespace Day2
{
    /// <summary>
    /// Ensure a given password has MinimumLength <= number of Letter <= MaximumLength
    /// </summary>
    internal record PasswordValidator(int MustHavePosition1, int MustHavePosition2, char Letter)
    {
        /// <summary>
        /// Test if password is valid.
        /// </summary>
        /// <param name="password">The password to test.</param>
        /// <returns>True if <paramref name="password"/> has Letter at MustHavePosition and not have Letter at 
        /// MustNotHavePosition.</returns>
        public bool IsPasswordValid(string password) => password.Length >= MustHavePosition1
                                                        && password.Length >= MustHavePosition2
                                                        && (password[MustHavePosition1 - 1] == Letter
                                                            ^ password[MustHavePosition2 - 1] == Letter);
    }
}
