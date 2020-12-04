using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Day4
{
    internal record Passport
    {
        private readonly List<string> _requiredFields = new() { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid", };
        private readonly List<string> _optionalFields = new() { "cid", };

        public bool IsValid { get; }

        public Passport(TextReader textReader)
        {
            StringBuilder stringBuilder = new();
            string? line;
            while (!string.IsNullOrWhiteSpace(line = textReader.ReadLine()))
            {
                _ = stringBuilder.Append(line + " ");
            }
            string[] fields = stringBuilder.ToString().Trim().Split(null);
            List<string> fieldNames = new();
            foreach (string field in fields)
            {
                fieldNames.Add(field.Split(':')[0]);
            }

            IsValid = _requiredFields.All(r => fieldNames.Contains(r))
                      && (_optionalFields.Any(o => fieldNames.Contains(o)) 
                          || !_optionalFields.All(o=>fieldNames.Contains(o)))
                      && fieldNames.All(f => _requiredFields.Union(_optionalFields).Contains(f));
        }
    }
}