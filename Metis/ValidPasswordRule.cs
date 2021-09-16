using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace Metis
{
    class ValidPasswordRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string pass = "";
            try { pass = (string)value; }
            catch(Exception ex) { return new ValidationResult(false, ex.ToString()); }

            int length = pass.Length;

            if (pass.Length < 6 || pass.Length > 32)
                return new ValidationResult(false, "Password must be between 6 and 32 characters.");

            bool hasUpper = false;
            bool hasNum = false;

            for (int i = 0; i < length; i++)
            {
                if (pass[i] == ' ')
                    return new ValidationResult(false, "Password cannot contain spaces");
                else if (Char.IsUpper(pass[i]))
                    hasUpper = true;
                else if (Char.IsNumber(pass[i]))
                    hasNum = true;
            }

            if (!hasUpper)
                return new ValidationResult(false, "Password must have at least one upper case letter");

            if (!hasNum)
                return new ValidationResult(false, "Password must have at least one number");

            return ValidationResult.ValidResult;
        }
    }
}
