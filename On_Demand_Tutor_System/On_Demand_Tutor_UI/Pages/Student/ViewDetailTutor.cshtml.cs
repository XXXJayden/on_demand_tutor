using BusinessObjects.DTO.Service;
using BusinessObjects.DTO.Student;
using BusinessObjects.DTO.Tutor;
using BusinessObjects.Enums.Booking;
using BusinessObjects.Models;
using DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.BookingScheduleService;
using Services.BookingService;
using Services.ScheduleService;
using Services.ServiceServices;
using Services.StudentServices;
using Services.Tutors;
using Services.TutorServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ViewDetailTutorModel : PageModel
    {
        private readonly ITutorAccountService _tutorAccountService;
        private readonly IScheduleService _scheduleService;
        private readonly IStudentService _studentService;
        private readonly IServiceServices _serviceService;
        private readonly IBookingService _bookingService;
        private readonly IBookingScheduleService _bookingScheduleService;

        public ViewDetailTutorModel(ITutorAccountService tutorAccountService, IScheduleService scheduleService, IStudentService studentService, IServiceServices serviceServices, IBookingService bookingService, IBookingScheduleService bookingScheduleService)
        {
            _tutorAccountService = tutorAccountService;
            _scheduleService = scheduleService;
            _studentService = studentService;
            _serviceService = serviceServices;
            _bookingService = bookingService;
            _bookingScheduleService = bookingScheduleService;
            
        }

        public TutorDetailResponse TutorDetails { get; set; } = new TutorDetailResponse();
        public List<string> AvailableSlots { get; set; } = new List<string>();
        public Booking Booking { get; set; }
        public List<Service> Services { get; set; }

        public string SelectedServiceName { get; set; }
        public string selectedSlot { get; set; }
        public string PaymentMethod { get; set; }
        public DateOnly SelectedDate { get; set; }
        public int TutorId { get; set; }
        public BookingSchedule BookingSchedule { get; set; }

        public async Task<IActionResult> OnGetAsync(short id, DateOnly? date)
        {
            var tutor = _tutorAccountService.GetTutorById(id);
            if (tutor == null)
            {
                return NotFound();
            }

            TutorDetails = new TutorDetailResponse
            {
                TutorId = tutor.TutorId,
                Fullname = tutor.Fullname,
                Email = tutor.Email,
                Description = tutor.Description,
                Major = tutor.Major,
                Grade = tutor.Grade,
                Achievements = tutor.Achievements.Select(a => a.Certificate).ToList(),
                Services = tutor.TutorServices.Select(ts => new ServiceResponse
                {
                    ServiceName = ts.Service.Service1,
                    Price = ts.Price
                }).ToList()
            };


            if (date.HasValue)
            {
                string dateString = date.Value.ToString("yyyy-MM-dd");
                AvailableSlots = await _scheduleService.GetAvailableSlotsAsync(tutor.TutorId, dateString);
            }

            return Page();
        }

        public async Task<IActionResult> OnGetFetchSlotsAsync(short tutorId, string date)
        {
            var availableSlots = await _scheduleService.GetAvailableSlotsAsync(tutorId, date);
            return new JsonResult(availableSlots);
        }

        public async Task<IActionResult> OnPostAsync(string selectedService, string selectedDate, string selectedSlot, string selectedPaymentMethod, short id)
        {

            var userEmail = HttpContext.Session.GetString("UserEmail");
            var accStudent = _studentService.GetStudentByEmail(userEmail);
            var serviceId = _serviceService.GetServiceIdByName(selectedService);

            var booking = new Booking
            {
                StudentId = accStudent.StudentId,
                DateStart = DateOnly.Parse(selectedDate),
                DateEnd = DateOnly.Parse(selectedDate),
                PaymentMethods = selectedPaymentMethod,
                ServiceId = serviceId.Id,
                TutorId = id,
                Status = BookingStatus.Pending,
            };

            _bookingService.AddBooking(booking);

            var scService = _scheduleService.GetSlotIdByName(selectedSlot);

            var bookingSchedule = new BookingSchedule
            {
                BookingId = booking.Id, 
                ScId = scService.Id, 
                Date = selectedDate,
            };
            _bookingScheduleService.AddBookingSchedule(bookingSchedule);

            return RedirectToPage("/Index");
        }
    }
}
