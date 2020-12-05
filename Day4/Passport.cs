using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Day4
{
    internal record Passport
    {
        delegate bool ValidateField(string value);

        private readonly Dictionary<string, ValidateField> _requiredFields = new() {
            { "byr", ValidateByr },
            { "iyr", ValidateIyr },
            { "eyr", ValidateEyr },
            { "hgt", ValidateHgt },
            { "hcl", ValidateHcl },
            { "ecl", ValidateEcl },
            { "pid", ValidatePid },
        };

        private readonly Dictionary<string, ValidateField> _optionalFields = new() { { "cid", ValidateCid }, };

        public bool IsValid { get; }

        public Passport(TextReader textReader)
        {
            StringBuilder stringBuilder = new();
            string? line;
            while (!string.IsNullOrWhiteSpace(line = textReader.ReadLine()))
            {
                _ = stringBuilder.Append(line + " ");
            }
            string[] fieldStrings = stringBuilder.ToString().Trim().Split(null);
            Dictionary<string, string> fields = new();
            foreach (string field in fieldStrings)
            {
                fields[field.Split(':')[0]] = field.Split(':')[1];
            }

            IsValid = _requiredFields.Keys.All(r => fields.ContainsKey(r))
                      && (_optionalFields.Keys.Any(o => fields.ContainsKey(o)) 
                          || !_optionalFields.Keys.All(o=>fields.ContainsKey(o)))
                      && fields.All(f => _requiredFields.Keys.Union(_optionalFields.Keys).Contains(f.Key));

            if (IsValid)
            {
                foreach (KeyValuePair<string, string> field in fields)
                {
                    if (_requiredFields.ContainsKey(field.Key) && !_requiredFields[field.Key](field.Value))
                    {
                        IsValid = false;
                        break;
                    }
                    else if (_optionalFields.ContainsKey(field.Key) && !_optionalFields[field.Key](field.Value)){
                        IsValid = false;
                        break;
                    }
                }
            }        
        }

        /// <summary>
        /// Validate birth year. 
        /// </summary>
        /// <param name="value">The birth year.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains four digits; at least 1920 and at most 
        /// 2002; otherwise <see langword="false"/>.</returns>
        static bool ValidateByr(string value) => int.TryParse(value, out int year) && year >= 1920 && year <= 2002;

        /// <summary>
        /// Validate issue year. 
        /// </summary>
        /// <param name="value">The issue year.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains four digits; at least 2010 and at most 
        /// 2020.; otherwise <see langword="false"/>.</returns>
        static bool ValidateIyr(string value) => int.TryParse(value, out int year) && year >= 2010 && year <= 2020;

        /// <summary>
        /// Validate expiration year. 
        /// </summary>
        /// <param name="value">The expiration year.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains four digits; at least 2020 and at most 
        /// 2030; otherwise <see langword="false"/>.</returns>
        static bool ValidateEyr(string value) => int.TryParse(value, out int year) && year >= 2020 && year <= 2030;

        /// <summary>
        /// Validate height. 
        /// </summary>
        /// <param name="value">The height.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains a number followed by either cm or in:
        ///     If cm, the number must be at least 150 and at most 193.
        ///     If in, the number must be at least 59 and at most 76; 
        /// otherwise <see langword="false"/>.</returns>
        static bool ValidateHgt(string value)
            => int.TryParse(value[0..^2], out int height)
               && (value[^2..^0] == "cm" || value[^2..^0] == "in")
               && ((value[^2..^0] == "cm"
                    && height >= 150
                    && height <= 193) || (value[^2..^0] == "in" && height >= 59 && height <= 76));

        /// <summary>
        /// Validate hair color. 
        /// </summary>
        /// <param name="value">The hair color.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains a # followed by exactly six characters 0-9
        /// or a-f; otherwise <see langword="false"/>.</returns>
        static bool ValidateHcl(string value)
            => value.Length == 7
               && value[0] == '#'
            && int.TryParse(value[1..^0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out int _);

        /// <summary>
        /// Validate eye color. 
        /// </summary>
        /// <param name="value">The eye color.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains exactly one of: 
        /// amb blu brn gry grn hzl oth; otherwise <see langword="false"/>.</returns>
        static bool ValidateEcl(string value) 
            => new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value);

        /// <summary>
        /// Validate passport ID. 
        /// </summary>
        /// <param name="value">The passport ID.</param>
        /// <returns><see langword="true"/> if <paramref name="value"/> contains a nine-digit number, including leading 
        /// zeroes; otherwise <see langword="false"/>.</returns>
        static bool ValidatePid(string value) => value.Length == 9 && int.TryParse(value, out int _);

        /// <summary>
        /// Validate c ID. 
        /// </summary>
        /// <param name="value">The v ID.</param>
        /// <returns><see langword="true"/>.</returns>
        static bool ValidateCid(string value) => true;

    }
}