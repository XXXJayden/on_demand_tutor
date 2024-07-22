using BusinessObjects.DTO.Student;
using BusinessObjects.Enums.Booking;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using On_Demand_Tutor_UI.Validator;
using Services.BookingService;
using Services.Sercurity;
using Services.StudentServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class EditProfileModel : TrimmedPageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PasswordHasher _hasher;
        private readonly IStudentService _studentService;
        private readonly IBookingService _bookingService;


        public EditProfileModel(IStudentService studentService, IHttpContextAccessor httpContextAccessor, PasswordHasher hasher, IBookingService bookingService)
        {
            _studentService = studentService;
            _httpContextAccessor = httpContextAccessor;
            _hasher = hasher;
            _bookingService = bookingService;
        }

        [BindProperty]
        public StudentUpdateDTO Student { get; set; } = default!;
        public SelectList GradeOptions { get; set; }
        public bool HasRestrictedBooking { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }
            var studentDto = await _studentService.GetStudentByEmailAsync(userEmail);
            if (studentDto == null)
            {
                return NotFound();
            }
            Student = new StudentUpdateDTO
            {
                Email = studentDto.Email,
                Phone = studentDto.Phone,
                FullName = studentDto.Fullname,
                Address = studentDto.Address,
                Grade = Enum.TryParse<Grade>(studentDto.Grade, out var parsedGrade) ? parsedGrade : (Grade?)null,
            };

            GradeOptions = new SelectList(Enum.GetValues(typeof(Grade))
                                .Cast<Grade>()
                                .Select(x => new SelectListItem
                                {
                                    Text = GetDisplayName(x),
                                    Value = x.ToString()
                                }), "Value", "Text", Student.Grade);
            var existingStudent = await _studentService.GetStudentByEmailAsync(userEmail);
            var bookings = await _bookingService.GetStudentBookingById(existingStudent.StudentId);
            HasRestrictedBooking = bookings.Any(b => b.Status != BookingStatus.Complete && b.Status != BookingStatus.Cancel);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            GradeOptions = new SelectList(Enum.GetValues(typeof(Grade))
                    .Cast<Grade>()
                    .Select(x => new SelectListItem
                    {
                        Text = GetDisplayName(x),
                        Value = x.ToString()
                    }), "Value", "Text");

            TrimModelStrings(Student);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userEmail = _httpContextAccessor.HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(userEmail))
            {
                return RedirectToPage("/AccountPages/LoginPage");
            }

            var existingStudent = await _studentService.GetStudentByEmailAsync(userEmail);
            var bookings = await _bookingService.GetStudentBookingById(existingStudent.StudentId);
            HasRestrictedBooking = bookings.Any(b => b.Status != BookingStatus.Complete && b.Status != BookingStatus.Cancel);

            if (HasRestrictedBooking)
            {
                if (!string.IsNullOrWhiteSpace(Student.Password))
                {
                    existingStudent.Password = _hasher.HashPassword(Student.Password);
                    await _studentService.UpdateStudentAsync(existingStudent);
                    TempData["SuccessMessage"] = "Password updated successfully.";
                }
                else
                {
                    ModelState.AddModelError("", "You have bookings in processing. Only password can be updated");
                    return Page();
                }
            }
            else
            {
                existingStudent.Email = Student.Email;
                existingStudent.Fullname = Student.FullName;
                existingStudent.Address = Student.Address;
                existingStudent.Phone = Student.Phone;
                existingStudent.Grade = Student.Grade?.ToString();

                if (!string.IsNullOrWhiteSpace(Student.Password))
                {
                    existingStudent.Password = _hasher.HashPassword(Student.Password);
                }
                await _studentService.UpdateStudentAsync(existingStudent);
                TempData["SuccessMessage"] = "Profile updated successfully.";
            }
            return RedirectToPage();

        }
        private static string GetDisplayName(Enum enumValue)
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<DisplayAttribute>()?
                            .GetName() ?? enumValue.ToString();
        }
    }
}
