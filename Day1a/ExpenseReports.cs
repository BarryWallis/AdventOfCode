using System;
using System.Collections.Generic;

namespace Day1a
{
    /// <summary>
    /// An expense report processor.  
    /// </summary>
    internal class ExpenseReports
    {
        private static readonly List<int> _expenses = new();

        /// <summary>
        /// Process expense reports by finding the first three expenses that sum to <paramref name="sum"/> and return their
        /// product. If no expenses meet the criteria or their is an input format error, return null.
        /// </summary>
        /// <param name="sum">The amount that two expense reports need to sum to.</param>
        /// <returns>The product of the three expense reports or null if none meet the criteriaor there is a format error in
        /// the input.
        /// </returns>
        public static int? Process(int sum)
        {
            int? result = null;
            while (int.TryParse(Console.ReadLine(), out int expense) && !IfFoundExpenses(expense, sum, out result))
            {
                // This space intentionally left blank.
            }

            return result;
        }

        /// <summary>
        /// Check the current expense against all previous expenses to find the two expenses that sum to 
        /// <paramref name="sum"/>.
        /// </summary>
        /// <param name="expense">The current expense.</param>
        /// <param name="sum">The value that <paramref name="numberToCheck"/> expenses need to sum to.</param>
        /// <param name="result">If the two expenses sum to 2020, the product of the two expenses; otherwise null.</param>
        /// <returns>True if the two expenses sum to 2020; otherwise false.</returns>
        private static bool IfFoundExpenses(int expense, int sum, out int? result)
        {
            result = null;
            if (_expenses.Count < 2)
            {
                _expenses.Add(expense);
            }
            else
            {
                result = CheckExpenses(expense, sum);
                _expenses.Add(expense);
            }

            return result is not null;
        }
        /// <summary>
        /// Check current expense against all previous expenses to determine if they sum to <paramref name="sum"/>. If they
        /// do, return their product; otherwise return null.
        /// </summary>
        /// <param name="expense">The current expense.</param>
        /// <param name="sum">The value that two expenses need to sum to.</param>
        /// <param name="numberToCheck">The number of expenses to check their sum.</param>
        /// <returns>If they sum to <paramref name="sum"/>, their product; otherwise null.</returns>
        private static int? CheckExpenses(int expense, int sum)
        {
            for (int i = 0; i < _expenses.Count - 1; i++)
            {
                for (int j = i + 1; j < _expenses.Count; j++)
                {
                    if (expense + _expenses[i] + _expenses[j] == sum)
                    {
                        return expense * _expenses[i] * _expenses[j];
                    }
                }
            }

            return null;
        }
    }
}
