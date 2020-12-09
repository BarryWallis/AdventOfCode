using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Memory : List<Memory.Cell>
    {
        public class Cell
        {
            public Instruction Instruction { get; set; }
            public bool HasBeenExecuted { get; set; }

            public Cell(Instruction instruction, bool hasBeenExecuted)
            {
                Instruction = instruction;
                HasBeenExecuted = hasBeenExecuted;
            }
        }

        public void Add(Instruction instruction) => base.Add(new Cell(instruction, false));
    }
}
