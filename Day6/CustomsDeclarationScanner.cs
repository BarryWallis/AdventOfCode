using System.IO;

namespace Day6
{
    internal class CustomsDeclarationScanner
    {
        private readonly StreamReader _streamReader;

        /// <summary>
        /// Create an custome declaration scanner. 
        /// </summary>
        /// <param name="fileStream">The file to scan the customs declaractions from.</param>
        public CustomsDeclarationScanner(StreamReader streamReader) => _streamReader = streamReader;

        /// <summary>
        /// Scan each customs declaration and accumulate the number of discrete questions answered with yes.
        /// </summary>
        /// <returns>The number of questions answered with yes.</returns>
        internal int Scan()
        {
            int yesQuestions = 0;
            while (!_streamReader.EndOfStream)
            {
                CustomsDeclaration customsDeclaration = new(_streamReader);
                yesQuestions += customsDeclaration.YesQuestions();
            }

            return yesQuestions;
        }
    }
}