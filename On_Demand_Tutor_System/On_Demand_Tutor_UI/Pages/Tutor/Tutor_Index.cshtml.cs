using On_Demand_Tutor_UI.Pages.AccountPages;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class Tutor_IndexModel : AuthenPageModel
    {
        public string TutorStatus { get; set; }
        public void OnGet()
        {
            TutorStatus = HttpContext.Session.GetString("UserStatus");
        }
    }
}
