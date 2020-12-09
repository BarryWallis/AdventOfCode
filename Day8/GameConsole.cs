using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day8
{
    internal class GameConsole
    {
        private delegate void ExecuteInstruction(int argument);

        private int _programCounter = 0;
        private readonly Memory _memory = new();
        private readonly Dictionary<Operation, ExecuteInstruction> _executeInstructions = new();

        public int Accumulator { get; private set; } = 0;

        /// <summary>
        /// Create a new game console by reading the boot file from <paramref name="streamReader"/>.
        /// </summary>
        /// <param name="streamReader">The stream containing the boot file.</param>
        public GameConsole(StreamReader streamReader)
        {
            #region Preconditions
            Debug.Assert(!streamReader.EndOfStream);
            Debug.Assert(_executeInstructions.Count == 0);
            #endregion

            while (!streamReader.EndOfStream)
            {
                string? line = streamReader.ReadLine();
                Debug.Assert(line is not null);
                _memory.Add(new Instruction(line));
            }

            // Add new instructions here
            _executeInstructions[Operation.nop] = ExecuteNop;
            _executeInstructions[Operation.acc] = ExecuteAcc;
            _executeInstructions[Operation.jmp] = ExecuteJmp;

            #region Postconditions
            Debug.Assert(_memory.Count > 0);
            Debug.Assert(Accumulator == 0);
            Debug.Assert(_programCounter == 0);
            Debug.Assert(streamReader.EndOfStream);
            #endregion
        }

        /// <summary>
        /// Run the program. 
        /// </summary>
        public void Run()
        {
            #region Preconditions
            Debug.Assert(_programCounter is >= 0 && _programCounter < _memory.Count);
            #endregion

            while (!_memory[_programCounter].HasBeenExecuted)
            {
                Instruction instruction = _memory[_programCounter].Instruction;
                _memory[_programCounter].HasBeenExecuted = true;
                _executeInstructions[instruction.Operation](instruction.Argument);
            }

            #region Postconditions
            #endregion
        }

        /// <summary>
        /// Execute No Operation
        /// </summary>
        /// <param name="argument">Ignored.</param>
        private void ExecuteNop(int argument)
        {
            #region Preconditions
            Debug.Assert(_memory[_programCounter].Instruction.Operation == Operation.nop);
            #endregion

            _programCounter += 1;

            #region Postcondition
            Debug.Assert(_programCounter < _memory.Count);
            #endregion
        }

        /// <summary>
        /// Jump to a new location.
        /// </summary>
        /// <param name="argument">The amount to change the program counter by.</param>
        private void ExecuteJmp(int argument)
        {
            #region Preconditions
            Debug.Assert(_memory[_programCounter].Instruction.Operation == Operation.jmp);
            #endregion

            _programCounter += argument;

            #region Postcondition
            Debug.Assert(_programCounter < _memory.Count);
            Debug.Assert(_programCounter >= 0);
            #endregion
        }

        private void ExecuteAcc(int argument)
        {
            #region Preconditions
            Debug.Assert(_memory[_programCounter].Instruction.Operation == Operation.acc);
            #endregion

            Accumulator += argument;
            _programCounter += 1;

            #region Postcondition
            Debug.Assert(_programCounter < _memory.Count);
            #endregion
        }
    }
}