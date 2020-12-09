using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Memory
    {
        public class Cell
        {
            public Instruction Instruction { get; }
            public bool HasBeenExecuted { get; set; }

            public Cell(Instruction instruction, bool hasBeenExecuted)
            {
                Instruction = instruction;
                HasBeenExecuted = hasBeenExecuted;
            }
        }

        private readonly IList<Cell> _cells = new List<Cell>();

        public int Count => _cells.Count;

        public Cell this[int i] => _cells[i];

        /// <summary>
        /// Add a new instruction to the end of memory.
        /// </summary>
        /// <param name="instruction">The instruction to add.</param>
        internal void Add(Instruction instruction)
        {
            #region Preconditions
            // None
            int initialCellCount = _cells.Count;
            #endregion

            _cells.Add(new Cell(instruction, false));

            #region Postconditions
            Debug.Assert(_cells.Count == initialCellCount + 1);
            #endregion
        }
    }
}
