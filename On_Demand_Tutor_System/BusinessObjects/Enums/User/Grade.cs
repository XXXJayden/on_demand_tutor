using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Enums.User
{
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
}
