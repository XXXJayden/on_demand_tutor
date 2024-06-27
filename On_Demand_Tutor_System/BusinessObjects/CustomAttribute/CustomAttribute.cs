using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessObjects.CustomAttribute
{
    public class ValidPhoneNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Phone number is required.");
            }

            var phoneNumber = value.ToString();
            if (!Regex.IsMatch(phoneNumber, @"^0\d{9}$"))
            {
                return new ValidationResult("Phone number must be 10 numbers and start with 0");
            }

            return ValidationResult.Success;
        }
    }
}
