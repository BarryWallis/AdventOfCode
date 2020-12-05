using System;
using System.IO;
using System.Linq;

namespace Day5
{
    internal record BoardingPass
    {
        public string Seat { get; }

        public int SeatId 
        {
            get
            {
                string binarySeat = Seat.Replace('B', '1').Replace('F', '0').Replace('R', '1').Replace('L', '0');
                return Convert.ToInt32(binarySeat, 2);
            }
        }

        /// <summary>
        /// Read a new boarding pass from the <paramref name="streamReader"/>.
        /// </summary>
        /// <param name="streamReader">The stream to read the boarding pass from.</param>
        public BoardingPass(StreamReader streamReader)
        {
            string? line = streamReader.ReadLine();
            if (line is null)
            {
                throw new EndOfStreamException();
            }

            Seat = line.Length == 10 && line[0..7].All(c => c is 'B' or 'F') && line[7..^0].All(c => c is 'L' or 'R')
                ? line
                : throw new FormatException("Invalid BoardingPass format");
        }
    }
}