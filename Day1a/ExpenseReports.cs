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
        /// Process expense reports by finding the first two expenses that sum to <paramref name="sum"/> and return their
        /// product. If no expenses meet the criteria or their is an input format error, return null.
        /// </summary>
        /// <param name="sum">The amount that two expense reports need to sum to.</param>
        /// <returns>The product of the two expense reports or null if none meet the criteriaor there is a format error in the
        /// input.</returns>
        public static int? Process(int sum)
        {
            int? result = null;
            while (int.TryParse(Console.ReadLine(), out int expense) && !FoundExpenses(expense, sum, out result))
            {
                // This space intentionally left blank.
            }

            return result;
        }

        /// <summary>
        /// Check the current expense against all previous expenses to find the two expenses that sum to <paramref name="sum"/>.
        /// </summary>
        /// <param name="expense">The current expense.</param>
        /// <param name="sum">The value that two expenses need to sum to.</param>
        /// <param name="result">If the two expenses sum to 2020, the product of the two expenses; otherwise null.</param>
        /// <returns>True if the two expenses sum to 2020; otherwise false.</returns>
        private static bool FoundExpenses(int expense, int sum, out int? result)
        {
            result = null;
            if (_expenses.Count == 0)
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
        /// <returns>If they sum to <paramref name="sum"/>, their product; otherwise null.</returns>
        private static int? CheckExpenses(int expense, int sum)
        {
            foreach (int previousExpense in _expenses)
            {
                if (expense + previousExpense == sum)
                {
                    return expense * previousExpense;
                }
            }

            return null;
        }
    }
}
