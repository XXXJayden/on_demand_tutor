using BusinessObjects.DTO.Feedback;
using BusinessObjects.DTO.Tutor;
using BusinessObjects.Enums.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Services.FeedBackServices;
using Services.TutorServices;
using System.Collections.Generic;
using System.Linq;

namespace On_Demand_Tutor_UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITutorAccountService _tutorAccount;
        private readonly IFeedBackService _feedBackService;

        public IndexModel(ILogger<IndexModel> logger, ITutorAccountService tutorAccountService,IFeedBackService fedBackService)
        {
            _logger = logger;
            _tutorAccount = tutorAccountService;
            _feedBackService = fedBackService;
        }

        public IList<HomePageTutor> HomePageTutors { get; set; }
        public IList<HomePageFeedBack> HomePageFeedBacks { get; set; }

        public void OnGet()
        {
            var tutors = _tutorAccount.GetAllTutor()
                                      .Where(x => x.Status.Equals(UserStatus.Active))
                                      .ToList();

            HomePageTutors = tutors.Select(tutor => new HomePageTutor
            {
                Fullname = tutor.Fullname,
                Email = tutor.Email,
                Major = tutor.Major,
                Avatar = tutor.Avatar,
                Description = tutor.Description,
                Grade = tutor.Grade,
            }).ToList();

                var feedBack = _feedBackService.GetAllFeedback()
                .Where(x => x.Student.Status.Equals(UserStatus.Active))
                .ToList();
                HomePageFeedBacks = feedBack.Select(feedBack => new HomePageFeedBack
                {
                    Detail = feedBack.Detail,
                    Rating = feedBack.Rating,
                    StudentName = feedBack.Student.Fullname
                }).ToList();

            }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage();
        }
    }
}
