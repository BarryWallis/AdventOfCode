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
    }
}