using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using BusinessObjects.DTO.Booking;
using Services.BookingService;
using Services.StudentServices;
using BusinessObjects.Enums.Booking;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ViewHistoryComplete : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IStudentService _studentService;

        public ViewHistoryComplete(IBookingService bookingService, IStudentService studentService)
        {
            _bookingService = bookingService;
            _studentService = studentService;
        }

        public IList<ProcessingLearning> LearningComplete { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var accountStudent = HttpContext.Session.GetString("UserEmail");
            var allStudent = _studentService.GetStudentByEmail(accountStudent);
            var allbookingList = _bookingService.GetAllBookingTutor();
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals(BookingStatus.Complete))
                                            .Select(x => new ProcessingLearning
                                            {
                                                Id = x.Id,
                                                TutorName = x.Tutor.Fullname,
                                                TutorId = x.TutorId,
                                                Email = x.Tutor.Email,
                                                StudentId = x.StudentId,
                                                ServiceName = x.Service.Service1,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd,
                                                PaymentMethods = x.PaymentMethods,
                                                Schedules = x.BookingSchedules.Select(bs => bs.Sc.Slot).ToList(),

                                            });
            LearningComplete = bookingList.ToList();
        }

    }
}
