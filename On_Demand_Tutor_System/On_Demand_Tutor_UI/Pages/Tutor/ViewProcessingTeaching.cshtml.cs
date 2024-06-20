using BusinessObjects.DTO.Booking;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.BookingService;
using Services.TutorServices;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class ViewProcessingTeachingModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly ITutorAccountService _tutorService;

        public ViewProcessingTeachingModel(IBookingService bookingService, ITutorAccountService tutorService)
        {
            _bookingService = bookingService;
            _tutorService = tutorService;
        }

        public IList<ProcessingTeachingRespone> ProcessingTeach { get; set; } = default!;

        public async Task OnGetAsync()
        {

            var accountTutor = HttpContext.Session.GetString("UserEmail");
            var allTutor = _tutorService.GetTutorByEmail(accountTutor);
            var allbookingList = _bookingService.GetAllBookingTutor().Where(x => x.TutorId.Equals(allTutor.TutorId));
            var bookingList = allbookingList.OrderByDescending(x => x.DateStart)
                                            .Where(x => x.Status.Equals("Approved"))
                                            .Select(x => new ProcessingTeachingRespone
                                            {
                                                Id = x.Id,
                                                StudentName = x.Student.Fullname,
                                                StudentAddress = x.Student.Address,
                                                Grade = x.Student.Grade,
                                                Phone = x.Student.Phone,
                                                ServiceName = x.Service.Service1,
                                                DateStart = x.DateStart,
                                                DateEnd = x.DateEnd

                                            });
            ProcessingTeach = bookingList.ToList();
        }
    }
}
