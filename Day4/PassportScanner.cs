using System.IO;

namespace Day4
{
    internal class PassportScanner
    {
        private readonly StreamReader _streamReader;

        public PassportScanner(string filePath) => _streamReader = new StreamReader(filePath);

        internal int ScanPassports()
        {
            int validPassports = 0;
            while (!_streamReader.EndOfStream)
            {
                Passport passport = new(_streamReader);
                validPassports += passport.IsValid ? 1 : 0;
            }

            return validPassports;
        }
    }
}