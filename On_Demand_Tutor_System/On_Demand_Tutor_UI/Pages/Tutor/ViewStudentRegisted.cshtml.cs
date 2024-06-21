using BusinessObjects.DTO.Booking;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.BookingService;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class ViewStudentRegistedModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly ITutorAccountService _tutorService;

        public ViewStudentRegistedModel(IBookingService bookingService, ITutorAccountService tutorService)
        {
            _bookingService = bookingService;
            _tutorService = tutorService;
        }

        public IList<BookingTutorResponse> BookingTutor { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var allTutor = _tutorService.GetTutorByEmail(accountTutor);
            var allbookingList = _bookingService.GetAllBookingTutor().Where(x => x.TutorId.Equals(allTutor.TutorId));
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals("Pending"))
                                            .Select(x => new BookingTutorResponse
                                            {
                                                Id = x.Id,
                                                StudentName = x.Student.Fullname,
                                                ServiceName = x.Service.Service1,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd
                                            });
            BookingTutor = bookingList.ToList();
        }

    }
}
