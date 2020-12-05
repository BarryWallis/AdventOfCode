using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Day5
{
    internal class BoardingPassScanner
    {
        private StreamReader StreamReader { get; }

        /// <summary>
        /// Scan all boarding passes and return the highest seat ID.
        /// </summary>
        /// <param name="streamReader">The stream to read the boarding pass from.</param>
        public BoardingPassScanner(StreamReader streamReader) => StreamReader = streamReader;

        internal int FindHighestBoardingPass()
        {
            int highestSeatId = -1;
            while (!StreamReader.EndOfStream)
            {
                BoardingPass boardingPass = new(StreamReader);
                highestSeatId = boardingPass.SeatId > highestSeatId ? boardingPass.SeatId : highestSeatId;
            }

            Debug.Assert(highestSeatId >= 0);
            return highestSeatId;
        }

        /// <summary>
        /// There is only one empty seat. Find it.
        /// </summary>
        /// <returns>THe SeatId of the only empty seat.</returns>
        internal int FindMySeat()
        {
            List<BoardingPass> boardingPasses = new();
            while (!StreamReader.EndOfStream)
            {
                boardingPasses.Add(new BoardingPass(StreamReader));
            }

            int i;
            boardingPasses.Sort((left, right) => left.SeatId - right.SeatId);
            for (i = 0; i < boardingPasses.Count - 1; i++)
            {
                if (boardingPasses[i].SeatId + 1 != boardingPasses[i + 1].SeatId)
                {
                    break;
                }
            }

            return boardingPasses[i].SeatId + 1;
        }
    }
}