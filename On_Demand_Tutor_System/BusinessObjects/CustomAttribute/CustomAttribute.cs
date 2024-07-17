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

    public class MaxWordsAttribute : ValidationAttribute
    {
        private readonly int _maxWords;

        public MaxWordsAttribute(int maxWords)
        {
            _maxWords = maxWords;
            ErrorMessage = $"The field {{0}} must be a string with a maximum of {_maxWords} words.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString != null)
                {
                    var wordCount = valueAsString.Split(' ').Count();
                    if (wordCount > _maxWords)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }

    public static class CustomValidationMethods
    {
        public static ValidationResult ValidateGrade(string grade, ValidationContext context)
        {
            if (int.TryParse(grade, out int gradeValue) && gradeValue >= 9 && gradeValue <= 12)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Grade must be between 9 and 12");
        }

        public static ValidationResult ValidateFullname(string fullname, ValidationContext context)
        {
            if (string.IsNullOrEmpty(fullname))
            {
                return new ValidationResult("Full name is required.");
            }
            //if (fullname.Length < 5 || fullname.Length > 20)
            //{
            //    return new ValidationResult("Full name must be between 5 and 20 characters long.");
            //}
            if (!Regex.IsMatch(fullname, @"^[a-zA-Z\s]+$"))
            {
                return new ValidationResult("Full name must contain only letters and spaces.");
            }

            return ValidationResult.Success;
        }
    }



    public class AdminKeywordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email && email.Contains("admin", StringComparison.OrdinalIgnoreCase))
            {
                return new ValidationResult("Email address cannot contain the keyword 'admin'.");
            }
            return ValidationResult.Success;
        }
    }
}
