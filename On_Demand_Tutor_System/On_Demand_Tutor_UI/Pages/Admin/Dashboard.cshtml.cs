using BusinessObjects.DTO.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.AccountService;
using Services.BookingService;
using Services.FeedBackServices;
using Services.StudentServices;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IStudentService _studentService;
        private readonly ITutorAccountService _tutorService;
        private readonly IBookingService _bookingService;
        private readonly IFeedBackService _feedBackService;

        public AccountDashboardDTO Dashboard { get; set; }

        public DashboardModel(IStudentService studentService, ITutorAccountService tutorService, IBookingService bookingService, IFeedBackService feedBackService)
        {
            _studentService = studentService;
            _tutorService = tutorService;
            _bookingService = bookingService;
            _feedBackService = feedBackService;
        }

        public void OnGet()
        {
            var studentQuantity = _studentService.GetStudentQuantity();
            var tutorQuantity = _tutorService.GetTutorQuantity();
            var booking = _bookingService.GetBookingStatusCounts();
            var rating = _feedBackService.GetRatingPercentages();

            Dashboard = new AccountDashboardDTO
            {
                //account
                ActiveStudent = studentQuantity.ActiveStudent,
                InactiveStudent = studentQuantity.InactiveStudent,
                ActiveTutor = tutorQuantity.ActiveTutor,
                InactiveTutor = tutorQuantity.InactiveTutor,
                //booking status
                Complete = booking.Complete,
                Pending = booking.Pending,
                Approve = booking.Approve,
                Cancel = booking.Cancel,
                Processing = booking.Processing,
                // feedback rating
                OneStar = rating.OneStar,
                TwoStar = rating.TwoStar,
                ThreeStar = rating.ThreeStar,
                FourStar = rating.FourStar,
                FiveStar = rating.FiveStar
            };
        }
    }
}

