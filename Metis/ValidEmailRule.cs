using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Metis
{
    class ValidEmailRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string email = "";

            try { email = (string)value; }
            catch(Exception ex) { return new ValidationResult(false, ex.ToString()); }

            int length = email.Length;

            if (length > 320)
                return new ValidationResult(false, "Invalid email address: length greater than 320");

            if (length == 0)
                return new ValidationResult(false, "Required field");

            // source: https://stackoverflow.com/questions/16167983/best-regular-expression-for-email-validation-in-c-sharp
            if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                return new ValidationResult(false, "Invalid email address: bad format");

            return ValidationResult.ValidResult;
        }
    }
}
