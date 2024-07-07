using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace On_Demand_Tutor_UI.Pages.Tutor
{
    public class Tutor_IndexModel : PageModel
    {
        public string TutorStatus { get; set; }
        public void OnGet()
        {
            TutorStatus = HttpContext.Session.GetString("UserStatus");
        }
    }
}
