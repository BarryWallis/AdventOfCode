using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic;

namespace Day8
{
    public enum Operation { nop, acc, jmp, }

    public record Instruction(Operation Operation, int Argument)
    {
        /// <summary>
        /// Create an instruction by parsing the text. 
        /// </summary>
        /// <param name="instructionText">The text to parse. It must have an operation and an argument separated by 
        /// whitespace.</param>
        public Instruction(string instructionText) : this(Operation.nop, 0)
        {
            #region Preconditions
            Debug.Assert(!string.IsNullOrWhiteSpace(instructionText));
            #endregion

            string[] instructionFields = instructionText.Split(null);
            Debug.Assert(instructionFields.Length == 2);
            Operation = (Operation)Enum.Parse(typeof(Operation), instructionFields[0]);
            Argument = int.Parse(instructionFields[1]);

            #region Postconditions
            Debug.Assert(Enum.IsDefined(Operation));
            #endregion
        }
    }
}
