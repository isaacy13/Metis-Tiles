using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Metis
{
    class ValidNameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string input = "";
            try {input = (string)value;} // try to convert... can throw invalid in case somehow not convertable
            catch (Exception ex) { return new ValidationResult(false, ex.ToString()); }

            int length = input.Length;

            if (length > 15)
                return new ValidationResult(false, "Please stay within the 15 character limit");

            if (length == 0)
                return new ValidationResult(false, "Required field");

            if (input[0] == '-' || input[0] == ' ')
                return new ValidationResult(false, "Cannot start with dash or space");

            if (input[length - 1] == '-' || input[length - 1] == ' ')
                return new ValidationResult(false, "Cannot end with dash or space");

            for (int i = 0; i < length; i++)
            {
                if (!Char.IsLetter(input[i]) && input[i] != '-' && input[i] != ' ')
                    return new ValidationResult(false, "Please only use letters");

                if (i + 1 < length)
                {
                    if ((input[i] == ' ' || input[i] == '-') && (input[i+1] == ' ' || input[i+1] == '-'))
                        return new ValidationResult(false, "Please only use single spaces / dashes");
                }
            }

            // only allow letters
            return ValidationResult.ValidResult;
        }
    }
}
