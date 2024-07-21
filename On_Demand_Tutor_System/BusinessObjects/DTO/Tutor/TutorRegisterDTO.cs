using BusinessObjects.CustomAttribute;
using BusinessObjects.DTO.Student;
using BusinessObjects.Enums.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO.Tutor
{
    public enum Major
    {
        Math,
        English,
        Physics,
        Chemistry,
        [Display(Name = "C# Programming")]
        CSharp,
        [Display(Name = "Java Programming")]
        Java,
        Database
    }

    public enum Grade
    {
        [Display(Name = "Grade 9")]
        Grade9,
        [Display(Name = "Grade 10")]
        Grade10,
        [Display(Name = "Grade 11")]
        Grade11,
        [Display(Name = "Grade 12")]
        Grade12,
        [Display(Name = "1st Year")]
        FirstYear,
        [Display(Name = "2nd Year")]
        SecondYear,
        [Display(Name = "3rd Year")]
        ThirdYear,
        [Display(Name = "4th Year")]
        FourthYear
    }
    public class TutorRegisterDTO
    {
        [Required(ErrorMessage = "You must enter your name")]
        [CustomValidation(typeof(CustomValidationMethods), nameof(CustomValidationMethods.ValidateFullname))]
        public string Fullname { get; set; } = null!;


        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password is not matched")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [AdminKeywordValidation(ErrorMessage = "Email can't contain 'admin' keyword")]
        public string Email { get; set; } = null!;

        public string Status { get; set; } = UserStatus.Incomplete;

        [Required(ErrorMessage = "You must enter self introduction")]
        [MaxWords(30, ErrorMessage = "Introduction must be in 30 words")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "You must enter your major")]
        public Major? Major { get; set; }

        [Required(ErrorMessage = "You must enter your grade")]
        public Grade? Grade { get; set; }

    }
}
