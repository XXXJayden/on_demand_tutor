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
            if (int.TryParse(grade, out int gradeValue) && gradeValue >= 6 && gradeValue <= 12)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Grade must be between 6 and 12");
        }
    }
}
