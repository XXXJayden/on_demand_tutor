using BusinessObjects.DTO.Booking;
using BusinessObjects.Enums.Booking;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using On_Demand_Tutor_UI.Pages.AccountPages;
using Services.BookingService;
using Services.FeedBackServices;
using Services.StudentServices;

namespace On_Demand_Tutor_UI.Pages.Student
{
    public class ViewHistoryComplete : AuthenPageModel
    {
        private readonly IBookingService _bookingService;
        private readonly IStudentService _studentService;
        private readonly IFeedBackService _feedbackService;

        public ViewHistoryComplete(IBookingService bookingService, IStudentService studentService, IFeedBackService feedbackService)
        {
            _bookingService = bookingService;
            _studentService = studentService;
            _feedbackService = feedbackService;
        }

        public IList<BookingComplete> LearningComplete { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var accountStudent = HttpContext.Session.GetString("UserEmail");
            var allStudent = _studentService.GetStudentByEmail(accountStudent);
            var allbookingList = _bookingService.GetAllBookingTutor().Where(x => x.StudentId.Equals(allStudent.StudentId));
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals(BookingStatus.Complete))
                                            .Select(x => new BookingComplete
                                            {
                                                Id = x.Id,
                                                TutorName = x.Tutor.Fullname,
                                                TutorId = x.TutorId,
                                                Email = x.Tutor.Email,
                                                StudentId = x.StudentId,
                                                ServiceName = x.Service.Service1,
                                                ServiceId = x.ServiceId,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd,
                                                PaymentMethods = x.PaymentMethods,
                                                Schedules = x.BookingSchedules.Select(bs => bs.Sc.Slot).ToList(),

                                            });
            LearningComplete = bookingList.ToList();
        }

        [BindProperty]
        public Feedback FeedbackModel { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _feedbackService.AddFeedbackAsync(FeedbackModel);
            await OnGetAsync();
            return RedirectToPage();
        }

    }
}
